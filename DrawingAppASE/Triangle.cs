﻿using System.Drawing;

namespace DrawingAppASE
{
    /// <summary>
    /// Triangle class used to draw a triangle
    /// </summary>
    public class Triangle : Shape
    {
        private int X1 { get; set; }
        private int Y1 { get; set; }
        private int X2 { get; set; }
        private int Y2 { get; set; }
        private int X3 { get; set; }
        private int Y3 { get; set; }

        public Triangle(int x, int y, int x1, int y1, int x2, int y2, int x3, int y3) : base(x, y)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
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
        /// Draws a triangle using a pen
        /// </summary>    
        private void Draw(Graphics graphics, Pen pen)
        {
            graphics.DrawPolygon(pen, new[] { new Point(X1, Y1), new Point(X2, Y2), new Point(X3, Y3) });
        }

        /// <summary>
        /// Draws a triangle using a brush, fills the shape with colour
        /// </summary>
        private void Draw(Graphics graphics, Brush brush)
        {
            graphics.FillPolygon(brush, new [] { new Point(X1, Y1), new Point(X2, Y2), new Point(X3, Y3)});
        }
    }
}
