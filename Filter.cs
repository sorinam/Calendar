using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public interface Filter
    {    
       void ApplyFilter(Events sourceList, string opeartor, string value);
    }
}
