namespace Calendar
{
    using System.IO;

    class ExportArgument : IArgument
    {
        const string ListArg = "/export";
        const int OptionalParameters = 1;
        const int NumberOfArguments = 3;
        string[] parameters = { "past", "future", "today" };
        string[] inputArgs;

        public ExportArgument(string[] args)
        {
            inputArgs = args;
        }

        private bool IsValidFirstParameter(string arg)
        {
            return arg.ToLower() == ListArg;
        }

        private bool IsValidSecondParameter(string arg)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == arg)
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsValidFilenameAndPath(string fileName)
        {   
            return !string.IsNullOrEmpty(fileName) &&
                fileName.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;
        }

        public bool IsValid()
        {
            if (IsValidFirstParameter(inputArgs[0]))
            {
                if ((inputArgs.Length == 3) && (IsValidSecondParameter(inputArgs[1].ToLower()) && IsValidFilenameAndPath(inputArgs[2])))
                {
                    return true;
                }
                else
                {
                    if (inputArgs.Length == 2 && IsValidFilenameAndPath(inputArgs[1]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
