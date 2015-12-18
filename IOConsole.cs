namespace Calendar
{
    using System;
    using System.Collections.Generic;

    public class IOConsole
    {
        Events eventsList;

        public IOConsole(List<Event> list)
        {
            eventsList = new Events(list);
        }

        public IOConsole(Events list)
        {
            eventsList = list;
        }

        public IOConsole()
        {
            eventsList = new Events();
        }

        public void AddDataFromConsole(string date, string title, string description)
        {
            //TXTFile file = new TXTFile();
            //eventsList = file.LoadEventsFromFile();
            //eventsList = XMLUtils.LoadEventsFromXMLFile();

            string lastID = XMLUtils.GetLastIDFromXMLFile();
            var iD = int.Parse(lastID) + 1;
            XMLUtils.AddNewEventToXMLFile(iD.ToString(), date, title, description);
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
                Console.Write(" \nTitle:{0}", Utils.DecodingNewLineChar(line.Title));
                if (line.Description != string.Empty)
                {
                    Console.Write(" \nDescription:{0}", Utils.DecodingNewLineChar(line.Description));
                }

                Console.Write("\n");
            }
            Console.WriteLine("\n\tThe events were listed. There are {0} events. ", eventsList.Length);
        }

        public void DisplayTagsAndCountersToConsole(Tag[] tagValues)
        {
            if (tagValues.Length == 0)
            {
                Console.WriteLine("\n There are not defined tags. ");
            }
            else
            {
                Console.WriteLine("\nThere are {0} defined tags :\n ", tagValues.Length);
                for (int i = 0; i < tagValues.Length; i++)
                {
                    Console.WriteLine(" {0}\t:{1} event(s)", tagValues[i].Name, tagValues[i].Count);
                }
            }

        }
    }
}