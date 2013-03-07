using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.DataAccess;
using DataService.Io;
using DataService.Model;
using NUnit.Framework;

namespace RunTrack
{
    [TestFixture]
    public class DownloadServiceTester
    {
        private readonly InMemoryDataContext _inMemoryDataContext;

        private class DummyCsvData : ICsvData
        {
            public string AsFileContent(IEnumerable<Run> runs)
            {
                return "Gryffe";
            }
        }

        public DownloadServiceTester()
        {
            RunTrackEnvironment.MappedFullyQualifiedDownloadDirectory =
                Environment.CurrentDirectory;
            RunTrackEnvironment.FullyQualifiedDownloadDirectoryUrl = "Foo";

            _inMemoryDataContext = new InMemoryDataContext();
            RunDataAccess.ResolveDataContext = () => _inMemoryDataContext;
            DownloadService.ResolveCsvData = () => new DummyCsvData();
            DownloadService.ResolveFileSystem = () => new DummyFileSystem();
        }

        public Run Build()
        {
            var date = new DateTime(2010, 1, 30, 12, 25, 7);
            var shoe = new Shoe { Brand = "Nike" };
            var run = new Run
            {
                ID=1,
                Distance = 10000,
                Labels = (int)LabelEnumeration.None,
                LastChanged = date,
                Start = date,
                Shoe = shoe,
                Time = 10000
            };
            return run;
        }

        [Test]
        public void AssertSavesRunsAsCsv()
        {
            var athleteBuilder = new AthleteBuilder();
            var athlete = athleteBuilder.Build();
            athlete.User.UserName = "peter.wihlborg@gmail.com";

            var run = Build();
            run.Athlete = athlete;

            _inMemoryDataContext.Add(run);


            var e = new DownloadService();

            var expected =
                "Foo/peter.wihlborg@gmail.com.csv";

            var downloadUrl = e.DownloadMyRuns(athlete);

            Assert.AreEqual(expected, downloadUrl);
        }
    }
}
