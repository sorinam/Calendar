using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Should;
using Calendar;
using System.Text;

namespace UnitTestCalendar
{
    [TestClass]
    public class TestsIOFiles
    {
        [TestMethod]
        public void ShouldDisplayOneEvent()
        {
            Events newEvent = new Events();
            IOFiles newObj = new IOFiles();
            string expectedConsole;
            StringWriter consoleOut;

            string date = "2015/12/25";
            string subject = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";
            SetExpectedResultToConsole(date, subject, description, out expectedConsole, out consoleOut);

            newEvent.EventsList.ShouldBeEmpty();
            newEvent.Add(date, subject, description);
            newObj.DisplayEventsToConsole(newEvent);

            consoleOut.ToString().ShouldContain(expectedConsole);
        }
              
        [TestMethod]
        public void ShouldDisplayMulytiLineOneEvent()
        {
            Events newEvent = new Events();
            IOFiles newObj = new IOFiles();
            string expectedConsole;
            StringWriter consoleOut;

            string date = "2015/12/25";
            string subject = "Christmas \n Day!";
            string description = "Santa Claus is comming in our house....\n";
            SetExpectedResultToConsole(date, subject, description, out expectedConsole, out consoleOut);

            newEvent.EventsList.ShouldBeEmpty();
            newEvent.Add(date, subject, description);
            newObj.DisplayEventsToConsole(newEvent);

            consoleOut.ToString().ShouldContain(expectedConsole);
        }

        [TestMethod]
        public void ShouldDisplayOneEventWithoutDescription()
        {
            Events newEvent = new Events();
            IOFiles newObj = new IOFiles();
            string expectedConsole;
            StringWriter consoleOut;

            string date = "2015/12/25";
            string subject = "Christmas Day!";
            SetExpectedResultToConsole(date, subject,"", out expectedConsole, out consoleOut);
            
            newEvent.EventsList.ShouldBeEmpty();
            newEvent.Add(date, subject);
            newObj.DisplayEventsToConsole(newEvent);

            consoleOut.ToString().ShouldContain(expectedConsole);
        }

        [TestMethod]
        public void ShouldDisplayAllEvents()
        {
            Events newEvent = new Events();
            IOFiles newObj = new IOFiles();
            string expectedConsole;
            var consoleOut = new StringWriter();

            string date = "2015/12/25";
            string subject = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";

            newEvent.EventsList.ShouldBeEmpty();
            newEvent.Add(date, subject,description);

            string date1 = "2015/10/25";
            string subject1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";
            newEvent.Add(date1, subject1, description1);

            expectedConsole = "Date:" + Convert.ToDateTime(date1).ToShortDateString() + " \tEvent:" + subject1 + " \tDescription:" + description1 + "\n" +
                "Date:" + Convert.ToDateTime(date).ToShortDateString() + " \tEvent:" + subject + " \tDescription:" + description;

            
            Console.SetOut(consoleOut);
            newObj.DisplayEventsToConsole(newEvent);

            consoleOut.ToString().ShouldContain(expectedConsole);
        }

        [TestMethod]
        public void ShouldDisplayPastEvents()
        {
            Events newEvents = new Events();
            IOFiles newObj = new IOFiles();
            EventsOp toDisplay = new EventsOp();

            string expectedConsole;
            var consoleOut = new StringWriter();

            string date = "2015/12/25";
            string subject = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";

            string date1 = "2015/10/25";
            string subject1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";
           
            SetExpectedResultToConsole(date1, subject1,description1, out expectedConsole, out consoleOut);

            newEvents.EventsList.ShouldBeEmpty();
            newEvents.Add(date, subject, description);
            newEvents.Add(date1, subject1, description1);
                 
            Events eventsToDisplay = toDisplay.ExtractEventsFromCalendar(newEvents, "past");

            newObj.DisplayEventsToConsole(eventsToDisplay);

            consoleOut.ToString().ShouldContain(expectedConsole);

        }

        [TestMethod]
        public void ShouldDisplayFutureEvents()
        {
            Events newEvents = new Events();
            IOFiles newObj = new IOFiles();
            EventsOp toDisplay = new EventsOp();

            string expectedConsole;
            var consoleOut = new StringWriter();

            string date = "2019/12/25";
            string subject = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";

            string date1 = "2015/10/25";
            string subject1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";

            SetExpectedResultToConsole(date, subject, description, out expectedConsole, out consoleOut);

            newEvents.EventsList.ShouldBeEmpty();
            newEvents.Add(date, subject, description);
            newEvents.Add(date1, subject1, description1);

            Events eventsToDisplay = toDisplay.ExtractEventsFromCalendar(newEvents, "future");

            newObj.DisplayEventsToConsole(eventsToDisplay);

            consoleOut.ToString().ShouldContain(expectedConsole);
        }

        [TestMethod]
        public void ShouldNotDisplayEventsForInvalidListParameter()
        {
            Events newEvents = new Events();
            IOFiles newObj = new IOFiles();
            EventsOp toDisplay = new EventsOp();

            string expectedConsole = "";
            var consoleOut = new StringWriter();

            string date = "2019/12/25";
            string subject = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";

            string date1 = "2015/10/25";
            string subject1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";

            newEvents.EventsList.ShouldBeEmpty();
            newEvents.Add(date, subject, description);
            newEvents.Add(date1, subject1, description1);

            Events eventsToDisplay = toDisplay.ExtractEventsFromCalendar(newEvents, "fture");

            newObj.DisplayEventsToConsole(eventsToDisplay);

            consoleOut.ToString().ShouldContain(expectedConsole);

        }

        [TestMethod]
        public void ShouldDisplaySortedEvents()
        {
            Events newEvent = new Events();
            IOFiles newObj = new IOFiles();
            string expectedConsole;
            var consoleOut = new StringWriter();

            string date = "2015/12/25";
            string subject = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";

            newEvent.EventsList.ShouldBeEmpty();
            newEvent.Add(date, subject, description);

            string date1 = "2015/10/25";
            string subject1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";
            newEvent.Add(date1, subject1, description1);

            string date2 = "2015/11/25";
            string subject2 = "John's Birtday!";
            string description2 = "Don't forget to call him...";
            newEvent.Add(date2, subject2, description2);

            string date3 = "2015/10/25";
            string subject3 = "Tim's Birtday!";
            string description3 = "Don't forget to call him...";
            newEvent.Add(date3, subject3, description3);

            expectedConsole = "Date:" + Convert.ToDateTime(date1).ToShortDateString() + " \tEvent:" + subject1 + " \tDescription:" + description1 + "\n" +
                "Date:" + Convert.ToDateTime(date3).ToShortDateString() + " \tEvent:" + subject3 + " \tDescription:" + description3 + "\n" +
                "Date:" + Convert.ToDateTime(date2).ToShortDateString() + " \tEvent:" + subject2 + " \tDescription:" + description2 + "\n" +
                "Date:" + Convert.ToDateTime(date).ToShortDateString() + " \tEvent:" + subject + " \tDescription:" + description;


            Console.SetOut(consoleOut);
            newObj.DisplayEventsToConsole(newEvent);

            consoleOut.ToString().ShouldContain(expectedConsole);

        }

        [TestMethod]
        public void ShouldNotDisplayEventsForEmptyCalendar()
        {
            Events newEvent = new Events();
            IOFiles newObj = new IOFiles();
            newEvent.EventsList.ShouldBeEmpty();

            string expectedConsole = "";

            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);
       
            newObj.DisplayEventsToConsole(newEvent);

            consoleOut.ToString().ShouldContain(expectedConsole);
        }

        [TestMethod]
        public void ShouldLoadEventsFromFile()
        {
            Events expectedList = new Events();
            expectedList.Add(new Event("11 / 5 / 2015 12:00:00 AM\ttoday\tevent"));
            IOFiles newObj = new IOFiles();
         
            var myFile = @"11 / 5 / 2015 12:00:00 AM@\ttoday@\tevent";
            var stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(myFile));
            string[] result = Encoding.
                            ASCII.
                            GetString(stream.ToArray()).
                            Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            Events listofEvents = new Events(result);

            expectedList.ShouldEqual(listofEvents);
        }

        private static void SetExpectedResultToConsole(string date, string subject, string description, out string expectedConsole, out StringWriter consoleOut)
        {
            expectedConsole = "Date:" + Convert.ToDateTime(date).ToShortDateString() + " \tEvent:" + subject;
            if (description != "")
            {
                expectedConsole += " \tDescription:" + description;
            }
            consoleOut = new StringWriter();
            Console.SetOut(consoleOut);
        }

    }
}
