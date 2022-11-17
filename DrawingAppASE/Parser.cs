using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingAppASE
{
    public class Parser
    {
        public static Action ParseAction(IEnumerable<string> commands)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<int> ParseInt(IEnumerable<string> input)
        {
            throw new NotImplementedException();
        }

        public static Action ParseInput(string input) //should output command
        {
            throw new NotImplementedException();
        }

        //so prob ParseAction parses it then passes maybe the command only to ParseInput as a string and outputs a command object so which command? 
    }
}
