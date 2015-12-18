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
            string title = Utils.CodingNewLineChar(args[2]);
            string description = "";
            if (args.Length == 4)
            {
                description = Utils.CodingNewLineChar(args[3]);
            }
            newEvent.AddDataFromConsole(date, title, description);

        }

        public static void DisplayEvents(string parameter)
        {
            //TXTFile files = new TXTFile();
            //Events eventsList = files.LoadEventsFromFile();
            Events eventsList = XMLUtils.LoadEventsFromXMLFile();

            if (eventsList != null)
            {
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
            else
            {
                Console.WriteLine("\n\tThere are no events to list!");
            }
        }

        public static void ExportEvents(string[] args)
        {
            //TXTFile files = new TXTFile();
            //Events eventsList = files.LoadEventsFromFile();

            Events eventsList = XMLUtils.LoadEventsFromXMLFile();
            if (eventsList != null)
            {
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
            else
            {
                Console.WriteLine("\n\tThere are no events to export!");
            }

        }

        public static void ExportToHTMLFile(string path, Events eventsList)
        {
            HTMLFile exportHtml = new HTMLFile(eventsList);
            exportHtml.ExportToHTMLFile(path);
        }

        public static void SearchAndExportEvents(string field, string op, string[] val, string path)
        {
            //TXTFile files = new TXTFile();
            //Events eventsList = files.LoadEventsFromFile();

            Events eventsList = XMLUtils.LoadEventsFromXMLFile();
            if (eventsList != null)
            {
                Events filteredList = SearchEvents(eventsList, field, op, val);

                if (path != "")
                {
                    ExportToHTMLFile(path, filteredList);
                }
            }
            else
            {
                Console.WriteLine("\n\tThere are no events !");
            }
        }

        public static Events SearchEvents(Events eventsList, string field, string op, string[] values)
        {
            Events filteredList = FilterEvents(eventsList, field, op, values);

            IOConsole toDisplay = new IOConsole(filteredList);
            toDisplay.DisplayEventsToConsole();
            return filteredList;
        }

        public static void ListAllTags(string sort)
        {
            //TXTFile files = new TXTFile();
            //Events eventsList = files.LoadEventsFromFile();

            Events eventsList = XMLUtils.LoadEventsFromXMLFile();
            if (eventsList != null)
            {
                TagsCounter tags = new TagsCounter(eventsList);
                switch (sort)
                {
                    case "byCount":
                        {
                            tags.SortTagsDescByCount();
                            break;
                        }
                    case "byName":
                        {
                            tags.SortTagsAscByName();
                            break;
                        }
                }
                Tag[] listTodispaly = tags.TagList.ToArray();
                new IOConsole().DisplayTagsAndCountersToConsole(listTodispaly);
            }
            else
            {
                Console.WriteLine("\n\tThere are no events !");
            }
        }


        public static Events FilterEvents(Events eventsList, string field, string criteria, string[] values)
        {
            Events filteredList = new Events();

            switch (field)
            {
                case "date":
                    {
                        string firstValue = values[0];
                        string secondValue = values[1];
                        filteredList = GetFilteredListByDate(eventsList, criteria, firstValue, secondValue);
                        break;
                    }
                case "description":
                    {
                        string firstValue = values[0];
                        filteredList = GetFilteredListByDescription(eventsList, criteria, firstValue);
                        break;
                    }
                case "tag":
                    {
                        filteredList = GetFilteredListByTag(eventsList, criteria, values);
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

        private static Events GetFilteredListByTag(Events eventsList, string criteria, string[] values)
        {
            TagFilter eventsToFilter = new TagFilter(Utils.ParseFilteringCriteria(criteria), values);
            return eventsToFilter.ApplyFilter(eventsList);
        }

        public static Events GetFilteredListByDescription(Events eventsList, string criteria, string value)
        {
            DescriptionFilter eventsToFilter = new DescriptionFilter(Utils.ParseFilteringCriteria(criteria), value);
            return eventsToFilter.ApplyFilter(eventsList);
        }

        public static Events GetFilteredListByDate(Events eventsList, string op, string val1, string val2)
        {
            Events filteredList = new Events();

            if (Utils.ParseFilteringCriteria(op) == "<>")
                filteredList = DoubleDateFiltering(eventsList, val1, val2);
            else
                filteredList = SimpleDateFiltering(eventsList, op, val1);

            return filteredList;
        }

        public static Events DoubleDateFiltering(Events eventsList, string beginDate, string endDate)
        {
            string firstCriteria = "<=";
            string secondCriteria = ">=";

            Events firstFilteredList = SimpleDateFiltering(eventsList, firstCriteria, endDate);
            Events filteredList = SimpleDateFiltering(firstFilteredList, secondCriteria, beginDate);
            return filteredList;
        }

        public static Events SimpleDateFiltering(Events eventsList, string criteria, string value)
        {
            DateFilter eventsToFilter = new DateFilter(Utils.ParseFilteringCriteria(criteria), value);
            return eventsToFilter.ApplyFilter(eventsList);
        }
    }
}
