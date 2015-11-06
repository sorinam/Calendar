using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;

namespace UnitTestCalendar
{
    [TestClass]
    public class TestsEventsOP
    {
        [TestMethod]
        public void TestMethod1()
        {
            EventsTools newObj = new EventsTools();
            List<Event> eventsRepo = new List<Event>
            {new Event("2015-01-01","event","description"), new Event("2015-01-02","event2"),new Event("2015-03-01","event3","description3")};
            Events newRepo = new Events(eventsRepo);
            newObj.CreateHtmlFile(@"HTMLcalendar.html",newRepo);
            Assert.AreEqual(1, 0);
        }
    }
}
