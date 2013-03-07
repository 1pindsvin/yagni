using System.Collections.Generic;
using DataService.DataAccess;
using DataService.Model;
using NUnit.Framework;
using System.Linq;

namespace Unittests
{
    [TestFixture]
    public class PagingTester
    {
        
        private readonly IEnumerable<Run> _runs = new List<Run>
         {
             new Run {ID = 0, Athlete = null, AthleteID =10},
             new Run {ID = 1, Athlete = null, AthleteID =10},
             new Run {ID = 2, Athlete = null, AthleteID =10},
             new Run {ID = 3, Athlete = null, AthleteID =10},
             new Run {ID = 4, Athlete = null, AthleteID =10},
             new Run {ID = 5, Athlete = null, AthleteID =10},
             new Run {ID = 6, Athlete = null, AthleteID =10},
             new Run {ID = 7, Athlete = null, AthleteID =10},
             new Run {ID = 8, Athlete = null, AthleteID =10},
             new Run {ID = 9, Athlete = null, AthleteID =10},
         };

        [Test]
        public void AssertPagingGrabsPageCountElements()
        {
            var pageSize = 2;
            var start = 0;
            var items = GetAthleteRuns(start, pageSize).ToList();
            Assert.AreEqual(pageSize, items.Count());
            Assert.AreEqual(0, items.First().ID);
            Assert.AreEqual(1, items[1].ID);

            items = GetAthleteRuns(8, pageSize).ToList();
            Assert.AreEqual(pageSize, items.Count());
            Assert.AreEqual(8, items.First().ID);
            Assert.AreEqual(9, items[1].ID);
        }

        [Test]
        public void AssertPagerResolvesStartAsZeroWhenIQueryableIsEmpty()
        {
            var runs = new List<Run>();
            var pager = new Pager<Run>(runs.AsQueryable(), 0, 10);
            Assert.AreEqual(0,pager.PageOffset);
        }


        [Test]
        public void AssertPagingGrabsElementsWhenStartBelowOrEqualToUpperLimit()
        {
            var pageSize = 3;
            var start = 8;
            var items = GetAthleteRuns(start, pageSize).ToList();
            Assert.AreEqual(2, items.Count());
            Assert.AreEqual(8, items[0].ID);
            Assert.AreEqual(9, items[1].ID);


            start = 9;
            items = GetAthleteRuns(start, pageSize).ToList();
            Assert.AreEqual(1, items.Count());

            start = _runs.Count();
            items = GetAthleteRuns(start, pageSize).ToList();
            Assert.AreEqual(1, items.Count());
        }

        [Test]
        public void AssertPagingGrabsLastPageWhenStartExceedsUpperLimit()
        {
            var start = 0;
            var pageSize = 7;
            start += pageSize;
            var items = GetAthleteRuns(start, pageSize).ToList();
            Assert.AreEqual(3, items.Count());
            Assert.AreEqual(7, items[0].ID);
            Assert.AreEqual(8, items[1].ID);
            Assert.AreEqual(9, items[2].ID);

            start += pageSize;
            items = GetAthleteRuns(start, pageSize).ToList();
            Assert.AreEqual(3, items.Count());
            Assert.AreEqual(7, items[0].ID);
            Assert.AreEqual(8, items[1].ID);
            Assert.AreEqual(9, items[2].ID);

            
        }

        [Test]
        public void AssertPagingGrabsLastPageWhenPageSizeExceedsRunCount()
        {
            var start = 0;
            var pageSize = 11;
            var items = GetAthleteRuns(start, pageSize).ToList();
            Assert.AreEqual(10, items.Count());

            start += pageSize;
            items = GetAthleteRuns(start, pageSize).ToList();
            Assert.AreEqual(10, items.Count());

        }

        [Test]
        public void AssertPagingGrabsLastPageWhenPageSizeEqualsRunCount()
        {
            var start = _runs.Count();
            var pageSize = _runs.Count() ;
            var items = GetAthleteRuns(start, pageSize).ToList();
            Assert.AreEqual(10, items.Count());

            start = _runs.Count()*2;
            items = GetAthleteRuns(start, pageSize).ToList();
            Assert.AreEqual(10, items.Count());

        }

        public IEnumerable<Run> GetAthleteRuns(int start, int page)
        {
            var pager = new Pager<Run>(_runs.AsQueryable(), start, page);
            return pager.GetPagedItems();
        }

    }
}