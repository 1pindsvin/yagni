using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ParsePascalDependencies
{
    [TestFixture]
    internal class AppRunnerFixture
    {
        private class FakeFileEnumerator : IFileEnumerator
        {
            public IEnumerable<string> EnumerateFiles()
            {
                throw new NotImplementedException();
            }
        }

        private class FakeUnitBuilder : IUnitBuilder
        {
            public PascalUnit Build(string path, IEnumerable<string> lines)
            {
                throw new NotImplementedException();
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
            return new AppRunner(new FakeFileEnumerator(), new FakeUnitBuilder());
        }
    }
}