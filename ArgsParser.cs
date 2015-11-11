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
    }
}
