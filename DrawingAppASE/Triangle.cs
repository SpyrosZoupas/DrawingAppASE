using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppASE
{
    class Triangle : Shape
    {
        private int X1 { get; set; }
        private int Y1 { get; set; }
        private int X2 { get; set; }
        private int Y2 { get; set; }
        private int X3 { get; set; }
        private int Y3 { get; set; }

        public Triangle(int x, int y, int x1, int y1, int x2, int y2, int x3, int y3) : base(x, y)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        public void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawLine(pen, X1, Y1, X2, Y2);
            graphics.DrawLine(pen, X2, Y2, X3, Y3);
            graphics.DrawLine(pen, X3, Y3, X1, Y1);
        }
    }
}
