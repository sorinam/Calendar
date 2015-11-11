using System;

namespace Calendar
{
    public interface IFilter
    {
        Events ApplyFilter(Events sourceList);
    }
}
