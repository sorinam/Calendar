using System;
using System.Collections.Generic;
using System.IO;

namespace Calendar
{
    public class Events
    {
        private static string calendarFile = @"Calendar.txt";
        private static List<Event> calendar = new List<Event>();

        public static List<Event> Calendar
        {
            set { calendar = value; }
            get { return calendar; }
        }

        public static void AddEvent( DateTime date, string subject)
        {
            Event newEvent = new Event();
            newEvent.Subject = subject;
            newEvent.Date = date;
            calendar.Add(newEvent);
        }

        public static void LoadCalendar()
        {
            if (!File.Exists(calendarFile))
            {
                Console.WriteLine("\n\tThe file does not exist! There are no events added to calendar!");
                return;
            }
            System.IO.StreamReader file = new System.IO.StreamReader(calendarFile);

            string[] lines = System.IO.File.ReadAllLines(calendarFile);
            foreach (string line in lines)
            {
                int separatorPosition = line.IndexOf("\t");
                Event item = new Event();
                item.Date = Convert.ToDateTime(line.Substring(0, separatorPosition));
                item.Subject = line.Substring(separatorPosition + 1);
               
                calendar.Add(item);
            }
        }

        public static void DisplayCalendar()
        {
            for (int i = 0; i < calendar.Count; i++)
            {
                Console.WriteLine("\t Date: {0},  Event: {1}", calendar[i].Date, calendar[i].Subject);
            }
        }

        public static void SaveEvents()
        {
            StreamWriter file = new StreamWriter(calendarFile);
            for (int i = 0; i < calendar.Count; i++)
            {
                file.Write(calendar[i].Date);
                file.Write("\t" + calendar[i].Subject);
                file.Write(file.NewLine);
            }

            file.Close();
            Console.WriteLine("\tFile saved. {0} notes saved", calendar.Count);
        }
    }
}