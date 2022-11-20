using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppASE
{
    class DrawTo : Shape
    {
        private int X1 { get; set; }
        private int Y1 { get; set; }

        public DrawTo(int x, int y, int x1, int y1) : base(x, y)
        {
            X1 = x1;
            Y1 = y1;
        }

        public void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, x, y, X1, Y1);
        }
    }
}
