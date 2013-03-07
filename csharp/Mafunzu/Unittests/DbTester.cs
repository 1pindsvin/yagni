using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.Model;
using NUnit.Framework;

namespace Unittests
{
    [TestFixture]
    public class DataBaseFromObjectModel
    {
        [Test, Ignore]
        public void CreateDatabaseFromObjectModel()
        {
            using (var db = new DbDataContext())
            {
                db.CreateDatabase();
            }
        }
    }
}
