using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using DataService.Model;
using NUnit.Framework;

namespace Unittests
{
    [Table(Name = "Foo")]
    public class TableClass
    {
        public EntitySet<Run> TrainingSessions { get; set; }

        public string Bar { get; set; }

    }

    public class ClassWithOneMethod
    {
        public string FooBar(int foo, List<int> bar)
        {
            return "foo";
        }
    }


    [TestFixture]
    public class ScriptTypeSearcherTester
    {
        readonly Assembly[] _assemblies = new[] { typeof(TableClass).Assembly };

        [Test]
        public void AssertFindsClassWithTableAttribute()
        {
            var types = new ScriptTypeSearcher(_assemblies).GetTypesWithTableAttribute();

            var expected = types.Where(x => x.Name == typeof (TableClass).Name).First();
            Assert.IsNotNull(expected);
        }

        
    }
}
