using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class UIClass
    {
        private string[] args;
        
        public  UIClass(string[] value)
        {
            args = value;
        }

        public string FirstArg()
        {
            return (IsValidFirstArgs(args[0])) ? args[0].ToLower() : "";
         }

        public void ProcessingAddArguments()
        {
            IOFiles file = new IOFiles();
            if ((args.Length == 3) || (args.Length == 4))
            {
                string date, subject, description;
                SetEventFields(out date, out subject, out description);

                DateTime dateTime;
                if (DateTime.TryParse(date, out dateTime))
                {
                    Events eventsListFromFile = file.LoadEventsFromFile();
                    eventsListFromFile.Add(date, subject, description);
                    file.SaveEventsToFile(eventsListFromFile);
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

        public void ProcessingListArguments()
        {
            if ((args.Length == 1) || ((args.Length == 2) && (IsValidListParameter(args[1]))))
            {
                DisplayEvents(DefaultParameter(args));
            }
            else
            {
                InvalidCommand();
            }
        }

        public void InvalidCommand()
        {
            Console.WriteLine("\n\t Invalid command.Use calendar.exe /? for more details.");
        }

        bool IsValidFirstArgs(string firstArg)
        {
            string[] validValues = { "/add", "/list" };
            return IsValid(firstArg.ToLower(), validValues);
        }

        bool IsValidListParameter(string listOption)
        {
            string[] listParameters = { "all","past", "future" };
            return IsValid(listOption.ToLower(), listParameters);
        }

        private bool IsValid(string arg,string[] list)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] == arg)
                { return true; }
            }
            return false;
        }

        private string DefaultParameter(string[] args)
        {
            return (args.Length == 1) ? "all" : args[1].ToLower();
        }

        private void DisplayEvents(string parameter)
        {
            IOFiles files = new IOFiles();
            Events eventsListFromFile = files.LoadEventsFromFile();

            if (parameter == "all")
            {
                files.DisplayEventsToConsole(eventsListFromFile);
            }
            else
            {
                EventsOp toDisplay = new EventsOp();
                Events eventsToDisplay = toDisplay.ExtractEventsFromCalendar(eventsListFromFile, parameter);
                files.DisplayEventsToConsole(eventsToDisplay);
            }
        }
        
        private void SetEventFields(out string date, out string subject, out string description)
        {
            date = args[1];
            subject = ReplaceNewLineChar(args[2]);
            description = "";
            if (args.Length == 4)
            {
                description = ReplaceNewLineChar(args[3]);
            }
        }

        private string ReplaceNewLineChar(string value)
        {
            return(value.Replace('\n', '\a'));
        }

      
    }
}
