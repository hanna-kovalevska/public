# System imports
import sys
import os
import datetime
import logging
import questionary
# Async imports
import asyncio, asyncstdlib

# Telegram imports
import pandas as pd
import telethon
from telethon import TelegramClient
from telethon import functions
from telethon.tl.types import User, Chat, Channel
from telethon import utils
from telethon.errors.rpcerrorlist import RpcCallFailError

# Modules imports
from db import dataframe_init

api_id = "input id"
api_hash = "input hash"
client = TelegramClient('telegram_module', api_id, api_hash)
class Channels:
    def __init__(self, channel_id=None):
        self.channel = None
        self.participants = None
        self.title = None
        self.username = None
        self.total_info = None
        self.id = channel_id

    async def get_info_id(self):
        self.total_info = await client(functions.channels.GetFullChannelRequest(self.id))
        self.username = self.total_info.chats[0].username
        self.title = self.total_info.chats[0].title
        self.participants = self.total_info.full_chat.participants_count
        if self.channel is None:
            self.channel = await client.get_entity(self.id)

        # self.posts = self.total_info.full_chat.read_inbox_max_id
        return self

    async def get_info_username(self, telegram_username):
        self.channel = await client.get_entity(telegram_username)
        self.id = self.channel.id
        await self.get_info_id()
        return self

    async def channel_dataframe(self):
        if self.title is None:
            await self.get_info_id()
        return pd.DataFrame(data={
            "id": [self.id],
            "title": [self.title],
            "username": [self.username],
            "participants": [self.participants],
            "datestamp": [datetime.datetime.now()],
            "checked": False
        })


async def telegram_parser_main(channel):
    # logging.basicConfig(filename='log/main.log',
    #                     level=logging.INFO,
    #                     format='%(asctime)s - %(levelname)s - %(message)s')

    # print(channel.total_info)

    channel_node_df, channel_edge_df = dataframe_init(mode="local")

    channel_node_df = await Channels(channel.id).channel_dataframe()
    total_channel_node_df = pd.read_csv('telegram_node_df.csv')
    total_channel_edge_df = pd.read_csv('telegram_edge_df.csv')

    # print(total_channel_node_df)

    total_channel_id_unique = set(total_channel_node_df['id'].to_list())
    channel_forward_id_unique = {channel.id}
    async for reversed_message_id, message in asyncstdlib.enumerate(client.iter_messages(channel.channel)):
        try:
            if reversed_message_id == 0:
                channel_messages_total = message.id
            channel_messages_left = channel_messages_total - message.id
            channel_messages_left_percentage = round(channel_messages_left / channel_messages_total * 100, 2)

            channel_status = "\r%s :: %s percent :: %s/%s messages" % (
                channel.title,
                channel_messages_left_percentage,
                channel_messages_left,
                channel_messages_total
            )
            sys.stdout.write(channel_status)

            sys.stdout.flush()
            if message.fwd_from is not None:
                if isinstance(message.forward.from_id, telethon.tl.types.PeerChannel):
                    channel_forwarded_id = message.fwd_from.from_id.channel_id
                    # print(channel_forwarded_id)
                    if channel_forwarded_id not in channel_forward_id_unique:
                        if channel_forwarded_id not in total_channel_id_unique:
                            try:
                                channel_forwarded = await Channels(channel_forwarded_id).get_info_id()
                            except telethon.errors.rpcerrorlist.ChannelInvalidError:
                                pass
                            if channel_forwarded.total_info.chats[0].broadcast:
                                channel_forwarded_df = await channel_forwarded.channel_dataframe()

                                channel_node_df = pd.concat([channel_node_df, channel_forwarded_df],
                                                            ignore_index=True)
                                channel_forward_id_unique.add(channel_forwarded_id)

                            # print(channel_node_df)

                    else:
                        pass

                    edge = pd.DataFrame({'id1': [channel.id], 'id2': [channel_forwarded_id]})
                    channel_edge_df = pd.concat([channel_edge_df, edge],
                                                ignore_index=True)

                    # print(channel_edge_df)
                    # print(channel_edge_df)
            # await asyncio.sleep(10)
        except RpcCallFailError:  # Internal Telegram issues
            await asyncio.sleep(2)
        except telethon.errors.ChannelPrivateError:
            pass
        except telethon.errors.ChannelBannedError:
            pass

    # channel_edge_df.drop_duplicates()
    channel_edge_df = channel_edge_df.groupby(channel_edge_df.columns.tolist(), as_index=False).size()
    total_channel_node_df = pd.concat([total_channel_node_df, channel_node_df],
                                      ignore_index=True)
    total_channel_node_df = total_channel_node_df.drop_duplicates(subset=['id'])
    total_channel_edge_df = pd.concat([total_channel_edge_df, channel_edge_df],
                                      ignore_index=True)
    # print(total_channel_edge_df)
    # print(list(channel_forward_id_unique))
    total_channel_node_df.loc[total_channel_node_df['id'] == channel.id, 'checked'] = True
    total_channel_edge_df.to_csv('telegram_edge_df.csv', index=False)
    total_channel_node_df.to_csv('telegram_node_df.csv', index=False)

    with open('last_channel_id.t', 'w') as last_channel_id_wrt:
        last_channel_id_wrt.write(str(channel.id))
    # print(total_channel_id_unique)
    await telegram_channel_handler()


async def telegram_channel_handler():
    telegram_node_id_list = pd.read_csv('telegram_node_df.csv')['id'].to_list()
    # print(len(telegram_node_id_list))
    if len(telegram_node_id_list) == 0:
        telegram_channel_name = input('Please input initial Telegram channel username: ').lower().strip()
        channel = await Channels().get_info_username(telegram_channel_name)
        await telegram_parser_main(channel)

    else:
        if os.path.exists("last_channel_id.t"):
            last_channel_id = int(open("last_channel_id.t", 'r').read())
            last_channel_id_num = telegram_node_id_list.index(last_channel_id)
            channel_id = telegram_node_id_list[last_channel_id_num + 1]
            channel = await Channels(channel_id=channel_id).get_info_id()
            await telegram_parser_main(channel)
        # else: # TO ADD: HANDLER LOST LAST_CHANNEL_ID FILE !!!
        #     telegram_channel_name = input('Please input initial Telegram channel username: ').lower().strip()


with client:

    try:
        database_status = int(input('''
What do you want to do with the DB?
 1 - Start from scratch.
 2 - Add to previous one (if exists).
Your input: ''')[0])

        dataframe_init(mode="global", database_status=database_status)
        client.loop.run_until_complete(telegram_channel_handler())
    except KeyboardInterrupt as err:
        print(err)
