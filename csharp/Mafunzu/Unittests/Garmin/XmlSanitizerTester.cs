using System.IO;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;

namespace DataService.Garmin
{
    [TestFixture]
    public class XmlSanitizerTester
    {
        const string GarminXml = TestConstants.GarminXml;

        [Test]
        public void AssertSanitize()
        {

            const string namespacePrefix = "{http://www.garmin.com/xmlschemas/TrainingCenterDatabase/v2}";
            const int expectedTrackpointCount = 168;
            const int failedTrackpointCount = 0;

            const string trackpoint = "Trackpoint";


            var doc = XDocument.Parse(GarminXml, LoadOptions.None);
            Assert.IsNotNull(doc.Descendants());

            var trackPoints = doc.Descendants(trackpoint);

            Assert.AreEqual(failedTrackpointCount, trackPoints.Count());

            trackPoints = doc.Descendants(namespacePrefix + trackpoint);
            Assert.AreEqual(expectedTrackpointCount, trackPoints.Count());

            trackPoints = doc.Descendants().Where(x => x.Name.LocalName == trackpoint);
            Assert.AreEqual(expectedTrackpointCount, trackPoints.Count());

            var sanitizer = new XmlSanitizer();

            var saneXml = sanitizer.Sanitize(GarminXml);

            doc = XDocument.Parse(saneXml);
            trackPoints = doc.Descendants(trackpoint);

            Assert.AreEqual(expectedTrackpointCount, trackPoints.Count());
        }

        const string trackpointName = "Trackpoint";

        [Test]
        public void AssertLinq()
        {
            const string trainingcenterdatabaseName = "TrainingCenterDatabase";
            const string activityName = "Activity";
           

            var doc = BuildXDocument();

            var centers = doc.Elements(trainingcenterdatabaseName);

            Assert.AreEqual(1, centers.Count());

            var activities =  doc.Descendants(activityName);

            Assert.AreEqual(1, activities.Count());

            var trackPoints = doc.Descendants(trackpointName);

            const int expectedTrackpointCount = 168;
            Assert.AreEqual(expectedTrackpointCount, trackPoints.Count());


        }

        private static XDocument BuildXDocument()
        {
            return BuildXDocument(GarminXml);
        }

        private static XDocument BuildXDocument(string xml)
        {
            var sanitizer = new XmlSanitizer();
            var saneXml = sanitizer.Sanitize(xml);
            return XDocument.Parse(saneXml);
        }

        private static XDocument BuildXDocumentFromFile(string path)
        {
            var xml = File.ReadAllText(path);
            return BuildXDocument(xml);
        }

 
    }
}