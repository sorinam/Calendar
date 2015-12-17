﻿using System;
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
                AddNewAppoinmetElement(ID, data, title, description);
                //xmlDocument.Save(calendarXMLFile);
            }
            catch (Exception e)
            {
                if (e.GetType().Name == "FileNotFoundException")
                {
                    result = true;
                    CreateEmptyXMLFile();
                    AddNewAppoinmetElement(ID, data, title, description);
                                  }
            }
            return result;
        }

        private static void AddNewAppoinmetElement(string ID, string data, string title, string description)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(calendarXMLFile);

            XmlElement appointmentElement = CreateNewXMLAppointment(ID, data, title, description);
            xmlDocument.DocumentElement.AppendChild(appointmentElement);
            xmlDocument.Save(calendarXMLFile);

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

        public static void SaveEventsToXMLFile(Events eventsList)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(calendarXMLFile);

            string lastID = GetLastIDFromXMLFile();
            var ID=Int32.Parse(lastID);

            foreach (Event eventL in eventsList)
            {
                ID++;
                XmlElement appointmentElement = CreateNewXMLAppointment(ID.ToString(), eventL.Date.ToString("yyyy/MM/dd").ToString(), eventL.Title, eventL.Description);
                XmlNode importNode = xmlDocument.ImportNode(appointmentElement, true);
                xmlDocument.DocumentElement.AppendChild(importNode);
            }
            xmlDocument.Save(calendarXMLFile);

            Console.WriteLine("\tFile saved. Calendar contains {0} events. ", eventsList.Length);
        }

        public static string GetLastIDFromXMLFile()
        {
            string xpath = "(calendar/appointment)[last()]";
            var ID=GetValueOfIDFromXMLFile(xpath);
            return (ID == "") ? "0" : ID;
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