using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class IOFiles
    {
        static string calendarFile = @"Calendar.txt";

        public List <Event> LoadFile()
        {
            List <Event> listofEvents = new List <Event>(); 
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

        public void SaveToFile(List <Event> eventsList)
        {
            StreamWriter file = new StreamWriter(calendarFile);
            for (int i = 0; i < eventsList.Count; i++)
            {
                file.Write(eventsList[i].Date + "\t" + eventsList[i].Subject + "\t" + eventsList[i].Description);
                file.Write(file.NewLine);
            }
            file.Close();
            Console.WriteLine("\tFile saved. Calendar contains {0} events. ", eventsList.Count);
        }

        public void DisplayToConsole(List<Event> listToDisplay)
        {
            listToDisplay.Sort();
            for (int i = 0; i < listToDisplay.Count; i++)
            {
                Console.Write("Date:{0} \tEvent:{1} ", listToDisplay[i].Date.ToShortDateString(), listToDisplay[i].Subject.Replace('\a', '\n'));
                if (listToDisplay[i].Description != "") Console.Write("\tDescription:{0}", listToDisplay[i].Description.Replace('\a', '\n'));
                Console.Write("\n");
            }
        }

    }
}
