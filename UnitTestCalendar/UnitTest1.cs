using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using Should;

namespace UnitTestCalendar
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ApplicationShouldAddEvent()
        {
            DateTime date = new DateTime(2015, 11, 20);
            string subject = "My birthday";

            Events.AddEvent(date, subject);
            Events.Calendar[0].Date.ShouldEqual(date);
            Events.Calendar[0].Subject.ShouldEqual(subject);
        }
    }
}
