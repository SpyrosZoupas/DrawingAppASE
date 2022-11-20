using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppASE
{
    public class Circle : Shape
    {
        private int Radius { get; set; }

        public Circle(int x, int y, int radius) : base(x, y)
        {
            Radius = radius;
        }

        public void Draw(Graphics graphics, Pen pen, bool fill)
        {
            if (!fill)
            {
                Draw(graphics, pen);
            }
            else
            {
                Draw(graphics, new SolidBrush(pen.Color));
            }
        }

        private void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawEllipse(pen, x, y, Radius, Radius);
        }

        private void Draw(Graphics graphics, Brush brush)
        {
            graphics.FillEllipse(brush, x, y, Radius, Radius);
        }
    }
}
