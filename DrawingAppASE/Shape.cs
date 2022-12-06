using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppASE
{
    public abstract class Shape
    {
        protected Color colour;
        protected int x, y;

        public Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        abstract public void Draw(Graphics g, Pen pen, bool fill);
    }
}
