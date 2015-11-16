﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;
using Should;

namespace UnitTestCalendar
{
    [TestClass]
    public class TestSearchBytitleFromConsole
    {
        [TestMethod]
        public void ShouldListOnlyEventsWithSometitle()
        {
            Events newEvents = new Events {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two") },
        };

            List<Event> expectedList = new List<Event>
            {{ new Event ( "2015/01/01", "one", "test") },
            };
            string[] inputArgs = { "/search", "title", "=", "test" };
            SearchArgument searchArgs = new SearchArgument(inputArgs);
            string field = "";
            string op = "";
            string val1 = "";
            string val2 = "";
            searchArgs.IsValid();
            field = searchArgs.Field;
            op = searchArgs.Criteria;
            val1 = searchArgs.Value;
            val2 = searchArgs.AnotherValue;

            Events filteredList = Dispenser.SearchEvents(newEvents,field, op, val1, val2);

            Utils.AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void ShouldListOnlyEventsWithtitleContainingText()
        {
            Events newEvents = new Events {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15","two", "two cats") },
        };

            List<Event> expectedList = new List<Event>
            {{ new Event("2015/11/15","two", "two cats") },
            };
            string[] inputArgs = { "/search", "title", "contains", "two" };

            SearchArgument searchArgs = new SearchArgument(inputArgs);
            string field = "";
            string op = "";
            string val1 = "";
            string val2 = "";
            searchArgs.IsValid();
            field = searchArgs.Field;
            op = searchArgs.Criteria;
            val1 = searchArgs.Value;
            val2 = searchArgs.AnotherValue;

            Events filteredList = Dispenser.SearchEvents(newEvents,field, op, val1, val2);
            Utils.AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void ShouldNotListEventsWithSometitle()
        {
            Events newEvents = new Events {
                        { new Event ( "2015/01/01", "one", "test") },
                        {new Event("2015/11/15", "two cats") },
                };

            string[] inputArgs = { "/search", "title", "contains", "pair" };
            SearchArgument searchArgs = new SearchArgument(inputArgs);
            string field = "";
            string op = "";
            string val1 = "";
            string val2 = "";
            searchArgs.IsValid();
            field = searchArgs.Field;
            op = searchArgs.Criteria;
            val1 = searchArgs.Value;
            val2 = searchArgs.AnotherValue;

            Events filteredList = Dispenser.SearchEvents(newEvents,field, op, val1, val2);

            filteredList.ShouldBeEmpty();
        }

        [TestMethod]
        public void ShouldListEventsWithEmptytitle()
        {
            Events newEvents = new Events {
                        { new Event ( "2015/01/01", "one", "test") },
                        {new Event("2015/11/15", "two") },
                };
            List<Event> expectedList = new List<Event>
            {{ new Event("2015/11/15","two") },
            };

            string[] inputArgs = { "/search", "title", "" };
            SearchArgument searchArgs = new SearchArgument(inputArgs);
            string field = "";
            string op = "";
            string val1 = "";
            string val2 = "";
            searchArgs.IsValid();
            field = searchArgs.Field;
            op = searchArgs.Criteria;
            val1 = searchArgs.Value;
            val2 = searchArgs.AnotherValue;

            Events filteredList = Dispenser.SearchEvents(newEvents,field, op, val1, val2);

            Utils.AssertAreEqual(filteredList, expectedList);
        }
    }
}
