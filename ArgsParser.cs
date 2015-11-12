using System;
using System.IO;

namespace Calendar
{
   public class ArgsParser
    {
        private string[] args;
       
        public  ArgsParser(string[] value)
        {
            args = value;
        }
      
        public bool ProcessingAddArguments()
        {
            AddArgument addArgs = new AddArgument(args);
            if (addArgs.IsValid())
            {
                return (Utils.IsValidDate(args[1])) ? true: false;
            }
            else
            {
                InvalidCommand(); 
                return false;
            }
       }

      

        public bool ProcessingListArguments()
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

        public bool ProcessingSearchArguments()
        {
            SearchArgument searchArgs = new SearchArgument(args);
            if (searchArgs.IsValid())
            {               
                return true;
            }
            else
            {
                InvalidCommand();
                return false;
            }
        }

        public bool ProcessingExportArguments()
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

        public void InvalidCommand()
        {
            Console.WriteLine("\n\t Invalid command.Use calendar.exe /? for more details.");
        }

       
    }
}
