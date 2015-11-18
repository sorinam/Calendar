using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Calendar
{
    public class Event : IComparable<Event>
    {
        private DateTime date;
        private string subject;
        private string title;
        private string description;
        string[] tags;

        public string Subject
        {
            set { subject = value; }
            get { return subject; }
        }

        public string Title
        {
            set { title = value; }
            get { return title; }
        }

        public string[] Tags
        {
           get {
                return tags = GetTags();
               
                    }
        }
        public DateTime Date
        {
            set { date = value; }
            get { return date; }
        }

        public string Description
        {
            set { description = value; }
            get { return description; }
        }
        public Event(string line)
        {           
            string[] words = line.Split('\t');
            if (words.Length == 4)
            {
                DateTime convertedDate;
                if (DateTime.TryParse(words[0], out convertedDate))
                {
                    SetMembers(words[1], words[2],words[3], convertedDate);
                }
                else
                {
                    throw new FormatException("Bad Date/Time format or conversion not supported!");
                }
            }
        }

        public Event(string date, string subject, string title="",string description="")
        {       DateTime convertedDate;
            if (DateTime.TryParse(date, out convertedDate))
            {
                SetMembers(subject, title,description, convertedDate);
            }
            else
            {
                throw new FormatException("Bad Date/Time format or conversion not supported!");
            }
        }

        private void SetMembers(string subject, string title,string description, DateTime date)
        {
            this.date = date;
            this.subject = subject;
            this.title = title;
            this.description = description;
        }

        public string StringParser ()
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            String newString = date.ToString("yyyy/MM/dd") + "\t" + subject + "\t" + title;
            return newString;
        }

        public string[] GetTags()
        {
            string value =title + " " + description;
            var allTags = value.Split(' ');
            var tags = Array.FindAll(allTags, s => s.StartsWith("#") || s.StartsWith("@"));
            return tags.Distinct().ToArray();
        }
        public Tag[] GetTagsWithNumber()
        {
            string[] tags = GetTags();
            Tag[] evTagList = new Tag[tags.Length];
            for (int i = 0; i < tags.Length; i++)
            {
                evTagList[i]= new Tag(tags[i], 0); ;
            }
            return evTagList;

        }
        public int CompareTo(Event other)
        {
            return this.Date.CompareTo(other.Date);
        }
      }
}