using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;
using Should;
using System.Linq;

namespace UnitTestCalendar
{
    [TestClass]
    public class TestTags
    {
        [TestMethod]
        public void SouldListEventsContainingTagInTitle()
        {            
                Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "one", "#tag Title","Description") },
                {new Event("2015/11/15", "two","title","desc") },
                {new Event("2015/11/15", "day","tag") }
            };

                TagFilter eventsToFilter = new TagFilter("=",new string[] { "tag" });
                Events filteredList = eventsToFilter.ApplyFilter(newEvents);
                List<Event> expectedList = new List<Event>
            {
                {new Event(  "2015/01/01", "one", "#tag Title","Description") }
            };

                Utils.AssertAreEqual(filteredList, expectedList);
            }

        [TestMethod]
        public void SouldListEventsContainingTagInDescription()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "one", "Title","@tag Description") },
                {new Event("2015/11/15", "two","title","Description") },
                {new Event("2015/11/15", "day","tag") }
            };

            TagFilter eventsToFilter = new TagFilter("=", new string[] { "tag" });
            Events filteredList = eventsToFilter.ApplyFilter(newEvents);
            List<Event> expectedList = new List<Event>
            {
                {new Event("2015/01/01", "one", "Title","@tag Description") }
            };

            Utils.AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void SouldNotListEventsNotContainingTag()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "one", "@day Title","#tag Description") },
                {new Event("2015/11/15", "two","title","Description") },
                {new Event("2015/11/15", "day","tag") }
            };

            TagFilter eventsToFilter = new TagFilter("=", new string[] { "days" });
            Events filteredList = eventsToFilter.ApplyFilter(newEvents);

            filteredList.ShouldBeEmpty();
        }
        [TestMethod]
        public void SouldListEventsNotContainingTag()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "one", "#day Title","#tag Description") },
                {new Event("2015/11/15", "two","title","Description") },
                {new Event("2015/11/15", "day","tag Title","#day Test") }
            };

            TagFilter eventsToFilter = new TagFilter("!=", new string[] { "tag" });
            Events filteredList = eventsToFilter.ApplyFilter(newEvents);

            List<Event> expectedList = new List<Event>
            {
                { new Event("2015/11/15", "two","title","Description") },
                {new Event("2015/11/15", "day","tag Title","#day Test") }
            };

            Utils.AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void SouldListEventsContainingDifferentTags()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "subj", "#tag title","description") },
                {new Event("2015/11/15", "subj","title","@desc") },
                {new Event("2015/11/15", "subj","tag") },
                {new Event("2015/11/15", "subj","#tag","#desc tag test" ) }
            };

            TagFilter eventsToFilter = new TagFilter("=", new string[] { "tag","desc" });
            List<Event> expectedList = new List<Event>
            {
                {new Event ( "2015/01/01", "subj", "#tag title","description") },
                {new Event("2015/11/15", "subj","title","@desc") },
                {new Event("2015/11/15", "subj","#tag","#desc tag test" ) }
            };

            Events filteredList = eventsToFilter.ApplyFilter(newEvents);

            Utils.AssertAreEqual(filteredList, expectedList);
        }
        [TestMethod]
        public void SouldListEventsContainingAllTagsFromPredicate()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "subj", "#tag title","description") },
                {new Event("2015/11/15", "subj","title","@desc") },
                {new Event("2015/11/15", "subj","tag") },
                {new Event("2015/11/15", "subj","#tag","#desc tag test" ) }
            };

            TagFilter eventsToFilter = new TagFilter("!=", new string[] { "ta", "des" });
            List<Event> expectedList = new List<Event>
            {
                {new Event("2015/11/15", "subj","#tag","#desc tag test" ) }
            };

            Events filteredList = eventsToFilter.ApplyFilter(newEvents);

            Utils.AssertAreEqual(filteredList, expectedList);
        }


    }
}

