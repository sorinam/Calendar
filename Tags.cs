using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Calendar
{
    public class Tag : IComparable<Tag>
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
            set { this.count = value; }
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
        public int CompareTo(Tag other)
        {
            return count.CompareTo(other.Count);
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
        Tag[] tagList;

        public TagsCounter(Events list)
        {
            tagList = GetTagsAndCounts(list);

        }

        public Tag[] TagList
        {
            get { return tagList; }
        }

        public int Length
        {
            get { return tagList.Count(); }
        }

        public Tag[] GetTagsAndCounts(Events eventsList)
        {
            Tag[] tags = { };
            Tag[] el_tags = { };
            foreach (Event ev in eventsList)
            {
                el_tags = ev.GetTagsAndCount();
                var union = tags.Union(el_tags, new TagsComparer()).ToArray();
                IncreaseCounter(el_tags, union);
                tags = union;
            };
            return tags;
        }

        public void SortTagsDescByCount()
        {
            var sorted = new sortTagDescendingByCount();
            Array.Sort(tagList, sorted);
        }

        public void SortTagsAscByName()
        {
            var sorted = new sortTagAscendingByName();
            Array.Sort(tagList, sorted);
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
    public class TagsNameList
    {
        string[] tagList;
        public TagsNameList(Events eventsList)
        {
            tagList = GetTagsNameList(eventsList);
        }

        private string[] GetTagsNameList(Events eventsList)
        {   Tag[] el_tags;
            string[] el_TagsNameList= { };
            foreach (Event ev in eventsList)
            {
                el_tags = ev.GetTagsAndCount();
                el_TagsNameList = GetTagsNameForAnEvent(el_tags);
                var union = el_TagsNameList.Union(el_TagsNameList);
                el_TagsNameList = union.ToArray();
            }
            return el_TagsNameList;
        }

        private string[] GetTagsNameForAnEvent(Tag[] el_tagList)
        {
           string[] tagList=new string [el_tagList.Count()];
            for (int i=0;i< el_tagList.Count();i++)
            {
                tagList[i] = el_tagList[i].Name;
            }
            return tagList;

        }

        public string[] TagList
        {
            get { return tagList; }
        }

        public int Length
        {
            get { return tagList.Count(); }
        }


    }
    class sortTagAscendingByName : IComparer<Tag>
    {
        public int Compare(Tag x, Tag y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
    class sortTagDescendingByCount : IComparer<Tag>
    {
        public int Compare(Tag x, Tag y)
        {
            if (x.Count < y.Count) return 1;
            else
            if (x.Count > y.Count) return -1;
            else return 0;

        }
    }
}
