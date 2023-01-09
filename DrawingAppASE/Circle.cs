using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppASE
{
    /// <summary>
    /// Circle class used to draw a circle 
    /// </summary>
    public class Circle : Shape
    {
        private int Radius { get; set; }

        public Circle(int x, int y, int radius) : base(x, y)
        {
            Radius = radius;
        }

        /// <summary>
        /// Decides whether to draw or fill a circle based on <paramref name="fill"/>
        /// </summary>
        /// <param name="fill"></param>
        public override void Draw(Graphics graphics, Pen pen, bool fill)
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

        /// <summary>
        /// Draws a circle using a pen
        /// </summary>>
        private void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawEllipse(pen, x, y, Radius, Radius);
        }

        /// <summary>
        /// Draws a circle using a brush, fills the shape with colour
        /// </summary>      
        private void Draw(Graphics graphics, Brush brush)
        {
            graphics.FillEllipse(brush, x, y, Radius, Radius);
        }
    }
}
