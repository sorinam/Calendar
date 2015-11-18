using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class TagFilter
    {
        string[] valueToCompare;
        string criteria;

        public TagFilter(string criteria, string[] valueToCompare)
        {
            this.valueToCompare = valueToCompare;
            this.criteria = criteria;
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
                    return ContainsAnyTag(ev, valueToCompare);
                case "&&":
                    return ContainsAllTags(ev, valueToCompare);
                default: return false;
            }

        }
        bool ContainsAnyTag(Event ev, string[] tagValues)
        {
            return tagValues.Any(elem => ev.Tags.Contains('#' + elem) || ev.Tags.Contains('@' + elem));
        }
        bool ContainsAllTags(Event ev, string[] tagValues)
        {
            return tagValues.All(elem => ev.Tags.Contains('#' + elem) || ev.Tags.Contains('@' + elem));
        }
    }
}
