using System;

namespace Calendar
{
    public class DateFilter : Filter
    {
        string[] AcceptedOperators = { "=","!=", "<", ">", "<=", ">=", "<>" };
        Events eventsList = new Events();
        string criteria;
        string dateToCompare;

        public DateFilter(Events sourceList,string criteria,string dateToCompare)
            {
            SourceList = sourceList;
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

        public Events SourceList
        {
            get { return eventsList; }
            set { this.eventsList = value; }
        }
        public Events ApplyFilter()
        {
            Events filteredList = new Events();
            Event compare = new Event(dateToCompare, "", "");
            foreach (Event ev in eventsList)
            {
                if (IsTrueCriteria(ev,compare,criteria))
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
                case "=":
                    {
                        return (ev.CompareTo(compare) == 0);
                     }
                case "!=":
                    {
                        return !(ev.CompareTo(compare) == 0);
                    }
                case "<=":
                    {
                        return (ev.CompareTo(compare) <= 0);
                    }
                case "<":
                    {
                        return (ev.CompareTo(compare) <0);
                    }
                case ">=":
                    {
                        return (ev.CompareTo(compare) >= 0);
                    }
                case ">":
                    {
                        return (ev.CompareTo(compare) > 0);
                    }
            }
            return false;
        }
   }
}
