using System;
using System.IO;

namespace Calendar
{
   public class ArgsParser
    {
        private string[] args;
        string[] parameters = { "/add", "/list", "/export" };
        string[] listParameters = { "all", "past", "future","today" };

        public  ArgsParser(string[] value)
        {
            args = value;
        }
        public ArgsParser()
        {
            args = new string[0];
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

        public bool ProcessingExportArguments()
        {
           if ((args.Length == 2)&&IsValidFilenameAndPath(args[1]))
            {
                return true;
            }

            if ((args.Length == 3) && IsValidFilenameAndPath(args[2]) && IsValidListParameter(args[1]))
            {
                return true;
            }
            else
            {
                //InvalidCommand();
                return false; }
        }

        public bool IsValidFilenameAndPath(string fileName)
        {
            StreamWriter MyStream = null;
            string MyString = "A";

            try
            {
                MyStream = File.CreateText(fileName);
                MyStream.Write(MyString);
            }
            catch (IOException e)
            {
                Console.WriteLine();
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                if (MyStream != null)
                {
                    MyStream.Close();
                    File.Delete(fileName);
                }
            }
            return true;
        }

        public void InvalidCommand()
        {
            Console.WriteLine("\n\t Invalid command.Use calendar.exe /? for more details.");
        }

        bool IsValidFirstArgs(string firstArg)
        {
            return IsValid(firstArg.ToLower(),parameters);
        }

        bool IsValidListParameter(string listOption)
        {
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
        
    }
}
