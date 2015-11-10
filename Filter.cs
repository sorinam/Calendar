using System;

namespace Calendar
{
    public interface Filter
    {
        Events SourceList
            {set;get;}
        String Criteria
        { set; }
        String ValueToCompare
        { set; }

        Events ApplyFilter();
        bool IsTrueCriteria(Event item, Event compareTo, string criteria);
    }
}
