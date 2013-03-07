using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.Model;
using NUnit.Framework;

namespace DataService.DataAccess
{
    [TestFixture]
    public class SaveAthleteTester : BaseDataAccessTester
    {

        private Athlete _athlete;

        private void InsertDefaultAthlete(int weight)
        {
            var user = new User { ID = 1, Password = "0", UserName = "Gryffe" };
            MemoryDataContext.InsertOnSubmit(user);
            MemoryDataContext.Commit();

            new UserDataAccess().Save(user);

            _athlete = new Athlete { ID = 0, User = user, Weight = weight};

            new AthleteDataAccess().SaveAthlete(_athlete);
        }

        [Test]
        public void WhenExistingAthleteIsSavedAndWeightIsChangedShouldAddWeightHistory()
        {
            var weightBefore = 90;
            MemoryDataContext.Clear();
            InsertDefaultAthlete(weightBefore);
            _athlete.ID = 1; //saved
            var db = new AthleteDataAccess();

            Assert.AreEqual(0, MemoryDataContext.Queryable<AthleteHealth>().Count());

            weightBefore += 10;
            var disconnectedAthleteThatHasGainedWeight =
                new Athlete { ID = _athlete.ID, User = _athlete.User, Weight = weightBefore };

            db.SaveAthlete(disconnectedAthleteThatHasGainedWeight);

            Assert.AreEqual(1, MemoryDataContext.Queryable<AthleteHealth>().Count());
        }

        [Test]
        public void WhenExistingAthleteIsSavedAndWeightIsUnChangedShouldNotAddWeightHistory()
        {
            const int weight = 90;
            MemoryDataContext.Clear();
            InsertDefaultAthlete(weight);
            _athlete.ID = 1; //saved
            var db = new AthleteDataAccess();

            Assert.AreEqual(0, MemoryDataContext.Queryable<AthleteHealth>().Count());

            var disconnectedAthleteWithSameWeight =
                new Athlete { ID = _athlete.ID, User = _athlete.User, Weight = weight };

            db.SaveAthlete(disconnectedAthleteWithSameWeight);

            Assert.AreEqual(0, MemoryDataContext.Queryable<AthleteHealth>().Count());
        }

        [Test]
        public void WhenExistingAthleteIsSavedAndWeightIsNullShouldNotAddWeightHistory()
        {
            const int weightBefore = 90;
            MemoryDataContext.Clear();

            InsertDefaultAthlete(weightBefore);
            _athlete.ID = 1; //saved
            var db = new AthleteDataAccess();

            Assert.AreEqual(0, MemoryDataContext.Queryable<AthleteHealth>().Count());
            
            var disconnectedAthleteThatHasGainedWeight =
                new Athlete { ID = _athlete.ID, User = _athlete.User, Weight = Athlete.NullIntValue };

            db.SaveAthlete(disconnectedAthleteThatHasGainedWeight);

            Assert.AreEqual(0, MemoryDataContext.Queryable<AthleteHealth>().Count());
        }

    }
}
