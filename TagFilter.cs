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

        public TagFilter( string criteria,string[] valueToCompare)
        {
            this.valueToCompare = valueToCompare;
            this.criteria=criteria;
        }

        public Events ApplyFilter(Events sourceList)
        {
            Events filteredList = new Events();

            foreach (Event ev in sourceList)
            {
                if (IsTrueCriteria(ev,criteria))
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
                case "=":
                    return ContainsAnyTag(ev, valueToCompare);
                case "!=":
                    return !ContainsAnyTag(ev, valueToCompare);
                default: return false;
            }

        }
        private bool ContainsAnyTag(Event ev, string[] tagValues)
        {
            return tagValues.Any(tag => ContainsTag(ev,tag)) ;
        }

        private bool ContainsTag(Event ev,string value)
        {
            string[] tag = new string[] { "#" + value, "@" + value };
          
            return tag.Any(c => ev.Title.Contains(c)) || (tag.Any(c => ev.Description.Contains(c)));
        }
    }
}
