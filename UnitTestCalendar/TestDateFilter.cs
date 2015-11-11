using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using Should;
using System.Collections.Generic;

namespace UnitTestCalendar
{
    [TestClass]
    public class TestDateFilter
    {
        [TestMethod]
        public void ShouldSelectEventsFromSpecifiedDate()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two") },
                {new Event("2015/11/15", "three","test2") }
            };

            DateFilter eventsToFilter = new DateFilter("=", "2015/11/15");
            Events filteredList = eventsToFilter.ApplyFilter(newEvents);
            List <Event> expectedList =new List<Event> 
            {
                {new Event("2015/11/15", "two") },
                {new Event("2015/11/15", "three","test2") }
            };
            
            AssertAreEqual(filteredList,expectedList);

        }
        [TestMethod]
        public void ShouldSelectEventsFromSpecifiedPeriod()
        {
            Events newEvents = new Events {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two") },
                { new Event("2015/07/01", "three") },
                { new Event("2015/12/03", "four", "test1") },
                { new Event("2015/03/04", "five", "test2") },
                { new Event("2015/09/08", "six") }
        };

           List< Event> expectedList = new List <Event>
            {
                {new Event ("2015/07/01", "three") },
                { new Event("2015/03/04", "five", "test2")},
                { new Event("2015/09/08", "six") }
            };

            DateFilter firstFilter = new DateFilter("<", "2015/10/25");
            Events firstFilteredList = firstFilter.ApplyFilter((newEvents));
            DateFilter filteredListResult = new DateFilter(">", "2015/02/25");
            Events filteredList = filteredListResult.ApplyFilter(firstFilteredList);

            AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void ShouldSelectEventsDifferentFromSpecifiedDate()
        {
            Events newEvents = new Events {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two") },
                { new Event("2015/07/01", "three") },
                { new Event("2015/12/03", "four", "test1") },
                { new Event("2015/03/04", "five", "test2") },
                { new Event("2015/03/04", "six") }
        };

            List<Event> expectedList = new List<Event>
            {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two") },
                { new Event("2015/07/01", "three") },
                { new Event("2015/12/03", "four", "test1") },
            };

            DateFilter firstFilter = new DateFilter("!=", "2015/03/04");
            Events filteredList = firstFilter.ApplyFilter(newEvents);

            AssertAreEqual(filteredList, expectedList);
        }

        [TestMethod]
        public void ShouldBeEmptyWhenNoEventsFound()
        {
            Events newEvents = new Events {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two") },
                { new Event("2015/07/01", "three") },
                { new Event("2015/12/03", "four", "test1") },
                { new Event("2015/03/04", "five", "test2") },
                { new Event("2015/03/04", "six") }
        };

            Events expectedList = new Events();

            DateFilter firstFilter = new DateFilter("=", "2015/03/14");
            Events filteredList = firstFilter.ApplyFilter(newEvents);

            filteredList.ShouldBeEmpty();
        }

        private void AssertAreEqual(Events listofEvents, List <Event> expectedList)
        {
            listofEvents.Length.ShouldEqual(expectedList.Count);

            int i = 0;
            foreach (Event ev in listofEvents)
            {
                ev.Date.ShouldEqual(expectedList[i].Date);
                ev.Subject.ShouldEqual(expectedList[i].Subject);
                ev.Description.ShouldEqual(expectedList[i].Description);
                i++;
            }
        }
    }
}
