using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DataService.DataAccess
{
    [TestFixture]
    public class CreateUserTester : BaseDataAccessTester
    {
        [Test]
        public void AssertUserDataIsSet()
        {
            var userDataAccess = new UserDataAccess();
            MemoryDataContext.Clear();
            const string email = "gryffe@c.dk";
            const string password = "1qaz";

            var user = userDataAccess.CreateUserWithDefaultAthlete(email, password);

            Assert.AreEqual(email, user.UserName);
            Assert.AreEqual(password, user.Password);
            Assert.AreEqual(3, MemoryDataContext.CommitCallCount);
            Assert.AreEqual(user.CustomerID, user.ID.ToString());

        }

        [Test]
        public void AssertDefaultAthleteForNewUser()
        {
            var userDataAccess = new UserDataAccess();
            MemoryDataContext.Clear();
            const string email = "gryffe@c.dk";
            const string password = "1qaz";

            var user = userDataAccess.CreateUserWithDefaultAthlete(email, password);

            var athleteDataAccess = new AthleteDataAccess();
            var athlete = athleteDataAccess.GetAthlete(user);
            Assert.AreEqual(user, athlete.User);

        }


    }
}
