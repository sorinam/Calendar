using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class AddArgument : IArgument
    {
        const string addArg="/add";
        const int parameters= 4;
        const int optionalParameters = 1;
        string[] inputArgs;

        public AddArgument(string[] args)
            {
            inputArgs = args;
            }
        
        private bool IsValidFirstParameter(string arg)
        {
            return (arg.ToLower() == addArg);
        }

        public bool IsValid()
        {
            if (IsValidFirstParameter(inputArgs[0]))
            {
                if ((inputArgs.Length == parameters) || (inputArgs.Length == parameters - optionalParameters)) return true;
            }
            return false; 
        }
    }
}
