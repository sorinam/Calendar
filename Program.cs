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
                string firstArg = args[0];
                if (firstArg == "/?")
                {
                    Console.WriteLine("\n\tPossible commands:");
                    Console.WriteLine("\t /add <Event's date> <Event's Subject>\t add new event in calendar");
                    Console.WriteLine("\t /list \t\t\t\t\t list events from calendar");
                }
                else
                {
                    SwitchCommands(args, firstArg);
                }
            }
        }

        private static void SwitchCommands(string[] args, string firstArg)
        {
            switch (firstArg)
            {
                case "/add":
                    {
                        if (args.Length == 3)
                        {
                            Events.LoadCalendar();
                            string subject = args[1];
                            string date = args[2];
                            Events.AddEvent(subject, Convert.ToDateTime(date));
                            Events.SaveEvents();
                        }
                        else
                        {
                            InvalidCommand();
                        }
                        break;
                    }
                case "/list":
                    {
                        Events.LoadCalendar();
                        Events.DisplayCalendar();
                        break;
                    }
                default:
                    {
                        InvalidCommand();
                        break;
                    }
            }
        }

        public static void InvalidCommand()
        {
            Console.WriteLine("\n\t Invalid command. Use calendar.exe /? for more details.");
        }
    }
}