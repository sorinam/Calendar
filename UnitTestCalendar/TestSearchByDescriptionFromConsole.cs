using System;
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
        public void ShouldListOnlyEventsWithSomeTitle()
        {
            Events newEvents = new Events {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two") },
        };

            List<Event> expectedList = new List<Event>
            {{ new Event ( "2015/01/01", "one", "test") },
            };
            string[] inputArgs = { "/search", "title", "=", "test" };
            SearchTitleArgument searchArgs = new SearchTitleArgument(inputArgs);
            string field = "";
            string op = "";
            string val1 = "";
            searchArgs.IsValid();
            field = searchArgs.Field;
            op = searchArgs.Criteria;
            val1 = searchArgs.Value;
            
            Events filteredList = Dispenser.SearchEvents(newEvents,field, op,new string[] { val1});

            Utils.AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void ShouldListOnlyEventsWithTitleContainingText()
        {
            Events newEvents = new Events {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15","two", "two cats") },
        };

            List<Event> expectedList = new List<Event>
            {{ new Event("2015/11/15","two", "two cats") },
            };
            string[] inputArgs = { "/search", "title", "contains", "two" };

            SearchTitleArgument searchArgs = new SearchTitleArgument(inputArgs);
            string field = "";
            string op = "";
            string val1 = "";
          
            searchArgs.IsValid();
            field = searchArgs.Field;
            op = searchArgs.Criteria;
            val1 = searchArgs.Value;
           
            Events filteredList = Dispenser.SearchEvents(newEvents,field, op, new String[] { val1 });
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
            SearchTitleArgument searchArgs = new SearchTitleArgument(inputArgs);
            string field = "";
            string op = "";
            string val1 = "";
           
            searchArgs.IsValid();
            field = searchArgs.Field;
            op = searchArgs.Criteria;
            val1 = searchArgs.Value;
         
            Events filteredList = Dispenser.SearchEvents(newEvents,field, op, new String[] { val1 });

            filteredList.ShouldBeEmpty();
        }

        [TestMethod]
        public void ShouldListEventsWithEmptyTitle()
        {
            Events newEvents = new Events {
                        { new Event ( "2015/01/01", "one", "test") },
                        {new Event("2015/11/15", "two") },
                };
            List<Event> expectedList = new List<Event>
            {{ new Event("2015/11/15","two") },
            };

            string[] inputArgs = { "/search", "title", "" };
            SearchTitleArgument searchArgs = new SearchTitleArgument(inputArgs);
            string field = "";
            string op = "";
            string val1 = "";
           
            searchArgs.IsValid();
            field = searchArgs.Field;
            op = searchArgs.Criteria;
            val1 = searchArgs.Value;
          
            Events filteredList = Dispenser.SearchEvents(newEvents,field, op, new String[] { val1 });

            Utils.AssertAreEqual(filteredList, expectedList);
        }
    }
}
