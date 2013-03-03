using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ParsePascalDependencies
{
    [TestFixture]
    internal class DependencyParserFixture
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
            var e = BuildDependencyParser();
        }

        private static DependencyParser BuildDependencyParser()
        {
            return new DependencyParser(new FakeFileEnumerator(),new FakeUnitBuilder());
        }
    }
}