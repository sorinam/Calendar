using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;
using Should;

namespace UnitTestCalendar
{
    [TestClass]
    public class TestXMLs
    {

        [TestMethod]
        public void ShouldListAllNodesFromXML()
        {
            string xpath = "//calendar/appointment";
            var resultString = XMLUtils.GetValuesOfXmlElementAtXpath_XmlFromFile(xpath);
            List<string> expectedString = new List<string> { "2015/12/20First itemThis is my first XML test", "2015/12/25Second itemThis is my second XML test" };
            resultString.ShouldEqual(expectedString);
        }

        [TestMethod]
        public void ShouldListOneNodeFromXMLFindAnAttribute()
        {
            string xpath = "calendar/appointment[@ID='2']";
            var resultString = XMLUtils.GetValueOfXmlElementAtXpath_XmlFromFile(xpath);
            var expectedString = "2015/12/25Second itemThis is my second XML test";
            resultString.ShouldEqual(expectedString);
        }

        [TestMethod]
        public void ShouldListOneValueOfNodeFromXML()
        {
            string xpath = "calendar/appointment[@ID='2']/description";
            var resultString = XMLUtils.GetValueOfXmlElementAtXpath_XmlFromFile(xpath);
            var expectedString = "This is my second XML test";
            resultString.ShouldEqual(expectedString);
        }

        [TestMethod]
        public void ShouldSetValueOfNodeToXML()
        {
            string xpath = "calendar/appointment[@ID='2']/description";
            string newValue = "This is my modified second XML test";
            var resultString = XMLUtils.SetValueOfXmlElementAtXpath_XmlFromFile(xpath, newValue);
            resultString.ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldAddANewNodeToXML()
        {
            string ID = "3";
            string data = "2015/12/18";
            string title = "@Rares #bday";
            string description = "don't forget to #call him";
            var result = XMLUtils.AddNewAppointmentElementToXMLFile(ID, data, title, description);
            result.ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldListLastIDValueFromXML()
        {
            //string xpath = "(calendar/appointment)[last()]";
            //var resultString = XMLUtils.GetValueOfIDFromXMLFile(xpath);
            var resultString = XMLUtils.GetLastIDFromXMLFile();
            var expectedString = "3";
            resultString.ShouldEqual(expectedString);
        }

        [TestMethod]
        public void ShouldGetListOfAppointmentsFromXMLFile()
        {
            List<Event> expectedEventsList = new List<Event> {
            new Event("2015/12/20","First item","This is my first XML test"),
            new Event("2015/12/25", "Second item", "This is my modified second XML test"),
            new Event("2015/12/18", "@Rares #bday")
        };

            Utils.AssertAreEqual(XMLUtils.LoadEventsFromXMLFile(),expectedEventsList);
        }

        [TestMethod]
        public void ShouldAddAppointmentsToXMLFile()
        {
            List<Event> eventsList = new List<Event>{
            new Event("2015/12/27","One","One test"),
            new Event("2015/11/25", "Two") };
            Events newAppoinments = new Events(eventsList);
            XMLUtils.SaveEventsToXMLFile(newAppoinments);
           
        }
    }
}
