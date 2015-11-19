using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using Should;

namespace UnitTestCalendar
{
    [TestClass]
    public class TestListArg
    {
        [TestMethod]
        public void ShouldAccepttAllListParameter()
        {
            string[] args = { "/list", "all" };
            ListArgument listArg = new ListArgument(args);
            listArg.IsValid().ShouldBeTrue() ;
        }

        [TestMethod]
        public void ShouldAccepttPastListParameter()
        {
            string[] args = { "/list", "Past" };
            ListArgument listArg = new ListArgument(args);
            listArg.IsValid().ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldAccepttFutureListParameter()
        {
            string[] args = { "/list", "FUTUre" };
            ListArgument listArg = new ListArgument(args);
            listArg.IsValid().ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldAcceptDefaultListParameter()
        {
            string[] args = { "/list" };
            ListArgument listArg = new ListArgument(args);
            listArg.IsValid().ShouldBeTrue();
        }
        [TestMethod]
        public void ShouldAccepTodayListParameter()
        {
            string[] args = { "/list","TODAY" };
            ListArgument listArg = new ListArgument(args);
            listArg.IsValid().ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldNotAccepttInvalidListParameter()
        {
            string[] args = { "/list","tags" ,"new"};
            ListArgument listArg = new ListArgument(args);
            listArg.IsValid().ShouldBeFalse();
        }

        [TestMethod]
        public void ShouldAccepttListTagsByNameParameter()
        {
            string[] args = { "/list", "tags", "byName"};
            ListArgument listArg = new ListArgument(args);
            listArg.IsValid().ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldAccepttListTagsWithoutParameter()
        {
            string[] args = { "/list", "tags"};
            ListArgument listArg = new ListArgument(args);
            listArg.IsValid().ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldAccepttListTagsByCountParameter()
        {
            string[] args = { "/list", "tags", "byCount" };
            ListArgument listArg = new ListArgument(args);
            listArg.IsValid().ShouldBeTrue();
        }
        [TestMethod]
        public void ShouldNotAccepttInvalidFirstParameter()
        {
            string[] args = { "/lis", "tags","new" };
            ListArgument listArg = new ListArgument(args);
            listArg.IsValid().ShouldBeFalse();
        }
    }
}
