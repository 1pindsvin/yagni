using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.Model;
using NUnit.Framework;

namespace DataService.DataAccess
{
    [TestFixture]
    public class GetAthleteShoesTester : BaseDataAccessTester
    {

        [Test]
        public void WhenAthleteHasNoShoesShouldReturnEmptyList()
        {
            var athlete = new AthleteBuilder().Build();
            var shoeController = new ShoeDataAccess();
            var shoes = shoeController.GetShoes(athlete);
            Assert.AreEqual(0, shoes.Count);
        }



    }
}
