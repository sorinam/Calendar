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

        public static void SearchAndExportEvents(string field,string op,string val1,string val2,string path)
        {
            TXTFile files = new TXTFile();
            Events eventsList = files.LoadEventsFromFile();
            Events filteredList = SearchEvents( eventsList,field, op, val1, val2);
            if (path != "")
            {
                ExportToHTMLFile(path, filteredList);
            }
        }

        public static Events SearchEvents(Events eventsList,string field, string op, string val1,string val2) 
            {
            Events filteredList = FilterEvents(eventsList,field, op, val1, val2);

            IOConsole toDisplay = new IOConsole(filteredList);
            toDisplay.DisplayEventsToConsole();
            return filteredList;
        }

        private static Events FilterEvents(Events eventsList, string field, string criteria, string firstValue, string secondValue)
        {
            Events filteredList = new Events();

            switch (field)
            {
                case "date":
                    {
                        filteredList = GetFilteredListByDate(eventsList, criteria,firstValue,secondValue);
                        break;
                    }
                case "description":
                    {
                        filteredList = GetFilteredListByDescription(eventsList, criteria, firstValue);
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

        public static Events GetFilteredListByDescription(Events eventsList, string criteria, string value)
        {
            DescriptionFilter eventsToFilter = new DescriptionFilter(Utils.ParseFilteringCriteria(criteria), value);
            return eventsToFilter.ApplyFilter(eventsList);
        }

        public static Events GetFilteredListByDate(Events eventsList, string op, string val1,string val2)
        {
            Events filteredList = new Events();

            if (Utils.ParseFilteringCriteria(op) == "<>")
                filteredList = DoubleDateFiltering(eventsList, val1, val2);
            else
                filteredList = SimpleDateFiltering(eventsList, op, val1);

            return filteredList;
        }
                
        private static Events DoubleDateFiltering(Events eventsList, string beginDate, string endDate)
        {
            string firstCriteria = "<=";
            string secondCriteria = ">=";

            Events firstFilteredList = SimpleDateFiltering(eventsList, firstCriteria, endDate);
            Events filteredList = SimpleDateFiltering(firstFilteredList, secondCriteria, beginDate);
            return filteredList;
        }

        private static Events SimpleDateFiltering(Events eventsList, string criteria, string value)
        {
            DateFilter eventsToFilter = new DateFilter(Utils.ParseFilteringCriteria(criteria), value);
            return eventsToFilter.ApplyFilter(eventsList);
        }
    }
}
