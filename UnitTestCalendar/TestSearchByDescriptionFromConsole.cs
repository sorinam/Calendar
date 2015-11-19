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
            string[] inputArgs = { "/search", "description", "=", "test" };
            SearchDescriptionArgument searchArgs = new SearchDescriptionArgument(inputArgs);
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

            SearchDescriptionArgument searchArgs = new SearchDescriptionArgument(inputArgs);
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
            SearchDescriptionArgument searchArgs = new SearchDescriptionArgument(inputArgs);
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
        public void ShouldListEventsWithEmptyDescription()
        {
            Events newEvents = new Events {
                        { new Event ( "2015/01/01", "one", "test") },
                        {new Event("2015/11/15", "two") },
                };
            List<Event> expectedList = new List<Event>
            {{ new Event("2015/11/15","two") },
            };

            string[] inputArgs = { "/search", "title", "" };
            SearchDescriptionArgument searchArgs = new SearchDescriptionArgument(inputArgs);
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
