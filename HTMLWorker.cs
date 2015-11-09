using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class HTMLWorker
    {
        Events eventsList;

        public HTMLWorker(List<Event> list)
        {
            eventsList = new Events(list);
        }
        public HTMLWorker(Events list)
        {
            eventsList = list;
        }

        public HTMLWorker()
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
    }
}
