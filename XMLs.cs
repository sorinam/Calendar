using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace Calendar
{
    public class XMLUtils
    {
        const string fileName=@"ncalendar.xml";
        public static string GetValueOfXmlElementAtXpath_XmlFromFile(string xpath)
        {
            string result = "";
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
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
                xmlDocument.Load(fileName);
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
                xmlDocument.Load(fileName);
                XmlNode element = xmlDocument.SelectSingleNode(xpath);
                if (element != null)
                {
                    element.InnerText = newValue;
                    result = true;
                    xmlDocument.Save(fileName);
                }
            }
            catch (Exception)
            { }
            return result;
        }

        public static bool AddNewAppointmentElementToXMLFile(string ID,string data, string title, string description="")
        {
            bool result=false ;
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
                result = true;
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
                xmlDocument.Save(fileName);
            }
            catch (Exception e )
            {
                CreateEmptyXMLFile();
            }
            return result;
        }

        private static void CreateEmptyXMLFile()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode productsNode = doc.CreateElement("calendar");
            doc.AppendChild(productsNode);

            //XDocument doc = new XDocument(
            //    new XDeclaration("1.0", "utf-8", "yes"),
            //    new XComment("XML File for storing appointments"));
            //doc.Add(new XElement("root",new XElement("kkk")));
            doc.Save(fileName);

        }

        public static string GetValueOfIDFromXMLFile(string xpath)
        {
            string result = "";
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileName);
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
    }
}
