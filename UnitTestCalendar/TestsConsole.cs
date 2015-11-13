using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;
using System.IO;
using Should;
using System;

namespace UnitTestCalendar
{
    [TestClass]
    public class TestsConsole
    {
        [TestMethod]
        public void ShouldDisplayOneEvent()
        {
            Events newEvent = new Events();
            string expectedConsole;
            StringWriter consoleOut;

            string date = "2015/12/25";
            string subject = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";
            SetExpectedResultToConsole(date, subject, description, out expectedConsole, out consoleOut);

            newEvent.EventsList.ShouldBeEmpty();
            newEvent.Add(date, subject, description);

            ConsoleWorker newObj = new ConsoleWorker(newEvent);
            newObj.DisplayEventsToConsole();
        
            consoleOut.ToString().ShouldContain(expectedConsole);
        }

        [TestMethod]
        public void ShouldDisplayMulytiLineOneEvent()
        {
            Events newEvent = new Events();
            string expectedConsole;
            StringWriter consoleOut;

            string date = "2015/12/25";
            string subject = "Christmas \n Day!";
            string description = "Santa Claus is comming in our house....\n";
            SetExpectedResultToConsole(date, subject, description, out expectedConsole, out consoleOut);

            newEvent.EventsList.ShouldBeEmpty();
            newEvent.Add(date, subject, description);

            ConsoleWorker newObj = new ConsoleWorker(newEvent);
            newObj.DisplayEventsToConsole();

            consoleOut.ToString().ShouldContain(expectedConsole);
        }

        [TestMethod]
        public void ShouldDisplayOneEventWithoutDescription()
        {
            Events newEvent = new Events();
            string expectedConsole;
            StringWriter consoleOut;

            string date = "2015/12/25";
            string subject = "Christmas Day!";
            SetExpectedResultToConsole(date, subject, "", out expectedConsole, out consoleOut);

            newEvent.EventsList.ShouldBeEmpty();
            newEvent.Add(date, subject);

            ConsoleWorker newObj = new ConsoleWorker(newEvent);
            newObj.DisplayEventsToConsole();

            consoleOut.ToString().ShouldContain(expectedConsole);
        }

        [TestMethod]
        public void ShouldDisplayAllEvents()
        {
            Events newEvent = new Events();

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

            expectedConsole = " \nDate:" + Convert.ToDateTime(date1).ToString("yyyy/MM/dd") + " \nSubject:" + subject1 + " \nDescription:" + description1 + "\n" +
                " \nDate:" + Convert.ToDateTime(date).ToString("yyyy/MM/dd") + " \nSubject:" + subject + " \nDescription:" + description;


            Console.SetOut(consoleOut);
            ConsoleWorker newObj = new ConsoleWorker(newEvent);
            newObj.DisplayEventsToConsole();

            consoleOut.ToString().ShouldContain(expectedConsole);
        }

        [TestMethod]
        public void ShouldDisplayPastEvents()
        {
            Events newEvents = new Events();
            ConsoleWorker toDisplay = new ConsoleWorker();

            string expectedConsole;
            var consoleOut = new StringWriter();

            string date = "2015/12/25";
            string subject = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";

            string date1 = "2015/11/10";
            string subject1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";

            SetExpectedResultToConsole(date1, subject1, description1, out expectedConsole, out consoleOut);

            newEvents.EventsList.ShouldBeEmpty();
            newEvents.Add(date, subject, description);
            newEvents.Add(date1, subject1, description1);

            string today= DateTime.Now.ToShortDateString();

            DateFilter eventsToDisplay = new DateFilter("<", today);
            Events filteredList = eventsToDisplay.ApplyFilter(newEvents);

            ConsoleWorker newObj = new ConsoleWorker(filteredList);
            newObj.DisplayEventsToConsole();

            consoleOut.ToString().ShouldContain(expectedConsole);

        }

        [TestMethod]
        public void ShouldDisplayFutureEvents()
        {
            Events newEvents = new Events();
            ConsoleWorker toDisplay = new ConsoleWorker();

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
          
            string today = DateTime.Now.ToShortDateString();
            DateFilter eventsToDisplay = new DateFilter( ">", today);
            Events filteredList = eventsToDisplay.ApplyFilter(newEvents);

            ConsoleWorker newObj = new ConsoleWorker(filteredList);
            newObj.DisplayEventsToConsole();
            consoleOut.ToString().ShouldContain(expectedConsole);
        }

        [TestMethod]
        public void ShouldDisplayEventsFromCertainDate()
        {
            Events newEvents = new Events();
            ConsoleWorker toDisplay = new ConsoleWorker();

            string expectedConsole;
            var consoleOut = new StringWriter();

            string date = "2019/12/25";
            string subject = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";

            string date1 = "2015/10/25";
            string subject1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";

            SetExpectedResultToConsole(date1, subject1, description1, out expectedConsole, out consoleOut);

            newEvents.EventsList.ShouldBeEmpty();
            newEvents.Add(date, subject, description);
            newEvents.Add(date1, subject1, description1);

            DateFilter eventsToDisplay = new DateFilter("=", "2015/10/25");
            Events filteredList = eventsToDisplay.ApplyFilter(newEvents);

            ConsoleWorker newObj = new ConsoleWorker(filteredList);
            newObj.DisplayEventsToConsole();
            consoleOut.ToString().ShouldContain(expectedConsole);
        }
        [TestMethod]
        public void ShouldDisplayEventsBeetwenTwoDate()
        {
            ConsoleWorker toDisplay = new ConsoleWorker();

            string expectedConsole;
            var consoleOut = new StringWriter();

            Events newEvents = new Events {
                { new Event ( "2015/01/01", "one", "test") },
                {new Event("2015/11/15", "two") },
                { new Event("2015/07/01", "three") },
                { new Event("2015/12/03", "four", "test1") },
                { new Event("2015/03/04", "five", "test2") },
                { new Event("2015/09/08", "six") }
        };
            
           SetExpectedResultToConsole("2015/09/08", "six", "", out expectedConsole, out consoleOut);
           
            DateFilter firstFilter = new DateFilter( "<", "2015/10/25");
            Events firstFilteredList = firstFilter.ApplyFilter((newEvents));
            DateFilter eventsToDisplay = new DateFilter( ">", "2015/02/25");
            Events filteredList = eventsToDisplay.ApplyFilter(firstFilteredList);

            ConsoleWorker newObj = new ConsoleWorker(filteredList);
            newObj.DisplayEventsToConsole();
            consoleOut.ToString().ShouldContain(expectedConsole);
        }
        
        [TestMethod]
        public void ShouldDisplaySortedEvents()
        {
            Events newEvent = new Events();
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

            expectedConsole = " \nDate:" + Convert.ToDateTime(date1).ToString("yyyy/MM/dd") + " \nSubject:" + subject1 + " \nDescription:" + description1 + "\n" +
                " \nDate:" + Convert.ToDateTime(date3).ToString("yyyy/MM/dd") + " \nSubject:" + subject3 + " \nDescription:" + description3 + "\n" +
                " \nDate:" + Convert.ToDateTime(date2).ToString("yyyy/MM/dd") + " \nSubject:" + subject2 + " \nDescription:" + description2 + "\n" +
                " \nDate:" + Convert.ToDateTime(date).ToString("yyyy/MM/dd") + " \nSubject:" + subject + " \nDescription:" + description;


            Console.SetOut(consoleOut);
            ConsoleWorker newObj = new ConsoleWorker(newEvent);
            newObj.DisplayEventsToConsole();
            consoleOut.ToString().ShouldContain(expectedConsole);

        }

        [TestMethod]
        public void ShouldNotDisplayEventsForEmptyCalendar()
        {
            Events newEvent = new Events();

            newEvent.EventsList.ShouldBeEmpty();

            string expectedConsole = "";

            var consoleOut = new StringWriter();
            Console.SetOut(consoleOut);

            ConsoleWorker newObj = new ConsoleWorker(newEvent);
            newObj.DisplayEventsToConsole();

            consoleOut.ToString().ShouldContain(expectedConsole);
        }

        private static void SetExpectedResultToConsole(string date, string subject, string description, out string expectedConsole, out StringWriter consoleOut)
        {
            expectedConsole = " \nDate:" + Convert.ToDateTime(date).ToString("yyyy/MM/dd") + " \nSubject:" + subject;
            if (description != "")
            {
                expectedConsole += " \nDescription:" + description;
            }
            consoleOut = new StringWriter();
            Console.SetOut(consoleOut);
        }

        [TestMethod]
        public void ShouldExportToHTMLFile()
        {
           
            List<Event> eventsRepo = new List<Event>
            {new Event("2015-01-01","event","description"), new Event("2015-01-02","event2"),new Event("2015-03-01","event3","description3")};

            HTMLDocument newObj = new HTMLDocument(eventsRepo);
            newObj.ExportToHTMLFile(@"HTMLFile.html");
            Assert.IsTrue(File.Exists(@"HTMLFile.html"));
          }
       
        }
    }
    

