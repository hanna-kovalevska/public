//#74d37e

#include <string>
#include <SFML/Graphics.hpp>
#include <iostream>
#include <fstream>
#include <sstream>
#include <time.h>

using namespace sf; // подключаем пространство имён sf

struct Solution;

class Cell
{
private:
	Image image1;
	Texture t1;
	Sprite s;
	Image image2;
	Texture t2;
public:
	short k = 0;//отвечает за состояние клетки, если 1-зарисована, 2-крестик, 0-ничего
	Cell();
	void Create(int, int, int);//двигаем нашу картинку в данные координаты
	Sprite get();
	void con();
	Sprite Paint();
};

class Task
{
private:
	Solution* first;
	int n;
public:

	Task(Solution& s);

	void Add(Solution* s);

	Solution Rand();
};

class Field
{
private:
	int n;// размер поля
	Cell* arr;//массив клеток
	int z;//заполненность поля
	int ze=0;//заполненность поля, которая необходима
	bool** mas;
	String name;
	Sprite s1;
	Image image1;
	Texture t1;
	Texture t2;
	Image image2;
	Sprite s2;
	int** hor;
	int** ver;
	bool fin = false;//по умолчанию наш кроссворд считается нерешенным 
	std::string time_game;//время игры
public:
	Field(Solution so1);
	void Work(RenderWindow& window);
};

Task Plus_small();

bool Compare(int n, Cell* (arr), bool* (mas)[]);
void Hello(RenderWindow &window);
void Size(RenderWindow& window);

int** Horisontal(int n, bool* (mas)[]);
int** Vertical(int n, bool* (mas)[]);

int main()
{
	RenderWindow window(VideoMode(1050, 630), "Japanese crossword", Style::Close);//создаю окно
	Hello(window);
}

//структура решение, в которой хранится размерность, имя и булевый двумерный массив, где 1-клеточка закрашена, 0-пустая
struct Solution
{
	String name;
	int size;
	bool** mas;
	Solution* next;
};

//функция, которая добавляет структуру решений для маленького размера
Task Plus_small()
{
	int n = 10;
		bool mas1[10][10] =
		{
			{0, 0, 1, 0, 0, 0, 0, 1, 0, 0},
			{0, 0, 0, 1, 0, 0, 1, 0, 0, 0},
			{0, 0, 0, 1, 0, 0, 1, 0, 0, 0},
			{0, 1, 1, 0, 1, 1, 0, 1, 1, 0},
			{1, 0, 1, 1, 1, 1, 1, 1, 0, 1},
			{0, 0, 0, 1, 1, 1, 0, 0, 0, 0},
			{0, 1, 1, 0, 1, 1, 0, 1, 1, 0},
			{1, 0, 0, 1, 0, 0, 1, 0, 0, 1},
			{0, 0, 1, 0, 0, 0, 0, 1, 0, 0},
			{0, 0, 1, 0, 0, 0, 0, 1, 0, 0}
		};
		bool** vas1 = new bool* [10];
		for (int i = 0; i < 10; i++)
		{
			vas1[i] = new bool[10];
			for (int j = 0; j < 10; j++)
			{
				vas1[i][j] = mas1[i][j];
			}
		}
		
		bool** mas = new bool* [n];
		struct Solution* Spider = new Solution;
		Spider->size = n;
		Spider->mas = vas1;
		Spider->name = "Spider";

		Task Task_small(*Spider);

		bool mas2[10][10] =
		{
			{0, 1, 1, 1, 0, 0, 0, 0, 0, 0},
			{1, 1, 0, 0, 1, 0, 0, 0, 0, 0},
			{1, 0, 1, 0, 0, 1, 1, 1, 0, 0},
			{1, 1, 0, 0, 1, 1, 1, 0, 0, 0},
			{0, 1, 1, 1, 0, 0, 0, 1, 1, 0},
			{0, 1, 0, 0, 1, 1, 1, 0, 1, 0},
			{1, 0, 0, 0, 1, 1, 0, 0, 0, 1},
			{1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
			{1, 1, 0, 0, 0, 0, 1, 1, 1, 0},
			{0, 1, 1, 1, 1, 1, 1, 0, 1, 1}
		};
		bool** vas2 = new bool* [10];
		for (int i = 0; i < 10; i++)
		{
			vas2[i] = new bool[10];
			for (int j = 0; j < 10; j++)
			{
				vas2[i][j] = mas2[i][j];
			}
		}
		struct Solution* Duck = new Solution;
		Duck->size = n;
		Duck->mas = vas2;
		Duck->name = "Duck";
		Task_small.Add(Duck);

		bool mas3[10][10] =
		{
			{1, 1, 1, 1, 0, 0, 0, 0, 1, 1},
			{1, 1, 1, 0, 0, 0, 0, 1, 1, 1},
			{1, 0, 0, 0, 1, 1, 1, 1, 1, 1},
			{0, 1, 0, 0, 1, 1, 1, 1, 1, 1},
			{0, 0, 0, 0, 0, 0, 0, 1, 1, 1},
			{1, 1, 0, 0, 0, 0, 0, 0, 1, 1},
			{1, 1, 0, 0, 0, 0, 0, 0, 0, 1},
			{1, 1, 0, 1, 0, 0, 0, 0, 0, 0},
			{1, 1, 1, 1, 1, 0, 0, 0, 0, 1},
			{1, 1, 1, 0, 0, 0, 0, 0, 1, 1}
		};
		bool** vas3 = new bool* [10];
		for (int i = 0; i < 10; i++)
		{
			vas3[i] = new bool[10];
			for (int j = 0; j < 10; j++)
			{
				vas3[i][j] = mas3[i][j];
			}
		}
		struct Solution* Rabbit = new Solution;
		Rabbit->size = n;
		Rabbit->mas = vas3;
		Rabbit->name = "Rabbit";
		Task_small.Add(Rabbit);

		bool mas4[10][10] =
		{
			{0, 0, 1, 1, 1, 0, 0, 0, 0, 0},
			{0, 1, 0, 0, 0, 1, 0, 0, 0, 0},
			{0, 1, 0, 1, 0, 1, 0, 0, 0, 0},
			{1, 1, 0, 0, 0, 1, 0, 0, 0, 0},
			{0, 1, 0, 0, 0, 1, 1, 1, 1, 1},
			{0, 1, 0, 0, 0, 0, 0, 1, 0, 1},
			{0, 1, 0, 0, 0, 1, 1, 1, 0, 1},
			{0, 1, 1, 0, 0, 0, 0, 0, 1, 1},
			{0, 0, 1, 1, 1, 1, 1, 1, 1, 0},
			{0, 0, 0, 0, 1, 0, 1, 0, 0, 0}
		};
		bool** vas4 = new bool* [10];
		for (int i = 0; i < 10; i++)
		{
			vas4[i] = new bool[10];
			for (int j = 0; j < 10; j++)
			{
				vas4[i][j] = mas4[i][j];
			}
		}
		struct Solution* Chiken = new Solution;
		Chiken->size = n;
		Chiken->mas = vas4;
		Chiken->name = "Chiken";
		Task_small.Add(Chiken);
	

	bool mas5[10][10] =
	{
		{0, 0, 1, 0, 1, 0, 0, 0, 0, 0},
		{0, 1, 1, 0, 1, 1, 0, 0, 0, 0},
		{0, 1, 1, 1, 1, 1, 0, 0, 0, 0},
		{1, 1, 0, 1, 0, 1, 1, 0, 0, 1},
		{0, 1, 1, 1, 1, 1, 0, 0, 1, 1},
		{0, 0, 1, 1, 1, 0, 0, 1, 1, 0},
		{1, 1, 1, 1, 1, 1, 0, 0, 1, 1},
		{1, 0, 1, 1, 1, 1, 1, 0, 0, 1},
		{0, 0, 1, 1, 1, 1, 1, 1, 1, 1},
		{0, 1, 1, 0, 1, 1, 1, 1, 0, 0}
	};
	bool** vas5 = new bool* [10];
	for (int i = 0; i < 10; i++)
	{
		vas5[i] = new bool[10];
		for (int j = 0; j < 10; j++)
		{
			vas5[i][j] = mas5[i][j];
		}
	}
	struct Solution* Cat = new Solution;
	Cat->size = n;
	Cat->mas = vas5;
	Cat->name = "Cat";
	Task_small.Add(Cat);

	return Task_small;
}

//функция, которая добавляет структуру решений для большого размера
Task Plus_big()
{
	int n =15;
	bool mas1[15][15] =
	{
		{0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0},
		{0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0},
		{0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0},
		{0, 1, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0},
		{1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0},
		{1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0},
		{1, 1, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 1, 1},
		{1, 0, 0, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0},
		{0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0},
		{0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0},
		{0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0},
		{0, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0},
		{0, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0},
		{0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0},
		{0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0},

	};
	bool** vas1 = new bool* [15];
	for (int i = 0; i < 15; i++)
	{
		vas1[i] = new bool[15];
		for (int j = 0; j < 15; j++)
		{
			vas1[i][j] = mas1[i][j];
		}
	}
	struct Solution* Pear = new Solution;
	Pear->size = n;
	Pear->mas = vas1;
	Pear->name = "Pear";

	Task Task_big(*Pear);

	bool mas2[15][15] =
	{
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1},
		{0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0},
		{0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0},
		{0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 0, 0},
		{0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0},
		{0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0},
		{0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0},
		{0, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0},
		{0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0},
		{0, 1, 1, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0, 0},
		{1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 0},
		{1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0},
		{0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
		{0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},

	};
	bool** vas2 = new bool* [15];
	for (int i = 0; i < 15; i++)
	{
		vas2[i] = new bool[15];
		for (int j = 0; j < 15; j++)
		{
			vas2[i][j] = mas2[i][j];
		}
	}
	struct Solution* Bird = new Solution;
	Bird->size = n;
	Bird->mas = vas2;
	Bird->name = "Bird";

	Task_big.Add(Bird);

	bool mas3[15][15] =
	{
		{0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0},
		{0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1},
		{1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1},
		{1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1},
		{1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1},
		{1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 1, 1},
		{0, 1, 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0},
		{1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0},
		{1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 0},
		{1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0},
		{1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0},
		{1, 1, 1, 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0},
		{0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0, 1, 0, 0},
		{0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0},
		{0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0},
	};
	bool** vas3 = new bool* [15];
	for (int i = 0; i < 15; i++)
	{
		vas3[i] = new bool[15];
		for (int j = 0; j < 15; j++)
		{
			vas3[i][j] = mas3[i][j];
		}
	}

	struct Solution* Coala = new Solution;
	Coala->size = n;
	Coala->mas = vas3;
	Coala->name = "Coala";

	Task_big.Add(Coala);

	return Task_big;
}

//функция, которая проверяет правильно ли решение
bool Compare(int n, Cell* (arr), bool* (mas)[])

{
	for (int i = 0; i < n * n; i++)
	{
		if (arr[i / n + 10 * (i % n)].k == 1)
		{
			if (mas[i / n][i % n] == false)
			{
				return false;
			}

		}
		else
		{
			if (mas[i / n][i % n] == true)
			{
				return false;
			}
		}
	}
	return true;
}

//функция захода в программу
void Hello(RenderWindow &window)
{
	while (window.isOpen())
	{
		Event event;// Обрабатываем очередь событий в цикле
		while (window.pollEvent(event))
		{
			if (event.type == Event::Closed)
				window.close();
		}

		window.clear(Color::White);

		// Отрисовка окна
		Image image1;
		Texture start;
		image1.loadFromFile("images/Hello.png");
		start.loadFromImage(image1);
		Sprite sprite(start);
		window.draw(sprite);
		
		//кнопка Новая игра
		Texture start_button;
		start_button.loadFromFile("images/game_button_new.png");
		Sprite sprite1(start_button);
		sprite1.move(300, 250);
		if (IntRect(300, 250, 443, 66).contains(Mouse::getPosition(window)))
		{
			sprite1.setColor(Color::Yellow);
			if (Mouse::isButtonPressed(Mouse::Left))
			{
				Size(window);
			}
		}
		window.draw(sprite1);

		//кнопка Выход
		Texture start_button2;
		start_button2.loadFromFile("images/game_button_exit.png");
		Sprite sprite3(start_button2);
		sprite3.move(300, 390);
		if (IntRect(300, 390, 443, 66).contains(Mouse::getPosition(window)))
		{
			sprite3.setColor(Color::Yellow);
			if (Mouse::isButtonPressed(Mouse::Left))
				window.close();
		}
	
		window.draw(sprite3);

		window.display();
		//рисуем фон
	}
}

//функция выбора размерности кроссворда
void Size(RenderWindow& window)
{
	while (window.isOpen())
	{
		bool t = 0;
		Event event;
		while (window.pollEvent(event))
		{
			if (event.type == Event::Closed)
				window.close();
			if (event.type == Event::MouseButtonPressed && event.mouseButton.button == Mouse::Left)
				t = 1;
		}

		window.clear(Color::White);

		// Отрисовка окна
		Image image1;
		Texture start;
		image1.loadFromFile("images/Hello.png");
		start.loadFromImage(image1);
		Sprite sprite(start);
		window.draw(sprite);

		//кнопка Маленькая
		Texture start_button;
		start_button.loadFromFile("images/game_button_small.png");
		Sprite sprite1(start_button);
		sprite1.move(300, 200);
		if (IntRect(300, 200, 443, 66).contains(Mouse::getPosition(window)))
		{
			sprite1.setColor(Color::Yellow);
			if (t)//если кнопка мышки нажата
			{
				Task t =Plus_small();
				Field K(t.Rand());
				K.Work(window);
			}
		}
		window.draw(sprite1);

		//кнопка Большой
		Texture start_button1;
		start_button1.loadFromFile("images/game_button_big.png");
		Sprite sprite2(start_button1);
		sprite2.move(300, 350);
		if (IntRect(300, 350, 443, 66).contains(Mouse::getPosition(window)))
		{
			sprite2.setColor(Color::Yellow);
			if (t)
			{
				Task t = Plus_big();
				Field K(t.Rand());
				K.Work(window);
			}
		}
		window.draw(sprite2);
		
		//значек Вернуться назад
		Texture start_button3;
		start_button3.loadFromFile("images/game_button_return.png");
		Sprite sprite4(start_button3);
		sprite4.move(30, 480);
		if (IntRect(30, 480, 50, 50).contains(Mouse::getPosition(window)) && t)
			Hello(window);
		window.draw(sprite4);

		//значек Вернуться назад
		Texture start_button4;
		start_button4.loadFromFile("images/game_button_stop.png");
		Sprite sprite5(start_button4);
		sprite5.move(930, 480);
		if (IntRect(930, 480, 50, 50).contains(Mouse::getPosition(window)) && t)
			window.close();
		window.draw(sprite5);

		window.display();
		//прорисуем все дравы!
	}
}

//функция зашифровки кроссворда по столбцам
int** Horisontal(int n, bool* (mas)[])
{
	int** arr = new int* [(n - 1) / 2];
	for (int i = 0; i < (n - 1) / 2; i++)
	{
		arr[i] = new int[n] { 0 };
	}
	for (int j = 0; j < n; j++)
	{
		int k = 0, t = (n - 3) / 2;
		for (int i = 0; i < n; i++)
		{
			if (mas[n-i-1][j] == false)
			{
				if (k != 0)
				{
					arr[t][j] = k;
					k = 0;
					t--;
				}
			}
			else
			{
				k++;
			}
		}
		if (k != 0)
		{
			arr[t][j] = k;
		}
	}
	return arr;
}

//функция зашифровки кроссворда по строкам
int** Vertical(int n, bool* (mas)[])
{
	int** arr = new int* [n];
	for (int i = 0; i < n; i++)
	{
		arr[i] = new int[(n - 1) / 2] { 0 };
	}
	for (int j = 0; j < n; j++)
	{
		int k = 0, t = (n - 3) / 2;
		for (int i = 0; i < n; i++)
		{
			if (mas[j][n - i - 1] == false)
			{
				if (k != 0)
				{
					arr[j][t] = k;
					k = 0;
					t--;
				}
			}
			else
			{
				k++;
			}
		}
		if (k != 0)
		{
			arr[j][t] = k;
		}
	}
	return arr;
}

//класс поле маленькой клетки

Cell::Cell()
{
	
}

void Cell::Create(int n, int x, int y)//дыигаем нашу картинку в данные координаты
{
	if (n==10)
	{
		image1.loadFromFile("images/cell.png");
		image2.loadFromFile("images/not.png");
		t1.loadFromImage(image1);
		t2.loadFromImage(image2);
	}
	if (n == 15)
	{
		image1.loadFromFile("images/cell_m.png");
		image2.loadFromFile("images/not_m.png");
		t1.loadFromImage(image1);
		t2.loadFromImage(image2);
	}
	s.setPosition(x, y);
}

Sprite Cell::get()
{
	if (k == 1)
	{
		s.setTexture(t1);
		s.setColor(Color::Black);
	}
	else
	{
		if (k == 0)
		{
			s.setTexture(t1);
		}
		else
		{
			s.setTexture(t2);
		}
		s.setColor(Color::White);
	}
	return s;
}

void Cell::con()
{
	k = ++k % 3;
}

Sprite Cell::Paint()
{
	Sprite k = get();
	k.setColor(Color::Yellow);
	return k;
}

//класс с односвязным списком структур, в которых записана решение наших кроссвордов, размерность и имя

Task::Task(Solution &s)
{
	first = new Solution;
	first->mas = s.mas;
	first->name = s.name;
	first->size = s.size;
	first->next = nullptr;
	n = 1;
}

void Task::Add(Solution* s)
{
	{
		Solution* Now = first;
		while (Now->next != nullptr)
		{
			Now = Now->next;
		}
		Solution* t = new Solution;
		t = s;
		t->next = nullptr;
		Now->next = t;
		n++;
	}
}

Solution Task::Rand()
{
	int k = 0, t = rand() % n;
	Solution* Now;
	Now = first;
	while (k != t)
	{
		Now = Now->next;
		k++;
	}
	return *Now;
}

//класс поле, в который мы передаем структуру решения и размерность, а он сам кодирует и всё отрисовывает 

Field::Field(Solution so1)
{
	{
		n = so1.size;//определяем размерность
		image1.loadFromFile("images/field.png");
		t1.loadFromImage(image1);
		s1.setTexture(t1);
		{
			if (n == 10)
			{
				image2.loadFromFile("images/small.png");
			}
			if (n == 15)
			{
				image2.loadFromFile("images/big.png");
			}
			t2.loadFromImage(image2);
			s2.setTexture(t2);
			s2.setPosition(35, 50);
		}
		
		
		mas = new bool* [n];
		for (int i = 0; i < n; i++)
		{
			mas[i] = new bool[n];
			for (int j = 0; j < n; j++)
			{
				mas[i][j] = so1.mas[i][j];
				if (mas[i][j]) ze++;
			}
		}
		arr = new Cell[n * n];
		name = so1.name;
		for (int i = 0; i < n; i++)
			for (int j = 0; j < n; j++)
			{
				if (n==10)
					arr[n * i + j].Create(n, 169 /*=35+134*/ + i * 32, 186 /*=50+136*/ + j * 32);
				if (n == 15)
					arr[n * i + j].Create(n, 151.5 /*=35+116*/ + i * 22.5, 156 /*=50+106*/ + j * 20.5);
			}
		hor = Horisontal(n, mas);
		ver = Vertical(n, mas);
	}
}

void Field::Work(RenderWindow& window)
{
	clock_t start;
	int k = 0;
	start = clock();
	while (window.isOpen())
	{
		// Обрабатываем очередь событий в цикле
		Event event;
		bool t = 0;
		while (window.pollEvent(event))
		{
			if (event.type == Event::Closed)
				window.close();
			if (event.type == Event::MouseButtonPressed && event.mouseButton.button == Mouse::Left)
				t = 1;
		}
		window.clear(Color::White);
		window.draw(s1);
		window.draw(s2);

		for (int i = 0; i < n; i++)
			for (int j = 0; j < n; j++)
			{
				if (IntRect(169/*35+134*/ + i * 32, 186 /*50+136*/ + j * 32, 31, 31).contains(Mouse::getPosition(window)) && n == 10 && !fin || IntRect(151 /*=35+116*/ + i * 22, 156 /*=50+106*/ + j * 21, 21, 20).contains(Mouse::getPosition(window)) && n == 15 && !fin) /////////////||)
				{

					if (t)
					{
						arr[n * i + j].con();
						if (arr[n * i + j].k == 1) z++;
						if (arr[n * i + j].k == 2) z--;
					}
					window.draw(arr[n * i + j].Paint());
				}
				else
				{
					window.draw(arr[n * i + j].get());
				}
					
			}

		Font font;//шрифт 
		font.loadFromFile("text/calibri.ttf");
		Text text;
		text.setFont(font);
		text.setCharacterSize(40);
		text.setFillColor(Color::Black);
		text.setStyle(sf::Text::Bold);

		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < (n - 1) / 2; j++)
			{
				if (hor[j][i] != 0)
				{
					text.setString(std::to_string(hor[j][i]));
					if (n == 10)
					{
						text.setCharacterSize(40);
						text.setPosition(172 + i * 32, 42 + j * 32);
					}
					if (n == 15)
					{
						text.setCharacterSize(18);
						text.setPosition(152 + i * 22.5, 13+j * 20);
					}
					window.draw(text);
				}
			}
		}

		for (int i = 0; i < (n - 1) / 2; i++)
		{
			for (int j = 0; j < n; j++)
			{
				if (ver[j][i] != 0)
				{
					text.setString(std::to_string(ver[j][i]));
					if (n == 10)
					{
						text.setCharacterSize(40);
						text.setPosition(45 + i * 32, 175 + j * 32);
					}
					if (n == 15)
					{
						text.setCharacterSize(18);
						text.setPosition(-5 + i * 22.5, 155 + j * 20.5);
					}
					window.draw(text);
				}
			}
		}

		text.setCharacterSize(40);

		//проверяю равно ли текущая плотность заполнения поля плотности ответа
		if (z == ze)
		{
			fin = Compare(n, arr, mas);
		}

		Texture stone;
		stone.loadFromFile("images/game_button_stone.png");
		Sprite sprite_stone(stone);
		sprite_stone.move(740, 360);
		window.draw(sprite_stone);

		//значек Вернуться назад
		Texture start_button3;
		start_button3.loadFromFile("images/game_button_return.png");
		Sprite sprite4(start_button3);
		sprite4.move(30, 530);
		if (IntRect(30, 530, 50, 50).contains(Mouse::getPosition(window)) && t && !fin)
			Size(window);
		window.draw(sprite4);

		if (!fin)
		{
			text.setString("Complection: " + std::to_string(100 * z / (n * n)) + "%" + " from " + std::to_string(100 * ze / (n * n)) + "%");
			text.setPosition(550, 300);
			window.draw(text);

			text.setCharacterSize(64);
			text.setString(name);
			text.setPosition(700, 160);
			window.draw(text);

			text.setCharacterSize(52);
			text.setFillColor(Color::White);
			text.setPosition(835, 445);
			time_game = (std::to_string(((clock() - start) / CLK_TCK) / 60)) + ":" + std::to_string(((clock() - start) / CLK_TCK) % 60);
			text.setString(time_game);
			window.draw(text);
		}
		else
		{
			k++;
			text.setCharacterSize(52);
			text.setFillColor(Color::White);
			text.setPosition(835, 445);
			text.setString(time_game);
			window.draw(text);

			text.setCharacterSize(64);
			text.setFillColor(Color::Red);

			text.setString("You won!");
			text.setPosition(700, 140);
			window.draw(text);

			text.setPosition(570, 240);
			window.draw(text);

			text.setString("Name: " + name);
			
			text.setPosition(620, 340);
			window.draw(text);
			if (t && k>10)
				Hello(window);
		}
		window.display();
	}
}