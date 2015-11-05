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
        const string calendarFile = @"Calendar.txt";
     
        public EventsEnum LoadFile()
        {
            //List <Event> listofEvents = new List <Event>(); 
            EventsEnum listOfEvents = new EventsEnum();
            if (!File.Exists(calendarFile))
            {
                Console.WriteLine("\n\tThe file does not exist! There are no events added to calendar!");
              }

            StreamReader file = new StreamReader(calendarFile);

            string[] lines = File.ReadAllLines(calendarFile);
            foreach (string line in lines)
            {
                Event item = new Event(line);
                //listofEvents.Add(item);
                listOfEvents.Add(item);
            }
            file.Close();

            return listOfEvents;
        }

        public void SaveToFile(EventsEnum eventsList)
        {
            int index = 0;
            StreamWriter file = new StreamWriter(calendarFile);
           foreach (Event ev in eventsList)
            {
                file.Write(ev.Date + "\t" + ev.Subject + "\t" + ev.Description);
                file.Write(file.NewLine);
                index++;
            }
            file.Close();
            Console.WriteLine("\tFile saved. Calendar contains {0} events. ", index);
        }

        public void DisplayToConsole(List <Event>  listToDisplay)
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
