﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            string title = "Santa Claus";
            string description = "Santa Claus is comming in our house....";
            SetExpectedResultToConsole(date, title,out expectedConsole, out consoleOut,description);

            newEvent.EventsList.ShouldBeEmpty();
            newEvent.Add(date, title,description);

            IOConsole newObj = new IOConsole(newEvent);
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
            string title = "Christmas \n Day!";
            string description = "Santa Claus is comming in our house....\n";
            SetExpectedResultToConsole(date, title,out expectedConsole, out consoleOut, description);

            newEvent.EventsList.ShouldBeEmpty();
            newEvent.Add(date, title, description);

            IOConsole newObj = new IOConsole(newEvent);
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
            string title = "Christmas Day!";
            SetExpectedResultToConsole(date, title, out expectedConsole, out consoleOut);

            newEvent.EventsList.ShouldBeEmpty();
            newEvent.Add(date, title);

            IOConsole newObj = new IOConsole(newEvent);
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
            string title = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";

            newEvent.EventsList.ShouldBeEmpty();
            newEvent.Add(date, title, description);

            string date1 = "2015/10/25";
            string title1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";
            newEvent.Add(date1, title1, description1);

            expectedConsole = " \nDate:" + Convert.ToDateTime(date1).ToString("yyyy/MM/dd") + " \nTitle:" + title1 + " \nDescription:" + description1 + "\n" +
                " \nDate:" + Convert.ToDateTime(date).ToString("yyyy/MM/dd") + " \nTitle:" + title + " \nDescription:" + description;


            Console.SetOut(consoleOut);
            IOConsole newObj = new IOConsole(newEvent);
            newObj.DisplayEventsToConsole();

            consoleOut.ToString().ShouldContain(expectedConsole);
        }

        [TestMethod]
        public void ShouldDisplayPastEvents()
        {
            Events newEvents = new Events();
            IOConsole toDisplay = new IOConsole();

            string expectedConsole;
            var consoleOut = new StringWriter();

            string date = "2015/12/25";
            string title = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";

            string date1 = "2015/11/10";
            string title1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";

            SetExpectedResultToConsole(date1, title1, out expectedConsole, out consoleOut, description1);

            newEvents.EventsList.ShouldBeEmpty();
            newEvents.Add(date, title, description);
            newEvents.Add(date1, title1, description1);

            string today= DateTime.Now.ToShortDateString();

            DateFilter eventsToDisplay = new DateFilter("<", today);
            Events filteredList = eventsToDisplay.ApplyFilter(newEvents);

            IOConsole newObj = new IOConsole(filteredList);
            newObj.DisplayEventsToConsole();

            consoleOut.ToString().ShouldContain(expectedConsole);

        }

        [TestMethod]
        public void ShouldDisplayFutureEvents()
        {
            Events newEvents = new Events();
            IOConsole toDisplay = new IOConsole();

            string expectedConsole;
            var consoleOut = new StringWriter();

            string date = "2019/12/25";
            string title = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";

            string date1 = "2015/10/25";
            string title1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";

            SetExpectedResultToConsole(date, title, out expectedConsole, out consoleOut, description);

            newEvents.EventsList.ShouldBeEmpty();
            newEvents.Add(date, title, description);
            newEvents.Add(date1, title1, description1);
          
            string today = DateTime.Now.ToShortDateString();
            DateFilter eventsToDisplay = new DateFilter( ">", today);
            Events filteredList = eventsToDisplay.ApplyFilter(newEvents);

            IOConsole newObj = new IOConsole(filteredList);
            newObj.DisplayEventsToConsole();
            consoleOut.ToString().ShouldContain(expectedConsole);
        }

        [TestMethod]
        public void ShouldDisplayEventsFromCertainDate()
        {
            Events newEvents = new Events();
            IOConsole toDisplay = new IOConsole();

            string expectedConsole;
            var consoleOut = new StringWriter();

            string date = "2019/12/25";
            string title = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";

            string date1 = "2015/10/25";
            string title1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";

            SetExpectedResultToConsole(date1, title1,out expectedConsole, out consoleOut, description1);

            newEvents.EventsList.ShouldBeEmpty();
            newEvents.Add(date, title, description);
            newEvents.Add(date1, title1, description1);

            DateFilter eventsToDisplay = new DateFilter("=", "2015/10/25");
            Events filteredList = eventsToDisplay.ApplyFilter(newEvents);

            IOConsole newObj = new IOConsole(filteredList);
            newObj.DisplayEventsToConsole();
            consoleOut.ToString().ShouldContain(expectedConsole);
        }
        [TestMethod]
        public void ShouldDisplayEventsBeetwenTwoDate()
        {
            IOConsole toDisplay = new IOConsole();

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
            
           SetExpectedResultToConsole("2015/09/08", "six", out expectedConsole, out consoleOut);
           
            DateFilter firstFilter = new DateFilter( "<", "2015/10/25");
            Events firstFilteredList = firstFilter.ApplyFilter((newEvents));
            DateFilter eventsToDisplay = new DateFilter( ">", "2015/02/25");
            Events filteredList = eventsToDisplay.ApplyFilter(firstFilteredList);

            IOConsole newObj = new IOConsole(filteredList);
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
            string title = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";

            newEvent.EventsList.ShouldBeEmpty();
            newEvent.Add(date, title, description);

            string date1 = "2015/10/25";
            string title1 = "Johana's Birtday!";
            string description1 = "Don't forget to call her...";
            newEvent.Add(date1, title1, description1);

            string date2 = "2015/11/25";
            string title2 = "John's Birtday!";
            string description2 = "Don't forget to call him...";
            newEvent.Add(date2, title2, description2);

            string date3 = "2015/10/25";
            string title3 = "Tim's Birtday!";
            string description3 = "Don't forget to call him...";
            newEvent.Add(date3, title3, description3);

            expectedConsole = " \nDate:" + Convert.ToDateTime(date1).ToString("yyyy/MM/dd") + " \nTitle:" + title1 + " \nDescription:" + description1 + "\n" +
                " \nDate:" + Convert.ToDateTime(date3).ToString("yyyy/MM/dd") + " \nTitle:" + title3 + " \nDescription:" + description3 + "\n" +
                " \nDate:" + Convert.ToDateTime(date2).ToString("yyyy/MM/dd") + " \nTitle:" + title2 + " \nDescription:" + description2 + "\n" +
                " \nDate:" + Convert.ToDateTime(date).ToString("yyyy/MM/dd") + " \nTitle:" + title + " \nDescription:" + description;


            Console.SetOut(consoleOut);
            IOConsole newObj = new IOConsole(newEvent);
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

            IOConsole newObj = new IOConsole(newEvent);
            newObj.DisplayEventsToConsole();

            consoleOut.ToString().ShouldContain(expectedConsole);
        }

        private static void SetExpectedResultToConsole(string date, string title, out string expectedConsole, out StringWriter consoleOut, string description = "")
        {
            expectedConsole = " \nDate:" + Convert.ToDateTime(date).ToString("yyyy/MM/dd") ;
            expectedConsole += " \nTitle:" + title;
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

            HTMLFile newObj = new HTMLFile(eventsRepo);
            newObj.ExportToHTMLFile(@"HTMLFile.html");
            Assert.IsTrue(File.Exists(@"HTMLFile.html"));
          }
       
        }
    }
    

