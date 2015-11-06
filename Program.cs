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

        private static void DisplayHelp()
        {
            Console.WriteLine("\n\tPossible commands:\n");
            Console.WriteLine(" /add \t <Event's Date> <Event's Subject> <Event's Description> ");
            Console.WriteLine("\t Use the yyyy/mm/dd format for Date ");
            Console.WriteLine("\n\n /list all \t list all events from calendar; 'all' parameter is optional");
            Console.WriteLine("       past \t list past events from calendar");
            Console.WriteLine("       future \t list future events from calendar");
        }

        static void SwitchCommands(string[] args)
        {
            UIClass uiObj = new UIClass(args);

            switch (uiObj.FirstArg())
            {
                case "/add":
                    {
                        uiObj.ProcessingAddArguments();
                        break;
                    }
                case "/list":
                    {
                        uiObj.ProcessingListArguments();
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
   
}
}