using DataService.Model;
using NUnit.Framework;

namespace DataService.DataAccess
{
    [TestFixture]
    public class GetHealthHistoryTester : BaseDataAccessTester
    {
        private static PagingData BuildPagingData(int pagesize)
        {
            var pagingData =
                new PagingData {PageOffset = 0, PageSize = pagesize, RequestsLastPage = false};
            return pagingData;
        }

        private void InsertTestHealthHistory(Athlete athlete, int noOfInstances)
        {
            for (var i = 0; i < noOfInstances; i++)
            {
                var athleteHealth =
                    new AthleteHealth {Athlete = athlete};
                MemoryDataContext.Add(athleteHealth);
            }
        }

        [Test]
        public void AssertFindsHistory()
        {
            const int pagesize = 5;
            var athleteBuilder = new AthleteBuilder();
            var athlete = athleteBuilder.Build();
            var query =
                new AthleteHealthQuery {PagingData = BuildPagingData(pagesize), Athlete = athlete};
            MemoryDataContext.Clear();

            MemoryDataContext.Add(athlete);
            InsertTestHealthHistory(athlete, pagesize*2);

            var athleteDataAccess = new AthleteDataAccess();

            query = athleteDataAccess.GetHealthHistory(query);

            Assert.AreEqual(pagesize, query.AthleteHealthHistory.Count);
            Assert.AreEqual(pagesize*2, query.PagingData.TotalCount);
        }
    }
}