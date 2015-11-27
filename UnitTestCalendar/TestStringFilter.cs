using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;

namespace UnitTestCalendar
{
    [TestClass]
    public class StringFilter
    {
        [TestMethod]
        public void ShouldListAllItemsContainsAStringInTitleOrDescription()
        {  Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "#tag"," title description") },
                {new Event("2015/11/15", "title","@desc") },
                {new Event("2015/11/15","tag","@Ioana") },
                {new Event("2015/11/15", "#tag","#desc tag @Ioana test" ) }
            };

            Calendar.StringFilter eventsToFilter = new Calendar.StringFilter("||",new string[] { "title" } );
            List<Event> expectedList = new List<Event>
            {   {new Event ( "2015/01/01", "#tag"," title description") },
                {new Event("2015/11/15", "title","@desc") }
            };

            Events filteredList = eventsToFilter.ApplyFilter(newEvents);

            Utils.AssertAreEqual(filteredList, expectedList);
        }

    }
}

