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
    }
}
