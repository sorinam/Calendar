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
                    Console.WriteLine("\n\tPossible commands:");
                    Console.WriteLine("\t /add <Event's date> <Event's Subject>\t add new event in calendar");
                    Console.WriteLine("\t /list \t\t\t\t\t list events from calendar");
                }
                else
                {
                    SwitchCommands(args);
                }
            }
        }

        static void SwitchCommands(string[] args)
        {
            switch (args[0])
            {
                case "/add":
                    {
                        if (args.Length == 3)
                        {
                            string date = args[1];
                            string subject = args[2];
                            Events.LoadCalendar();
                            Events.AddEvent(Convert.ToDateTime(date), subject);
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