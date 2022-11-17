using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppASE
{
    class Square : Rectangle
    {
        internal int Size { get; set; }

        public Square(Color colour, int x, int y, int size) : base(colour, x, y, size, size)
        {
            Size = size;
        }
    }
}
