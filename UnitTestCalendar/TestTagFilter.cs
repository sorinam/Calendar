using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;

namespace UnitTestCalendar
{
    [TestClass]
    public class TestTagFilter
    {
        [TestMethod]
        public void SouldListEventsContainingTagInTitle()
        {            
                Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "#tag Title","Description") },
                {new Event("2015/11/15", "title","desc") },
                {new Event("2015/11/15","tag") }
            };

                StringFilter eventsToFilter = new StringFilter("||",new string[] { "tag" });
            
                List<Event> expectedList = new List<Event>
            {
                {new Event(  "2015/01/01", "#tag Title","Description") }
            };
          
            Events filteredList = eventsToFilter.ApplyFilter(newEvents, "tag");

            Utils.AssertAreEqual(filteredList, expectedList);
            }

        [TestMethod]
        public void SouldListEventsContainingTagInDescription()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01","Title","@tag Description") },
                {new Event("2015/11/15", "title","Description") },
                {new Event("2015/11/15", "tag") }
            };

            StringFilter eventsToFilter = new StringFilter("||", new string[] { "tag" });
            Events filteredList = eventsToFilter.ApplyFilter(newEvents, "tag");
            List<Event> expectedList = new List<Event>
            {
                {new Event("2015/01/01", "Title","@tag Description") }
            };

            Utils.AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void SouldListEventsContainingDifferentTags()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "#tag title","description") },
                {new Event("2015/11/15", "title","@desc") },
                {new Event("2015/11/15","tag") },
                {new Event("2015/11/15", "#tag","#desc tag test" ) }
            };

            StringFilter eventsToFilter = new StringFilter("||", new string[] { "tag","desc" });
            List<Event> expectedList = new List<Event>
            {
                {new Event ( "2015/01/01", "#tag title","description") },
                {new Event("2015/11/15", "title","@desc") },
                {new Event("2015/11/15","#tag","#desc tag test" ) }
            };

            Events filteredList = eventsToFilter.ApplyFilter(newEvents, "tag");

            Utils.AssertAreEqual(filteredList, expectedList);
        }
        [TestMethod]
        public void SouldListEventsContainingAllTagsFromPredicate()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "#tag title","description") },
                {new Event("2015/11/15", "title","@desc") },
                {new Event("2015/11/15","tag","@Ioana") },
                {new Event("2015/11/15", "#tag","#desc tag @Ioana test" ) }
            };

            StringFilter eventsToFilter = new StringFilter("&&", new string[] { "tag", "Ioana" });
            List<Event> expectedList = new List<Event>
            {
                {new Event("2015/11/15", "#tag","#desc tag @Ioana test" ) }
            };

            Events filteredList = eventsToFilter.ApplyFilter(newEvents, "tag");

            Utils.AssertAreEqual(filteredList, expectedList);
        }
 
    }
}

