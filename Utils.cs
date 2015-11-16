using Should;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Calendar
{
    public class Utils
    {
        struct FilteringCriteriaParser
        {
            private string UIvalue;
            private string internalValue;

            public FilteringCriteriaParser(string v1, string v2)
            {
                this.UIvalue = v1;
                this.internalValue = v2;
            }
            public string UIValue { get { return UIvalue; } }
            public string InternalValue { get { return internalValue; } }

        }
        public static string CodingNewLineChar(string value)
        {
            return (value.Replace('\n', '\a'));
        }

        public static string DecodingNewLineChar(string value)
        {
            return (value.Replace('\a', '\n'));
        }

        public static string DecodingNewLineCharForHTML(string value)
        {
            Regex regex = new Regex(@"(\r\n|\r|\n)+");
            return regex.Replace(value, "<br />");
        }

        public static string ParseFilteringCriteria(string UIParameter)
        {

        FilteringCriteriaParser[] AcceptedParameters = {
                new FilteringCriteriaParser("equal","="),
                new FilteringCriteriaParser("=","="),
                new FilteringCriteriaParser("past","<"),
                new FilteringCriteriaParser("<","<"),
                new FilteringCriteriaParser("<=","<="),
                new FilteringCriteriaParser(">=",">="),
                new FilteringCriteriaParser(">",">"),
                new FilteringCriteriaParser("<>","<>"),
                new FilteringCriteriaParser("future",">"),
                new FilteringCriteriaParser("between","<>"),
                new FilteringCriteriaParser("not equal","!="),
                new FilteringCriteriaParser("!=","!="),
                new FilteringCriteriaParser("today","="),
                new FilteringCriteriaParser("contains",">"),
                new FilteringCriteriaParser("older","<"),
                new FilteringCriteriaParser("newer",">"),
            };

            for (int i = 0; i < AcceptedParameters.Length;i++)
            {
                if (UIParameter == AcceptedParameters[i].UIValue) return AcceptedParameters[i].InternalValue;
            }
            return "";
        }

        public static void AssertAreEqual(Events listofEvents, List<Event> expectedList)
        {
            listofEvents.Length.ShouldEqual(expectedList.Count);

            int i = 0;
            foreach (Event ev in listofEvents)
            {
                ev.Date.ShouldEqual(expectedList[i].Date);
                ev.Subject.ShouldEqual(expectedList[i].Subject);
                ev.Title.ShouldEqual(expectedList[i].Title);
                ev.Description.ShouldEqual(expectedList[i].Description);
                i++;
            }
        }
        public static bool IsValidDate(string date)
        {
            DateTime dateTime;
            if (DateTime.TryParse(date, out dateTime))
            {
                return true;
            }
            else
            {
                Console.WriteLine("\n\t Bad Date/Time format or conversion not supported!");
                return false;
            }
        }

        public static void GetBeginEndDaysOfWeek(string date,out string beginDateofWeek, out string endDayOfWeek)
        {
            beginDateofWeek = "";
            endDayOfWeek = "";
            if (IsValidDate(date))
            {   DateTime inputDate= DateTime.Parse(date);

                DateTime firstDay =inputDate.AddDays(-(int)inputDate.DayOfWeek);
                DateTime endDay = firstDay.AddDays(6);

                beginDateofWeek = firstDay.ToString("yyyy/MM/dd");
                endDayOfWeek = endDay.ToString("yyyy/MM/dd");
            }
        }
    }
    
}
