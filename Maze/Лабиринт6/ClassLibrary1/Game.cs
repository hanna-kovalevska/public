using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary1
{
    public class Game
    {
        public Field MyFlied;
        int hor;
        int ver;
        public Cell now;
        public int n1;
        public int n2;
        public int l1;
        public int l2;
        public Cell first;
        public Cell last;
        public Game(int a, int b, int fx, int fy, int lx, int ly)
        {
            hor = a;
            ver = b;
            MyFlied = new Field(a, b);
            first = MyFlied.mas[fy, fx];
            now =first;
            last = MyFlied.mas[ly, lx];
            n1 = fx;
            n2 = fy;
            l1 = lx;
            l2 = ly;
        }
        public void Go(string text)
        {
            if (text == "r")
            {
                if (now.e)
                {
                    for (int i = 0; i < hor; i++)
                    {
                        for (int j = 0; j < ver; j++)
                        {
                            if (now == this.MyFlied.mas[i, j])
                            {
                                now = MyFlied.mas[i, j + 1];
                                if (now == last)
                                {
                                    Console.WriteLine("!!!Вы прошли лабиринт!!!");
                                }
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Вы врезались в стену");
                }
            }
            if (text == "l")
            {
                if (now.w)
                {
                    for (int i = 0; i < hor; i++)
                    {
                        for (int j = 0; j < ver; j++)
                        {
                            if (now == this.MyFlied.mas[i, j])
                            {
                                now = MyFlied.mas[i, j - 1];
                                if (now==last)
                                {
                                    Console.WriteLine("!!!Вы прошли лабиринт!!!");
                                }
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Вы врезались в стену");
                }
            }
            if (text == "d")
            {
                bool dp = true;
                if (now.s)
                {
                    for (int i = 0; i < hor; i++)
                    {
                        for (int j = 0; j < ver; j++)
                        {
                            if (now == this.MyFlied.mas[i, j] && dp)
                            {
                                dp = false;
                                now = MyFlied.mas[i + 1, j];
                                if (now == last)
                                {
                                    Console.WriteLine("!!!Вы прошли лабиринт!!!");
                                }
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Вы врезались в стену");
                }
            }
            if (text == "t")
            {
                if (now.n)
                {
                    bool dp = true;
                    for (int i = 0; i < hor; i++)
                    {
                        for (int j = 0; j < ver; j++)
                        {
                            if (now == this.MyFlied.mas[i, j] && dp)
                            {
                                dp = false;
                                now = MyFlied.mas[i - 1, j];
                                if (now == last)
                                {
                                    Console.WriteLine("!!!Вы прошли лабиринт!!!");
                                }
                                break;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Вы врезались в стену");
                }
            }
        }
    }
}
