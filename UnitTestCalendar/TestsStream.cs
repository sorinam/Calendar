using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Should;
using Calendar;
using System.Text;

namespace UnitTestCalendar
{
    [TestClass]
    public class TestsStream
    {
        [TestMethod]
        public void ShouldLoadEventsFromStream()
        {
            var myFile = @"12/12/2015 12:00:00 AM	subject

01/11/2015 12:00:00 AM	subject description";
            string[] expectedList = { @"12/12/2015 12:00:00 AM	subject", @"01/11/2015 12:00:00 AM	subject description" };
            var stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(myFile));
            StreamWorker news = new StreamWorker(stream);

            string[] text = news.GetLinesFromStream();
            expectedList.ShouldEqual(text);
        }

        [TestMethod]
        public void ShouldExportTOHTMLFromStream()
        {
            string myFile = "";
            string expectedFile = @"<!DOCTYPE html>
<html>
<head>
<title>Events List</title>
</head>
<body><p><b>Date:</b> 2015/12/25</p>
<p><b>Subject:</b> Christmas Day!</p><p><bSanta Claus</b> </p><hr>
</body>
</html> ";
            Events newEvent = new Events();

            string date = "2015/12/25";
            string subject = "Christmas Day!";
            string description = "Santa Claus";

            newEvent.Add(date, subject, description);

            byte[] byteArray = Encoding.UTF8.GetBytes(myFile);
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                using (StreamWorker streamObj = new StreamWorker())
                {
                    streamObj.ExportEventsInHTMLStream(newEvent);
                    expectedFile.ShouldEqual(myFile);
                }
            }
           
        }
    }
}
