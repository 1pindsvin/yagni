using System;
using DataService.Model;
using NUnit.Framework;
using System.Linq;

namespace DataService.DataAccess
{
    public class GetAthleteShoePageTester : BaseDataAccessTester
    {
        private Athlete BuildAthlete()
        {
            var dateOfBirth = DateTime.MinValue;
            var athlete = new Athlete
                              {
                                  DateOfBirth = dateOfBirth,
                                  FirstName = "Gryffe",
                                  ID = 1,
                                  LastName = null,
                                  User = new User()
                              };
            return athlete;
        }


        private void BuildAndInsert10ActiveShoes(Athlete athlete)
        {
            for (var idx = 0; idx < 10; idx++)
            {
                var shoe = new Shoe {Athlete = athlete,Active = true};
                MemoryDataContext.InsertOnSubmit(shoe);
            }
        }

        [Test]
        public void WhenAthleteHas10ShoesShouldReturnPageWith10Shoes()
        {
            MemoryDataContext.Clear();
            var athlete = BuildAthlete();
            BuildAndInsert10ActiveShoes(athlete);
            var shoePage = new ShoePage
                               {
                                   Active = true,
                                   Athlete = athlete,
                                   RequestsLastPage = false,
                                   Shoes = null,
                                   Start = 0,
                                   PageSize = int.MaxValue
                               };
            var shoeController = new ShoeDataAccess();
            var page = shoeController.GetShoePage(shoePage);

            Assert.AreEqual(10, page.Shoes.Count);
        }

        [Test]
        public void WhenAthleteHasNoShoesShouldReturnPageWithEmptyList()
        {
            MemoryDataContext.Clear();
            var athlete = BuildAthlete();

            var shoePage = new ShoePage
                               {
                                   Active = true,
                                   Athlete = athlete,
                                   RequestsLastPage = false,
                                   Shoes = null,
                                   Start = 0
                               };
            var shoeController = new ShoeDataAccess();
            var page = shoeController.GetShoePage(shoePage);

            Assert.AreEqual(0, page.Shoes.Count);
        }


        [Test]
        public void WhenAthleteIsNullShouldThrowNullReferenceException()
        {
            try
            {
                var shoePage = new ShoePage();
                var shoeController = new ShoeDataAccess();
                var page = shoeController.GetShoePage(shoePage);
                Assert.Fail("NullReferenceException");
            }
            catch (NullReferenceException)
            {
            }
        }

        [Test]
        public void WhenPageSizeIs5ShouldReturnPageWith5Shoes()
        {
            MemoryDataContext.Clear();
            var athlete = BuildAthlete();
            BuildAndInsert10ActiveShoes(athlete);
            var shoePage = new ShoePage
                               {
                                   Active = true,
                                   Athlete = athlete,
                                   RequestsLastPage = false,
                                   Shoes = null,
                                   Start = 0,
                                   PageSize = 5
                               };
            var shoeController = new ShoeDataAccess();
            var page = shoeController.GetShoePage(shoePage);

            Assert.AreEqual(5, page.Shoes.Count);
        }

        [Test]
        public void WhenShoesAreInActiveShouldReturnPageWithActiveShoes()
        {
            MemoryDataContext.Clear();
            var athlete = BuildAthlete();
            BuildAndInsert10ActiveShoes(athlete);

            Set6ShoesInactive(MemoryDataContext.Queryable<Shoe>());

            var shoePage = new ShoePage
            {
                Active = true,
                Athlete = athlete,
                RequestsLastPage = false,
                Shoes = null,
                Start = 0,
                PageSize = int.MaxValue
            };
            var shoeController = new ShoeDataAccess();
            var page = shoeController.GetShoePage(shoePage);

            Assert.AreEqual(4, page.Shoes.Count);
        }

        private void Set6ShoesInactive(IQueryable<Shoe> shoeQueryable)
        {
            var shoes = shoeQueryable.ToList();
            for (int i = 0; i < 6; i++)
            {
                shoes[i].Active = false;
            }
        }
    }
}