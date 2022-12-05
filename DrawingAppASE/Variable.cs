using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppASE
{
    public class Variable
    {
        public static Dictionary<string, int> variables = new Dictionary<string, int>();

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

        //should I put the code in the constructor in a seperate method and leave the constructor empty? and call that method in the parser class
    }
}
