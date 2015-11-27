using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class StringFilter
    {
        string criteria;
        string[] valueToCompare;

        public StringFilter(string criteria, string[] valueToCompare)
        {
            this.criteria = criteria;
            this.valueToCompare = valueToCompare;
        }

        public Events ApplyFilter(Events sourceList)
        {
            Events filteredList = new Events();

            foreach (Event ev in sourceList)
            {
                if (IsTrueCriteria(ev, criteria))
                {
                    filteredList.Add(ev);
                }
            }

            return filteredList;
        }

        bool IsTrueCriteria(Event ev, string criteria)
        {
            switch (criteria)
            {
                case "||":
                    return ContainsAnyString(ev, valueToCompare);
                case "&&":
                    return ContainsAllStrings(ev, valueToCompare);
                default: return false;
            }

        }
        bool ContainsAnyString(Event ev, string[] stringValues)
        {
            return stringValues.Any(elem => ev.Title.Contains(elem) || ev.Description.Contains(elem));
        }
        bool ContainsAllStrings(Event ev, string[] stringValues)
        {
            return stringValues.All(elem => ev.Title.Contains(elem) || ev.Description.Contains(elem));
        }
    }
}
