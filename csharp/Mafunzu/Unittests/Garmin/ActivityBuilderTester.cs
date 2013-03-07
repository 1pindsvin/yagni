using System;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using DataService.Model;
using NUnit.Framework;

namespace DataService.Garmin
{
    [TestFixture]
    public class ActivityBuilderTester
    {
        private string _withoutNamespaceDeclarationsXml;
        private string _emptyXml;
        private string _emptyActivityXml;

        private ActivityBuilder _activityBuilder;

        public ActivityBuilderTester()
        {
            Setup();
        }

        private void Setup()
        {
            _withoutNamespaceDeclarationsXml = new XmlSanitizer().Sanitize(TestConstants.RawGarminXmlWith5TrackPoints);
            var xDoc = XDocument.Parse(_withoutNamespaceDeclarationsXml);
            xDoc.Descendants(ActivityBuilder.LapName).Remove();
            _emptyActivityXml = xDoc.ToString(SaveOptions.None);
            xDoc.Descendants(ActivityBuilder.ActivityName).Remove();
            _emptyXml = xDoc.ToString(SaveOptions.None);

            _activityBuilder = new ActivityBuilder(_withoutNamespaceDeclarationsXml);
            _activityBuilder.Build();
        }

        [Test]
        public void AssertBuildsExpectedTrackpointDateTimeValue()
        {
            var e = _activityBuilder;
            //"2010-03-01T17:08:01Z"
            var expectedDatetime = new DateTime(2010, 3, 1, 17, 8, 1);
            var actual = e.TrackPoints.First().Time;
            Assert.AreEqual(expectedDatetime, actual);
        }

        [Test]
        public void AssertBuildsExpectedTrackpointValues()
        {
            var e = _activityBuilder;

            var trackpoint = e.TrackPoints.First();

            Assert.AreEqual(e.Activity, trackpoint.Track.Lap.Activity);
            Assert.AreEqual(15038, trackpoint.AltitudeMeters);
            Assert.AreEqual(561348027, trackpoint.LatitudeDegrees);
            Assert.AreEqual(101973644, trackpoint.LongitudeDegrees);
            Assert.AreEqual(4146, trackpoint.DistanceMeters);
            Assert.AreEqual(96, trackpoint.HeartRateBpm);
            Assert.AreEqual("Absent", trackpoint.SensorState);
        }

        [Test]
        public void AssertBuildsExpectedActivityValues()
        {
            var activity = _activityBuilder.Activity;

            Assert.AreEqual(1, activity.ActivityType);
            Assert.AreEqual("Forerunner305 (Unit ID 3673610590)", activity.Description);
            Assert.AreEqual("2010-03-01T17:08:00Z", activity.ForeignSystemID);
            Assert.AreEqual(13593858, activity.DistanceMeters);
            Assert.AreEqual(148, activity.AverageHeartRateBpm);
            Assert.AreEqual(164, activity.MaximumHeartRateBpm);
            Assert.AreEqual(52932005, activity.MaximumSpeed);
            Assert.AreEqual(4217, activity.TotalTimeSeconds);
        }

        [Test]
        public void AssertBuildsExpectedLapValues()
        {
            var lap = _activityBuilder.Laps.Single();

            Assert.AreEqual(_activityBuilder.Activity, lap.Activity);
            Assert.AreEqual(148, lap.AverageHeartRateBpm);
            Assert.AreEqual(1252, lap.Calories);
            Assert.AreEqual(13593858, lap.DistanceMeters);
            Assert.AreEqual("Active", lap.Intensity);
            Assert.AreEqual(164, lap.MaximumHeartRateBpm);
            Assert.AreEqual(52932005, lap.MaximumSpeed);
            Assert.AreEqual(4217, lap.TotalTimeSeconds);
            Assert.AreEqual("Manual", lap.TriggerMethod);
        }

        [Test]
        public void AssertBuildsExpectedParentChildRelations()
        {
            var track = _activityBuilder.Tracks.First();
            var trackpoints = _activityBuilder.TrackPoints.Where(x => x.Track.Equals(track));
            Assert.AreEqual(2, trackpoints.Count());
            Assert.AreEqual(_activityBuilder.Activity, trackpoints.First().Track.Lap.Activity);

        }


        [Test]
        public void AssertCanBuildEmptyActivity()
        {
            var e = new ActivityBuilder(_emptyActivityXml);
            e.Build();

            Assert.NotNull(e.Activity);
            Assert.AreEqual(0, e.Laps.Count);
        }

        [Test]
        public void AssertCanResolveTestActivityValues()
        {
            var e = _activityBuilder;

            Assert.IsNotNull(e.Activity);
            Assert.AreEqual(1, e.Laps.Count);
            Assert.AreEqual(2, e.Tracks.Count);
            Assert.AreEqual(5, e.TrackPoints.Count);
        }

        [Test]
        public void AssertWhenXmlIsEmptyContatinsNoActivity()
        {
            var e = new ActivityBuilder(_emptyXml);
            Assert.IsFalse(e.ContainsActivity);
        }


        [Test]
        public void AssertConstructor()
        {
            Assert.Throws(typeof(NullReferenceException), () => new ActivityBuilder(null));
            Assert.Throws(typeof(NullReferenceException), () => new ActivityBuilder(""));
            Assert.Throws(typeof(InvalidOperationException),
                          () => new ActivityBuilder(TestConstants.RawGarminXmlWith5TrackPoints));

            Assert.DoesNotThrow(() => new ActivityBuilder(_emptyXml));
            Assert.DoesNotThrow(()=>new ActivityBuilder(_withoutNamespaceDeclarationsXml));
        }
    }
}