using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;
using Should;


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
            List<Event> expectedList = new List<Event>
            { new Event(date, subject, description) };

            newEvent.Add(date, subject, description);
            var listofEvents = newEvent.EventsList;
            AssertAreEqual(listofEvents, expectedList);
        }

        [TestMethod]
        public void ShouldAddMoreEvents()
        {
            Events newEvent = new Events();

            string date = "2015/11/20";
            string subject = "My birthday";
            string description = "It will be a nice day...";

            newEvent.Add(date, subject, description);

            string date1 = "2015/10/25";
            string subject1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";
            newEvent.Add(date1, subject1, description1);

            var listofEvents = newEvent.EventsList;

            List<Event> expectedList = new List<Event>
            { new Event(date, subject, description),new Event(date1, subject1, description1) };

            AssertAreEqual(listofEvents, expectedList);
        }

        [TestMethod]
        public void ShouldAddEventWithoutDescription()
        {
            string date = "2015/11/20";
            string subject = "My birthday";
            Events newEvent = new Events();

            newEvent.Add(date, subject);
            var listofEvents = newEvent.EventsList;
            foreach (Event ev in listofEvents)
            {
                ev.Date.ShouldEqual(Convert.ToDateTime(date));
                ev.Subject.ShouldEqual(subject);
            }
        }

        [TestMethod]
        public void ShouldAddMultiLineEvent()
        {
            string date = "2015/11/20";
            string subject = "My birthday";
            string description = "It will be a nice day...\n Nice party....\n....";
            Events newEvent = new Events();
            List<Event> expectedList = new List<Event>
            { new Event(date, subject, description) };


            newEvent.Add(date, subject, description);
            var listofEvents = newEvent.EventsList;

            AssertAreEqual(listofEvents, expectedList);
        }

        [TestMethod]
        public void ShouldParseEvents()
        {   Events newEvent = new Events();

            string date = "2015/11/20";
            string subject = "My birthday";
            string description = "It will be a nice day...";
            newEvent.Add(date, subject, description);

            string date1 = "2015/10/20";
            string subject1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";
            newEvent.Add(date1, subject1, description1);

            var listofEvents = newEvent.EventsList;
            string[] expectedList = {date+"\t"+ subject +"\t"+ description , date1+ "\t"+ subject1 +"\t"+ description1 };

            string[] parseEvents = newEvent.ToStringList();

            expectedList.ShouldEqual(parseEvents);
        }

        [TestMethod]
        public void ShouldParseEventWithoutDescription()
        {
            Events newEvent = new Events();

            string date = "2015/11/20";
            string subject = "My birthday";
            string description = "It will be a nice day...";
            newEvent.Add(date, subject, description);

            string date1 = "2015/10/20";
            string subject1 = "Johana's Birtday!";
            newEvent.Add(date1, subject1);

            var listofEvents = newEvent.EventsList;
            string[] expectedList = { date + "\t" + subject + "\t" + description, date1 + "\t" + subject1+"\t" };

            string[] parseEvents = newEvent.ToStringList();

            expectedList.ShouldEqual(parseEvents);
        }
      public static void AssertAreEqual(IEnumerable<Event> listofEvents, List<Event> expectedList)
        {
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
