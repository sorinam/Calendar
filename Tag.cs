using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
   public class Tag
    {
        char[] prefix;
        string value;

        private static string[] GetTags(Events eventsList)
        {
            string[] tags = { };
            string[] el_tags = { };
            foreach (Event ev in eventsList)
            {
                el_tags = GetEventTags(ev);
                tags = tags.Union(el_tags).ToArray();
            };
            return tags;
        }

        private static string[] GetEventTags(Event ev)
        {
            string value = ev.Title + " " + ev.Description;
            var allTags = value.Split(' ');
            var evTags = Array.FindAll(allTags, s => s.StartsWith("#") || s.StartsWith("@"));

            for (int i = 0; i < evTags.Length; i++)
            {
                evTags[i] = evTags[i].Remove(0, 1);
            }

            return evTags.Distinct().ToArray();
        }

    }
}
