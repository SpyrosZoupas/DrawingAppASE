using System.Drawing;


namespace DrawingAppASE
{
    /// <summary>
    /// Abstract shape class that all shapes inherit from, holds common properties and methods found in all shapes
    /// </summary>
    public abstract class Shape:Shapes
    {
        protected Color colour;
        public int x, y;

        public Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        abstract public void Draw(Graphics g, Pen pen, bool fill);
    }
}
