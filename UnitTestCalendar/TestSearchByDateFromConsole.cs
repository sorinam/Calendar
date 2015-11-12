using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;
using Should;
using System.IO;

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
            string[] inputArgs = { "/search", "date", "=", "2015/01/01" };

            Events filteredList = Dispenser.SearchAndExport(inputArgs, newEvents);

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
            string[] inputArgs = { "/search", "date", "=", "2015/01/01", "/export","test.html"};

            Events filteredList = Dispenser.SearchAndExport(inputArgs, newEvents);

            Utils.AssertAreEqual(filteredList, expectedList);
            File.Exists(@"test.html)");
        }
        [TestMethod]
        public void ShouldListEventsFromToday()
        {
            Events newEvents = new Events {
                { new Event ( "2015/11/11", "one", "test") },
                {new Event(DateTime.Now.ToShortDateString(),"today","today test") }
        };

            List<Event> expectedList = new List<Event>
            {{new Event(DateTime.Now.ToShortDateString(),"today","today test") }
            };
            string[] inputArgs = { "/search", "date", "today" };
            Events filteredList = Dispenser.GetFilteredListByDate(newEvents, ref inputArgs);

            Utils.AssertAreEqual(filteredList, expectedList);

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
            string[] inputArgs = { "/search", "date","<>","2015/09/01", "2015/10/30" };
            Events filteredList = Dispenser.GetFilteredListByDate(newEvents, ref inputArgs);

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

            Events filteredList = Dispenser.GetFilteredListByDate(newEvents, ref inputArgs);

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
            string[] inputArgs = { "/search", "date", "older", "2015/10/01" };

            Events filteredList = Dispenser.GetFilteredListByDate(newEvents, ref inputArgs);

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
            string[] inputArgs = { "/search", "date", ">", "2015/10/01" };

            Events filteredList = Dispenser.GetFilteredListByDate(newEvents, ref inputArgs);

            Utils.AssertAreEqual(filteredList, expectedList);
        }
    }
}

