import pandas as pd
import numpy as np
import os
import logging


def dataframe_init(mode, database_status=2):

    logging.basicConfig(filename='log/db.log',
                        level=logging.INFO,
                        format='%(asctime)s - %(levelname)s - %(message)s')

    node_df = pd.DataFrame(columns=[
        'id',
        'title',
        'username',
        'participants',
        'datestamp',
        'checked'
    ])
    edge_df = pd.DataFrame(columns=[
        'id1',
        'id2',
    ])
    if mode == "global":
        if database_status == 1:
            node_df.to_csv('telegram_node_df.csv')
            edge_df.to_csv('telegram_edge_df.csv')
            return 0
        elif database_status == 2:
            if not os.path.exists("telegram_node_df.csv"):
                node_df.to_csv("telegram_node_df.csv")
                logging.info("telegram_node_df.csv" + ' database created')
            else:
                logging.info("telegram_node_df.csv" + ' database already exists')

            if not os.path.exists("telegram_edge_df.csv"):
                node_df.to_csv("telegram_edge_df.csv")
                logging.info("telegram_edge_df.csv" + ' database created')
            else:
                logging.info("telegram_edge_df.csv" + ' database already exists')
            return 0

    elif mode == 'local':
        return node_df, edge_df

