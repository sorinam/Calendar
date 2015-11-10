using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using Calendar;

namespace UnitTestCalendar
{
    [TestClass]
    public class TestUtils
    {
        [TestMethod]
        public void ShouldParseValidFilteringCriteria()
        {
            string UIvalue = "past";
            string expectedcode = "<=";
            expectedcode.ShouldEqual(Utils.ParseFilteringCriteria(UIvalue));
        }

        [TestMethod]
        public void ShouldParseInValidFilteringCriteria()
        {
            string UIvalue = "pastr";
            string expectedcode = "";
            expectedcode.ShouldEqual(Utils.ParseFilteringCriteria(UIvalue));
        }
    }
}
