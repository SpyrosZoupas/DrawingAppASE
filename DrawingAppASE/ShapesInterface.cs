using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppASE
{
    interface Shapes
    {
        void Draw(Graphics g, Pen pen, bool fill);
    }
}
