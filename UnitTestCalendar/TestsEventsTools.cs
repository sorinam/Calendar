using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;
using System.IO;

namespace UnitTestCalendar
{
    [TestClass]
    public class TestsEventsTools
    {
        [TestMethod]
        public void ShouldExportToHTMLFile()
        {
           
            List<Event> eventsRepo = new List<Event>
            {new Event("2015-01-01","event","description"), new Event("2015-01-02","event2"),new Event("2015-03-01","event3","description3")};

            EventsTools newObj = new EventsTools(eventsRepo);
            newObj.ExportToHTMLFile(@"HTMLFile.html");
            Assert.IsTrue(File.Exists(@"HTMLFile.html"));
              
        }
       
        }
    }
    

