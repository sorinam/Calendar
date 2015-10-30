using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using Should;
using System.IO;

namespace UnitTestCalendar
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ApplicationShouldNotAddEvent()
        {
            string date = "2015/15/20";
            string subject = "My birthday";
            string description = "It will be a wonderfull day...";
            Events newEvent = new Events();
            newEvent.AddEvent(date, subject,description);
            newEvent.Calendar.ShouldBeEmpty();
        }

        [TestMethod]
        public void ApplicationShouldAddEvent()
        {
            string date = "2015/11/20";
            string subject = "My birthday";
            string description = "It will be a wonderfull day...";
            Events newEvent = new Events();
            newEvent.AddEvent(date, subject, description);

            newEvent.Calendar[0].Date.ShouldEqual(Convert.ToDateTime(date));
            newEvent.Calendar[0].Subject.ShouldEqual(subject);
            newEvent.Calendar[0].Description.ShouldEqual(description);
        }

        [TestMethod]
        public void ApplicationShouldDisplayOneEvent()
        {
            string date = "2015/12/25";
            string subject = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";
            Events newEvent = new Events();
            newEvent.Calendar.ShouldBeEmpty();
            newEvent.AddEvent(date, subject,description);

            string expectedConsole = "Date:" + Convert.ToDateTime(date).ToShortDateString() + " \tEvent:" + subject+" \tDescription:"+description ;

            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);
            newEvent.DisplayAllEvents();
            consoleOut.ToString().ShouldContain(expectedConsole);
        }

        [TestMethod]
        public void ApplicationShouldNotDisplayEventForEmptyCalendar()
        {
            Events newEvent = new Events();
            newEvent.Calendar.ShouldBeEmpty();

            string expectedConsole = "";

            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);
            newEvent.DisplayAllEvents();
            consoleOut.ToString().ShouldContain(expectedConsole);
            
        }
        [TestMethod]
        public void DateTimeAddEvent()
        {
            string date = "2015/10/20";
            string subject = "My birthday";
            string description = "It will be a wonderfull day...";
            Events newEvent = new Events();
            newEvent.AddEvent(date, subject, description);

            newEvent.Calendar[0].Date.ShouldEqual(Convert.ToDateTime(date));
            int result = DateTime.Compare(DateTime.Today, newEvent.Calendar[0].Date);
            Assert.AreEqual(0, result);
        }
    }
}

