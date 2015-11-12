using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class SearchArgument:IArgument
    {
        const string searchArg = "/search";
        string[] date = { "date", "equal","=","!=", "not equal","<>", "between","<","older",">","newer","today"};
        string[] description = { "description", "!=", "not equal", "=", "equal", "contains" };
        const int parameters = 4;
        const int optionalParameters = 1;
        string[] inputArgs;

        string fieldName = "";
        string op1 = "";
        string op2 = "";
        string criteria = "";
        string value = "";

        public SearchArgument(string[] args)
        {
            inputArgs = args;
        }

        private bool IsValidFirstParameter(string arg)
        {
            return (arg.ToLower() == searchArg);
        }

        private bool IsValidSecondParameter(string arg)
        {
            if (((arg.ToLower() == date[0]) || ((arg.ToLower()) == description[0]))) return true;
            return false;
        }


        public bool IsValid1()
        {
            if (inputArgs.Length >= (parameters-optionalParameters))
            {
                if (IsValidFirstParameter(inputArgs[0]))
                {
                    if (IsValidSecondParameter(inputArgs[1]))
                    {
                        switch (inputArgs[1].ToLower())
                        {
                            case "date":
                                {
                                    if ((IsValidDateFilterOperator(inputArgs[2].ToLower())) &&
                                        (!(inputArgs[3].ToLower().Contains("between"))) && (inputArgs.Length == 4)&&Utils.IsValidDate(inputArgs[3]))
                                    { return true; };

                                    if ((IsValidDateFilterOperator(inputArgs[2].ToLower())) &&
                                         ((inputArgs[3].ToLower().Contains("between"))) && (inputArgs.Length == 5) && Utils.IsValidDate(inputArgs[3])&& Utils.IsValidDate(inputArgs[4]))
                                    { return true; };
                                    return false;
                                }
                            case "description":
                                {
                                    if ((IsValidDescriptionFilterOperator(inputArgs[2].ToLower())) &&
                                       inputArgs.Length == 4)
                                    { return true; };
                                    return false;
                                }
                            default:
                                { return false; }

                        }
                    }
                }
            }
            return false;
        }

        public bool IsValid()
        {
            switch (inputArgs[1].ToLower())
            {
                case "date":
                    {
                      if( IsValidDateFilterParametrs(inputArgs) )return true;
                        break;
                    }
                case "description":
                    {
                        if (IsValidDescriptionFilterParametrs(inputArgs)) return true;
                        break;
                    }
                default:
                    {
                        return false;
                    }
            }
            return false;
        }

        private bool IsValidDescriptionFilterParametrs(string[] inputArgs)
        {
            throw new NotImplementedException();
        }

        private bool IsValidDateFilterParametrs(string[] inputArgs)
        {
            throw new NotImplementedException(); ;
        }

        private bool IsValidDateFilterOperator(string arg)
        {
            for (int i = 1; i < date.Length; i++)
            {
                if (date[i] == arg)
                { return true; }
            }
            return false;
        }
        private bool IsValidDescriptionFilterOperator(string arg)
        {
            for (int i = 1; i < description.Length; i++)
            {
                if (description[i] == arg)
                { return true; }
            }
            return false;
        }
    }
}
