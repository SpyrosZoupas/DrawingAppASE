using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppASE
{
    class Rectangle : Shape
    {
        internal int Width {  get; set; }
        internal int Height { get; set; }

        public Rectangle(Color colour , int x, int y, int width, int height) : base(colour, x, y)
        {
            Width = width;
            Height = height;
        }
    }
}
