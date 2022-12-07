using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

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
        private static bool executeCommands = true;
        private static bool insideMethod = false;
        private static ShapeFactory shapeFactory = new ShapeFactory();
        private static DataTable dataTable = new DataTable();
        private static List<string> methodCommands = new List<string>();
        private static Dictionary<string, string[]> methods = new Dictionary<string, string[]>();
        private static List<string> methodParameters = new List<string>();

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

                //change it so variables can be used in if conditions

                switch (command)
                {
                    case "method":                       
                        ParseMethod(input, command);
                        break;
                    case "endmethod":
                        insideMethod = false;
                        executeCommands = true;
                        break;
                    case "if":
                        if (!Convert.ToBoolean(dataTable.Compute(input.Split(' ')[1], "")))
                        {
                            executeCommands = false;
                        }
                        break;
                    case "endif":
                        executeCommands = true;
                        break;
                    default:
                        if (!insideMethod)
                        {
                            ParseCommand(graphics, pen, input, command);
                        }
                        else
                        {
                            methodCommands.Add(input);
                        }
                        break;
                }                                                             
            }
        }

        public static void ParseCommand(Graphics graphics, Pen pen, string input, string command)
        {
            if (executeCommands == true)
            {
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
                            if (methods.ContainsKey(input.Split('(')[0]))
                            {
                                ParseMethod(input,command);
                                ParseAction(graphics, pen, methodCommands);
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show("ERROR: Invalid command");
                            }
                            break;
                    }
                }
                else
                {
                    List<int> paramList = new List<int> { x, y };

                    var parameters = input.Split(' ')[1].Split(',');

                    if (parameters[0] == "=")
                    {
                        var value = Convert.ToInt32(input.Split(' ')[2]);
                        var variable = new Variable(command, value);
                    }
                    else
                    {

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
                                    drawTo.Draw(graphics, pen, fill);
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
                                            System.Windows.Forms.MessageBox.Show("ERROR: Please choose a valid colour");
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
                                    paramList.Add(Parser.ParseInt(parameters[0]));
                                    var circle = shapeFactory.CreateShape(command, paramList);
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
                                    paramList.Add(Parser.ParseInt(parameters[0]));
                                    paramList.Add(Parser.ParseInt(parameters[1]));
                                    var rectangle = shapeFactory.CreateShape(command, paramList);
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
                                    var paramCounter = 0;
                                    foreach (var param in parameters)
                                    {
                                        paramList.Add(Parser.ParseInt(parameters[paramCounter]));
                                        paramCounter++;
                                    }
                                    var triangle = shapeFactory.CreateShape(command, paramList);
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
        }

        public static void ParseMethod(string input, string command)
        {
            if (command == "method")
            {
                var methodName = input.Split(' ')[1].Split('(')[0];
                var parameters = input.Split(' ')[1].Split('(')[1].Split(')')[0].Split(',');
                if (!methods.ContainsKey(methodName))
                {
                    methods.Add(key: methodName, value: parameters);
                    insideMethod = true;
                    executeCommands = false;
                    foreach (var param in parameters)
                    {
                        var methodVariable = new Variable(param, 0);
                        methodParameters.Add(param);
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("ERROR: A method with that name already exists");
                }
            } 
            else
            {
                var methodName = input.Split('(')[0];
                var parameters = input.Split('(')[1].Split(')')[0].Split(',');
                int counter = 0;
                foreach (var param in parameters)
                {
                    var methodVariable = new Variable(methodParameters[counter], Parser.ParseInt(param));
                    counter++;
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
            else if (Variable.variables.ContainsKey(parameter))  
            {
                return Variable.variables[parameter];         
            } 
            else
            {
                throw new FormatException();
            }
        }      
    }
}