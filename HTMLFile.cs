using System;
using System.Collections.Generic;
using System.IO;

namespace Calendar
{
    public class HTMLFile
    {
        Events eventsList;

        public HTMLFile(List<Event> list)
        {
            eventsList = new Events(list);
        }
        public HTMLFile(Events list)
        {
            eventsList = list;
        }

        public HTMLFile()
        {
            eventsList = new Events();
        }
        private void ExportEvents(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    Console.WriteLine("\n\tExporting file...");
                    IOStream stremObj = new IOStream(fs);
                    stremObj.ExportEventsInHTMLStream(eventsList);
                }
                Console.WriteLine("\n\t{0} events were exported in '{1}' file .\n", eventsList.Length, path);
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
    }
}
