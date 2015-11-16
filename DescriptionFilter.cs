namespace Calendar
{
    public class titleFilter : IFilter
    {
        string criteria;
        string valueToCompare;

        public titleFilter(string criteria, string valueToCompare)
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
                case "=":
                    {
                        return (ev.Title == valueToCompare);
                    }
                case "!=":
                    {
                        return (ev.Title != valueToCompare);
                    }
                case ">":
                    {
                        return (ev.Title.Contains(valueToCompare));
                    }
            }
            return false;
        }
    }
}
