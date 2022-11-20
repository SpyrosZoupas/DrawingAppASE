using System;
using System.Collections.Generic;
using System.Drawing;

namespace DrawingAppASE
{
    public class Parser
    {
        private static int x = 0;
        private static int y = 0;
        private static bool fill = false;

        public static void ParseAction(Graphics graphics, Pen pen, IEnumerable<string> commands)
        {
            foreach (var input in commands)
            {
                var command = input.Split(' ')[0];

                if (input.Split(' ').Length == 1)
                {
                    switch (command)
                    {
                        case "clear":
                            graphics.Clear(Color.Gray);
                            break;
                        case "reset":
                            x = 0;
                            y = 0;
                            break;
                    }
                }
                else
                {
                    
                    var parameters = input.Split(' ')[1].Split(',');
                    foreach (var parameter in parameters)
                    {
                        Parser.ParseInt(parameter);
                    }
                    switch (command)
                    {
                        case "moveto":
                            x = Parser.ParseInt(parameters[0]);
                            y = Parser.ParseInt(parameters[1]);
                            break;
                        case "drawto":
                            var drawTo = new DrawTo(x, y, Parser.ParseInt(parameters[0]), Parser.ParseInt(parameters[1]));
                            drawTo.Draw(graphics, pen);
                            break;
                        case "pen":
                            switch (parameters[0])
                            {
                                case "green":
                                    pen.Color = Color.Green;
                                    break;
                                case "blue":
                                    pen.Color = Color.Blue;
                                    break;
                                case "red":
                                    pen.Color = Color.Red;
                                    break;
                                case "yellow":
                                    pen.Color = Color.Yellow;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "fill":
                            if (parameters[0] == "on")
                            {
                                fill = true;
                            }
                            else if (parameters[0] == "off")
                            {
                                fill = false;
                            }
                            else
                            {
                                throw new ArgumentException("Invalid parameters");
                            }
                            break;
                        case "circle":
                            var circle = new Circle(x, y, Parser.ParseInt(parameters[0]));
                            circle.Draw(graphics, pen, fill);
                            break;
                        case "rectangle":
                            var rectangle = new Rectangle(x, y, Parser.ParseInt(parameters[0]), Parser.ParseInt(parameters[1]));
                            rectangle.Draw(graphics, pen, fill);
                            break;
                        case "triangle":
                            var triangle = new Triangle(x, y, Parser.ParseInt(parameters[0]), Parser.ParseInt(parameters[1]), Parser.ParseInt(parameters[2]), Parser.ParseInt(parameters[3]), Parser.ParseInt(parameters[4]), Parser.ParseInt(parameters[5]));
                            triangle.Draw(graphics, pen, fill);
                            break;
                        default:
                            throw new ArgumentException("Invalid command");
                    }
                }
            }
        }
        public static int ParseInt(string parameter)
        {
            if (int.TryParse(parameter, out int result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("Invalid parameters");
            }
        }
    }
}