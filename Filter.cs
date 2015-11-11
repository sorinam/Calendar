using System;

namespace Calendar
{
    public interface Filter
    {
        Events ApplyFilter(Events sourceList);
    }
}
