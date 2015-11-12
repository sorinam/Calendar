using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;

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
            string[] inputArgs = { "/search", "date", "=", "2015/01/01)" };

            Events filteredList = Selector.GetFilteredListByDate(newEvents, inputArgs);

            Utils.AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void ShouldListAndExportOnlyEventsFromSpecifiedDate()
        {
            Events newEvents = new Events {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/11", "two") },
        };

            List<Event> expectedList = new List<Event>
            {{ new Event ( "2015/01/01", "one", "test") },
            };
            string[] inputArgs = { "/search", "date", "=", "2015/11/11)" ,"/export" ,"test.html"};
            Events result = new Events();
           // Events filteredList = Selector.NewMethod(inputArgs, newEvents, result);

            //Utils.AssertAreEqual(filteredList, expectedList);
        }
    }
}

