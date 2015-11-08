using System;
using System.Collections.Generic;
using System.IO;
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

        private void ExportEvents(string path)
        { try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    Console.WriteLine("\n\tExporting file...");
                    StreamO stremObj = new StreamO(fs);
                    stremObj.ExportEventsInHTMLStream(eventsList);
                  }
                Console.WriteLine("\n{0} events were exported in '{1}' file .\n", eventsList.Length, path);
            }
            catch (IOException e)
            {
                Console.WriteLine("The file path didn't find!");
            }
        }

        public void ExportToHTMLFile(string path)
        {
            if (eventsList.Length > 0)
            {
                ExportEvents(path);
            }
            else
            {
                Console.WriteLine("\n\tThere are no events to export!");
            }
         }

        public void AddDataFromConsole(string date, string subject, string description)
        {
            WorkingFiles file = new WorkingFiles();
            eventsList = file.LoadEventsFromFile();
            eventsList.Add(date, subject, description);
            file.SaveEventsToFile(eventsList);
        }

        public string CodingNewLineChar(string value)
        {
            return (value.Replace('\n', '\a'));
        }

        public string DecodingNewLineChar(string value)
        {
            return (value.Replace('\a', '\n'));
        }

        public string DecodingNewLineCharForHTML(string value)
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
                Console.WriteLine("\n\tThere are no events to list!");
            }
        }

        private void DisplayToConsole()
        {
            EventsTools tools = new EventsTools();
            eventsList.Sort();
            foreach (Event line in eventsList)
            {
                Console.Write("\nDate:{0} \nEvent:{1} ", line.Date.ToString("yyyy/MM/dd"), tools.DecodingNewLineChar(line.Subject));
                if (line.Description != "") Console.Write("\nDescription:{0}", tools.DecodingNewLineChar(line.Description));
                Console.Write("\n");
            }
            Console.WriteLine("\n\tThe events were listed. There are {0} events. ", eventsList.Length);
        }
    }
}