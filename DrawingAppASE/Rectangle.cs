using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppASE
{
    public class Rectangle : Shape
    {
        private int Width {  get; set; }
        private int Height { get; set; }

        public Rectangle(int x, int y, int width, int height) : base(x, y)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Decides whether to draw or fill a rectangle based on <paramref name="fill"/>
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
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
        /// Draws a rectangle using a pen
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        private void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawRectangle(pen, x, y, Width, Height);
        }

        /// <summary>
        /// Draws a rectangle using a brush, fills the shape with colour
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="brush"></param>
        private void Draw(Graphics graphics, Brush brush)
        {
            graphics.FillRectangle(brush, x, y, Width, Height);
        }
    }
}
