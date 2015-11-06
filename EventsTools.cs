using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Calendar
{
    public class EventsTools
    {
        Events eventsList;

        public EventsTools()
        {
            eventsList = new Events();
        }

        public Events ExtractEventsFromCalendar(Events eventsList, string parameter)
        {
            Events resultList = new Events();
            SubList(eventsList, resultList, parameter);
            return resultList;
        }

        private static void SubList(Events eventsList, Events resultList, string parameter)
        {
            foreach (Event eventL in eventsList)
            {
                if (ShouldBeListed(eventL, parameter))
                {
                    resultList.Add(eventL);
                }
            }

        }

        private static bool ShouldBeListed(Event eventL, string parameter)
        {
            if ((parameter == "past") && (eventL.Older() < 0)) return true;
            if ((parameter == "future") && (eventL.Older() >= 0)) return true;
            return false;
        }


        private void ExportEvents(string path, Events eventsList)
        {

            path += ".html";
            Console.WriteLine("\n\tExporting file...");
            CreateHtmlFile(path, eventsList);

        }

        public void CreateHtmlFile(string path, Events eventsList)
        {

            string beginTags = "<!DOCTYPE html>\n<html>\n<head>\n<title>Events List</title>\n</head>\n<body>";
            string endTags = "\n</body>\n</html> ";
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.Write(beginTags);
                    foreach (Event ev in eventsList)
                    {
                        string htmlData = "";
                        htmlData += "<p>Date: " + ev.Date+"</p>\n"  ;
                        htmlData += "<p>Subject: " + ev.Subject + "</p>\n";
                        htmlData += "<p>Description: " + DecodingNewLineChar(ev.Description) + "</p>\n";
                        htmlData += "<br>" + "</br>";
                        w.Write(htmlData);
                    }
                    w.Write(endTags);
                }
            }
        }
        private string CodingNewLineChar(string value)
        {
            return (value.Replace('\n', '\a'));
        }

        private string DecodingNewLineChar(string value)
        {
            return (value.Replace('\a', '\n'));
        }

    }
}