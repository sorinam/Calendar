using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Calendar
{
    public class WorkingFiles
    {
        const string calendarPath = @"C:\Users\sori\Documents\Calendar\bin\Debug\Calendar.txt";

        public Events LoadEventsFromFile()
        {
            string[] fileContent = LoadEventsFromFileToArray();
            Events list = new Events(fileContent);
            return list;
        }

        public string[] LoadEventsFromFileToArray()
        {
            string[] lines;

            if (!File.Exists(calendarPath))
            {
                Console.WriteLine("\n\tThe source file does not exist! There are no events added to calendar!");
                return null;
            }
            using (FileStream fs = new FileStream(calendarPath, FileMode.Open))
            {
                StreamO streamObj = new StreamO(fs);
                lines = streamObj.GetLinesFromStream();
            };
            return lines;
        }

        public void SaveEventsToFile(Events eventsList)
        {
            StreamWriter file = new StreamWriter(calendarPath);
            foreach (Event eventL in eventsList)
            {
                file.Write(eventL.Date + "\t" + eventL.Subject + "\t" + eventL.Description);
                file.Write(file.NewLine);
            }
            file.Close();

            Console.WriteLine("\tFile saved. Calendar contains {0} events. ", eventsList.Length);
        }

       
    }
}