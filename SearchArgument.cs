using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class SearchArgument : IArgument
    {
        string[] dateOneValueOperator = { "equal", "=", "!=", "not equal", "<", "older", ">", "newer" };
        string[] dateTwoValueOperator = { "between", "<>" };
        string[] dateSortcut = { "today", "this week" };
        string[] descriptionOperator = { "!=", "not equal", "=", "equal", "contains" };

        string[] inputArgs;
        string field;
        string criteria;
        string firstValue;
        string secondValue;
        public string Field
        { get { return field; } }
        public string Criteria
        { get { return criteria; } }
        public string Value
        { get { return firstValue; } }
        public string AnotherValue
        { get { return secondValue; } }

        public SearchArgument(string[] args)
        {
            inputArgs = args;
        }

        private bool IsValidDateOperator(string arg)
        {
            return dateOneValueOperator.Contains(arg.ToLower()) ? true : false;
        }

        private bool IsValidOperatorForTwoDate(string arg)
        {
            return dateTwoValueOperator.Contains(arg.ToLower()) ? true : false;
        }
        private bool IsValidDescriptionOperator(string arg)
        {
            return descriptionOperator.Contains(arg.ToLower()) ? true : false;
        }


        public bool IsValid()
        {
            if (inputArgs.Length > 1)
            {
                switch (inputArgs[1].ToLower())
                {
                    case "date":
                        {
                            field = "date";
                            if (IsValidDateFilterParametrs(inputArgs)) return true;
                            break;
                        }
                    case "description":
                        {
                            field = "description";
                            if (IsValidDescriptionFilterParametrs(inputArgs)) return true;
                            break;
                        }
                    default:
                        {
                            return false;
                        }
                }
            }
            return false;
        }

        private bool IsValidDescriptionFilterParametrs(string[] inputArgs)
        {
            switch (inputArgs.Length)
            {
                case 3:
                    {
                        if (!descriptionOperator.Contains(inputArgs[2]))
                        {
                            criteria = "=";
                            firstValue = inputArgs[2];
                            return true;
                        }
                        return false;
                    }
                case 4:
                    {
                        if (descriptionOperator.Contains(inputArgs[2]))
                        {
                            criteria = Utils.ParseFilteringCriteria(inputArgs[2]);
                            firstValue = inputArgs[3];
                            return true;
                        };
                        return false;
                    }
           }
            return false;
        }

        private bool IsValidRegularForm(string[] inputArgs)
        {
            if ((dateOneValueOperator.Contains(inputArgs[2].ToLower())) &&
                    Utils.IsValidDate(inputArgs[3]))
            {
                criteria = Utils.ParseFilteringCriteria(inputArgs[2]);
                firstValue = inputArgs[3];
                return true;
            }

            if ((dateOneValueOperator.Contains(inputArgs[2].ToLower())) &&
                   (inputArgs[3].ToLower() == "today"))
            {
                criteria = Utils.ParseFilteringCriteria(inputArgs[2]);
                firstValue = DateTime.Today.ToShortDateString();
                return true;
            }
            return false;

        }

        private bool IsValidBeetwenDateForm(string[] inputArgs)
        {
            if ((dateTwoValueOperator.Contains(inputArgs[2].ToLower())) && (Utils.IsValidDate(inputArgs[3]))
                    && (Utils.IsValidDate(inputArgs[4])))
            {
                criteria = Utils.ParseFilteringCriteria(inputArgs[2]);
                firstValue = inputArgs[3];
                secondValue = inputArgs[4];
                return true;
            }
            return false;
        }

        private bool IsValidShortForm(string[] inputArgs)
        {
            if (dateSortcut.Contains(inputArgs[2].ToLower()))
            {
                switch (inputArgs[2].ToLower())
                {
                    case "today":
                        {
                            criteria = "=";
                            firstValue = DateTime.Today.ToShortDateString();
                            return true;
                        }
                    case "this week":
                        {
                            criteria = "<>";
                            Utils.GetBeginEndDaysOfWeek(DateTime.Today.ToShortDateString(), out firstValue, out secondValue);
                            return true;
                        }
                    default: return false;
                }
            }
            else
            {
                if (Utils.IsValidDate(inputArgs[2]))
                {
                    criteria = "=";
                    firstValue = inputArgs[2];
                    return true;
                }
                else
                { return false; }
            }
        }

        private bool IsValidDateFilterParametrs(string[] inputArgs)
        {
            switch (inputArgs.Length)
            {
                case 3:
                    {
                        return IsValidShortForm(inputArgs) ? true : false;
                    }
                case 4:
                    {
                        return IsValidRegularForm(inputArgs) ? true : false;
                    }
                case 5:
                    {
                        return IsValidBeetwenDateForm(inputArgs) ? true : false;
                    }
                default:
                    { return false; }
            }
        }

    }
}
