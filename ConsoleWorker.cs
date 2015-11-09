using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Calendar
{
    public class ConsoleWorker
    {
        Events eventsList;

        public ConsoleWorker(List <Event> list)
        {
         eventsList=new Events(list);
        }

        public ConsoleWorker(Events list)
        {
            eventsList = list;
        }

        public ConsoleWorker()
        {
            eventsList = new Events();
        }

        public void AddDataFromConsole(string date, string subject, string description)
        {
            WorkingFiles file = new WorkingFiles();
            eventsList = file.LoadEventsFromFile();
            eventsList.Add(date, subject, description);
            file.SaveEventsToFile(eventsList);
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
            Utils tools = new Utils();
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