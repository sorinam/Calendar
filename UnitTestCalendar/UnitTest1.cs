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

            Events.AddEvent(date, subject);
            Events.Calendar.ShouldBeEmpty();
        }

        [TestMethod]
        public void ApplicationShouldAddEvent()
        {
            string date = "2015/11/20";
            string subject = "My birthday";

            Events.AddEvent(date, subject);
         
            Events.Calendar[0].Date.ShouldEqual(Convert.ToDateTime(date));
            Events.Calendar[0].Subject.ShouldEqual(subject);
        }

        [TestMethod]
        public void ApplicationShouldDisplayEvent()
        {
            string date = "2015/12/25";
            string subject = "Christmas Day!";

            Events.Calendar.ShouldBeEmpty();
            Events.AddEvent(date, subject);

            string expectedConsole = "Date: " + Convert.ToDateTime(date).ToShortDateString() + " Event:" + subject+"\n";

            var consoleOut= new StringWriter();
            Console.SetOut(consoleOut);
            Events.DisplayCalendar();
            expectedConsole.ShouldContain(consoleOut.ToString());
            
            }
        }
    }

