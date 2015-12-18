using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Calendar
{
    public class XMLUtils
    {
        const string calendarXMLFile = @"calendar.xml";
        public static string GetValueOfXmlElementAtXpath_XmlFromFile(string xpath)
        {
            string result = "";
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(calendarXMLFile);
                result = GetValueOfXmlElement(xpath, xmlDocument);
            }
            catch 
            { }
            return result;
        }

        public static string GetValueOfXmlElement(string xpath, XmlDocument xmlDocument)
        {
            string result = "";
            XmlNode element = xmlDocument.SelectSingleNode(xpath);
            if (element != null)
            {
                result = element.InnerText;
            }
            return result;
        }

        public static List<string> GetValuesOfXmlElementAtXpath_XmlFromFile(string xpath)
        {
            List<string> result = new List<string>();
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(calendarXMLFile);
                result = GetValuesOfAllXmlElements(xpath, xmlDocument);
            }
            catch (Exception)
            { }
            return result;
        }

        public static List<string> GetValuesOfAllXmlElements(string xpath, XmlDocument xmlDocument)
        {
            List<string> result = new List<string>();
            XmlNodeList nodeList = xmlDocument.SelectNodes(xpath);
            if (nodeList != null)
            {
                foreach (XmlNode node in nodeList)
                {
                    result.Add(node.InnerText);
                }
            }
            return result;
        }

        public static bool SetValueOfXmlElementAtXpath_XmlFromFile(string xpath, string newValue)
        {
            bool result = false;
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(calendarXMLFile);
                result = SetValueOfXmlElement(xpath, newValue, xmlDocument);
            }
            catch (Exception)
            { }
            return result;
        }

        public static bool SetValueOfXmlElement(string xpath, string newValue, XmlDocument xmlDocument)
        {
            bool result = false;
            XmlNode element = xmlDocument.SelectSingleNode(xpath);
            if (element != null)
            {
                element.InnerText = newValue;
                result = true;
                xmlDocument.Save(calendarXMLFile);
            }

            return result;
        }

        public static bool AddNewEventToXMLFile(string ID, string data, string title, string description = "")
        {
            bool result = false;
            if (!File.Exists(calendarXMLFile))
            {
                Console.WriteLine("\n\tThe source file does not exist! There are no events added to calendar!");
                CreateEmptyXMLFile();
            }
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(calendarXMLFile);
                result = true;
                AddNewNodeToXmlDocument(ID, data, title, description, ref xmlDocument);
                xmlDocument.Save(calendarXMLFile);
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\t Exception: {0} ", e.Message);

            }
            return result;
        }

        public static bool AddNewNodeToXmlDocument(string ID, string data, string title, string description, ref XmlDocument xmlDocument)
        {
            bool result = false;
            try
            {
                XmlElement appointmentElement = CreateNewXMLAppointment(ID, data, title, description);
                XmlNode importNode = xmlDocument.ImportNode(appointmentElement, true);
                xmlDocument.DocumentElement.AppendChild(importNode);
                result = true;
            }
            catch { };
            return result;
        }

        private static XmlElement CreateNewXMLAppointment(string ID, string data, string title, string description)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement appointmentElement = xmlDocument.CreateElement("appointment");
            appointmentElement.SetAttribute("ID", ID);

            XmlElement dataElement = xmlDocument.CreateElement("data");
            dataElement.InnerText = data;
            appointmentElement.AppendChild(dataElement);

            XmlElement titleElement = xmlDocument.CreateElement("title");
            titleElement.InnerText = title;
            appointmentElement.AppendChild(titleElement);
            if (description != "")
            {
                XmlElement descriptionElement = xmlDocument.CreateElement("description");
                descriptionElement.InnerText = description;
                appointmentElement.AppendChild(descriptionElement);
            }

            return appointmentElement;
        }

        public static bool AddNewEventsToXMLFile(Events eventsList)
        {
            bool result = false;
            if (!File.Exists(calendarXMLFile))
            {
                Console.WriteLine("\n\tThe source file does not exist! There are no events added to calendar!");
                CreateEmptyXMLFile();
            }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(calendarXMLFile);
                xmlDocument = AddEventsToXmlDocument(eventsList, xmlDocument);
                xmlDocument.Save(calendarXMLFile);
                Console.WriteLine("\tFile saved. Calendar contains {0} events. ", eventsList.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : {0}  ", e.Message);
                result = false;
            }
            return result;
        }

        public static XmlDocument AddEventsToXmlDocument(Events eventsList, XmlDocument xmlDocument)
        {
            string lastID = GetLastIDFromXMLFile();
            var ID = Int32.Parse(lastID);

            foreach (Event eventL in eventsList)
            {
                ID++;
                AddNewNodeToXmlDocument(ID.ToString(), eventL.Date.ToString("yyyy/MM/dd").ToString(), eventL.Title, eventL.Description, ref xmlDocument);
            }

            return xmlDocument;
        }

        private static void CreateEmptyXMLFile()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode productsNode = doc.CreateElement("calendar");
            doc.AppendChild(productsNode);
            doc.Save(calendarXMLFile);
        }

        public static Events LoadEventsFromXMLFile()
        {
            if (!File.Exists(calendarXMLFile))
            {
                Console.WriteLine("\n\tThe source file does not exist! There are no events added to calendar!");
                return null;
            }
            else
            {
                return GetEventsListFromXMLFile(); ;
            }
        }

        private static Events GetEventsListFromXMLFile()
        {
            Events list = new Events();
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(calendarXMLFile);
                list = GetEventsListFromXmlDocument(xmlDocument);
            }
            catch
            { }
            return list;
        }

        public static Events GetEventsListFromXmlDocument(XmlDocument xmlDocument)
        {
            Events list = new Events();
            var xpath = "calendar/appointment";
            XmlNodeList nodeList = xmlDocument.SelectNodes(xpath);

            if (nodeList != null)
            {
                foreach (XmlNode node in nodeList)
                {
                    string data, title, description;
                    GetAllValuesOfNodeChilds(node, out data, out title, out description);
                    list.Add(new Event(data, title, description));
                }
            }
            return list;
        }

        public static string GetLastIDFromXMLFile()
        {
            string xpath = "(calendar/appointment)[last()]";
            var ID = GetValueOfIDFromXMLFile(xpath);
            return (ID == "") ? "0" : ID;
        }
        public static string GetValueOfIDFromXMLFile(string xpath)
        {
            string result = "";
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(calendarXMLFile);
                result = GetIDFromNodeAttribute(xpath, xmlDocument);
            }
            catch
            { }
            return result;
        }

        public static string GetIDFromNodeAttribute(string xpath, XmlDocument xmlDocument)
        {
            string result = "";
            XmlNode element = xmlDocument.SelectSingleNode(xpath);
            if (element != null)
            {
                result = element.Attributes["ID"].Value;
            }
            return result;
        }

        private static void GetAllValuesOfNodeChilds(XmlNode node, out string data, out string title, out string description)
        {
            var id = node.Attributes["ID"].Value;
            data = node["data"].InnerText;
            title = node["title"].InnerText;
            if (node.ChildNodes.Count == 3)
            {
                description = node["description"].InnerText;
            }
            else
            { description = ""; }
        }
    }
}
