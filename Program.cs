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
            switch (args[0].ToLower())
            {
                case "/add":
                    {
                        if (uiObj.ProcessingAddArguments())
                        {
                            Dispenser.AddEvents(args);
                        }
                        break;
                    }
                case "/list":
                    {
                        if (uiObj.ProcessingListArguments())
                        {
                            Dispenser.DisplayEvents(DefaultParameter(args));
                        }
                        break;
                    }
                case "/export":
                    {
                        if (uiObj.ProcessingExportArguments())
                        {
                            Dispenser.ExportEvents(args);
                        }
                        break;
                    }
                case "/search":
                    {
                        //if (uiObj.ProcessingSearchArguments())
                        //{
                         Dispenser.SearchEvents(args);
                        
                    //}
                    break;
            }
            default:
                    {
                uiObj.InvalidCommand();
                break;
            }
        }
    }

       

        static string DefaultParameter(string[] args)
        {
            return (args.Length == 1) ? "all" : args[1].ToLower();
        }

    }
}