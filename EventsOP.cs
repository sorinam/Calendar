using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Calendar
{
    public class EventsOp
    {
        Events eventsList;

        public EventsOp()
        {
            eventsList = new Events();
        }

        public Events ExtractEventsFromCalendar(Events eventsList, string parameter)
        {
            Events resultList = new Events();
            switch (parameter)
                {
                case "past":
                    {
                        foreach (Event eventL in eventsList)
                        {
                            if (eventL.Older() < 0)
                                resultList.Add(eventL);
                        }
                        break;
                    }
                case "future":
                    {
                        foreach (Event eventL in eventsList)
                        {
                            if (eventL.Older() >= 0)
                                resultList.Add(eventL);
                        }
                        break;
                    }
            }
            return resultList;
        }
    }
}