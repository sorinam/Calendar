using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCalendar
{
    [TestClass]
    public class UnitTestIOFiles
    {
        //[TestMethod]
        //public void ShouldDisplayOneEvent()
        //{
        //    string date = "2015/12/25";
        //    string subject = "Christmas Day!";
        //    string description = "Santa Claus is comming in our house....";
        //    EventsEnum newEvent = new EventsEnum();

        //    newEvent.Events.ShouldBeEmpty();
        //    newEvent.Add(date, subject, description);

        //    string expectedConsole = "Date:" + Convert.ToDateTime(date).ToShortDateString() + " \tEvent:" + subject + " \tDescription:" + description;

        //    var consoleOut = new StringWriter();
        //    Console.SetOut(consoleOut);
        //    newEvent.DisplayEvents("all");
        //    consoleOut.ToString().ShouldContain(expectedConsole);
        //}
        //    //[TestMethod]
        //    //public void ApplicationShouldDisplayMulytiLineOneEvent()
        //    //{
        //    //    string date = "2015/12/25";
        //    //    string subject = "Christmas \n Day!";
        //    //    string description = "Santa Claus is comming in our house....\n";
        //    //    Events newEvent = new Events();
        //    //    newEvent.Calendar.ShouldBeEmpty();
        //    //    newEvent.AddEvent(date, subject, description);

        //    //    string expectedConsole = "Date:" + Convert.ToDateTime(date).ToShortDateString() + " \tEvent:" + subject + " \tDescription:" + description;

        //    //    var consoleOut = new StringWriter();
        //    //    Console.SetOut(consoleOut);
        //    //    newEvent.DisplayEvents("all");
        //    //    consoleOut.ToString().ShouldContain(expectedConsole);
        //    //}
        //    //[TestMethod]
        //    //public void ApplicationShouldDisplayOneEventWithoutDescription()
        //    //{
        //    //    string date = "2015/12/25";
        //    //    string subject = "Christmas Day!";
        //    //    Events newEvent = new Events();
        //    //    newEvent.Calendar.ShouldBeEmpty();
        //    //    newEvent.AddEvent(date, subject);

        //    //    string expectedConsole = "Date:" + Convert.ToDateTime(date).ToShortDateString() + " \tEvent:" + subject;

        //    //    var consoleOut = new StringWriter();
        //    //    Console.SetOut(consoleOut);
        //    //    newEvent.DisplayEvents("all");
        //    //    consoleOut.ToString().ShouldContain(expectedConsole);
        //    //}
        //    //[TestMethod]
        //    //public void ApplicationShouldDisplayAllEvents()
        //    //{
        //    //    string date = "2015/12/25";
        //    //    string subject = "Christmas Day!";
        //    //    string description = "Santa Claus is comming in our house....";
        //    //    Events newEvent = new Events();
        //    //    newEvent.Calendar.ShouldBeEmpty();
        //    //    newEvent.AddEvent(date, subject, description);
        //    //    string date1 = "2015/10/25";
        //    //    string subject1 = "Johana's Birtday!";
        //    //    string description1 = "Don't forget to call her...";
        //    //    newEvent.AddEvent(date1, subject1, description1);

        //    //    string expectedConsole = "Date:" + Convert.ToDateTime(date1).ToShortDateString() + " \tEvent:" + subject1 + " \tDescription:" + description1 + "\n" +
        //    //        "Date:" + Convert.ToDateTime(date).ToShortDateString() + " \tEvent:" + subject + " \tDescription:" + description;

        //    //    var consoleOut = new StringWriter();
        //    //    Console.SetOut(consoleOut);
        //    //    newEvent.DisplayEvents("all");
        //    //    consoleOut.ToString().ShouldContain(expectedConsole);
        //    //}

        //    //[TestMethod]
        //    //public void ApplicationShouldDisplayPastEvents()
        //    //{
        //    //    string date = "2019/12/25";
        //    //    string subject = "Christmas Day!";
        //    //    string description = "Santa Claus is comming in our house....";
        //    //    Events newEvent = new Events();
        //    //    newEvent.Calendar.ShouldBeEmpty();
        //    //    newEvent.AddEvent(date, subject, description);
        //    //    string date1 = "2015/10/25";
        //    //    string subject1 = "Johana's Birtday!";
        //    //    string description1 = "Don't forget to call her...";
        //    //    newEvent.AddEvent(date1, subject1, description1);

        //    //    string expectedConsole = "Date:" + Convert.ToDateTime(date1).ToShortDateString() + " \tEvent:" + subject1 + " \tDescription:" + description1 + "\n";

        //    //    var consoleOut = new StringWriter();
        //    //    Console.SetOut(consoleOut);
        //    //    newEvent.DisplayEvents("past");

        //    //    consoleOut.ToString().ShouldContain(expectedConsole);

        //    //}

        //    //[TestMethod]
        //    //public void ApplicationShouldDisplayFutureEvents()
        //    //{
        //    //    string date = "2019/12/25";
        //    //    string subject = "Christmas Day!";
        //    //    string description = "Santa Claus is comming in our house....";
        //    //    Events newEvent = new Events();
        //    //    newEvent.Calendar.ShouldBeEmpty();
        //    //    newEvent.AddEvent(date, subject, description);
        //    //    string date1 = "2015/10/25";
        //    //    string subject1 = "Johana's Birtday!";
        //    //    string description1 = "Don't forget to call her...";
        //    //    newEvent.AddEvent(date1, subject1, description1);

        //    //    string expectedConsole = "Date:" + Convert.ToDateTime(date).ToShortDateString() + " \tEvent:" + subject + " \tDescription:" + description + "\n";

        //    //    var consoleOut = new StringWriter();
        //    //    Console.SetOut(consoleOut);
        //    //    newEvent.DisplayEvents("future");

        //    //    consoleOut.ToString().ShouldContain(expectedConsole);

        //    //}

        //    //[TestMethod]
        //    //public void ApplicationShouldNotDisplayEventsForInvalidListParameter()
        //    //{
        //    //    string date = "2019/12/25";
        //    //    string subject = "Christmas Day!";
        //    //    string description = "Santa Claus is comming in our house....";
        //    //    Events newEvent = new Events();
        //    //    newEvent.Calendar.ShouldBeEmpty();
        //    //    newEvent.AddEvent(date, subject, description);
        //    //    string date1 = "2015/10/25";
        //    //    string subject1 = "Johana's Birtday!";
        //    //    string description1 = "Don't forget to call her...";
        //    //    newEvent.AddEvent(date1, subject1, description1);

        //    //    string expectedConsole = "";

        //    //    var consoleOut = new StringWriter();
        //    //    Console.SetOut(consoleOut);
        //    //    consoleOut.ToString().ShouldBeEmpty();

        //    //    newEvent.DisplayEvents("fture");
        //    //    consoleOut.ToString().ShouldEqual(expectedConsole);

        //    //}

        //    //[TestMethod]
        //    //public void ApplicationShouldDisplaySortedEvents()
        //    //{
        //    //    string date = "2015/12/25";
        //    //    string subject = "Christmas Day!";
        //    //    string description = "Santa Claus is comming in our house....";
        //    //    Events newEvent = new Events();
        //    //    newEvent.Calendar.ShouldBeEmpty();
        //    //    newEvent.AddEvent(date, subject, description);

        //    //    string date1 = "2015/10/25";
        //    //    string subject1 = "Johana's Birtday!";
        //    //    string description1 = "Don't forget to call her...";
        //    //    newEvent.AddEvent(date1, subject1, description1);

        //    //    string date2 = "2015/11/25";
        //    //    string subject2 = "John's Birtday!";
        //    //    string description2 = "Don't forget to call him...";
        //    //    newEvent.AddEvent(date2, subject2, description2);

        //    //    string date3 = "2015/10/25";
        //    //    string subject3 = "Tim's Birtday!";
        //    //    string description3 = "Don't forget to call him...";
        //    //    newEvent.AddEvent(date3, subject3, description3);

        //    //    string expectedConsole = "Date:" + Convert.ToDateTime(date1).ToShortDateString() + " \tEvent:" + subject1 + " \tDescription:" + description1 + "\n" +
        //    //        "Date:" + Convert.ToDateTime(date3).ToShortDateString() + " \tEvent:" + subject3 + " \tDescription:" + description3 + "\n" +
        //    //        "Date:" + Convert.ToDateTime(date2).ToShortDateString() + " \tEvent:" + subject2 + " \tDescription:" + description2 + "\n" +
        //    //        "Date:" + Convert.ToDateTime(date).ToShortDateString() + " \tEvent:" + subject + " \tDescription:" + description;

        //    //    var consoleOut = new StringWriter();
        //    //    Console.SetOut(consoleOut);
        //    //    newEvent.DisplayEvents("all");

        //    //    consoleOut.ToString().ShouldContain(expectedConsole);

        //    //}

        //    //[TestMethod]
        //    //public void ApplicationShouldNotDisplayEventForEmptyCalendar()
        //    //{
        //    //    Events newEvent = new Events();
        //    //    newEvent.Calendar.ShouldBeEmpty();

        //    //    string expectedConsole = "";

        //    //    var consoleOut = new StringWriter();
        //    //    Console.SetOut(consoleOut);
        //    //    newEvent.DisplayEvents("all");
        //    //    consoleOut.ToString().ShouldContain(expectedConsole);

        //    //}
        //    //[TestMethod]
        //    //public void UITEst()
        //    //{
        //    //    Events newEvent = new Events();
        //    //    newEvent.DisplayEvents("all");


        //    //}
    }
}
