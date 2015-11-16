using System;

namespace Calendar
{
    public class DateFilter : IFilter
    {
        string criteria;
        string dateToCompare;

        public DateFilter(string criteria, string dateToCompare)
        {
            Criteria = criteria;
            ValueToCompare = dateToCompare;
        }

        public string Criteria
        {
            set { this.criteria = value; }
        }

        public string ValueToCompare
        {
            set { this.dateToCompare = value; }
        }

        public Events ApplyFilter(Events sourceList)
        {
            Events filteredList = new Events();
            Event compare = new Event(dateToCompare, "", "");
            foreach (Event ev in sourceList)
            {
                if (IsTrueCriteria(ev, compare, criteria))
                {
                    filteredList.Add(ev);
                }
            }
            return filteredList;
        }

        public bool IsTrueCriteria(Event ev, Event compare, string criteria)
        {
            switch (criteria)
            {
                case "=": return (ev.CompareTo(compare) == 0);
                case "!=": return !(ev.CompareTo(compare) == 0);
                case "<=": return (ev.CompareTo(compare) <= 0);
                case "<": return (ev.CompareTo(compare) < 0);
                case ">=": return (ev.CompareTo(compare) >= 0);
                case ">": return (ev.CompareTo(compare) > 0);
            }
            return false;
        }

    }
}
