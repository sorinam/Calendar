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
        public void ShouldListAllTagsWithCounters()
        {
            Events newEvents = new Events
            {
                {new Event ("2015/01/01", "subj", "#tag","description") },
                {new Event("2015/11/15", "subj","title @Ioana","#desc") },
                {new Event("2015/11/15", "subj","new tag","@Ioana") },
                {new Event("2015/11/15", "subj","#tag","#desc @Ioana test" ) }
            };
            Tag[] expectedTagList = {
                new Tag("#tag",2),
                new Tag("#desc",2),
                new Tag("@Ioana",3) };

            var tagList = new TagsCounter(newEvents);
            var tags = tagList.TagList;
            expectedTagList.ShouldEqual(tags);

        }
            }
}
