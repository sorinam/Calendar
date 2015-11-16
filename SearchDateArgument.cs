using System;
using System.Linq;

namespace Calendar
{
    public class SearchDateArgument
    {
        string[] dateOneValueOperator = { "equal", "=", "!=", "not equal", "<", "older", ">", "newer" };
        string[] dateTwoValueOperator = { "between", "<>" };
        string[] dateSortcut = { "today", "this week" };
    
        string[] inputArgs;
        string field;
        string criteria;
        string date;
        string anotherDate;
        public string Field
        { get { return field; } }
        public string Criteria
        { get { return criteria; } }
        public string Date
        { get { return date; } }
        public string AnotherDate
        { get { return anotherDate; } }

        public SearchDateArgument(string[] args)
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
   
        public bool IsValid()
        {
            field = "date";

            return IsValidDateFilterParametrs(inputArgs)? true: false;
        }

         private bool IsValidRegularForm(string[] inputArgs)
        {
            if ((dateOneValueOperator.Contains(inputArgs[2].ToLower())) &&
                    Utils.IsValidDate(inputArgs[3]))
            {
                criteria = Utils.ParseFilteringCriteria(inputArgs[2]);
                date = inputArgs[3];
                return true;
            }

            if ((dateOneValueOperator.Contains(inputArgs[2].ToLower())) &&
                   (inputArgs[3].ToLower() == "today"))
            {
                criteria = Utils.ParseFilteringCriteria(inputArgs[2]);
                date = DateTime.Today.ToShortDateString();
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
                date = inputArgs[3];
                anotherDate = inputArgs[4];
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
                            date = DateTime.Today.ToShortDateString();
                            return true;
                        }
                    case "this week":
                        {
                            criteria = "<>";
                            Utils.GetBeginEndDaysOfWeek(DateTime.Today.ToShortDateString(), out date, out anotherDate);
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
                    date = inputArgs[2];
                    return true;
                }
                else
                { return false; }
            }
        }

        private bool IsValidDateFilterParametrs(string[] inputArgs)
        {
            switch (inputArgs.Length)
            {   case 3:return IsValidShortForm(inputArgs) ? true : false;
                case 4:return IsValidRegularForm(inputArgs) ? true : false;
                case 5:return IsValidBeetwenDateForm(inputArgs) ? true : false;
              default:return false; 
            }
        }

    }
}

