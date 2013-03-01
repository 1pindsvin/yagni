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

        class FakeUnitBuilder : IUnitBuilder
        {
            public PascalUnit Build(string path, IEnumerable<string> lines)
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
            var e = BuildAppRunner();
        }

        private static AppRunner BuildAppRunner()
        {
            return new AppRunner("some/path", new FakeFileEnumerator(), new FakeUnitBuilder());
        }

    }
}