using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class ExportArgument : IArgument
    {
        const string listArg = "/export";
        string[] parameters = { "past", "future", "today" };
        const int optionalParameters = 1;
        const int numberOfArguments = 3;
        string[] inputArgs;

        public ExportArgument(string[] args)
        {
            inputArgs = args;
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

        private bool IsValidFilenameAndPath(string fileName)
        {   
            return (!string.IsNullOrEmpty(fileName) &&
                fileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0);
        }

        public bool IsValid()
        {
            if (IsValidFirstParameter(inputArgs[0]))
            {
                if ((inputArgs.Length == 3)&& (IsValidSecondParameter(inputArgs[1].ToLower())&& IsValidFilenameAndPath(inputArgs[2])))
                {
                    return true;
                }
                else
                {
                    if ((inputArgs.Length == 2) && (IsValidFilenameAndPath(inputArgs[1])) ) return true;
                }
            }
            return false;
        }
    }
}
