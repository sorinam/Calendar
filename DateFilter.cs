using System;

namespace Calendar
{
    public class DateFilter : Filter
    {
        string[] criteria = { "=","!=", "<", ">", "<=", ">=", "<>" };
        Events repo=new Events();

        public Events FilteredList
        {
            get { return repo; }
            set { this.repo = value; }
        }

        public void ApplyFilter(Events eventsList, string criteria, string dateValue)
        {
            Event compare = new Event(dateValue, "", "");
            foreach (Event ev in eventsList)
            {
                if (IsTrueCriteria(ev,compare,criteria))
                {
                    repo.Add(ev);
                }
            }
         }

        private bool IsTrueCriteria(Event ev, Event compare, string criteria)
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
