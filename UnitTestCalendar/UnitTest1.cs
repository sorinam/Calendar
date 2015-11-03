using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using Should;
using System.IO;
using System.Collections.Generic;

namespace UnitTestCalendar
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ApplicationShouldNotAddEvent()
        {
            string date = "2015/15/20";
            string subject = "My birthday";
            string description = "It will be a wonderfull day...";
            Events newEvent = new Events();
            newEvent.AddEvent(date, subject, description);
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
        public void ApplicationShouldAddEventWithoutDescription()
        {
            string date = "2015/11/20";
            string subject = "My birthday";
            Events newEvent = new Events();
            newEvent.AddEvent(date, subject);

            newEvent.Calendar[0].Date.ShouldEqual(Convert.ToDateTime(date));
            newEvent.Calendar[0].Subject.ShouldEqual(subject);
        }

        [TestMethod]
        public void ApplicationShouldAddMultiLineEvent()
        {
            string date = "2015/11/20";
            string subject = "My birthday";
            string description = "It will be a wonderfull day...\n Nice party....\n....";
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
            newEvent.AddEvent(date, subject, description);

            string expectedConsole = "Date:" + Convert.ToDateTime(date).ToShortDateString() + " \tEvent:" + subject + " \tDescription:" + description;

            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);
            newEvent.DisplayEvents("all");
            consoleOut.ToString().ShouldContain(expectedConsole);
        }
        [TestMethod]
        public void ApplicationShouldDisplayMulytiLineOneEvent()
        {
            string date = "2015/12/25";
            string subject = "Christmas \n Day!";
            string description = "Santa Claus is comming in our house....\n";
            Events newEvent = new Events();
            newEvent.Calendar.ShouldBeEmpty();
            newEvent.AddEvent(date, subject, description);

            string expectedConsole = "Date:" + Convert.ToDateTime(date).ToShortDateString() + " \tEvent:" + subject + " \tDescription:" + description;

            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);
            newEvent.DisplayEvents("all");
            consoleOut.ToString().ShouldContain(expectedConsole);
        }
        [TestMethod]
        public void ApplicationShouldDisplayOneEventWithoutDescription()
        {
            string date = "2015/12/25";
            string subject = "Christmas Day!";
            Events newEvent = new Events();
            newEvent.Calendar.ShouldBeEmpty();
            newEvent.AddEvent(date, subject);

            string expectedConsole = "Date:" + Convert.ToDateTime(date).ToShortDateString() + " \tEvent:" + subject;

            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);
            newEvent.DisplayEvents("all");
            consoleOut.ToString().ShouldContain(expectedConsole);
        }
        [TestMethod]
        public void ApplicationShouldDisplayAllEvents()
        {
            string date = "2015/12/25";
            string subject = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";
            Events newEvent = new Events();
            newEvent.Calendar.ShouldBeEmpty();
            newEvent.AddEvent(date, subject, description);
            string date1 = "2015/10/25";
            string subject1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";
            newEvent.AddEvent(date1, subject1, description1);

            string expectedConsole = "Date:" + Convert.ToDateTime(date1).ToShortDateString() + " \tEvent:" + subject1 + " \tDescription:" + description1 + "\n" +
                "Date:" + Convert.ToDateTime(date).ToShortDateString() + " \tEvent:" + subject + " \tDescription:" + description;

            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);
            newEvent.DisplayEvents("all");
            consoleOut.ToString().ShouldContain(expectedConsole);
        }

        [TestMethod]
        public void ApplicationShouldDisplayPastEvents()
        {
            string date = "2019/12/25";
            string subject = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";
            Events newEvent = new Events();
            newEvent.Calendar.ShouldBeEmpty();
            newEvent.AddEvent(date, subject, description);
            string date1 = "2015/10/25";
            string subject1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";
            newEvent.AddEvent(date1, subject1, description1);

            string expectedConsole = "Date:" + Convert.ToDateTime(date1).ToShortDateString() + " \tEvent:" + subject1 + " \tDescription:" + description1 + "\n";

            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);
            newEvent.DisplayEvents("past");

            consoleOut.ToString().ShouldContain(expectedConsole);

        }

        [TestMethod]
        public void ApplicationShouldDisplayFutureEvents()
        {
            string date = "2019/12/25";
            string subject = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";
            Events newEvent = new Events();
            newEvent.Calendar.ShouldBeEmpty();
            newEvent.AddEvent(date, subject, description);
            string date1 = "2015/10/25";
            string subject1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";
            newEvent.AddEvent(date1, subject1, description1);

            string expectedConsole = "Date:" + Convert.ToDateTime(date).ToShortDateString() + " \tEvent:" + subject + " \tDescription:" + description + "\n";

            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);
            newEvent.DisplayEvents("future");

            consoleOut.ToString().ShouldContain(expectedConsole);

        }

        [TestMethod]
        public void ApplicationShouldNotDisplayEventsForInvalidListParameter()
        {
            string date = "2019/12/25";
            string subject = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";
            Events newEvent = new Events();
            newEvent.Calendar.ShouldBeEmpty();
            newEvent.AddEvent(date, subject, description);
            string date1 = "2015/10/25";
            string subject1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";
            newEvent.AddEvent(date1, subject1, description1);

            string expectedConsole = "";

            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);
            consoleOut.ToString().ShouldBeEmpty();

            newEvent.DisplayEvents("fture");
            consoleOut.ToString().ShouldEqual(expectedConsole);

        }

        [TestMethod]
        public void ApplicationShouldDisplaySortedEvents()
        {
            string date = "2015/12/25";
            string subject = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";
            Events newEvent = new Events();
            newEvent.Calendar.ShouldBeEmpty();
            newEvent.AddEvent(date, subject, description);

            string date1 = "2015/10/25";
            string subject1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";
            newEvent.AddEvent(date1, subject1, description1);

            string date2 = "2015/11/25";
            string subject2 = "John's Birtday!";
            string description2 = "Don't forget to call him...";
            newEvent.AddEvent(date2, subject2, description2);

            string date3 = "2015/10/25";
            string subject3 = "Tim's Birtday!";
            string description3 = "Don't forget to call him...";
            newEvent.AddEvent(date3, subject3, description3);

            string expectedConsole = "Date:" + Convert.ToDateTime(date1).ToShortDateString() + " \tEvent:" + subject1 + " \tDescription:" + description1 + "\n" +
                "Date:" + Convert.ToDateTime(date3).ToShortDateString() + " \tEvent:" + subject3 + " \tDescription:" + description3 + "\n" +
                "Date:" + Convert.ToDateTime(date2).ToShortDateString() + " \tEvent:" + subject2 + " \tDescription:" + description2 + "\n" +
                "Date:" + Convert.ToDateTime(date).ToShortDateString() + " \tEvent:" + subject + " \tDescription:" + description;

            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);
            newEvent.DisplayEvents("all");

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
            newEvent.DisplayEvents("all");
            consoleOut.ToString().ShouldContain(expectedConsole);

        }
    }
}

