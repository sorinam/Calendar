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

        public EventsTools(List <Event> list)
        {
         eventsList=new Events(list);
        }

        public EventsTools(Events list)
        {
            eventsList = list;
        }

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
            Console.WriteLine("\n\tExporting file...");
            ExportToHTMLFile(path);
        }

        public void ExportToHTMLFile(string path)
        {
            if (File.Exists(path)) File.Delete(path);

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
                        htmlData += "<p>Subject: " + DecodingNewLineChar(ev.Subject) + "</p>\n";
                        htmlData += "<p>Description: " + DecodingNewLineChar(ev.Description) + "</p>\n";
                        htmlData += "<br>" + "</br>";
                        w.Write(htmlData);
                    }
                    w.Write(endTags);
                }
            }
            Console.WriteLine("\n{0} events were exported in '{1}' file .\n",eventsList.Length, path);
        }

        public void AddDataFromConsole(string date, string subject, string description)
        {
            IOFiles file = new IOFiles();
            eventsList = file.LoadEventsFromFile();
            eventsList.Add(date, subject, description);
            file.SaveEventsToFile(eventsList);
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