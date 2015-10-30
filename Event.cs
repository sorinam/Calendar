using System;

namespace Calendar
{
    public class Event
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
            int firstSeparatorPosition = line.IndexOf("\t");
            int secondSeparatorPosition = line.LastIndexOf("\t");
            DateTime convertedDate;
            if (DateTime.TryParse(line.Substring(0, firstSeparatorPosition), out convertedDate))
            {
                date = convertedDate;
                subject = line.Substring(firstSeparatorPosition + 1,secondSeparatorPosition-firstSeparatorPosition-1);
                description = line.Substring(secondSeparatorPosition + 1);
            }
        }
    }
}