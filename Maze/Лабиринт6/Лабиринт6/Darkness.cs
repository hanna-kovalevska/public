﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace Лабиринт6
{
    public class Darkness : Strateg
    {
        public void DrawView(Game G, Form1 k)
        {
            List<PictureBox> ras = new List<PictureBox>();
            ras.Add(k.r20);
            ras.Add(k.r21);
            ras.Add(k.r22);
            ras.Add(k.r23);
            ras.Add(k.r24);
            ras.Add(k.r00);
            ras.Add(k.r01);
            ras.Add(k.r02);
            ras.Add(k.r03);
            ras.Add(k.r04);
            ras.Add(k.r10);
            ras.Add(k.r11);
            ras.Add(k.r12);
            ras.Add(k.r13);
            ras.Add(k.r14);
            ras.Add(k.r30);
            ras.Add(k.r31);
            ras.Add(k.r32);
            ras.Add(k.r33);
            ras.Add(k.r34);
            ras.Add(k.r40);
            ras.Add(k.r41);
            ras.Add(k.r42);
            ras.Add(k.r43);
            ras.Add(k.r44);
            ras.Add(k.r50);
            ras.Add(k.r51);
            ras.Add(k.r52);
            ras.Add(k.r53);
            ras.Add(k.r54);

            List<PictureBox> das = new List<PictureBox>();
            das.Add(k.d00);
            das.Add(k.d01);
            das.Add(k.d02);
            das.Add(k.d03);
            das.Add(k.d04);
            das.Add(k.d05);
            das.Add(k.d10);
            das.Add(k.d11);
            das.Add(k.d12);
            das.Add(k.d13);
            das.Add(k.d14);
            das.Add(k.d15);
            das.Add(k.d20);
            das.Add(k.d21);
            das.Add(k.d22);
            das.Add(k.d23);
            das.Add(k.d24);
            das.Add(k.d25);
            das.Add(k.d30);
            das.Add(k.d31);
            das.Add(k.d32);
            das.Add(k.d33);
            das.Add(k.d34);
            das.Add(k.d35);
            das.Add(k.d40);
            das.Add(k.d41);
            das.Add(k.d42);
            das.Add(k.d43);
            das.Add(k.d44);
            
        }
    }
}
