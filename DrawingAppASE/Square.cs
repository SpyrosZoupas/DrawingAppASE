﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppASE
{
    public class Square : Rectangle
    {
        internal int Size { get; set; }

        public Square(int x, int y, int size) : base(x, y, size, size)
        {
            Size = size;
        }

        public void Draw(Graphics graphics, Pen pen)
        {

        }

        public void DrawTo(Graphics graphics, Pen pen, int x, int y)
        {

        }
    }
}
