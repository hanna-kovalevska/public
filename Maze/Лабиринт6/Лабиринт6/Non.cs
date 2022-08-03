using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace Лабиринт6
{
    public class Non : Strateg
    {
        public void DrawView(Game G, Form1 k)
        {
            k.hed.Visible = true;
            k.apple.Visible = true;
            k.hed.Location= new System.Drawing.Point(G.n1*85+20, (G.n2*165/2)+54);
            k.apple.Location = new System.Drawing.Point(G.l1*85 + 20, (G.l2*165/2) + 54);
        }
    }
}
