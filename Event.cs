using System;
using System.Globalization;
using System.Threading;

namespace Calendar
{
    public class Event : IComparable<Event>
    {
        private DateTime date;
        private string subject;
        private string description;

        public string Subject
        {
            set { subject = value; }
            get { return subject; }
        }

        public string Description
        {
            set { description = value; }
            get { return description; }
        }

        public DateTime Date
        {
            set { date = value; }
            get { return date; }
        }

        public Event(string line)
        {           
            string[] words = line.Split('\t');
            if (words.Length == 3)
            {
                DateTime convertedDate;
                if (DateTime.TryParse(words[0], out convertedDate))
                {
                    SetMembers(words[1], words[2], convertedDate);
                }
                else
                {
                    throw new FormatException("Bad Date/Time format or conversion not supported!");
                }
            }
        }

        public Event(string date, string subject, string description="")
        {       DateTime convertedDate;
            if (DateTime.TryParse(date, out convertedDate))
            {
                SetMembers(subject, description, convertedDate);
            }
            else
            {
                throw new FormatException("Bad Date/Time format or conversion not supported!");
            }
        }

        private void SetMembers(string subject, string description, DateTime date)
        {
            this.date = date;
            this.subject = subject;
            this.description = description;
        }

        public string StringParser ()
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            String newString = date.ToString("yyyy/MM/dd") + "\t" + subject + "\t" + description;
            return newString;
        }

        public int CompareTo(Event other)
        {
            return this.Date.CompareTo(other.Date);
        }
      }
}