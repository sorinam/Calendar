using System;
using System.Collections.Generic;
using System.Linq;

namespace Calendar
{
    public class Tag
    {
        string name;
        int count;
        public string Name
        {
            set { name = value; }
            get { return name; }
        }
        public int Count
        {
            set { this.count= value; }
            get { return count; }
        }

        public Tag()
        {
            name = "";
            count = 0;
        }
        public Tag(string tagName, int number)
        {
            name = tagName;
            count = number;
        }
    }
    public class TagsComparer : IEqualityComparer<Tag>
    {
        public bool Equals(Tag x, Tag y)
        {
            return x != null && y != null && x.Name.Equals(y.Name);

        }

        public int GetHashCode(Tag obj)
        {
                int hashName = obj.Name == null ? 0 : obj.Name.GetHashCode();
                return hashName;
            }
           
      }
    public class TagsCounter
    {
        Events eventsList;
        public TagsCounter(Events list)
        {
            eventsList = list;
        }

        public Tag[] GetTagsWithCounts()
        {
            Tag[] tags = { };
            Tag[] el_tags = { };
            foreach (Event ev in eventsList)
            {
                el_tags = ev.GetTagsWithNumber();
                var union = tags.Union(el_tags, new TagsComparer()).ToArray();
                {
                    IncreaseCounter(el_tags, union);
                }
                tags = union;
            };
            return tags;
        }

        private static void IncreaseCounter(Tag[] el_tags, Tag[] union)
        {
            foreach (Tag elem in el_tags)
            {
                int index = Array.FindIndex(union, e => e.Name == elem.Name);
                union[index].Count += 1;
            }
        }
    }
}
