using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should;
using Calendar;

namespace UnitTestCalendar
{
    [TestClass]
    public class TestTags
    {
        [TestMethod]
        public void ShouldListAllTagsDescByCounters()
        {
            Events newEvents = new Events
            {
                {new Event ("2015/01/01", "#tag","description") },
                {new Event("2015/11/15", "title @Ioana","#desc") },
                {new Event("2015/11/15","new tag","@Ioana") },
                {new Event("2015/11/15","#tag","#desc @Ioana test" ) }
            };
            Tag[] expectedTagList = {
                new Tag("@Ioana",3),
                new Tag("#tag",2),
                new Tag("#desc",2)
                 };

            var tagList = new TagsCounter(newEvents);

            tagList.SortTagsDescByCount();
            var tags = tagList.TagList;
            AreEquals(tags, expectedTagList);
        }

        [TestMethod]
        public void ShouldListAllTagsAscByName()
        {
            Events newEvents = new Events
            {
                {new Event ("2015/01/01",  "#tag","description") },
                {new Event("2015/11/15", "title @Ioana","#desc") },
                {new Event("2015/11/15", "new tag","@Ioana") },
                {new Event("2015/11/15", "#tag","#desc @Ioana test" ) }
            };
            Tag[] expectedTagList = {
                new Tag("#desc",2),
                new Tag("#tag",2),
                new Tag("@Ioana",3)
                };

            var tagList = new TagsCounter(newEvents);

            tagList.SortTagsAscByName();
            var tags = tagList.TagList;

            AreEquals(tags, expectedTagList);
        }

        [TestMethod]
        public void ShouldListOnlyTagsName()
        {
            Events newEvents = new Events
            {
                {new Event ("2015/01/01",  "#tag","description") },
                {new Event("2015/11/15", "title @Ioana","#desc") },
                {new Event("2015/11/15", "new tag","@Ioana") },
                {new Event("2015/11/15", "#tag","#desc @Ioana test" ) }
            };
            string[] expectedTagList = { "#desc","#tag", "@Ioana" };

            var tagList = new TagsNameList(newEvents);

            tagList.ShouldEqual(tagList);

           
        }

        private void AreEquals(Tag[] List,Tag[] ListToCompare)
        {
            List.Length.ShouldEqual(ListToCompare.Length);
            {
                for (int i=0;i<List.Length;i++)
                {
                    List[i].Name.ShouldEqual(ListToCompare[i].Name);
                    List[i].Count.ShouldEqual(ListToCompare[i].Count);
                }
            }
         }
       }
}
