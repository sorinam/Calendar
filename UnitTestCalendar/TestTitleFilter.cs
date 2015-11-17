using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;
using Should;

namespace UnitTestCalendar
{
    [TestClass]
    public class TesttitleFilter
    {
        [TestMethod]
        public void ShouldSelectEventsWithASpecifiedTitle()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two") },
                {new Event("2015/11/15", "three","test2") }
            };

            TitleFilter eventsToFilter = new TitleFilter("=", "test2");
            Events filteredList = eventsToFilter.ApplyFilter(newEvents);
            List<Event> expectedList = new List<Event>
            {
                {new Event("2015/11/15", "three","test2") }
            };

           Utils.AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void ShouldSelectEventsWithAnothertitle()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two","another") },
                {new Event("2015/11/15", "three","test2") }
            };

            TitleFilter eventsToFilter = new TitleFilter("!=", "another");
            Events filteredList = eventsToFilter.ApplyFilter(newEvents);
            List<Event> expectedList = new List<Event>
            {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "three","test2") }
            };

            Utils.AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void ShouldSelectEventsContainingSpecifiedtitle()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two") },
                {new Event("2015/11/15", "three","test2") }
            };

            TitleFilter eventsToFilter = new TitleFilter(">", "test");
            Events filteredList = eventsToFilter.ApplyFilter(newEvents);
            List<Event> expectedList = new List<Event>
            {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "three","test2") }
            };

            Utils.AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void ShouldSelectEventsWithSpecifiedtitleWhenThereAreAlmostEqual()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two","test1") },
                {new Event("2015/11/15", "three","test2") }
            };

            TitleFilter eventsToFilter = new TitleFilter("=", "test1");
            Events filteredList = eventsToFilter.ApplyFilter(newEvents);
            List<Event> expectedList = new List<Event>
            {
                { new Event("2015/11/15", "two","test1") },
            };

            Utils.AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void ShouldSelectNothingWhenSpecifiedtitleIsNotMatching()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two","test1") },
                {new Event("2015/11/15", "three","test2") }
            };

            TitleFilter eventsToFilter = new TitleFilter("=", "testul");
            Events filteredList = eventsToFilter.ApplyFilter(newEvents);
            filteredList.ShouldBeEmpty();
        }

    }
}
