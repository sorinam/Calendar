using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;
using Should;

namespace UnitTestCalendar
{
    //[TestClass]
    //public class TestSearchByDescriptionFromConsole
    //{
    //    [TestMethod]
    //    public void ShouldListOnlyEventsWithSomeDescription()
    //    {
    //        Events newEvents = new Events {
    //            { new Event ( "2015/01/01", "one", "test") },
    //            {new Event("2015/11/15", "two") },
    //    };

    //        List<Event> expectedList = new List<Event>
    //        {{ new Event ( "2015/01/01", "one", "test") },
    //        };
    //        string[] inputArgs = { "/search", "description", "=", "test" };

    //        Events filteredList = Dispenser.GetFilteredListByDescription(newEvents, inputArgs);

    //        Utils.AssertAreEqual(filteredList, expectedList);
    //    }

    //    [TestMethod]
    //    public void ShouldListOnlyEventsWithDescriptionContainingText()
    //    {
    //        Events newEvents = new Events {
    //            { new Event ( "2015/01/01", "one", "test") },
    //            {new Event("2015/11/15","two", "two cats") },
    //    };

    //        List<Event> expectedList = new List<Event>
    //        {{ new Event("2015/11/15","two", "two cats") },
    //        };
    //        string[] inputArgs = { "/search", "description", "contains", "two" };

    //        Events filteredList = Dispenser.GetFilteredListByDescription(newEvents, inputArgs);

    //        Utils.AssertAreEqual(filteredList, expectedList);
    //    }

    //    [TestMethod]
    //    public void ShouldNotListEventsWithSomeDescription()
    //    {
    //        Events newEvents = new Events {
    //            { new Event ( "2015/01/01", "one", "test") },
    //            {new Event("2015/11/15", "two cats") },
    //    };

    //        string[] inputArgs = { "/search", "description", "contains", "pair" };

    //        Events filteredList = Dispenser.GetFilteredListByDescription(newEvents, inputArgs);

    //        filteredList.ShouldBeEmpty();
    //    }
    //}
}
