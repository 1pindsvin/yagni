using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ParsePascalDependencies
{
    [TestFixture]
    internal class AppRunnerFixture
    {

        class FakeFileEnumerator : IFileEnumerator
        {
            public IEnumerable<string> EnumerateFiles()
            {
                throw new System.NotImplementedException();
            }
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CanCreate()
        {
            var e = new AppRunner("some/path", new FakeFileEnumerator());
        }

        [Test]
        public void IsMatchForUnitDeclaration()
        {
            var e = new AppRunner("some/path", new FakeFileEnumerator());
            Assert.True( e.IsMatchForUnitDeclaration("unit Unit1;"));
        }


        [Test]
        public void IsMatchForUnitName()
        {
            var e = new AppRunner("some/path", new FakeFileEnumerator());
            foreach (var line in new [] { "unit Unit1;", " Unit1 ; ", "Unit1 ; " })
            {
                Assert.True(e.IsMatchForUnitName(line));
            }
        }

    }
}