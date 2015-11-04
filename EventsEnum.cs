using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class EventsEnum : IEnumerable<Event>
    {
        private List<Event> events;
        List<Event> calendar = new List<Event>();
        List<Event> pastEvents = new List<Event>();
        List<Event> futureEvents = new List<Event>();
        public EventsEnum()
        {
            events = new List<Event>();
        }

        public void Add(Event newEvent)
        {
            events.Add(newEvent);
        }

        public IEnumerator<Event> GetEnumerator()
        {
            return events.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddEvent(string date, string subject, string description = "")
        {
            Event newEvent = new Event(date, subject, description);
            events.Add(newEvent);
        }

        public void DisplayEvents(string option)
        {
            IOFiles files = new IOFiles();

            switch (option)
            {
                case "future":
                    {
                        ExtractEventsFromCalendar();
                        files.DisplayToConsole(futureEvents);
                        break;
                    }
                case "past":
                    {
                        ExtractEventsFromCalendar();
                        files.DisplayToConsole(pastEvents);
                        break;
                    }
                case "all":
                    {
                        files.DisplayToConsole(calendar);
                        break;
                    }
            }
        }

        void ExtractEventsFromCalendar()
        {
            for (int i = 0; i < calendar.Count; i++)
            {
                if (calendar[i].Older() < 0)
                    pastEvents.Add(calendar[i]);
                else
                    futureEvents.Add(calendar[i]);
            }
        }

    }
}
