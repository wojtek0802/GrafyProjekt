using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class Punkty
    {
        int x1;
        int y1;
        int x2;
        int y2;
        public int X1 { get { return x1; } set { x1 = value; } }
        public int Y1 { get { return y1; } set { y1 = value; } }
        public int X2 { get { return x2; } set { x2 = value; } }
        public int Y2 { get { return y2; } set { y2 = value; } }

        public Punkty(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }
    }
}
