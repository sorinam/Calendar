using System;

namespace Calendar
{
    public class Event
    {
        private string subject;
        private DateTime date;

        public string Subject
        {
            set { subject = value; }
            get { return subject; }
        }

        public DateTime Date
        {
            set { date = value; }
            get { return date; }
        }

        public Event(string line)
        {
            int separatorPosition = line.IndexOf("\t");
            date = Convert.ToDateTime(line.Substring(0, separatorPosition));
            subject = line.Substring(separatorPosition + 1);
        }
    }
}