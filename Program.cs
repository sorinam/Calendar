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
                    Console.WriteLine("\n\tPossible commands:\n");
                    Console.WriteLine(" /add \t <Event's Date> <Event's Subject> <Event's Description> ");
                    Console.WriteLine("\t Use the yyyy/mm/dd format for Date ");
                    Console.WriteLine("\n\n /list all \t list all events from calendar; 'all' parameter is optional");
                    Console.WriteLine("       past \t list past events from calendar");
                    Console.WriteLine("       future \t list future events from calendar");
                }
                else
                {
                    SwitchCommands(args);
                }
            }
        }

        static void SwitchCommands(string[] args)
        {
            Events newEvent = new Events();
            switch (args[0])
            {
                case "/add":
                    {
                        ProcessingAddArguments(args, newEvent);
                        break;
                    }
                case "/list":
                    {
                        ProcessingListArguments(args, newEvent);
                        break;
                    }
                default:
                    {   InvalidCommand();
                        break;
                    }
            }
        }

       static void ProcessingListArguments(string[] args, Events newEvent)
        {
            if ((args.Length == 1)||((args.Length == 2) && (IsValidListParameter(args[1]))))
            {
                string parameter;
                if (args.Length == 1) { parameter = "all"; }
                else
                { parameter = args[1]; }
                newEvent.LoadCalendar();
                newEvent.DisplayEvents(parameter);
            }
            else
            {
                InvalidCommand();
            }
        }

        private static void ProcessingAddArguments(string[] args, Events newEvent)
        {
            if ((args.Length ==3)|| (args.Length ==4))
            {
                string date = args[1];
                string subject = args[2];
                string description="";
                if (args.Length == 4) { description = args[3]; }
                DateTime dateTime;
                if (DateTime.TryParse(date, out dateTime))
                {
                    newEvent.LoadCalendar();
                    newEvent.AddEvent(date, subject, description);
                    newEvent.SaveEvents();
                }
                else
                {
                    Console.WriteLine("\n\t Bad Date/Time format or conversion not supported!");
                }
            }
            else
            {
                InvalidCommand();
            }
        }

        static bool IsValidListParameter(string listOption)
        {
            string[] listParameters = { "all", "past", "future" };
            for (int i = 0; i < listParameters.Length; i++)
            {
                if (listParameters[i] == listOption)
                { return true; }
            }
            return false;
        }

        public static void InvalidCommand()
        {
            Console.WriteLine("\n\t Invalid command. Use calendar.exe /? for more details.");
        }
    }
}