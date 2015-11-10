using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class DateFilter : Filter
    {
        string[] criteria = { "=", "<", ">", "<=", ">=", "<>" };
        Events repo=new Events();

        public Events FilteredList
        {
            get { return repo; }
            set { this.repo = value; }
        }

        public void ApplyFilter(Events eventsList, string criteria, string value)
        {
            switch (criteria)
            {
                case "=":
                    {
                        Equal(eventsList, value);
                        break;
                    }
                case "<=":
                    {
                        EqualOrLessThan(eventsList, value);
                        break;
                    }
                case "<":
                    {
                        LessThan(eventsList, value);
                        break;
                    }
                case ">=":
                    {
                        EqualOrGreaterThan(eventsList, value);
                        break;
                    }
            }
           
                    }

        private void  Equal(Events sourceList, string dateValue)
        {
            Event compare = new Event(dateValue, "", "");
            foreach (Event ev in sourceList)
            {
                if (ev.CompareTo(compare) == 0)
                {
                    repo.Add(ev);
                }
            }
         }
        private void LessThan(Events sourceList, string dateValue)
        {
            Event compare = new Event(dateValue, "", "");
            foreach (Event ev in sourceList)
            {
                if (ev.CompareTo(compare) < 0)
                {
                    repo.Add(ev);
                }
            }
        }
        private void EqualOrLessThan(Events sourceList, string dateValue)
        {
            Event compare = new Event(dateValue, "", "");
            foreach (Event ev in sourceList)
            {
                if (ev.CompareTo(compare) <= 0)
                {
                    repo.Add(ev);
                }
            }
        }
        private void EqualOrGreaterThan(Events sourceList, string dateValue)
        {
            Event compare = new Event(dateValue, "", "");
            foreach (Event ev in sourceList)
            {
                if (ev.CompareTo(compare) >= 0)
                {
                    repo.Add(ev);
                }
            }
        }
    }
}
