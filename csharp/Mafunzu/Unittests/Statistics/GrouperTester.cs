using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Unittests.Statistics
{
    [TestFixture]
    public class GrouperTester
    {
        [Test]
        public void ShouldGroupBy3()
        {
            var items = new []{1,2,3,4,5,6};
            var dic = new Dictionary<int, string> {{1, "true"},{0, "false"}};
            var grouper = new Grouper<int>(items, dic, x=>x==3 ? 1: 0);
            var groups = grouper.GetGroups();
            Assert.AreEqual(2, groups.Count());
            
            var falseItems = groups.Where(x => x.ID == 0).Single();
            Assert.AreEqual(0,falseItems.ID);
            Assert.AreEqual(5, falseItems.Items.Count());
            Assert.AreEqual("false", falseItems.Description);

            var trueItems = groups.Where(x => x.ID == 1).Single();
            Assert.AreEqual(1, trueItems.ID);
            Assert.AreEqual(1, trueItems.Items.Count());
            Assert.AreEqual("true", trueItems.Description);

        }

        private static IEnumerable<int> BuildIntItems(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                yield return i;
            }
        }

        [Test]
        public void ShouldResolveGroupedData()
        {
            var allItems = BuildIntItems(1, 30);
            var items = BuildIntItems(1, 5);
            var dic = new Dictionary<int, string> { { 1, "true" }, { 0, "false" } };
            var grouper = new Grouper<int>(items, dic, x => x == 3 ? 1 : 0);
            var groupedData = grouper.ResolveGroupedData(allItems);
            Assert.AreEqual(2, groupedData.Count());
            var trueData = groupedData.Where(x => x.Description == "true").Single();
            var falseData = groupedData.Where(x => x.Description == "false").Single();

            Assert.AreEqual( "true" , trueData.Description);
            Assert.AreEqual(20, trueData.PercentageOf);
            Assert.AreEqual(1, trueData.GroupCount);
            Assert.AreEqual(5, trueData.AllGroupsCount);
            Assert.AreEqual(30, trueData.GlobalCount);

            Assert.AreEqual("false", falseData.Description);
            Assert.AreEqual(80, falseData.PercentageOf);
            Assert.AreEqual(4, falseData.GroupCount);
            Assert.AreEqual(5, falseData.AllGroupsCount);
            Assert.AreEqual(30, falseData.GlobalCount);

        }


    }
}
