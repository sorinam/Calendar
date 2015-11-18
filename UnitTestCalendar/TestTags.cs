using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using Calendar;

namespace UnitTestCalendar
{
    [TestClass]
    public class TestTags
    {
        [TestMethod]
        public void ShouldListAllTags()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "subj", "tag","description") },
                {new Event("2015/11/15", "subj","title","#desc") },
                {new Event("2015/11/15", "subj","tag","@Ioana") },
                {new Event("2015/11/15", "subj","#tag","#desc tag @Ioana test" ) }
            };
            string[] expectedTagList = { "#desc", "#tag", "@Ioana", };

            string[] tags = newEvents.GetTags();
            Array.Sort(tags);
            expectedTagList.ShouldEqual(tags);
        }

        [TestMethod]
        public void ShouldListAllTagsWithNumbers()
        {
            Events newEvents = new Events
            {
                {new Event ( "2015/01/01", "subj", "#tag","description") },
                {new Event("2015/11/15", "subj","title @Ioana","#desc") },
                {new Event("2015/11/15", "subj","#tag","@Ioana") },
                {new Event("2015/11/15", "subj","#tag","#desc @Ioana test" ) }
            };
            Tag[] expectedTagList = {
                new Tag("#desc",2),
                new Tag("#tag",3),
                new Tag("@Ioana",3) };

            var tagList =new TagsCounter(newEvents).GetTagsWithCounts();
            expectedTagList.ShouldEqual(tagList);

        }
            }
}
