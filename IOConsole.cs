using System;
using System.Collections.Generic;

namespace Calendar
{
    public class IOConsole
    {
        Events eventsList;

        public IOConsole(List <Event> list)
        {
         eventsList=new Events(list);
        }

        public IOConsole(Events list)
        {
            eventsList = list;
        }

        public IOConsole()
        {
            eventsList = new Events();
        }

        public void AddDataFromConsole(string date, string subject, string title,string description)
        {
            TXTFile file = new TXTFile();
            eventsList = file.LoadEventsFromFile();
            eventsList.Add(date, subject, title,description);
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
            eventsList.Sort();
            foreach (Event line in eventsList)
            {
                Console.Write(" \nDate:{0}", line.Date.ToString("yyyy/MM/dd"));
                Console.Write(" \nSubject:{0}", Utils.DecodingNewLineChar(line.Subject));
                if (line.Title != "") Console.Write(" \nTitle:{0}", Utils.DecodingNewLineChar(line.Title));
                if (line.Description != "") Console.Write(" \nDescription:{0}", Utils.DecodingNewLineChar(line.Description));
                Console.Write("\n");
            }
            Console.WriteLine("\n\tThe events were listed. There are {0} events. ", eventsList.Length);
           
        }
    }
}