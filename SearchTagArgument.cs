using System;
using System.Linq;

namespace Calendar
{
    class SearchTagArgument : IArgument
    {
        string[] stringOperator = {"||","any","&&","all"};

        string[] inputArgs;
        string field;
        string criteria;
        string[] values ;

        public string Field
        { get { return field; } }
        public string Criteria
        { get { return criteria; } }
        public string[] Values
        {
            get { return values; }
        }

        public SearchTagArgument(string[] args)
        {
            inputArgs = args;
        }

        private bool IsValidStringOperator(string arg)
        {
            return stringOperator.Contains(arg.ToLower()) ? true : false;
        }

        public bool IsValid()
        {
            field = "tag";
            return IsValidTagFilterParametrs(inputArgs) ? true : false;
        }

        private bool IsValidTagFilterParametrs(string[] inputArgs)
        {
            if (!stringOperator.Contains(inputArgs[2]))
            {
                Array.Resize(ref values, inputArgs.Length - 2);
                criteria = "||";
                Array.Copy(inputArgs, 2, values, 0, inputArgs.Length - 2);
                return true;
            }
            else
            {
                Array.Resize(ref values, inputArgs.Length - 3);
                criteria = Utils.ParseFilteringCriteria(inputArgs[2]);
                Array.Copy(inputArgs, 3, values, 0, inputArgs.Length - 3);
                return true;
            };
              
        }
    }
}
