using System.Linq;

namespace Calendar
{
    public class StringFilter
    {
        string[] valueToCompare;
        string criteria;

        public StringFilter(string criteria, string[] valueToCompare)
        {
            this.valueToCompare = valueToCompare;
            this.criteria = criteria;
        }

        public Events ApplyFilter(Events sourceList,string type)
        {
            Events filteredList = new Events();

            foreach (Event ev in sourceList)
            {
                if (IsTrueCriteria(ev, criteria,type))
                {
                    filteredList.Add(ev);
                }
            }

            return filteredList;
        }

        bool IsTrueCriteria(Event ev, string criteria,string type)
        {
            switch (criteria)
            {
                case "||":
                    if (type == "tag") return ContainsAnyTag(ev, valueToCompare);
                    else
                        return ContainsAnyValue(ev, valueToCompare)
               ;
                case "&&":
                    if (type == "tag") return ContainsAllTags(ev, valueToCompare);
                    else
                        return ContainsAllValues(ev, valueToCompare);
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

        bool ContainsAnyValue(Event ev, string[] tagValues)
        {
            return tagValues.Any(elem => ev.Tags.Contains(elem) || ev.Tags.Contains(elem));
        }
        bool ContainsAllValues(Event ev, string[] tagValues)
        {
            return tagValues.All(elem => ev.Tags.Contains(elem) || ev.Tags.Contains(elem));
        }
    }
}
