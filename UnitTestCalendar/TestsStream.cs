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
        public void ShouldExportTOHTMLFromStream()
        {
            string expectedFile = @"﻿<!DOCTYPE html>
<html>
<head>
<title>Events List</title>
</head>
<body><p><b>Date:</b> 2015.12.25</p>
<p><b>Subject:</b> Christmas Day!</p><p><b>title:</b> Santa Claus</p><hr>
</body>
</html>";
           expectedFile= expectedFile.Trim(new Char[] { '\r' });
            Events newEvent = new Events();

            string date = "2015/12/25";
            string subject = "Christmas Day!";
            string title = "Santa Claus";

            newEvent.Add(date, subject, title);

            using (MemoryStream ms = new MemoryStream())
            {
                using (IOStream streamObj = new IOStream(ms))
                {
                    streamObj.ExportEventsInHTMLStream(newEvent);
                    var htmlContent = Encoding.UTF8.GetString(ms.ToArray());
                    // htmlContent.ShouldContain(expectedFile);
                    htmlContent.ShouldBeSameAs(expectedFile);
                }
            }
        }

        [TestMethod]
        public void ShouldLoadEventsFromStream()
        {
            var myFile = @"12/12/2015 12:00:00 AM	subject

01/11/2015 12:00:00 AM	subject title";
            string[] expectedList = { @"12/12/2015 12:00:00 AM	subject", @"01/11/2015 12:00:00 AM	subject title" };
            var stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(myFile));
            IOStream news = new IOStream(stream);

            string[] text = news.GetLinesFromStream();
            expectedList.ShouldEqual(text);
        }

    }
}
