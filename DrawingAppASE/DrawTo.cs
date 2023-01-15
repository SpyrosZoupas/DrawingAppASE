using System.Drawing;


namespace DrawingAppASE
{
    /// <summary>
    /// drawto class that draws a line
    /// </summary>
    public class DrawTo : Shape
    {
        private int X1 { get; set; }
        private int Y1 { get; set; }

        public DrawTo(int x, int y, int x1, int y1) : base(x, y)
        {
            X1 = x1;
            Y1 = y1;
        }

        /// <summary>
        /// Draws a line from point x,y to point X1,Y1
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        public override void Draw(Graphics graphics, Pen pen, bool fill)
        {
            graphics.DrawLine(pen, x, y, X1, Y1);
        }
    }
}
