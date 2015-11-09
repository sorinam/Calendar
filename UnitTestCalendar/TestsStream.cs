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
            StreamO news = new StreamO(stream);

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
<body><p><b>Date:</b> 2015/11/09</p>
<p><b>Subject:</b> first event</p><p><b>Description:</b> </p><hr><p><b>Date:</b> 2015/11/11</p>
<p><b>Subject:</b> second event</p><p><b>Description:</b> description of Second Event</p><hr><p><b>Date:</b> 2015/11/11</p>
<p><b>Subject:</b> /list</p><p><b>Description:</b> </p><hr>
</body>
</html> ";
            Events newEvent = new Events();

            string date = "2015/12/25";
            string subject = "Christmas Day!";
            string description = "Santa Claus is comming in our house....";

            newEvent.Add(date, subject, description);

            byte[] byteArray = Encoding.UTF8.GetBytes(myFile);
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                using (StreamO streamObj = new StreamO())
                {
                    streamObj.ExportEventsInHTMLStream(newEvent);
                    expectedFile.ShouldEqual(myFile);
                }
            }
           
        }
    }
}
