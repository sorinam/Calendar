namespace Calendar
{
    public class DescriptionFilter : IFilter
    {
        string criteria;
        string valueToCompare;

        public DescriptionFilter(string criteria, string valueToCompare)
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
                case "=": return ev.Description == valueToCompare;
                case "!=": return ev.Description != valueToCompare;
                case ">": return ev.Description.Contains(valueToCompare);
            }

            return false;
        }
    }
}
