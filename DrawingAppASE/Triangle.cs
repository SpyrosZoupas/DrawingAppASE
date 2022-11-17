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
        internal int LineA { get; set; }
        internal int LineB { get; set; }
        internal int LineC { get; set; }

        public Triangle(Color colour, int x, int y, int lineA, int lineB, int lineC) : base(colour, x, y)
        {
            LineA = lineA;
            LineB = lineB;
            LineC = lineC;
        }

    }
}
