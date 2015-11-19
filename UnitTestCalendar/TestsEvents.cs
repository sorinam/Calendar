using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;
using Should;
using System.Linq;

namespace UnitTestCalendar
{
    [TestClass]
    public class TestsEvents
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ShouldNotAddEvent()
        {
            string date = "2015/15/20";
            string title = "It will be a nice day...";
            Events newEvent = new Events();
            newEvent.Add(date, title);
        }

        [TestMethod]
        public void ShouldAddEvent()
        {
            string date = "2015/11/20";
            string title = "Party";
            string description = "in the evenening go to party";
            Events newEvent = new Events();
            List<Event> expectedList = new List<Event>
            { new Event(date, title,description) };

            newEvent.Add(date, title,description);
            var listofEvents = newEvent.EventsList;
            AssertAreEqual(listofEvents, expectedList);
        }

        [TestMethod]
        public void ShouldAddMoreEvents()
        {
            Events newEvent = new Events();

            string date = "2015/11/20";
            string title = "It will be a nice day...";

            newEvent.Add(date, title);

            string date1 = "2015/10/25";
            string title1 = "Don't forget to call her...";
            newEvent.Add(date1, title1);

            var listofEvents = newEvent.EventsList;

            List<Event> expectedList = new List<Event>
            { new Event(date, title),new Event(date1, title1) };

            AssertAreEqual(listofEvents, expectedList);
        }

        [TestMethod]
        public void ShouldAddEventWithoutDescription()
        {
            string date = "2015/11/20";
            string title = "My birthday";
            Events newEvent = new Events();

            newEvent.Add(date, title);
            var listofEvents = newEvent.EventsList;
            foreach (Event ev in listofEvents)
            {
                ev.Date.ShouldEqual(Convert.ToDateTime(date));
                ev.Title.ShouldEqual(title);
            }
        }

        [TestMethod]
        public void ShouldAddMultiLineEvent()
        {
            string date = "2015/11/20";
            string title = "My birthday";
            string description = "It will be a nice day...\n Nice party....\n....";
            Events newEvent = new Events();
            List<Event> expectedList = new List<Event>
            { new Event(date, title, description) };


            newEvent.Add(date, title, description);
            var listofEvents = newEvent.EventsList;

            AssertAreEqual(listofEvents, expectedList);
        }

        [TestMethod]
        public void ShouldParseEvents()
        {   Events newEvent = new Events();

            string date = "2015/11/20";
            string title = "My birthday";
            string description = "It will be a nice day...";
            newEvent.Add(date, title,description);

            string date1 = "2015/10/20";
            string title1= "Johana's Birtday!";
            string description1 = "Don't forget to call her...";
            newEvent.Add(date1, title1, description1);

            var listofEvents = newEvent.EventsList;
            string[] expectedList = {date+"\t"+ title +"\t"+ description , date1+ "\t"+ title1 +"\t"+ description1 };

            string[] parseEvents = newEvent.ToStringList();

            expectedList.ShouldEqual(parseEvents);
        }

        [TestMethod]
        public void ShouldParseEventWithoutDescription()
        {
            Events newEvent = new Events();

            string date = "2015/11/20";
            string title = "My birthday";
            string description = "It will be a nice day...";
            newEvent.Add(date,title, description);

            string date1 = "2015/10/20";
            string title1 = "Johana's Birtday!";
            newEvent.Add(date1, title1);

            var listofEvents = newEvent.EventsList;
            string[] expectedList = { date + "\t" + title + "\t" + description, date1 + "\t" + title1+"\t" };

            string[] parseEvents = newEvent.ToStringList();

            expectedList.ShouldEqual(parseEvents);
        }
      public static void AssertAreEqual(IEnumerable<Event> listofEvents, List<Event> expectedList)
        {
            int i = 0;
            foreach (Event ev in listofEvents)
            {
                ev.Date.ShouldEqual(expectedList[i].Date);
                ev.Title.ShouldEqual(expectedList[i].Title);
                ev.Description.ShouldEqual(expectedList[i].Description);
                i++;
            }
        }

       
    }
}
