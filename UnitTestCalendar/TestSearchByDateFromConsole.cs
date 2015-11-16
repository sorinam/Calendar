using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;
using Should;
using System.IO;
using System.Globalization;

namespace UnitTestCalendar
{
    [TestClass]
    public class TestSearchByDateFromConsole
    {
        [TestMethod]
        public void ShouldListOnlyEventsFromSpecifiedDate()
        {
            Events newEvents = new Events {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two") },
        };

            List<Event> expectedList = new List<Event>
            {{ new Event ( "2015/01/01", "one", "test") },
            };

            Events filteredList = Dispenser.SearchEvents(newEvents, "date", "=", "2015/01/01", null);

            Utils.AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void ShouldListAndExportOnlyEventsFromSpecifiedDate()
        {
            Events newEvents = new Events {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two") },
        };

            List<Event> expectedList = new List<Event>
            {{ new Event ( "2015/01/01", "one", "test") },
            };
            string[] inputArgs = { "/search", "date", "=", "2015/01/01", "/export", "test.html" };

            Events filteredList = Dispenser.SearchEvents(newEvents,"date", "=", "2015/01/01", "");

            Utils.AssertAreEqual(filteredList, expectedList);
            File.Exists(@"test.html)");
        }


        [TestMethod]
        public void ShouldListEventsFromSpecifiedPeriod()
        {
            Events newEvents = new Events {
                { new Event ( "2015/10/11", "one", "test") },
                {new Event(DateTime.Now.ToShortDateString(),"today","today test") }
        };

            List<Event> expectedList = new List<Event> {
            {new Event ( "2015/10/11", "one", "test") }
            };

            Events filteredList = Dispenser.GetFilteredListByDate(newEvents, "<>", "2015/09/01", "2015/10/30");

            Utils.AssertAreEqual(filteredList, expectedList);

        }

        [TestMethod]
        public void ShouldNotListEventsFromSpecifiedDate()
        {
            Events newEvents = new Events {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two") },
        };

            string[] inputArgs = { "/search", "date", "=", "2015/10/01" };

            Events filteredList = Dispenser.GetFilteredListByDate(newEvents, "=", "2015/10/01", "");

            filteredList.ShouldBeEmpty();
        }

        [TestMethod]
        public void ShouldListOlderEventsFromSpecifiedDate()
        {
            Events newEvents = new Events {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two") },
        };

            List<Event> expectedList = new List<Event>
            {{ new Event ( "2015/01/01", "one", "test") },
            };
            Events filteredList = Dispenser.GetFilteredListByDate(newEvents, "older", "2015/09/01", "");

            Utils.AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void ShouldListNewerEventsFromSpecifiedDate()
        {
            Events newEvents = new Events {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two") },
        };

            List<Event> expectedList = new List<Event>
            {{ new Event("2015/11/15", "two") },
            };

            Events filteredList = Dispenser.GetFilteredListByDate(newEvents, ">", "2015/10/01", "");

            Utils.AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void ShouldListEventsFromThisWeek()
        {
            Events newEvents = new Events
            {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event(DateTime.Today.ToShortDateString(), "two") },
            };

            List<Event> expectedList = new List<Event>
            {{ new Event (DateTime.Today.ToShortDateString(),"two") },
            };

            string[] args = { "/search", "date", "this week" };
            SearchDateArgument searchArgs = new SearchDateArgument(args);
            string field = "";
            string op = "";
            string val1 = "";
            string val2 = "";
            searchArgs.IsValid();
            field = searchArgs.Field;
            op = searchArgs.Criteria;
            val1 = searchArgs.Date;
            val2 = searchArgs.AnotherDate;

            Events filteredList = Dispenser.SearchEvents(newEvents,field, op, val1, val2);
            Utils.AssertAreEqual(filteredList, expectedList);

        }
    }
}


