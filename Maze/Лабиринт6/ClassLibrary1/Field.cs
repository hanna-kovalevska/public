using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Field
    {
        public int hor;
        public int ver;
        public Cell[,] mas;
        public Field(int a, int b)
        {
            hor = a;
            ver = b;
            mas = new Cell[a, b];
            for (int i = 0; i < hor; i++)
            {
                for (int j = 0; j < ver; j++)
                {
                    mas[i, j] = new Cell(1);
                }
            }
            /*создаем правого соседа*/
            for (int i = 0; i < hor; i++)
            {
                for (int j = 0; j < ver - 1; j++)
                {
                    mas[i, j].r = mas[i, j + 1];
                }
            }
            /*создаем левого соседа*/
            for (int i = 0; i < hor; i++)
            {
                for (int j = 1; j < ver; j++)
                {
                    mas[i, j].l = mas[i, j - 1];
                }
            }
            /*создаем верхнего соседа*/
            for (int i = 1; i < hor; i++)
            {
                for (int j = 0; j < ver; j++)
                {
                    mas[i, j].t = mas[i - 1, j];
                }
            }
            /*создаем нижнего соседа*/
            for (int i = 0; i < hor - 1; i++)
            {
                for (int j = 0; j < ver; j++)
                {
                    mas[i, j].d = mas[i + 1, j];
                }
            }
            for (int i = 0; i < hor; i++)
            {
                mas[i, 0].w = false;
                mas[i, ver - 1].e = false;
            }
            for (int i = 0; i < ver; i++)
            {
                mas[0, i].n = false;
                mas[hor - 1, i].s = false;
            }
        }
        public void AddBorder(char type, int line, int column)
        {
            if (type == '|')
            {
                mas[line, column].e = false;
                mas[line, column + 1].w = false;
            }
            if (type == '_')
            {
                mas[line, column].s = false;
                mas[line + 1, column].n = false;
            }
        }
    }
}
