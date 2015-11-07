using System;
using System.Collections.Generic;

namespace Calendar
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("\t\n Use calendar.exe /? for more details . ");
            }
            else
            {

                if (args[0] == "/?")
                {
                    DisplayHelp();
                }
                else
                {
                    SwitchCommands(args);
                }
            }
        }

        static void DisplayHelp()
        {
            Console.WriteLine("\n\tPossible commands:\n");
            Console.WriteLine(" /add \t <Event's Date> <Event's Subject> <Event's Description> ");
            Console.WriteLine("\t Use the yyyy/mm/dd format for Date ");
            Console.WriteLine("\n\n /list all \t list all events from calendar; 'all' parameter is optional");
            Console.WriteLine("       past \t list past events from calendar");
            Console.WriteLine("       future \t list future events from calendar");
            Console.WriteLine("\n\n /export \t export all events from calendar to HTML file; 'all' parameter is optional");
        }

        static void SwitchCommands(string[] args)
        {
            ArgsParser uiObj = new ArgsParser(args);

            switch (uiObj.FirstArg())
            {
                case "/add":
                    {
                        if (uiObj.ProcessingAddArguments())
                        {
                            EventsTools evTools = new EventsTools();
                            string date = args[1]; ;
                            string subject = CodingNewLineChar(args[2]);
                            string description = "";
                            if (args.Length == 4)
                            {
                                description = CodingNewLineChar(args[3]);
                            }
                            evTools.AddDataFromConsole(date, subject, description);
                        }
                        break;
                    }
                case "/list":
                    {
                        if (uiObj.ProcessingListArguments())
                        {
                            DisplayEvents(DefaultParameter(args));
                        }

                        break;
                    }
                case "/export":
                    {
                        uiObj.ProcessingExportArguments();
                        break;
                    }
                default:
                    {
                        uiObj.InvalidCommand();
                        break;
                    }
            }

        }

        static void DisplayEvents(string parameter)
        {
            IOFiles files = new IOFiles();
            Events eventsList = files.LoadEventsFromFile();

            if (parameter == "all")
            {
                files.DisplayEventsToConsole(eventsList);
            }
            else
            {
                EventsTools toDisplay = new EventsTools();
                Events eventsToDisplay = toDisplay.ExtractEventsFromCalendar(eventsList, parameter);
                files.DisplayEventsToConsole(eventsToDisplay);
            }
        }

        static string DefaultParameter(string[] args)
        {
            return (args.Length == 1) ? "all" : args[1].ToLower();
        }

        static string CodingNewLineChar(string value)
        {
            return (value.Replace('\n', '\a'));
        }

    }
}