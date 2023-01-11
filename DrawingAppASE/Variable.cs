using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppASE
{
    /// <summary>
    /// Variable class that creates a user-declared variable for the user's program
    /// </summary>
    public class Variable
    {
        public static Dictionary<string, int> variables = new Dictionary<string, int>();

        /// <summary>
        /// Variable constructor checks if variable with similar name exists
        /// If not then adds new variable to variables Dictionary
        /// </summary>
        /// <param name="variableName"></param> name of variable
        /// <param name="value"></param> value of variable
        public Variable(string variableName, int value)
        {
            if (variables.ContainsKey(variableName))
            {
                variables[variableName] = value;
            }
            else
            {
                variables.Add(key: variableName, value: value);
            }
        }
    }
}
