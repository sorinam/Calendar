using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;
using Should;

namespace UnitTestCalendar
{
    [TestClass]
    public class TestDescriptionFilter
    {
        [TestMethod]
        public void ShouldSelectEventsWithASpecifiedDescription()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two") },
                {new Event("2015/11/15", "three","test2") }
            };

            DescriptionFilter eventsToFilter = new DescriptionFilter("=", "test2");
            Events filteredList = eventsToFilter.ApplyFilter(newEvents);
            List<Event> expectedList = new List<Event>
            {
                {new Event("2015/11/15", "three","test2") }
            };

           Utils.AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void ShouldSelectEventsWithAnotherDescription()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two","another") },
                {new Event("2015/11/15", "three","test2") }
            };

            DescriptionFilter eventsToFilter = new DescriptionFilter("!=", "another");
            Events filteredList = eventsToFilter.ApplyFilter(newEvents);
            List<Event> expectedList = new List<Event>
            {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "three","test2") }
            };

            Utils.AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void ShouldSelectEventsContainingSpecifiedDescription()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two") },
                {new Event("2015/11/15", "three","test2") }
            };

            DescriptionFilter eventsToFilter = new DescriptionFilter(">", "test");
            Events filteredList = eventsToFilter.ApplyFilter(newEvents);
            List<Event> expectedList = new List<Event>
            {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "three","test2") }
            };

            Utils.AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void ShouldSelectEventsWithSpecifiedDescriptionWhenThereAreAlmostEqual()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two","test1") },
                {new Event("2015/11/15", "three","test2") }
            };

            DescriptionFilter eventsToFilter = new DescriptionFilter("=", "test1");
            Events filteredList = eventsToFilter.ApplyFilter(newEvents);
            List<Event> expectedList = new List<Event>
            {
                { new Event("2015/11/15", "two","test1") },
            };

            Utils.AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void ShouldSelectNothingWhenSpecifiedDescriptionIsNotMatching()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two","test1") },
                {new Event("2015/11/15", "three","test2") }
            };

            DescriptionFilter eventsToFilter = new DescriptionFilter("=", "testul");
            Events filteredList = eventsToFilter.ApplyFilter(newEvents);
            filteredList.ShouldBeEmpty();
        }

    }
}
