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
                    Console.WriteLine("\n\n /list all \t list all events from calendar");
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
                        if (args.Length == 4)
                        {
                            string date = args[1];
                            string subject = args[2];
                            string description = args[3];
                            DateTime dateTime;
                            if (DateTime.TryParse(date, out dateTime))
                            {
                                newEvent.LoadCalendar();
                                newEvent.AddEvent(date, subject, description);
                                newEvent.SaveEvents();
                            }
                            else
                            {
                                Console.WriteLine("\n\t Invalid Date/Time format !");
                            }
                        }
                        else
                        {
                            InvalidCommand();
                        }
                        break;
                    }
                case "/list":
                    {
                        SelectListOption(args, newEvent);
                        break;
                    }
                default:
                    {
                        InvalidCommand();
                        break;
                    }
            }
        }

        private static void SelectListOption(string[] args, Events newEvent)
        {
            newEvent.LoadCalendar();
            switch (args[1])
            {
                case "past":
                    {
                        newEvent.DisplayPastEvents();
                        break;
                    }
                case "future":
                    {
                        newEvent.DisplayFutureEvents();
                        break;
                    }
                case "all":
                default:
                    {
                        newEvent.DisplayAllEvents();
                        break;
                    }
            }
        }

        static void InvalidCommand()
        {
            Console.WriteLine("\n\t Invalid command. Use calendar.exe /? for more details.");
        }
    }
}