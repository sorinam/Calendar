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
            IOConsole newEvent = new IOConsole();
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
            TXTFile files = new TXTFile();
            Events eventsList = files.LoadEventsFromFile();
            IOConsole display = new IOConsole(eventsList);

            if (parameter == "all")
            {
                display.DisplayEventsToConsole();
            }
            else
            {
                string criteria = Utils.ParseFilteringCriteria(parameter);
                Events eventsToDisplay = SimpleDateFiltering(eventsList, criteria, DateTime.Today.ToShortDateString());
                IOConsole toDisplay = new IOConsole(eventsToDisplay);
                toDisplay.DisplayEventsToConsole();
            }
        }

        public static void ExportEvents(string[] args)
        {
            TXTFile files = new TXTFile();
            Events eventsList = files.LoadEventsFromFile();
            eventsList.Sort();
            if (args.Length == 2)
            {
                ExportToHTMLFile(@args[1], eventsList);
            }
            else
            {
                IOConsole evTools = new IOConsole();
                string criteria = Utils.ParseFilteringCriteria(args[1]);
                Events eventsToExport = SimpleDateFiltering(eventsList, criteria, DateTime.Today.ToShortDateString());
                ExportToHTMLFile(@args[2], eventsToExport);
            }

        }

        public static void ExportToHTMLFile(string path, Events eventsList)
        {
            HTMLFile exportHtml = new HTMLFile(eventsList);
            exportHtml.ExportToHTMLFile(path);
        }

        public static void SearchEvents(string[] args)
        {
            TXTFile files = new TXTFile();
            Events eventsList = files.LoadEventsFromFile();

            SearchAndExportIfNecessary(args, eventsList);

        }

        public static Events SearchAndExportIfNecessary(string[] args, Events eventsList)
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

            IOConsole toDisplay = new IOConsole(filteredList);
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
                        filteredList = DescriptionFiltering(eventsList, criteria, parameter[2]);
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
                        if (parameter[2] == "today")
                        {
                            filteredList = GetTodayEvents(eventsList);
                        }
                        else
                        {
                            if (parameter[2] == ("this week"))
                            {
                                filteredList = GetThisWeekEvents(eventsList);
                            }
                            else
                                if (Utils.IsValidDate(parameter[2]))
                            {
                                filteredList = SimpleDateFiltering(eventsList, "=", parameter[2]);
                            }
                        }
                        break;
                    }
                case 4:
                    {
                        filteredList = SimpleDateFiltering(eventsList, parameter[2], parameter[3]);
                        break;
                    }
                case 5:
                    {
                        filteredList = DoubleDateFiltering(eventsList, parameter[3], parameter[4]);
                        break;
                    }
            }
            return filteredList;
        }

        private static Events GetThisWeekEvents(Events eventsList)
        {
            Events filteredList;
            string firstDayOfWeek, endDayOfWeek;
            Utils.GetBeginEndDaysOfThisWeek(DateTime.Today.ToShortDateString(), out firstDayOfWeek, out endDayOfWeek);
            filteredList = DoubleDateFiltering(eventsList, firstDayOfWeek, endDayOfWeek);
            return filteredList;
        }

        private static Events GetTodayEvents(Events eventsList)
        {
            Events filteredList;
            string criteria = "=";
            string today = DateTime.Today.ToShortDateString();
            filteredList = SimpleDateFiltering(eventsList, criteria, today);
            return filteredList;
        }

        private static Events DoubleDateFiltering(Events eventsList, string beginDate, string endDate)
        {
            string firstCriteria = "<";
            string secondCriteria = ">";

            Events firstFilteredList = SimpleDateFiltering(eventsList, firstCriteria, endDate);
            Events filteredList = SimpleDateFiltering(firstFilteredList, secondCriteria, beginDate);
            return filteredList;
        }

        private static Events SimpleDateFiltering(Events eventsList, string criteria, string value)
        {
            DateFilter eventsToFilter = new DateFilter(Utils.ParseFilteringCriteria(criteria), value);
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
