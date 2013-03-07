using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;
using System.Collections;
using System.IO;
using System.Linq;


namespace dk.magnus.VifManager
{
    [TestFixture, Category("integration")]
    public class VifObjectBuilderIntegrationFixture
    {
        private const string Path = @"TestFiles\Stamdata.vif";

        [Test]
        public void CanReadVifStructureFromFile()
        {
            var vif = ReadVifFromFile(Path);
            Debug.WriteLine(vif.ToString());
            Debug.WriteLine(string.Format("Name [{0}], Type: [{1}]", vif.Name, vif.Clazz));
        }

        [Test]
        public void CanPrintDeepVifInfo()
        {
            var vif = ReadVifFromFile(Path);
            Func<VifObject, string> transformer = x => string.Format("Name [{0}], Type: [{1}]", x.Name, x.Clazz);
            var grep = new VifGrepper<string>(transformer);
            var lines = grep.GetDeepVifInfo(vif);
            Debug.Print(string.Join(Environment.NewLine, lines));
        }


        private static VifObject ReadVifFromFile(string path)
        {
            var lines = File.ReadAllLines(path);
            var builder = new VifObjectBuilder();
            var root = builder.Build(lines);
            return root;
        }


        private void AppendLines(VifObject vif, List<string> lines)
        {
            var list = vif.Lines.ToList();
            if (!vif.HasChildren)
            {
                lines.AddRange(list);
                return;
            }
            //dump end statement
            lines.AddRange(list.Take(list.Count - 1));
            foreach (var child in vif.Children)
            {
                AppendLines(child, lines);
            }
            lines.Add(list.Last());
        }

        [Test]
        public void ComparePrintWithOriginalFile()
        {
            var vif = ReadVifFromFile(Path);
            var lines = File.ReadAllLines(Path).ToList();

            var list = new List<string>();
            AppendLines(vif, list);

            CollectionAssert.AreEqual(lines, list);
        }
    }
}