using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calendar
{
    public class Utils
    {
        struct FilteringCriteriaParser
        {   private string UIvalue;
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
                new FilteringCriteriaParser("past","<"),
                new FilteringCriteriaParser("future",">"),
                new FilteringCriteriaParser("beetwen","<>"),
                new FilteringCriteriaParser("not equal ","!="),
                new FilteringCriteriaParser("today","="),
                 new FilteringCriteriaParser("contains",">"),
            };

            for (int i = 0; i < AcceptedParameters.Length;i++)
            {
                if (UIParameter == AcceptedParameters[i].UIValue) return AcceptedParameters[i].InternalValue;
            }
            return "";
        }
        }
    
}
