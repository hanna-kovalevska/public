using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace Лабиринт6
{
    public partial class Form1 : Form
    {
        public Strateg strat;
        public Game G;
        

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(right);
            this.KeyDown += new KeyEventHandler(left);
            this.KeyDown += new KeyEventHandler(top);
            this.KeyDown += new KeyEventHandler(down);
        }

        public void down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "S" && G.now.s)
            {
                G.n2++;
                G.now = G.now.d;
                this.hed.Location = new System.Drawing.Point((G.n1 * 85) + 18, (G.n2 * 165 / 2) + 54);
                strat.DrawView(G, this);
                if (G.n1 == G.l1 && G.n2 == G.l2)
                {
                    label1.Visible = true;
                    this.Text = "Поздравляем!";
                }
            }
        }

        public void top(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "W" && G.now.n)
            {
                G.n2--;
                G.now = G.now.t;
                this.hed.Location = new System.Drawing.Point((G.n1 * 85) + 18, (G.n2 * 165 / 2) + 54);
                strat.DrawView(G, this);
                if (G.n1 == G.l1 && G.n2 == G.l2)
                {
                    label1.Visible = true;
                    this.Text = "Поздравляем!";
                }
            }
        }

        public void left(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "A"&& G.now.w)
            {
                G.n1--;
                G.now = G.now.l;
                this.hed.Location = new System.Drawing.Point((G.n1 * 85) + 18, (G.n2 * 165 / 2) + 54);
                strat.DrawView(G, this);
                if (G.n1 == G.l1 && G.n2 == G.l2)
                {
                    label1.Visible = true;
                    this.Text = "Поздравляем!";
                }
            }
        }

        public void right(object sender, KeyEventArgs e)
        {
            if(e.KeyCode.ToString()=="D"&& G.now.e)
            {
                G.n1++;
                G.now = G.now.r;
                this.hed.Location = new System.Drawing.Point((G.n1 * 85) + 18, (G.n2 * 165 / 2) + 54);
                strat.DrawView(G, this);
                if (G.n1 == G.l1 && G.n2 == G.l2)
                {
                    label1.Visible = true;
                    this.Text = "Поздравляем!";
                }
            }
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        public void label1_Click(object sender, EventArgs e)
        {
            p40.BackColor = System.Drawing.SystemColors.Info;
            p41.BackColor = System.Drawing.SystemColors.Info;
            p42.BackColor = System.Drawing.SystemColors.Info;
            p43.BackColor = System.Drawing.SystemColors.Info;
            p44.BackColor = System.Drawing.SystemColors.Info;
            p45.BackColor = System.Drawing.SystemColors.Info;
            p50.BackColor = System.Drawing.SystemColors.Info;
            p51.BackColor = System.Drawing.SystemColors.Info;
            p52.BackColor = System.Drawing.SystemColors.Info;
            p53.BackColor = System.Drawing.SystemColors.Info;
            p54.BackColor = System.Drawing.SystemColors.Info;
            p55.BackColor = System.Drawing.SystemColors.Info;

            r40.BackColor = System.Drawing.SystemColors.Info;
            r41.BackColor = System.Drawing.SystemColors.Info;
            r42.BackColor = System.Drawing.SystemColors.Info;
            r43.BackColor = System.Drawing.SystemColors.Info;
            r44.BackColor = System.Drawing.SystemColors.Info;
            r50.BackColor = System.Drawing.SystemColors.Info;
            r51.BackColor = System.Drawing.SystemColors.Info;
            r52.BackColor = System.Drawing.SystemColors.Info;
            r53.BackColor = System.Drawing.SystemColors.Info;
            r54.BackColor = System.Drawing.SystemColors.Info;

            d30.BackColor = System.Drawing.SystemColors.Info;
            d31.BackColor = System.Drawing.SystemColors.Info;
            d32.BackColor = System.Drawing.SystemColors.Info;
            d33.BackColor = System.Drawing.SystemColors.Info;
            d34.BackColor = System.Drawing.SystemColors.Info;
            d35.BackColor = System.Drawing.SystemColors.Info;
            d40.BackColor = System.Drawing.SystemColors.Info;
            d41.BackColor = System.Drawing.SystemColors.Info;
            d42.BackColor = System.Drawing.SystemColors.Info;
            d43.BackColor = System.Drawing.SystemColors.Info;
            d44.BackColor = System.Drawing.SystemColors.Info;
            d45.BackColor = System.Drawing.SystemColors.Info;

            p04.BackColor = System.Drawing.SystemColors.Info;
            p05.BackColor = System.Drawing.SystemColors.Info;
            p14.BackColor = System.Drawing.SystemColors.Info;
            p15.BackColor = System.Drawing.SystemColors.Info;
            p24.BackColor = System.Drawing.SystemColors.Info;
            p25.BackColor = System.Drawing.SystemColors.Info;
            p34.BackColor = System.Drawing.SystemColors.Info;
            p35.BackColor = System.Drawing.SystemColors.Info;

            r03.BackColor = System.Drawing.SystemColors.Info;
            r04.BackColor = System.Drawing.SystemColors.Info;
            r13.BackColor = System.Drawing.SystemColors.Info;
            r14.BackColor = System.Drawing.SystemColors.Info;
            r23.BackColor = System.Drawing.SystemColors.Info;
            r24.BackColor = System.Drawing.SystemColors.Info;
            r33.BackColor = System.Drawing.SystemColors.Info;
            r34.BackColor = System.Drawing.SystemColors.Info;

            d04.BackColor = System.Drawing.SystemColors.Info;
            d05.BackColor = System.Drawing.SystemColors.Info;
            d14.BackColor = System.Drawing.SystemColors.Info;
            d15.BackColor = System.Drawing.SystemColors.Info;
            d24.BackColor = System.Drawing.SystemColors.Info;
            d25.BackColor = System.Drawing.SystemColors.Info;

            lvl1.Visible = false;
            lvl2.Visible = false;
            lvl3.Visible = false;
            dark.Visible = true;
            light.Visible = true;
            fonarik.Visible = true;
            this.strat = new Non();

            Game G1 = new Game(4, 4, 0, 0, 0, 1);
            G1.MyFlied.AddBorder('|', 0, 1);
            G1.MyFlied.AddBorder('|', 1, 0);
            G1.MyFlied.AddBorder('|', 1, 2);
            G1.MyFlied.AddBorder('|', 2, 0);
            G1.MyFlied.AddBorder('|', 2, 1);
            G1.MyFlied.AddBorder('|', 3, 2);
            G1.MyFlied.AddBorder('_', 0, 0);
            G1.MyFlied.AddBorder('_', 0, 2);
            G1.MyFlied.AddBorder('_', 1, 1);
            G1.MyFlied.AddBorder('_', 1, 3);
            G1.MyFlied.AddBorder('_', 2, 1);
            G1.MyFlied.AddBorder('_', 2, 3);
            G = G1;
            strat.DrawView(G, this);
            this.Text = "Выберите стратегию";
        }

        public void lvl2_Click(object sender, EventArgs e)
        {
            p50.BackColor = System.Drawing.SystemColors.Info;
            p51.BackColor = System.Drawing.SystemColors.Info;
            p52.BackColor = System.Drawing.SystemColors.Info;
            p53.BackColor = System.Drawing.SystemColors.Info;
            p54.BackColor = System.Drawing.SystemColors.Info;
            p55.BackColor = System.Drawing.SystemColors.Info;

            r50.BackColor = System.Drawing.SystemColors.Info;
            r51.BackColor = System.Drawing.SystemColors.Info;
            r52.BackColor = System.Drawing.SystemColors.Info;
            r53.BackColor = System.Drawing.SystemColors.Info;
            r54.BackColor = System.Drawing.SystemColors.Info;

            d40.BackColor = System.Drawing.SystemColors.Info;
            d41.BackColor = System.Drawing.SystemColors.Info;
            d42.BackColor = System.Drawing.SystemColors.Info;
            d43.BackColor = System.Drawing.SystemColors.Info;
            d44.BackColor = System.Drawing.SystemColors.Info;
            d45.BackColor = System.Drawing.SystemColors.Info;

            p05.BackColor = System.Drawing.SystemColors.Info;
            p15.BackColor = System.Drawing.SystemColors.Info;
            p25.BackColor = System.Drawing.SystemColors.Info;
            p35.BackColor = System.Drawing.SystemColors.Info;
            p45.BackColor = System.Drawing.SystemColors.Info;

            r04.BackColor = System.Drawing.SystemColors.Info;
            r14.BackColor = System.Drawing.SystemColors.Info;
            r24.BackColor = System.Drawing.SystemColors.Info;
            r34.BackColor = System.Drawing.SystemColors.Info;
            r44.BackColor = System.Drawing.SystemColors.Info;

            d05.BackColor = System.Drawing.SystemColors.Info;
            d15.BackColor = System.Drawing.SystemColors.Info;
            d25.BackColor = System.Drawing.SystemColors.Info;
            d35.BackColor = System.Drawing.SystemColors.Info;
            lvl1.Visible = false;
            lvl2.Visible = false;
            lvl3.Visible = false;
            dark.Visible = true;
            light.Visible = true;
            fonarik.Visible = true;
            this.strat = new Non();

            Game G2 = new Game(5, 5, 0, 4, 1, 2);

            G2.MyFlied.AddBorder('_', 0, 1);
            G2.MyFlied.AddBorder('_', 0, 2);
            G2.MyFlied.AddBorder('_', 0, 3);
            G2.MyFlied.AddBorder('_', 1, 2);
            G2.MyFlied.AddBorder('_', 2, 1);
            G2.MyFlied.AddBorder('_', 3, 1);
            G2.MyFlied.AddBorder('_', 3, 2);

            G2.MyFlied.AddBorder('|', 1, 0);
            G2.MyFlied.AddBorder('|', 1, 3);
            G2.MyFlied.AddBorder('|', 2, 0);
            G2.MyFlied.AddBorder('|', 2, 1);
            G2.MyFlied.AddBorder('|', 2, 2);
            G2.MyFlied.AddBorder('|', 2, 3);
            G2.MyFlied.AddBorder('|', 3, 2);
            G2.MyFlied.AddBorder('|', 3, 3);

            G = G2;
            strat.DrawView(G, this);
            this.Text = "Выберите стратегию";
        }

        public void label1_Click_2(object sender, EventArgs e)
        {
            lvl1.Visible = false;
            lvl2.Visible = false;
            lvl3.Visible = false;
            dark.Visible = true;
            light.Visible = true;
            fonarik.Visible = true;
            this.strat = new Non();
            Game G3 = new Game(6, 6, 0, 0, 1, 4);
            G3.MyFlied.AddBorder('_', 0, 0);
            G3.MyFlied.AddBorder('_', 0, 1);
            G3.MyFlied.AddBorder('_', 0, 2);
            G3.MyFlied.AddBorder('_', 2, 1);
            G3.MyFlied.AddBorder('_', 2, 2);
            G3.MyFlied.AddBorder('_', 3, 1);
            G3.MyFlied.AddBorder('_', 3, 2);
            G3.MyFlied.AddBorder('_', 3, 3);
            G3.MyFlied.AddBorder('_', 4, 1);
            G3.MyFlied.AddBorder('_', 4, 2);
            G3.MyFlied.AddBorder('_', 4, 3);
            G3.MyFlied.AddBorder('_', 4, 4);
            G3.MyFlied.AddBorder('|', 1, 4);
            G3.MyFlied.AddBorder('|', 2, 4);
            G3.MyFlied.AddBorder('|', 3, 4);
            G3.MyFlied.AddBorder('|', 4, 4);
            G3.MyFlied.AddBorder('|', 0, 3);
            G3.MyFlied.AddBorder('|', 1, 3);
            G3.MyFlied.AddBorder('|', 2, 3);
            G3.MyFlied.AddBorder('|', 3, 3);
            G3.MyFlied.AddBorder('|', 1, 2);
            G3.MyFlied.AddBorder('|', 2, 2);
            G3.MyFlied.AddBorder('|', 4, 0);
            G = G3;
            strat.DrawView(G, this);
            this.Text = "Выберите стратегию";
        }

        public void light_Click(object sender, EventArgs e)
        {
            strat = new Light();
            strat.DrawView(G, this);
            dark.Visible = false;
            light.Visible = false;
            fonarik.Visible = false;
            this.Text = "Удачи!";
        }

        public void fonarik_Click(object sender, EventArgs e)
        {
            strat = new Fonarik();
            strat.DrawView(G, this);
            dark.Visible = false;
            light.Visible = false;
            fonarik.Visible = false;
            this.Text = "Удачи!";
        }

        public void dark_Click(object sender, EventArgs e)
        {
            strat = new Darkness();
            strat.DrawView(G, this);
            dark.Visible = false;
            light.Visible = false;
            fonarik.Visible = false;
            this.Text = "Удачи!";
        }

        public void label1_Click_1(object sender, EventArgs e)
        {

        }

        public void r20_Click(object sender, EventArgs e)
        {

        }
    }
}
