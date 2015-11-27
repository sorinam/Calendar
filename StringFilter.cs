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
        string valueToCompare;

        public StringFilter(string criteria, string valueToCompare)
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

        public bool IsTrueCriteria(Event ev, string criteria)
        {
            switch (criteria)
            {
                case "=": return ((ev.Description == valueToCompare)||(ev.Title == valueToCompare));
                case "!=": return ((ev.Description != valueToCompare) || (ev.Title != valueToCompare));
                case ">": return ((ev.Description.Contains(valueToCompare)) || (ev.Title.Contains(valueToCompare)));
            }
            return false;
        }
    }
}
