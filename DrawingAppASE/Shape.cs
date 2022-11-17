using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppASE
{
    abstract class Shape
    {
        protected Color colour;
        protected int x, y;

        public Shape(Color colour, int x, int y)
        {
            this.colour = colour;
            this.x = x;
            this.y = y;
        }
    }
}
