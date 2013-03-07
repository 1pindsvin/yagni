using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;
using System.Collections;
using System.IO;
using System.Linq;


namespace dk.magnus.VifManager
{

    [TestFixture,Category("integration")]
    public class VifObjectBuilderIntegrationFixture
    {
        const string Path = @"TestFiles\Stamdata.vif";

        [Test]
        public void CanVifStructureFromFile()
        {
            var firstActualVif = ReadVifFromFile(Path);
            Debug.WriteLine(firstActualVif.ToString());
        }

        private static VifObject ReadVifFromFile(string path)
        {
            var lines = File.ReadAllLines(path);
            var builder = new VifObjectBuilder();
            var root = builder.Build(lines);
            var firstActualVif = root.Children.First();
            return firstActualVif;
        }


        void AppendLines(VifObject vif, List<string> lines)
        {
            var list = vif.Lines.ToList();
            if (!vif.HasChildren)
            {
                lines.AddRange(list);
                return;
            }
            //dump end statement
            lines.AddRange(list.Take(list.Count-1));
            foreach (var child in vif.Children)
            {
                AppendLines(child,lines);
            }
            lines.Add(list.Last());
        }

        [Test]
        public void ComparePrintWithOriginalFile()
        {
            var list = new List<string>();
            var vif = ReadVifFromFile(Path);
            var lines = File.ReadAllLines(Path).ToList();
            AppendLines(vif,list);
            CollectionAssert.AreEqual(lines,list);
        }


    }
}
