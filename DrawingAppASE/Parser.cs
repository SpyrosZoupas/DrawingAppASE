using Antlr.Runtime;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Linq.Dynamic.Core.Parser;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace DrawingAppASE
{
    /// <summary>
    /// Parser class that takes one or more user commands as input either from command line or program box and analyses each command, checks for errors,
    /// informs the user if there are any, and executes each command if there are no errors
    /// </summary>
    public class Parser
    {
        private static int x = 0;
        private static int y = 0;
        private static int iterations;
        private static int loopCounter = 0;
        public static int lineCounter = 1;
        private static string command;
        private static string nameOfMethod;
        private static bool fill = false;
        private static bool executeCommands = true;
        private static bool insideMethod = false;
        private static bool insideLoop = false;
        private static bool syntaxCorrect;
        private static Font myFont = new Font("Arial", 14);
        private static ShapeFactory shapeFactory = new ShapeFactory();
        private static DataTable dataTable = new DataTable();
        private static List<string> methodCommands = new List<string>();
        private static Dictionary<string, string[]> methods = new Dictionary<string, string[]>();
        private static List<string> methodParameters = new List<string>();
        private static List<string> loopCommands = new List<string>();
        private static List<string> commandsList = new List<string>()
        {
            "method",
            "endmethod",
            "loop",
            "endloop",
            "if",
            "endif",
            "clear",
            "reset",
            "moveto",
            "drawto",
            "pen",
            "fill",
            "circle",
            "rectangle",
            "triangle"
        };

        /// <summary>
        /// Parses each line of commands from <paramref name="commands"/>
        /// Calls CheckSyntax method before starting execution to check for errors
        /// Calls the appropriate method depending on the nature of each command
        /// </summary>
        /// <param name="commands">collection of one or more user commands being parsed</param>
        public static bool ParseAction(Graphics graphics, Pen pen, IEnumerable<string> commands)
        {           
            if (syntaxCorrect == false)
            {
                graphics.Clear(Color.Gray);
            }

            lineCounter = 1;
            syntaxCorrect = true;
            methods.Clear();
            foreach (var input in commands)
            {
                command = input.Split(' ')[0];
                if(!CheckSyntax(graphics,pen,commands,input))
                {
                    syntaxCorrect = false;                   
                } else
                {
                    lineCounter++;
                }
            }
           
            if (syntaxCorrect == false)
            {
                return false;
            }

            foreach (var input in commands)
            {                

                command = input.Split(' ')[0];

                if (insideLoop == true)
                {
                    loopCommands.Add(input);
                }

                switch (command)
                {
                    case "method":                       
                        ParseMethod(input, command, graphics);
                        break;
                    case "endmethod":
                        insideMethod = false;
                        executeCommands = true;
                        break;
                    case "loop":
                        insideLoop = true;
                        iterations = Parser.ParseInt(input.Split(' ')[1]);                       
                        break;
                    case "endloop":
                        insideLoop = false;
                        loopCounter++;
                        if (loopCounter < iterations)
                        {
                            ParseAction(graphics, pen, loopCommands);
                        }
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
                            ParseCommand(graphics, pen, input);
                        }
                        else
                        {
                            methodCommands.Add(input);
                        }
                        break;
                }
            }
            return true;
        }

        /// <summary>
        /// Gets called for each command and checks if there are any errors, returns false if an error is found, returns true otherwise
        /// </summary>
        public static bool CheckSyntax(Graphics graphics, Pen pen, IEnumerable<string> commands, string input)
        {

            if (input.Split(' ').Count() > 1)
            {
                if (input.Split(' ')[1] == "=")
                {                
                    return true;
                }
            }

            if (!commandsList.Contains(command) & !commandsList.Contains(input.Split('(')[0]))
            {
                graphics.DrawString("ERROR: Invalid command", myFont, Brushes.Red, new Point(2, 2));    
                graphics.DrawString($"Error found in line: {lineCounter}", myFont, Brushes.Red, new Point(2, 30));
                return false;
            }

            if (command == "reset" || command == "clear")
            {
                if (input.Trim().Split(' ').Length > 1)
                {
                    graphics.DrawString("ERROR: Wrong number of parameters. Parameters for command needed: 0", myFont, Brushes.Red, new Point(2, 2));
                    graphics.DrawString($"Error found in line: {lineCounter}", myFont, Brushes.Red, new Point(2, 30));
                    return false;
                }
            }

            if (input.Trim().Split(' ').Length != 1)
            {
                if (command == "pen" || command == "fill" || command == "circle")
                {
                    if (input.Split(' ')[1].Split(',').Length != 1)
                    {
                        graphics.DrawString($"ERROR: Wrong number of parameters. Parameters for command needed: 1", myFont, Brushes.Red, new Point(2, 2));
                        graphics.DrawString($"Error found in line: {lineCounter}", myFont, Brushes.Red, new Point(2, 30));
                        return false;
                    }

                    if (command == "pen")
                    {
                        if (input.Split(' ')[1] != "green" & input.Split(' ')[1] != "blue" & input.Split(' ')[1] != "red" & input.Split(' ')[1] != "yellow")
                        {
                            graphics.DrawString("ERROR: Please choose a valid colour", myFont, Brushes.Red, new Point(2, 2));
                            graphics.DrawString($"Error found in line: {lineCounter}", myFont, Brushes.Red, new Point(2, 30));
                            return false;
                        }                      
                    }

                    if (command == "fill")
                    {
                        if (input.Split(' ')[1] != "on" & input.Split(' ')[1] != "off")
                        {
                            graphics.DrawString("ERROR: fill command only accepts 'on' or 'off' as parameters", myFont, Brushes.Red, new Point(2, 2));
                            graphics.DrawString($"Error found in line: {lineCounter}", myFont, Brushes.Red, new Point(2, 30));
                            return false;
                        }
                    }
                }

                if (command == "moveto" || command == "drawto" || command == "rectangle")
                {
                    if (input.Split(' ')[1].Split(',').Count() != 2)
                    {
                        graphics.DrawString($"ERROR: Wrong number of parameters. Parameters for command needed: 2", myFont, Brushes.Red, new Point(2, 2));
                        graphics.DrawString($"Error found in line: {lineCounter}", myFont, Brushes.Red, new Point(2, 30));
                        return false;
                    }                  
                }

                if (command == "triangle")
                {
                    if (input.Split(' ')[1].Split(',').Count() != 6)
                    {
                        graphics.DrawString($"ERROR: Wrong number of parameters. Parameters for command needed: 6", myFont, Brushes.Red, new Point(2, 2));
                        graphics.DrawString($"Error found in line: {lineCounter}", myFont, Brushes.Red, new Point(2, 30));
                        return false;
                    }                 
                }
            } 
            
            if (input.Trim().Split(' ').Length == 1 & command != "reset" & command != "clear" & command != "endmethod" & !commandsList.Contains(command.Split('(')[0]))
            {
                graphics.DrawString($"ERROR: Command needs parameters", myFont, Brushes.Red, new Point(2, 2));
                graphics.DrawString($"Error found in line: {lineCounter}", myFont, Brushes.Red, new Point(2, 30));
                return false;
            }

            if (command == "method")
            {
                nameOfMethod = input.Split(' ')[1].Split('(')[0];
            }

            if (command == "endmethod")
            {
                commandsList.Add(nameOfMethod);
            }

            return true;                    
        }

        /// <summary>
        /// Gets called if the command is a shape command, clear, reset, move, pen or fill
        /// Executes the selected command
        /// </summary>
        public static void ParseCommand(Graphics graphics, Pen pen, string input)
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
                                ParseMethod(input, command, graphics);
                                ParseAction(graphics, pen, methodCommands);
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
                        ParseVariable(input);
                    }
                    else
                    {

                        switch (command)
                        {
                            case "moveto":
                                    x = Parser.ParseInt(parameters[0]);
                                    y = Parser.ParseInt(parameters[1]);                        
                                break;
                            case "drawto":
                                    paramList.Add(Parser.ParseInt(parameters[0]));
                                    paramList.Add(Parser.ParseInt(parameters[1]));
                                    var drawTo = shapeFactory.CreateShape(command, paramList);
                                    drawTo.Draw(graphics, pen, fill);                             
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
                                break;
                            case "circle":
                                    paramList.Add(Parser.ParseInt(parameters[0]));
                                    var circle = shapeFactory.CreateShape(command, paramList);
                                    circle.Draw(graphics, pen, fill);
                                break;
                            case "rectangle":                               
                                    paramList.Add(Parser.ParseInt(parameters[0]));
                                    paramList.Add(Parser.ParseInt(parameters[1]));
                                    var rectangle = shapeFactory.CreateShape(command, paramList);
                                    rectangle.Draw(graphics, pen, fill);                           
                                break;
                            case "triangle":                               
                                    var paramCounter = 0;
                                    foreach (var param in parameters)
                                    {
                                        paramList.Add(Parser.ParseInt(parameters[paramCounter]));
                                        paramCounter++;
                                    }
                                    var triangle = shapeFactory.CreateShape(command, paramList);
                                    triangle.Draw(graphics, pen, fill);                                                      
                                break;                         
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets called if command is method
        /// checks if a method with the same name exists already in the program
        /// if a method with similar name exists produces an error
        /// else saves the method with its name and parameters
        /// </summary>
        /// <param name="input"></param>
        /// <param name="command"></param>
        /// <param name="graphics"></param>
        public static void ParseMethod(string input, string command, Graphics graphics)
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
                    graphics.DrawString($"ERROR: a method with that name already exists", myFont, Brushes.Red, new Point(2, 2));
                    graphics.DrawString($"Error found in line: {lineCounter}", myFont, Brushes.Red, new Point(2, 30));
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
        /// Gets called when a user declares a variable
        /// If variable with similar name does not exist, new variable object is created
        /// Also gets called when an expression needs parsing
        /// </summary>
        /// <param name="input"></param>
        public static void ParseVariable(string input)
        {
            var expression = input.Split('=')[1].Trim();
            StringBuilder builder = new StringBuilder(expression);
            foreach (KeyValuePair<string, int> test in Variable.variables)
            {
                if (expression.Contains(test.Key))
                {
                    builder.Replace(test.Key, Convert.ToString(test.Value));
                }
            }
            string newExpression = builder.ToString();
            var value = dataTable.Compute(newExpression, "");
            var variable = new Variable(command, Convert.ToInt32(value));
        }

        /// <summary>
        /// Checks whether a parameter is an integer
        /// If true returns the parameter as an integer
        /// else checks if parameter is a variable name
        /// If true returns variable value
        /// else throws FormatException()
        /// </summary>
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
                lineCounter--;
                throw new FormatException();
            }
        }      
    }
}