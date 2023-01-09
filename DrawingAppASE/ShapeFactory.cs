using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppASE
{
    /// <summary>
    /// Shape factory class that creates shape objects
    /// </summary>
    public class ShapeFactory
    {
        public Shape CreateShape(string shape, List<int> parameters)
        {
            shape = shape.Trim().ToLower();
            switch (shape)
            {
                case "circle":
                    return new Circle(parameters[0], parameters[1], parameters[2]);
                case "rectangle":
                    return new Rectangle(parameters[0], parameters[1], parameters[2],parameters[3]);
                case "triangle":
                    return new Triangle(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5], parameters[6], parameters[7]);
                case "drawto":
                    return new DrawTo(parameters[0], parameters[1],parameters[2],parameters[3]);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
