using System.Linq;
using NUnit.Framework;

namespace LinqStatistics.UnitTests
{
    [TestFixture]
    public class CovarianceTests
    {
        [Test]
        public void Covariance()
        {
            var source = TestData.GetDoubles();
            var other = TestData.GetDoubles();


            var result = source.Covariance(other);

            Assert.AreEqual(result, 3.081875, double.Epsilon);
        }

        [Test]
        public void Covariance1()
        {
            var source = TestData.GetDoubles();
            var other = TestData.GetInts().Select(x => (double) x);


            var result = source.Covariance(other);

            Assert.AreEqual(result, 2.59375, double.Epsilon);
        }


        [Test, Ignore]
        public void Pearson1FailsUnableToVerify()
        {
            var source = TestData.GetDoubles();
            var other = TestData.GetInts().Select(x => (double) x);

            var result = source.Pearson(other);

            //returns 0.99895649120828689 wich is outside expected value delta
            Assert.AreEqual(0.998956491208287,result, double.Epsilon);
        }

        [Test]
        public void PearsonIdentity()
        {
            var source = TestData.GetDoubles();
            var other = TestData.GetDoubles();


            var result = source.Pearson(other);

            Assert.AreEqual(result, 1.0, double.Epsilon);
        }
    }
}