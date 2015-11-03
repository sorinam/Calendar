using System;

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
                    date = convertedDate;
                    subject = words[1];
                    description = words[2];
                }
                else
                {
                    throw new FormatException("Bad Date/Time format or conversion not supported!");
                }
            }
        }

        public Event(string date, string subject, string description="")
        {
            DateTime convertedDate;
            if (DateTime.TryParse(date, out convertedDate))
            {
                this.date = convertedDate;
                this.subject = subject;
                this.description = description;
            }
            else
            {
                throw new FormatException("Bad Date/Time format or conversion not supported!");
            }
        }

        public int CompareTo(Event other)
        {
            return this.Date.CompareTo(other.Date);
        }
        public int Older()
        {
            DateTime thisDay = DateTime.Today;
            return this.Date.CompareTo(thisDay);
        }
    }
}