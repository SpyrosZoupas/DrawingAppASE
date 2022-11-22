using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;

namespace DrawingAppASE
{
    /// <summary>
    /// Parser class that takes one or more user commands as input either from command line or program box and analyses each command,
    /// decides whether to execute it or if there is a mistake inform the user how to fix it
    /// </summary>
    public class Parser
    {
        private static int x = 0;
        private static int y = 0;
        private static bool fill = false;

        /// <summary>
        /// ParseAction method parses each line of commands from <paramref name="commands"/>
        /// splits each line between command and parameters then splits parameters between them
        /// calls command or informs the user in case of error
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="pen"></param>
        /// <param name="commands">collection of one or more user commands being parsed</param>
        /// <exception cref="ArgumentException"></exception>
        public static void ParseAction(Graphics graphics, Pen pen, IEnumerable<string> commands)
        {
            foreach (var input in commands)
            {
                var command = input.Split(' ')[0];
                if (input.Trim().Split(' ').Length == 1)
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
                        default:
                            System.Windows.Forms.MessageBox.Show("ERROR: Invalid command");
                            break;
                    }
                }
                else
                {
                    
                    var parameters = input.Split(' ')[1].Split(',');

                    switch (command)
                    {
                        case "moveto":
                            if (parameters.Length == 2)
                            {
                                x = Parser.ParseInt(parameters[0]);
                                y = Parser.ParseInt(parameters[1]);
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show("ERROR: Wrong numbers of parameters. Parameters needed = 2");
                            }
                            break;
                        case "drawto":
                            if (parameters.Length == 2)
                            {
                                var drawTo = new DrawTo(x, y, Parser.ParseInt(parameters[0]), Parser.ParseInt(parameters[1]));
                                drawTo.Draw(graphics, pen);
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show("ERROR: Wrong numbers of parameters. Parameters needed = 2");
                            }
                            break;
                        case "pen":
                            if (parameters.Length == 1)
                            {
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
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show("ERROR: Wrong numbers of parameters. Parameters needed = 1");
                            }
                            break;
                        case "fill":
                            if (parameters.Length == 1)
                            {
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
                                    System.Windows.Forms.MessageBox.Show("ERROR: fill command only accepts 'on' or 'off' as parameters");
                                }
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show("ERROR: Wrong numbers of parameters. Parameters needed = 1");
                            }
                            break;
                        case "circle":
                            if (parameters.Length == 1)
                            {
                                var circle = new Circle(x, y, Parser.ParseInt(parameters[0]));
                                circle.Draw(graphics, pen, fill);
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show("ERROR: Wrong numbers of parameters. Parameters needed = 1");
                            }
                            break;
                        case "rectangle":
                            if (parameters.Length == 2)
                            {
                                var rectangle = new Rectangle(x, y, Parser.ParseInt(parameters[0]), Parser.ParseInt(parameters[1]));
                                rectangle.Draw(graphics, pen, fill);
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show("ERROR: Wrong numbers of parameters. Parameters needed = 2");
                            }
                            break;
                        case "triangle":
                            if (parameters.Length == 6)
                            {
                                var triangle = new Triangle(x, y, Parser.ParseInt(parameters[0]), Parser.ParseInt(parameters[1]), Parser.ParseInt(parameters[2]), Parser.ParseInt(parameters[3]), Parser.ParseInt(parameters[4]), Parser.ParseInt(parameters[5]));
                                triangle.Draw(graphics, pen, fill);
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show("ERROR: Wrong numbers of parameters. Parameters needed = 6");
                            }
                            break;
                        default:
                            System.Windows.Forms.MessageBox.Show("ERROR: Invalid command");
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// ParseInt method checks whether a parameter is an integer
        /// </summary>
        /// <param name="parameter">single parameter of a command</param>
        /// <returns></returns>
        public static int ParseInt(string parameter)
        {
            if (int.TryParse(parameter, out int result))
            {
                return result;
            } 
            else
            {
                throw new FormatException();
            }
        }
    }
}