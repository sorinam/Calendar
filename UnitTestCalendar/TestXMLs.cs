using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;
using Should;
using System.Xml;

namespace UnitTestCalendar
{
    [TestClass]
    public class TestXMLs
    {

        [TestMethod]
        public void ShouldListAllNodesFromXML()
        {
            XmlDocument doc = InitialiazeXMLDocument();
            string xpath = "//calendar/appointment";
            List<string> expectedString = new List<string> { "2015/12/20First itemThis is my first XML test", "2015/12/25Second itemThis is my second XML test" };

            var resultString = XMLUtils.GetValuesOfAllXmlElements(xpath, doc);
          
            resultString.ShouldEqual(expectedString);
        }
            
        [TestMethod]
        public void ShouldListOneNodeFromXMLFindAnAttribute()
        {
            XmlDocument doc = InitialiazeXMLDocument();
            string xpath = "calendar/appointment[@ID='2']";
            var expectedString = "2015/12/25Second itemThis is my second XML test";

            var resultString = XMLUtils.GetValueOfXmlElement(xpath, doc);
            
            resultString.ShouldEqual(expectedString);
        }

        [TestMethod]
        public void ShouldListOneValueOfNodeFromXML()
        {
            XmlDocument doc = InitialiazeXMLDocument();
            string xpath = "calendar/appointment[@ID='2']/description";
            var expectedString = "This is my second XML test";

            var resultString = XMLUtils.GetValueOfXmlElement(xpath, doc);

            resultString.ShouldEqual(expectedString);
        }

        [TestMethod]
        public void ShouldSetValueOfNodeToXML()
        {
            XmlDocument doc = InitialiazeXMLDocument();
            string xpath = "calendar/appointment[@ID='2']/description";
            string newValue = "This is my modified second XML test";

            var resultString = XMLUtils.SetValueOfXmlElement(xpath, newValue,doc);

            resultString.ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldAddANewNodeToXML()
        {
            XmlDocument doc = InitialiazeXMLDocument();
            string ID = "3";
            string data = "2015/12/18";
            string title = "@Rares #bday";
            string description = "don't forget to #call him";

            var result = XMLUtils.AddNewNodeToXmlDocument(ID, data, title, description,ref doc);

            result.ShouldBeTrue();
        }

        [TestMethod]
        public void ShouldAddAppointmentsToXMLFile()
        {
            XmlDocument doc = InitialiazeXMLDocument();
            List<Event> eventsList = new List<Event>{
            new Event("2015/12/27","One","One test"),
            new Event("2015/11/25", "Two") };
            Events newAppoinments = new Events(eventsList);

            //XMLUtils.AddNewEventsToXMLFile(newAppoinments);

        }

        [TestMethod]
        public void ShouldListLastIDValueFromXML()
        {
            XmlDocument doc = InitialiazeXMLDocument();
            string xpath = "(calendar/appointment)[last()]";
            var expectedString = "2";

            var resultString = XMLUtils.GetIDFromNodeAttribute(xpath,doc);
                        
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

        private static XmlDocument InitialiazeXMLDocument()
        {
            XmlDocument doc = new XmlDocument();
            string xmlData = @"<calendar><appointment ID=""1""><data>2015/12/20</data><title>First item</title><description>This is my first XML test</description></appointment><appointment ID=""2""><data>2015/12/25</data><title>Second item</title><description>This is my second XML test</description></appointment></calendar>";
            doc.LoadXml(xmlData);
            return doc;
        }
    }
}
