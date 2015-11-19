using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Calendar
{
    public class Events : IEnumerable<Event>
    {
        private List<Event> eventsList;
        
        public IEnumerable<Event> EventsList
        {
            get { return eventsList; }
        }

        public int Length
        {
            get { return eventsList.Count(); }
        }

        public Events()
        {
            eventsList = new List<Event>();
        }

        public Events(List <Event> list)
        {
            eventsList = list ;
        }

        public Events(string[] lines)
        {
            eventsList = new List<Event>();
            {
                if (lines!=null)
                    foreach (string line in lines)
                    {
                        Event ev = new Event(line);
                        eventsList.Add(ev);
                    }
            };
        }

        public void Add(Event newEvent)
        {
            eventsList.Add(newEvent);
        }

        public void Add(string date, string subject, string title = "",string description="")
        {
            Event newEvent = new Event(date, subject, title,description);
            eventsList.Add(newEvent);
        }

        public string[] ToStringList()
        {
            string[] repo=new string[0];
            int index = 0;
            foreach (Event e in eventsList)
            {
                index++;
                Array.Resize(ref repo, index);
                repo[index - 1] =e. StringParser();
            };
            return repo;
        }

        public string ToOneString()
        {
            string stringContent = "";
           foreach(Event ev in eventsList)
            {
                stringContent += ev.StringParser() + "\n";
            }
            return stringContent;
        }

        //public string[] GetTags()
        //{       
        //    string[] tags = { };
        //    string[] el_tags = { };
        //    foreach (Event ev in eventsList)
        //    {
        //        el_tags = ev.Tags;
        //        tags = tags.Union(el_tags).ToArray();
        //    };
        //    return tags;
        //}
       

        public void Sort()
        {
            eventsList.Sort();
        }
               
        public IEnumerator<Event> GetEnumerator()
        {
            return eventsList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
    }
}
