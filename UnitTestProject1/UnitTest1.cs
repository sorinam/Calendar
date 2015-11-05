using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.IO;
using Calendar;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestIOFiles
    {
        [TestMethod]
       public void ShouldLoadFile()
        {
            string file = @"3/3/2015 12:00:00 AM	subject	description
";
            EventsEnum listOfEvents = new EventsEnum();
            byte[] byteArray = Encoding.UTF8.GetBytes(file);
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                using ( IOFiles file = new IOFiles(stream))
                {
                    uint lineCount = csharpFile.GetCodeLinesCount();
                    lineCount.ShouldEqual(expectedCount);
                }
            }
        }
    }
}
