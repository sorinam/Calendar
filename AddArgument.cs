using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class AddArgument : IArgument
    {
        const string addArg="/add";
        const int parameters= 3;
        const int optionalParameters = 1;
        string[] inputArgs;

        string[] Arguments
        {
            set { inputArgs = value; }
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
