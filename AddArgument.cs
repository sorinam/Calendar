namespace Calendar
{
    public class AddArgument : IArgument
    {
        const string AddArg = "/add";
        const int Parameters = 5;
        const int OptionalParameters = 2;
        string[] inputArgs;

        public AddArgument(string[] args)
        {
            inputArgs = args;
        }

        public bool IsValid()
        {
            if (IsValidFirstParameter(inputArgs[0]))
            {
                if ((inputArgs.Length == Parameters) || (inputArgs.Length >= Parameters - OptionalParameters))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsValidFirstParameter(string arg)
        {
            return arg.ToLower() == AddArg;
        }
    }
}
