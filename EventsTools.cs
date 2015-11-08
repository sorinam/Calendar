using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

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
        {   string beginTags = "<!DOCTYPE html>\n<html>\n<head>\n<title>Events List</title>\n</head>\n<body>";
            string endTags = "\n</body>\n</html> ";
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                    {
                        w.Write(beginTags);
                        foreach (Event ev in eventsList)
                        {
                            string htmlData = "";
                            htmlData += "<p><b>Date:</b> " + ev.Date + "</p>\n";
                            htmlData += "<p><b>Subject:</b> " + DecodingNewLineCharForHTML(DecodingNewLineChar(ev.Subject)) + "</p>";
                            htmlData += "<p><b>Description:</b> " + DecodingNewLineCharForHTML(DecodingNewLineChar(ev.Description)) + "</p>";
                            htmlData += "<hr>";
                            w.Write(htmlData);
                        }
                        w.Write(endTags);
                    }
                }
                Console.WriteLine("\n{0} events were exported in '{1}' file .\n", eventsList.Length, path);
            }
            catch (IOException e)
            {
                Console.WriteLine("The file path didn't find!");
            }
            }

        public void AddDataFromConsole(string date, string subject, string description)
        {
            WorkingFiles file = new WorkingFiles();
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

        private string DecodingNewLineCharForHTML(string value)
        {
            Regex regex = new Regex(@"(\r\n|\r|\n)+");
            return regex.Replace(value, "<br />");
        }

        public void DisplayEventsToConsole()
        {
            if (eventsList.Length > 0)
            {
                DisplayToConsole();
            }
            else
            {
                Console.WriteLine("\n There are no events!");
            }

        }

        private void DisplayToConsole()
        {
            eventsList.Sort();
            foreach (Event line in eventsList)
            {
                Console.Write("\nDate:{0} \nEvent:{1} ", line.Date.ToShortDateString(), line.Subject.Replace('\a', '\n'));
                if (line.Description != "") Console.Write("\nDescription:{0}", line.Description.Replace('\a', '\n'));
                Console.Write("\n");
            }
            Console.WriteLine("\n\tThe events were listed. There are {0} events. ", eventsList.Length);
        }

    }
}