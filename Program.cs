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
                    Console.WriteLine(" /add \t <Event's date> <Event's Subject>\t  ");
                    Console.WriteLine("\t Use the yyyy/mm/dd format for Date ");
                    Console.WriteLine("\n\n /list \t list events from calendar");
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
                        if (args.Length == 3)
                        {
                            string date = args[1];
                            string subject = args[2];
                            DateTime dateTime;
                            if (DateTime.TryParse(date, out dateTime))
                            {
                                newEvent.LoadCalendar();
                                newEvent.AddEvent(date, subject);
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
                        newEvent.LoadCalendar();
                        newEvent.DisplayCalendar();
                        break;
                    }
                default:
                    {
                        InvalidCommand();
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