using System;
using System.Collections.Generic;
using System.IO;

namespace Calendar
{
    public class Events
    {
        private static string calendarFile = @"Calendar.txt";
        public List<Event> calendar = new List<Event>();
        List<Event> pastEvents = new List<Event>();
        List<Event> futureEvents = new List<Event>();

        public List<Event> Calendar
        {
            set { calendar = value; }
            get { return calendar; }
        }

        public void AddEvent(string date, string subject, string description)
        {
            Event newEvent = new Event(date + "\t" + subject + "\t" + description);
            if (newEvent.Subject != null)
            {
                calendar.Add(newEvent);
            }
        }

        public void LoadCalendar()
        {
            if (!File.Exists(calendarFile))
            {
                Console.WriteLine("\n\tThe file does not exist! There are no events added to calendar!");
                return;
            }
            StreamReader file = new StreamReader(calendarFile);

            string[] lines = File.ReadAllLines(calendarFile);
            foreach (string line in lines)
            {
                Event item = new Event(line);
                calendar.Add(item);
            }
            file.Close();
        }

        public void DisplayEvents(string option)
        {
            switch (option)
            {
                case "future":
                    {
                        ExtractEvents();
                        DisplayToConsole(futureEvents);
                        break;
                    }
                case "past":
                    {
                        ExtractEvents();
                        DisplayToConsole(pastEvents);
                        break;
                    }
                case "all":
                    {
                        DisplayToConsole(calendar);
                        break;
                    }
            }
        }

        private void DisplayToConsole(List<Event> listToDisplay)
        {
            listToDisplay.Sort();
            for (int i = 0; i < listToDisplay.Count; i++)
            {
                Console.Write("Date:{0} \tEvent:{1} \tDescription:{2}", listToDisplay[i].Date.ToShortDateString(), listToDisplay[i].Subject, listToDisplay[i].Description);
                Console.Write("\n");
            }
        }

        private void ExtractEvents()
        {
            for (int i = 0; i < calendar.Count; i++)
            {
                if (calendar[i].Older() < 0)
                    pastEvents.Add(calendar[i]);
                else
                    futureEvents.Add(calendar[i]);
            }
        }

        public void SaveEvents()
        {
            StreamWriter file = new StreamWriter(calendarFile);
            for (int i = 0; i < calendar.Count; i++)
            {
                file.Write(calendar[i].Date + "\t" + calendar[i].Subject + "\t" + calendar[i].Description);
                file.Write(file.NewLine);
            }
            file.Close();
            Console.WriteLine("\tFile saved. Calendar contains {0} events. ", calendar.Count);
        }
    }
}