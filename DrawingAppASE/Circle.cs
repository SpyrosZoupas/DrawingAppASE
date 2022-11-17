using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppASE
{
    class Circle : Shape
    {
        internal int Radius { get; set; }

        public Circle(Color colour, int x, int y, int radius) : base(colour, x, y)
        {
            Radius = radius;
        }
    }
}
