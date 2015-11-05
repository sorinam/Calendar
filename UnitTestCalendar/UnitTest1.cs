using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;
using Should;

namespace UnitTestCalendar
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ShouldNotAddEvent()
        {
            string date = "2015/15/20";
            string subject = "My birthday";
            string description = "It will be a nice day...";
            Events newEvent = new Events();
            newEvent.Add(date, subject, description);
        }

        [TestMethod]
        public void ShouldAddEvent()
        {
            string date = "2015/11/20";
            string subject = "My birthday";
            string description = "It will be a nice day...";
            Events newEvent = new Events();

            newEvent.Add(date, subject, description);
            List<Event> listofEvents = newEvent.EventsList;

            listofEvents[0].Date.ShouldEqual(Convert.ToDateTime(date));
            listofEvents[0].Subject.ShouldEqual(subject);
            listofEvents[0].Description.ShouldEqual(description);
        }

        [TestMethod]
        public void ShouldAddEventWithoutDescription()
        {
            string date = "2015/11/20";
            string subject = "My birthday";
            Events newEvent = new Events();

            newEvent.Add(date, subject);
            List<Event> listofEvents = newEvent.EventsList;

            listofEvents[0].Date.ShouldEqual(Convert.ToDateTime(date));
            listofEvents[0].Subject.ShouldEqual(subject);
        }

        [TestMethod]
        public void ShouldAddMultiLineEvent()
        {
            string date = "2015/11/20";
            string subject = "My birthday";
            string description = "It will be a nice day...\n Nice party....\n....";
            Events newEvent = new Events();

            newEvent.Add(date, subject, description);
            List<Event> listofEvents = newEvent.EventsList;

            listofEvents[0].Date.ShouldEqual(Convert.ToDateTime(date));
            listofEvents[0].Subject.ShouldEqual(subject);
            listofEvents[0].Description.ShouldEqual(description);
        }

        [TestMethod]
        public void ShouldSortEvents()
        {
            Events newEvent = new Events();

            string date = "2015/11/20";
            string subject = "My birthday";
            string description = "It will be a nice day...\n Nice party....\n....";
            newEvent.Add(date, subject, description);

            date = "2015/10/20";
            subject = "Joana's birthday";
            newEvent.Add(date, subject);

            List<Event> expectedList = new List<Event>{
                new Event ("2015/10/20","Joana's birthday"),
                new Event("2015/11/20", "My birthday", "It will be a nice day...\n Nice party....\n....")};

            List<Event> listofEvents = newEvent.EventsList;
            listofEvents.Sort();

            expectedList.ShouldEqual(listofEvents);
        }
    }
}
