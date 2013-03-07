using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.Model;
using NUnit.Framework;

namespace Unittests
{
    [TestFixture]
    public class AthleteTester
    {
        [Test, Category("slow"), Ignore]
        public void AssertVersionCanConvertToLong()
        {
            var db = new DbDataContext();

            var singleAthlete = db.Athletes.First();

            var version = singleAthlete.Version;
            Assert.AreEqual(8, version.Length);
        }
    }
}
