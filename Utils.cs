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
        public string CodingNewLineChar(string value)
        {
            return (value.Replace('\n', '\a'));
        }

        public string DecodingNewLineChar(string value)
        {
            return (value.Replace('\a', '\n'));
        }

        public string DecodingNewLineCharForHTML(string value)
        {
            Regex regex = new Regex(@"(\r\n|\r|\n)+");
            return regex.Replace(value, "<br />");
        }
    }
}
