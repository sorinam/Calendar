using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
   public class ArgsParser
    {
        private string[] args;
        
        public  ArgsParser(string[] value)
        {
            args = value;
        }

        public string FirstArg()
        {
            return (IsValidFirstArgs(args[0])) ? args[0].ToLower() : "";
         }

        public bool ProcessingAddArguments()
        {
            
            if ((args.Length == 3) || (args.Length == 4))
            {
                DateTime dateTime;
                if (DateTime.TryParse(args[1], out dateTime))
                {
                    return true;                   
                }
                else
                {
                    Console.WriteLine("\n\t Bad Date/Time format or conversion not supported!");
                    return false;
                }
            }
            else
            {
                InvalidCommand();
                return false;
            }
        }

        public bool ProcessingListArguments()
        {
            if ((args.Length == 1) || ((args.Length == 2) && (IsValidListParameter(args[1]))))
            {
                return true;
            }
            else
            {
                InvalidCommand();
                return false;
            }
        }

        public void ProcessingExportArguments()
        {
            if ((args.Length == 1) || ((args.Length == 2) ))
            {
               //ExportEvents(args[1],args[2]);
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
            string[] validValues = { "/add", "/list","/export" };
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

      

     
        //private string DecodingNewLineChar(string value)
        //{
        //    return (value.Replace('\a', '\n'));
        //}

    }
}
