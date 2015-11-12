using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public static class Dispenser
    {
        public static void AddEvents(string[] args)
        {
            ConsoleWorker newEvent = new ConsoleWorker();
            string date = args[1]; ;
            string subject = Utils.CodingNewLineChar(args[2]);
            string description = "";
            if (args.Length == 4)
            {
                description = Utils.CodingNewLineChar(args[3]);
            }
            newEvent.AddDataFromConsole(date, subject, description);

        }

        public static void DisplayEvents(string parameter)
        {
            FileDocument files = new FileDocument();
            Events eventsList = files.LoadEventsFromFile();
            ConsoleWorker display = new ConsoleWorker(eventsList);

            if (parameter == "all")
            {
                display.DisplayEventsToConsole();
            }
            else
            {
                Events eventsToDisplay = eventsList.GetFilteredEventsByToday(parameter);
                ConsoleWorker toDisplay = new ConsoleWorker(eventsToDisplay);
                toDisplay.DisplayEventsToConsole();
            }
        }

        public static void ExportEvents(string[] args)
        {
            FileDocument files = new FileDocument();
            Events eventsList = files.LoadEventsFromFile();
            eventsList.Sort();
            if (args.Length == 2)
            {
                ExportToHTMLFile(@args[1], eventsList);
            }
            else
            {
                ConsoleWorker evTools = new ConsoleWorker();
                Events eventsToExport = eventsList.GetFilteredEventsByToday(args[1].ToLower());
                ExportToHTMLFile(@args[2], eventsToExport);
            }

        }

        public static void ExportToHTMLFile(string path, Events eventsList)
        {
            HTMLDocument exportHtml = new HTMLDocument(eventsList);
            exportHtml.ExportToHTMLFile(path);
        }

        public static void SearchEvents(string[] args)
        {
            FileDocument files = new FileDocument();
            Events eventsList = files.LoadEventsFromFile();

            SearchAndExport(args, eventsList);

        }

        public static Events SearchAndExport(string[] args, Events eventsList)
        {
            int indexExport = GetIndexOfExportParameter(args);

            string[] searchArgs = new string[args.Length];

            if (indexExport > 0)
            {
                Array.Resize(ref searchArgs, indexExport);
                Array.Copy(args, searchArgs, indexExport);
            }
            else
            {
                searchArgs = args;
            }

            Events filteredList = FilterEvents(eventsList, searchArgs);

            ConsoleWorker toDisplay = new ConsoleWorker(filteredList);
            toDisplay.DisplayEventsToConsole();

            if (indexExport > 0)
            {
                ExportToHTMLFile(args[indexExport + 1], filteredList);
            }
            return filteredList;
        }

        private static Events FilterEvents(Events eventsList, string[] searchArgs)
        {
            Events filteredList = new Events();

            switch (searchArgs[1])
            {
                case "date":
                    {
                        filteredList = GetFilteredListByDate(eventsList, ref searchArgs);
                        break;
                    }
                case "description":
                    {
                        filteredList = GetFilteredListByDescription(eventsList, searchArgs);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid parameter!");
                        break;
                    }
            }

            return filteredList;
        }

        public static Events GetFilteredListByDescription(Events eventsList, string[] parameter)
        {
            Events filteredList = new Events();
            switch (parameter.Length)
            {
                case 3:
                    {
                        string criteria = "=";
                        filteredList = DescriptionFiltering(eventsList, criteria,parameter[2]);
                        break;
                    }
                case 4:
                    {
                        filteredList = DescriptionFiltering(eventsList, parameter[2], parameter[3]);
                        break;
                    }
               
            }
            return filteredList;
        }

        public static Events GetFilteredListByDate(Events eventsList, ref string[] parameter)
        {
            Events filteredList = new Events();
            switch (parameter.Length)
            {
                case 3:
                    {
                        string criteria = "=";
                        string date = parameter[2];
                        if (parameter[2] == "today")
                        {
                            parameter[2] = DateTime.Today.ToShortDateString();
                        }
                        filteredList = SimpleDateFiltering(eventsList, criteria, parameter[2]);
                        break;
                    }
                case 4:
                    {
                       filteredList = SimpleDateFiltering(eventsList, parameter[2],parameter[3]);
                       break;
                    }
                case 5:
                    {
                      filteredList = DoubleDateFiltering(eventsList, parameter);
                      break;
                    }
            }
            return filteredList;
        }

        private static Events DoubleDateFiltering(Events eventsList, string[] parameter)
        {
            string firstCriteria = "<";
            string secondCriteria = ">";
           
            Events firstFilteredList = SimpleDateFiltering(eventsList, firstCriteria, parameter[4]);
            Events filteredList = SimpleDateFiltering(firstFilteredList, secondCriteria, parameter[3]);
            return filteredList;
        }

        private static Events SimpleDateFiltering(Events eventsList, string criteria, string value)
        {
            DateFilter eventsToFilter = new DateFilter(Utils.ParseFilteringCriteria(criteria),value);
            return eventsToFilter.ApplyFilter(eventsList);
       }
        private static Events DescriptionFiltering(Events eventsList, string criteria, string value)
        {
            DescriptionFilter eventsToFilter = new DescriptionFilter(Utils.ParseFilteringCriteria(criteria), value);
            return eventsToFilter.ApplyFilter(eventsList);
        }
        private static int GetIndexOfExportParameter(string[] args)
        {
            int index = Array.IndexOf(args, "/export");
            return index;
        }
    }
}
