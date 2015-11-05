using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class IOFiles
    {   const string calendarFile = @"Calendar.txt";

        public Events LoadEventsFromFile()
        {
            Events listofEvents = new Events();

            if (!File.Exists(calendarFile))
            {
                Console.WriteLine("\n\tThe file does not exist! There are no events added to calendar!");
            }

            StreamReader file = new StreamReader(calendarFile);
            string[] lines = File.ReadAllLines(calendarFile);
            foreach (string line in lines)
            {
                Event item = new Event(line);
                listofEvents.Add(item);
            }
            file.Close();
            return listofEvents;
        }

        public void SaveEventsToFile(Events eventsList)
        {
           StreamWriter file = new StreamWriter(calendarFile);
           foreach (Event eventL in eventsList)
            {
                file.Write(eventL.Date + "\t" + eventL.Subject + "\t" + eventL.Description);
                file.Write(file.NewLine);
            }
            file.Close();
            Console.WriteLine("\tFile saved. Calendar contains {0} events. ", eventsList.Length);
        }

        public void DisplayEventsToConsole(Events listToDisplay)
        {
            listToDisplay.Sort();
            foreach (Event line in listToDisplay)
            {
                Console.Write("Date:{0} \tEvent:{1} ", line.Date.ToShortDateString(), line.Subject.Replace('\a', '\n'));
                if (line.Description != "") Console.Write("\tDescription:{0}", line.Description.Replace('\a', '\n'));
                Console.Write("\n");
            }
        }

    }
}
