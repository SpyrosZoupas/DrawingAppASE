﻿using System.Drawing;


namespace DrawingAppASE
{
    /// <summary>
    /// Rectangle class used to draw a rectangle
    /// </summary>
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
        private void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawRectangle(pen, x, y, Width, Height);
        }

        /// <summary>
        /// Draws a rectangle using a brush, fills the shape with colour
        /// </summary>
        private void Draw(Graphics graphics, Brush brush)
        {
            graphics.FillRectangle(brush, x, y, Width, Height);
        }
    }
}
