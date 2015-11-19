using System;
using System.Linq;

namespace Calendar
{
    public class SearchDescriptionArgument : IArgument
    {
        string[] stringOperator = { "!=", "not equal", "=", "equal", "contains" };

        string[] inputArgs;
        string field;
        string criteria;
        string value;

        public string Field
        { get { return field; } }
        public string Criteria
        { get { return criteria; } }
        public string Value
        { get { return value; } }

        public SearchDescriptionArgument(string[] args)
        {
            inputArgs = args;
        }

        private bool IsValidStringOperator(string arg)
        {
            return stringOperator.Contains(arg.ToLower()) ? true : false;
        }

        public bool IsValid()
        {
            field = "description";
            return IsValidTitleFilterParametrs(inputArgs) ? true : false;
        }

        private bool IsValidTitleFilterParametrs(string[] inputArgs)
        {
            switch (inputArgs.Length)
            {
                case 3:
                    {
                        if (!stringOperator.Contains(inputArgs[2]))
                        {
                            criteria = "=";
                            value = inputArgs[2];
                            return true;
                        }
                        return false;
                    }
                case 4:
                    {
                        if (stringOperator.Contains(inputArgs[2]))
                        {
                            criteria = Utils.ParseFilteringCriteria(inputArgs[2]);
                            value = inputArgs[3];
                            return true;
                        };
                        return false;
                    }
            }
            return false;
        }
    }
}
     