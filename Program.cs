using System;

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
            Console.WriteLine("\n\n /export filename.html\t\t export all events from calendar to HTML file ");
            Console.WriteLine("         past filename.html\t export past events from calendar to HTML file ");
            Console.WriteLine("         future filename.html\t export future events from calendar to HTML file ");
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
                            ConsoleWorker evTools = new ConsoleWorker();
                            string date = args[1]; ;
                            string subject = Utils.CodingNewLineChar(args[2]);
                            string description = "";
                            if (args.Length == 4)
                            {
                                description = Utils.CodingNewLineChar(args[3]);
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
                        if (uiObj.ProcessingExportArguments())
                        {
                            ExportEvents(args);
                        }
                        break;
                    }
                default:
                    {
                        uiObj.InvalidCommand();
                        break;
                    }
            }
        }

        private static void ExportEvents(string[] args)
        {
            FileWorker files = new FileWorker();
            Events eventsList = files.LoadEventsFromFile();
            eventsList.Sort();
            if (args.Length == 2)
            {
                ExportToHTMLFile(@args[1], eventsList);
            }
            else
            {
                ConsoleWorker evTools = new ConsoleWorker();
                Events eventsToExport = eventsList.ExtractEventsFromCalendar(args[1].ToLower());
                ExportToHTMLFile(@args[2], eventsToExport);
            }

        }

        private static void ExportToHTMLFile(string path, Events eventsList)
        {
            HTMLWorker exportHtml = new HTMLWorker(eventsList);
            exportHtml.ExportToHTMLFile(path);
        }

        static void DisplayEvents(string parameter)
        {
            FileWorker files = new FileWorker();
            Events eventsList = files.LoadEventsFromFile();
            ConsoleWorker tool = new ConsoleWorker(eventsList);

            if (parameter == "all")
            {
                tool.DisplayEventsToConsole();
            }
            else
            {   Events eventsToDisplay = eventsList.ExtractEventsFromCalendar(parameter);
                ConsoleWorker toDisplay = new ConsoleWorker(eventsToDisplay);
                toDisplay.DisplayEventsToConsole();
            }
        }

        static string DefaultParameter(string[] args)
        {
            return (args.Length == 1) ? "all" : args[1].ToLower();
        }

    }
}