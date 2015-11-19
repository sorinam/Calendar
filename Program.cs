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
            Console.WriteLine(" /add \t <Event's Date> <Event's Subject> <Event's title> ");
            Console.WriteLine("\t Use the yyyy/mm/dd format for Date ");
            Console.WriteLine("\n\n /list all \t list all events from calendar; 'all' parameter is optional");
            Console.WriteLine("       past \t list past events from calendar");
            Console.WriteLine("       future \t list future events from calendar");
            Console.WriteLine("\n\n /export filename.html\t\t export all events from calendar to HTML file ");
            Console.WriteLine("         past filename.html\t export past events from calendar to HTML file ");
            Console.WriteLine("         future filename.html\t export future events from calendar to HTML file ");
            Console.WriteLine("\n\n /search <field name> <operator> <value> [/export fine.html]");
            Console.WriteLine("\n \t\t  <field name> can be 'date','title'or 'tag' ");
            Console.WriteLine("\t\t  <operator>can be 'equal '='");
            Console.WriteLine("\t\t\t\t   'not equal '!='");
            Console.WriteLine("\t\t\t\t   'between '<>' - only for date");
            Console.WriteLine("\t\t\t\t   'older' '<'-only for date");
            Console.WriteLine("\t\t\t\t   'newer' '>'-only for date");
            Console.WriteLine("\t\t\t\t   'contains' - only for title");
            Console.WriteLine("\t\t  <value> \t   valid values for field");
            Console.WriteLine("\t\t\t\t   'today' -only for date");
        }

        static void SwitchCommands(string[] args)
        {
            switch (args[0].ToLower())
            {
                case "/add":
                    {
                        if (AreValidAddArguments(args))
                        {
                            Dispenser.AddEvents(args);
                        }
                        break;
                    }
                case "/list":
                    {
                        if (AreValidListArguments(args))
                        {
                            if ((args.Length > 1) && (args[1].ToLower() == "tags"))
                            {
                                Dispenser.ListAllTags(SortParameter(args));
                            }
                            else
                            {
                                Dispenser.DisplayEvents(DefaultParameter(args));
                            }
                        }
                        break;
                    }
                case "/export":
                    {
                        if (AreValidExportArguments(args))
                        {
                            Dispenser.ExportEvents(args);
                        }
                        break;
                    }
                case "/search":
                    {
                        string field, op;
                        string[] val;
                        string path = ExportToHtmlFile(ref args);

                        if (AreValidSearchArguments(args, out field, out op, out val))
                        {

                            Dispenser.SearchAndExportEvents(field, op, val, path);
                        }
                        break;

                    }
                default:
                    {
                        InvalidCommand();
                        break;
                    }
            }
        }

        private static string SortParameter(string[] args)
        {
            return (args.Length == 2) ? "byName" : args[2];
        }

        private static string ExportToHtmlFile(ref string[] args)
        {
            string path = "";
            int indexExport = Array.IndexOf(args, "/export");
            if (indexExport > -1)
            {
                path = args[indexExport + 1];
                Array.Resize(ref args, indexExport);
            }

            return path;
        }

        static bool AreValidAddArguments(string[] args)
        {
            AddArgument addArgs = new AddArgument(args);
            if (addArgs.IsValid())
            {
                return (Utils.IsValidDate(args[1])) ? true : false;
            }
            else
            {
                InvalidCommand();
                return false;
            }
        }

        static bool AreValidListArguments(string[] args)
        {
            ListArgument listArgs = new ListArgument(args);
            if (listArgs.IsValid())
            {
                return true;
            }
            else
            {
                InvalidCommand();
                return false;
            }
        }

        static bool AreValidSearchArguments(string[] args, out string field, out string op, out string[] val)
        {
            field = op = "";
            val = new string[10];
            if (args.Length > 1)
            {
                switch (args[1].ToLower())
                {
                    case "date":
                        {
                            SearchDateArgument searchArgs = new SearchDateArgument(args);
                            if (searchArgs.IsValid())
                            {
                                field = searchArgs.Field;
                                op = searchArgs.Criteria;
                                val[0] = searchArgs.Date;
                                val[1] = searchArgs.AnotherDate;
                                Array.Resize(ref val, 2);
                                return true;
                            }
                            break;
                        }
                    case "description":
                        {
                            SearchDescriptionArgument searchArgs = new SearchDescriptionArgument(args);
                            if (searchArgs.IsValid())
                            {
                                field = searchArgs.Field;
                                op = searchArgs.Criteria;
                                val[0] = searchArgs.Value;
                                Array.Resize(ref val, 1);
                                return true;
                            }
                            break;
                        }
                    case "tag":
                        {
                            SearchTagArgument searchArgs = new SearchTagArgument(args);
                            if (searchArgs.IsValid())
                            {
                                field = searchArgs.Field;
                                op = searchArgs.Criteria;
                                val = searchArgs.Values;
                                return true;
                            }
                            break;
                        }
                    default:
                        {
                            InvalidCommand();
                            return false;
                        }
                }
            }
            InvalidCommand();
            return false;
        }

        static bool AreValidExportArguments(string[] args)
        {
            ExportArgument exportArgs = new ExportArgument(args);
            if (exportArgs.IsValid())
            {
                return true;
            }
            else
            {
                InvalidCommand();
                return false;
            }
        }

        static void InvalidCommand()
        {
            Console.WriteLine("\n\t Invalid command.Use calendar.exe /? for more details.");
        }

        static string DefaultParameter(string[] args)
        {
            return (args.Length == 1) ? "all" : args[1].ToLower();
        }

    }
}