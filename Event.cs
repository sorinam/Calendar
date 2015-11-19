using System;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace Calendar
{
    public class Event : IComparable<Event>
    {
        private DateTime date;
        private string title;
        private string description;
        string[] tags;
              
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

        public Event(string date, string title,string description="")
        {       DateTime convertedDate;
            if (DateTime.TryParse(date, out convertedDate))
            {
                SetMembers(title,description, convertedDate);
            }
            else
            {
                throw new FormatException("Bad Date/Time format or conversion not supported!");
            }
        }

        private void SetMembers (string title,string description, DateTime date)
        {
            this.date = date;
            this.title = title;
            this.description = description;
        }

        public string StringParser ()
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            String newString = date.ToString("yyyy/MM/dd") + "\t" + title + "\t" + description;
            return newString;
        }

        string[] GetTags()
        {
            string value =title + " " + description;
            var allTags = value.Split(' ');
            var tags = Array.FindAll(allTags, s => s.StartsWith("#") || s.StartsWith("@"));
            return tags.Distinct().ToArray();
        }
        public Tag[] GetTagsAndCount()
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