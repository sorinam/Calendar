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

            string expectedConsole = "Date:" + Convert.ToDateTime(date).ToShortDateString() + "\tEvent:" + subject+" \t\tDescription:"+description ;

            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);
            newEvent.DisplayAllEvents();
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
            string description1= "Don't forget to call her...";
            newEvent.AddEvent(date1, subject1, description1);

            string expectedConsole = "Date:" + Convert.ToDateTime(date1).ToShortDateString() + "\tEvent:" + subject1 + " \t\tDescription:" + description1 + "\n" +
                "Date:" + Convert.ToDateTime(date).ToShortDateString() + "\tEvent:" + subject + " \t\tDescription:" + description;

            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);
            newEvent.DisplayAllEvents();
           
            consoleOut.ToString().ShouldContain(expectedConsole);

        }

        [TestMethod]
        public void ApplicationShouldDisplayPastEvents()
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

            string expectedConsole = "Date:" + Convert.ToDateTime(date1).ToShortDateString() + "\tEvent:" + subject1 + " \t\tDescription:" + description1 + "\n";
                
            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);
            newEvent.DisplayAllEvents();

            consoleOut.ToString().ShouldContain(expectedConsole);

        }
        [TestMethod]
        public void ApplicationShouldDisplayFutureEvents()
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

            string expectedConsole = "Date:" + Convert.ToDateTime(date).ToShortDateString() + "\tEvent:" + subject + " \t\tDescription:" + description + "\n";

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
        
    }
}

