using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using DataService.Garmin;
using NUnit.Framework;

namespace DataService.Model
{
    [TestFixture]
    public class DbXmlAssociationSetterTester
    {

        [Test, Category("slow")]
        public void AssertCanReadDbXml()
        {
            const string namespaceFormat = "{{http://schemas.microsoft.com/linqtosql/dbml/2007}}{0}";
            var associationName = string.Format(namespaceFormat, "Association");

            var localPath = Environment.CurrentDirectory;
            var path = Path.Combine(localPath, @"..\..\..\DataService\Model\Db.dbml");
            var xDoc = XDocument.Parse(File.ReadAllText(path));
            var childRelationAssociations =
                xDoc.Descendants(associationName).
                Where(x => x.Attribute("IsForeignKey") == null &&
                    x.Attribute("Name").Value != "Goal_TrainingPlan");
            Assert.AreEqual(0, childRelationAssociations.Count(), "Warning, child relations found in Db.dbml, they might indicate an error. Run RemoveLinqChildRelations()");
        }

        [Test, Ignore]
        public void RemoveLinqChildRelations()
        {
            const string namespaceFormat = "{{http://schemas.microsoft.com/linqtosql/dbml/2007}}{0}";
            var associationName = string.Format(namespaceFormat, "Association");

            const string linqDbPath = @"..\..\..\DataService\Model\Db.dbml";
            var localPath = Environment.CurrentDirectory;
            var path = Path.Combine(localPath, linqDbPath);
            var xDoc = XDocument.Parse(File.ReadAllText(path));
            string goalTrainingplanAssocName = "Goal_TrainingPlan";
            xDoc.Descendants(associationName).
            Where(x => x.Attribute("IsForeignKey") == null &&
                x.Attribute("Name").Value != goalTrainingplanAssocName).Remove();

            var d = xDoc.Descendants(associationName).
                Where(x => x.Attribute("IsForeignKey") == null &&
                           x.Attribute("Name").Value == goalTrainingplanAssocName).Single();
            d.SetAttributeValue("Cardinality", "One");
            xDoc.Save(linqDbPath);
        }
    }
}