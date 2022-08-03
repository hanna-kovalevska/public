from flask import Flask, render_template, request, jsonify, g
import threading
import random
import tkinter
import datetime, time
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg
import numpy as np
import logging
import sqlite3


heater_state=False
id_h=0
id_t=0

def create_tables():
    db = sqlite3.connect("database.db")
    cursor = db.cursor()
    # porogi
    cursor.execute("""CREATE TABLE IF NOT EXISTS heating ( 
                                     id_h INTEGER PRIMARY KEY,
                                     temperature REAL,
                                     min_th REAL,
                                     max_th REAL, 
                                     heater_state INTEGER);""")
    db.commit()
    #znachenia
    cursor.execute("""CREATE TABLE IF NOT EXISTS temperature_time (
                                id_t INTEGER PRIMARY KEY,
                                date DATETIME,
                                temperature REAL);""")
    db.commit()
    db.close()
 #   cursor.execute("""INSERT INTO threshold VALUES(0,1,2,0);""")
    #db.commit()

def delete_tables():
    db = sqlite3.connect("database.db")
    cursor = db.cursor()
    cursor.execute("""DROP TABLE heating""")
    db.commit()
    cursor.execute("""DROP TABLE temperature_time""")
    db.commit()
    db.close()

def update_table_heating(temperature, n1,n2):
    global heater_state, id_h
    db = sqlite3.connect("database.db")
    cursor = db.cursor()
    array =[]
    array.append(id_h)
    array.append(temperature)
    array.append(n1)
    array.append(n2)
    id_h+=1
    if heater_state==True:
        array.append(1)
        cursor.execute('''INSERT INTO heating VALUES(?,?,?,?,?)''', array)
    else:
        array.append(0)
        cursor.execute('''INSERT INTO heating VALUES(?,?,?,?,?)''', array)
    db.commit()
    cursor.close()
    db.close()

def update_table_temperature_time(date, temp):
    global id_t
    db = sqlite3.connect("database.db")
    cursor = db.cursor()
    id_t+=1
    cursor.execute("""INSERT INTO temperature_time VALUES(?,?,?);""", (id_t, date, temp))
    db.commit()
    cursor.close()
    db.close()

def get_table_temperature_time():
    con= sqlite3.connect("database.db")
    with con:
        cur = con.cursor()
        cur.execute("SELECT * FROM temperature_time")
        rows = cur.fetchall()
        print()
        print('Table Temperature_time:')
        for row in rows:
            print(row)
        cur.close()
    con.close()
    threading.Timer(20, get_table_temperature_time).start()  # каждые 20 секунд вызывается функция обновления

def get_table_heating():
    con= sqlite3.connect("database.db")
    with con:
        cur = con.cursor()
        cur.execute("SELECT * FROM heating")
        rows = cur.fetchall()
        print()
        print('Table heating:')
        for row in rows:
            print(row)
        cur.close()
    con.close()
    threading.Timer(20, get_table_heating).start()  # каждые 20 секунд вызывается функция обновления


minimum=maximum=0
temper1=15
light1 = "Выкл"
light1_1 = "включен"
light2 = "Выкл"
light2_2 = "включен"
lightnes1 = 50
lightnes2 = 50
heating = ""
n1 = 20.0
n2 = 22.0

temp = []  # создание массива температур
min_temp = []
max_temp = []
time = []  # создание массива времени

our_plot = plt.figure(dpi=60, figsize=(12, 10))
sub_plot = our_plot.add_subplot(111)



app = Flask(__name__)
#log = logging.getLogger('werkzeug')
#log.disabled = True


def click(event):
    global n1, n2, minimum, maximum
    n2 = float(maximum.get())
    n1 = float(minimum.get())



def create_window():
    global n1, n2, minimum, maximum
    window = tkinter.Tk()
    window.geometry('800x680')
    window.title(string="График зависимости")
    lbl1 = tkinter.Label(window, font=("Arial Bold", 18), fg="red")
    lbl1.config(text="Верхний предел")
    lbl1.pack()
    var1 = tkinter.StringVar(window)
    var1.set(str(n1))
    var2 = tkinter.StringVar(window)
    var2.set(str(n2))
    maximum = tkinter.Spinbox(window, textvariable=var2, bg="salmon", font=("Comic Sans MS", 18, "bold"), from_=20, to=50, increment=0.1)
    maximum.pack()
    lbl2 = tkinter.Label(window, font=("Arial Bold", 18), fg="green")
    lbl2.config(text="Нижний предел")
    minimum = tkinter.Spinbox(window, values=(n1), textvariable=var1, bg="palegreen", font=("Comic Sans MS", 18, "bold"), from_=15, to=40, increment=0.1)
    lbl2.pack()
    minimum.pack()
    btn=tkinter.Button(window, text="Ввести", bg="cornsilk", font=("Comic Sans MS", 18, "bold"))
    btn.bind('<Button-1>', click)
    btn.pack()
    return window

def upd(frame):
    global temper1, temper2, heating, n1, n2, temp, time, our_plot, sub_plot, min_temp, max_temp
    sub_plot.clear()  # очищаем старый график
    time_now = datetime.datetime.strftime(datetime.datetime.now(), "%H:%M:%S")
    temp.append(temper1)  # добавляем данные в конец массива температур append – добавляет в конец массива
    time.append(time_now)  # добавляем данные в конец массива времени
    min_temp.append(n1)
    max_temp.append(n2)
    update_table_temperature_time(time_now, temper1)

    if len(time) > 15:
        temp.pop(0)
        time.pop(0)
        max_temp.pop(0)
        min_temp.pop(0)
    plt.title("Изменение температуры от времени")
    plt.xlabel("Время")
    plt.ylabel("Показания датчика")
    plt.plot(time, temp, 'black')  # чертим график
    plt.plot(time, np.ones(len(time)) * n1, 'g')  # черта порога
    plt.plot(time, np.ones(len(time)) * n2, 'r')
    plt.xticks(rotation=90, fontsize=8)
    maximum['values'] = (n2)
    minimum['values'] = (n1)
    print('n1')
    print(n1)
    print('n2')
    print(n2)

try:
    F = open("data.txt", 'r')
    lines = [x.strip('\n') for x in F.readlines()]
    n2 = float(lines[0])
    n1 = float(lines[1])
except FileNotFoundError:
    None

@app.route('/temperature', methods=['get'])
def temperature():
    global temper1, temper2, heating, n1, n2, heater_state
    temper1 = round(random.uniform(15.0, 25.0), 1)
    temper2 = round(random.uniform(15.0, 25.0), 1)
    if temper1 < n1:
        heating = "Включен"
        heater_state=True
        update_table_heating(temper1, n1, n2)
    if temper1 > n2:
        heating = "Выключен"
        heater_state = False
        update_table_heating(temper1,n1, n2)

    return jsonify(temper1, temper2, heating, n1,n2)

@app.route('/', methods=['post', 'get'])
def hello():
    global light1, light1_1, light2, light2_2, temper1, temper2, heating, lightnes1, lightnes2, n1, n2
    write_to_file = False
    if request.method == 'POST':
        if request.form.get('Lig1'):
            lightnes1 = request.form.get('L1')
        if request.form.get('Lig2'):
            lightnes2 = request.form.get('L2')

        if request.form.get('But1') == "Вкл":
            light1_1 = "включен"
            light1 = "Выкл"
        if request.form.get('But1') == "Выкл":
            light1_1 = "выключен"
            light1 = "Вкл"

        if request.form.get('But2') == "Вкл":
            light2_2 = "включен"
            light2 = "Выкл"
        if request.form.get('But2') == "Выкл":
            light2_2 = "выключен"
            light2 = "Вкл"
        if request.form.get('thresholds'):
            n1 = float(request.form.get('th1'))
            n2 = float(request.form.get('th2'))
            write_to_file = True
    if write_to_file == True:
        F = str(n2) + "\n" + str(n1)
        with open("data.txt", 'w') as file:
            file.write(F)

    print("Яркость1 " + str(lightnes1) + " Яркость2 " + str(lightnes2))
    return render_template('index.html', light1=light1, light1_1=light1_1, light2=light2, light2_2=light2_2,
                           lightnes1=lightnes1, lightnes2=lightnes2, n1=n1, n2=n2)


def animation():
    window = create_window()
    insert_plot = FigureCanvasTkAgg(our_plot, master=window)  # монтируем график
    insert_plot.get_tk_widget().pack()
    animation1 = FuncAnimation(our_plot, upd, interval=4000)
    window.mainloop()


@app.route('/plot', methods=['get'])
def graf():
    global temp, min_temp, max_temp, time
    return jsonify(temp, min_temp, max_temp, time)


if __name__ == '__main__':
    tkinter_window = threading.Thread(target=animation, daemon=True)
    tkinter_window.start()
    delete_tables()
    create_tables()
    get_table_heating()
    get_table_temperature_time()
    app.run(debug=False, use_reloader=False)