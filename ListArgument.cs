using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class ListArgument : IArgument
    {
        const string listArg = "/list";
        string [] parameters = { "all","past","future","today"};
        const int optionalParameters = 1;
        string[] inputArgs;

        public ListArgument (string[] args)
        {
            inputArgs=args; 
        }

        private bool IsValidFirstParameter(string arg)
        {
            return (arg.ToLower() == listArg);
        }

        private bool IsValidSecondParameter(string arg)
        {          
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == arg)
                { return true; }
            }
            return false;
        }

    
    public bool IsValid()
        {
            if (IsValidFirstParameter(inputArgs[0]))
            {
                if ((inputArgs.Length == 2))
                {
                    if (IsValidSecondParameter(inputArgs[1].ToLower())) return true;
                }
                else
                {
                    if (inputArgs.Length == 1) return true;
                }
            }
            return false;
        }
    }
}
