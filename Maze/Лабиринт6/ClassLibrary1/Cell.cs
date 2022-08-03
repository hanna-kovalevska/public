using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Cell
    {
        /*1-"road" - обычная дорога, в будущем доавиться нахождение фонарика и выключателя 
                    для изменения стратегии игры*/
        public int specialty;
        public Cell r;
        public Cell l;
        public Cell d;
        public Cell t;
        public bool n;
        public bool w;
        public bool s;
        public bool e;
        public Cell()
        {
            specialty = 1;
            r = null;
            l = null;
            d = null;
            t = null;
            n = true;
            w = true;
            e = true;
            s = true;
        }
        public Cell(int k)
        {
            r = null;
            l = null;
            d = null;
            t = null;
            n = true;
            w = true;
            e = true;
            s = true;
            this.specialty = k;
        }
    }
}
