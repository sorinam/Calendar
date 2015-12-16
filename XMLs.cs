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
                XmlNode element = xmlDocument.SelectSingleNode(xpath);
                if (element != null)
                {
                    result = element.InnerText;
                }
            }
            catch (Exception e)
            { }
            return result;
        }

        public static List<string> GetValuesOfXmlElementAtXpath_XmlFromFile(string xpath)
        {
            List<string> result = new List<string>();
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(calendarXMLFile);
                XmlNodeList nodeList = xmlDocument.SelectNodes(xpath);
                if (nodeList != null)
                {
                    foreach (XmlNode node in nodeList)
                    {
                        result.Add(node.InnerText);
                    }
                }
            }
            catch (Exception)
            { }
            return result;
        }

        public static bool SetValueOfXmlElementAtXpath_XmlFromFile(string xpath, string newValue)
        {
            bool result = false;
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(calendarXMLFile);
                XmlNode element = xmlDocument.SelectSingleNode(xpath);
                if (element != null)
                {
                    element.InnerText = newValue;
                    result = true;
                    xmlDocument.Save(calendarXMLFile);
                }
            }
            catch (Exception)
            { }
            return result;
        }

        public static bool AddNewAppointmentElementToXMLFile(string ID, string data, string title, string description = "")
        {
            bool result = false;
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(calendarXMLFile);
                result = true;
                AddNewAppoimnetElement(ID, data, title, description);

            }
            catch (Exception e)
            {
                if (e.GetType().Name == "FileNotFoundException")
                {
                    result = true;
                    CreateEmptyXMLFile();
                    AddNewAppoimnetElement(ID, data, title, description);
                }
            }
            return result;
        }

        private static void AddNewAppoimnetElement(string ID, string data, string title, string description)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(calendarXMLFile);
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

            xmlDocument.DocumentElement.AppendChild(appointmentElement);
            xmlDocument.Save(calendarXMLFile);
        }

        private static void CreateEmptyXMLFile()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode productsNode = doc.CreateElement("calendar");
            doc.AppendChild(productsNode);
            doc.Save(calendarXMLFile);
        }

        public static string GetValueOfIDFromXMLFile(string xpath)
        {
            string result = "";
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(calendarXMLFile);
                XmlNode element = xmlDocument.SelectSingleNode(xpath);
                if (element != null)
                {
                    result = element.Attributes["ID"].Value;
                }
            }
            catch (Exception e)
            { }
            return result;
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
                return GetEventsList(); ;
            }

        }

        private static Events GetEventsList()
        {
            Events list = new Events();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(calendarXMLFile);

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
