using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            foreach (string line in lines)
            {
                Event ev = new Event(line);
                eventsList.Add(ev);
            };
        }

        public void Add(Event newEvent)
        {
            eventsList.Add(newEvent);
        }

        public void Add(string date, string subject, string description = "")
        {
            Event newEvent = new Event(date, subject, description);
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
