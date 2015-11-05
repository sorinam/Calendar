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
            SubList(eventsList, resultList, parameter);
            return resultList;
        }

        private static void SubList(Events eventsList, Events resultList, string parameter)
        {
            foreach (Event eventL in eventsList)
            {
                if (ShouldBeListed(eventL, parameter))
                {
                    resultList.Add(eventL);
                }
            }

        }

        private static bool ShouldBeListed(Event eventL, string parameter)
        {
            if ((parameter == "past") && (eventL.Older() < 0)) return true;
            if ((parameter == "future") && (eventL.Older() >= 0)) return true;
            return false;
        }
    }
}