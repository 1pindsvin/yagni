using NUnit.Framework;
using System.Collections;
using System.IO;
using System.Linq;


namespace dk.magnus.VifManager
{

    [TestFixture]
    public class VifObjectBuilderFixture
    {

        [Test]
        public void CanBuildSimpleRecursiveVif()
        {
            var lines = new[] { "object foo", "object bar", "end", "end" };
            var vifBuilder = new VifObjectBuilder();
            var root = vifBuilder.Build(lines);
            var first = root.Children.First();
            AssertChildCount(first,1);
            var firstChild = first.Children.Single();
            AssertChildCount(firstChild, 0);
            Assert.AreEqual(2,firstChild.Lines.Count());
            Assert.AreEqual(2, first.Lines.Count());
        }



        void AssertChildCount(VifObject vif, int expectedCount)
        {
            if (expectedCount == 0)
            {
                Assert.IsFalse(vif.HasChildren);

            }
            else
            {
                Assert.IsTrue(vif.HasChildren);    
            }
            Assert.AreEqual(expectedCount, vif.Children.Count());
        }

        [Test]
        public void CanBuildRecursiveVifWithTwoChildren()
        {
            var lines = new[] { "object foo", "object bar", "end", "object gombert", "end", "end" };
            var vifBuilder = new VifObjectBuilder();
            var root = vifBuilder.Build(lines);
            var first = root.Children.First();
            AssertChildCount(first,2);
            foreach (var child in first.Children)
            {
                AssertChildCount(child,0);
            }
        }
        
        [Test]
        public void CanBuildSimpleVif()
        {
            var lines = new[] { "object foo", "end" };
            var vifBuilder = new VifObjectBuilder();
            var root = vifBuilder.Build(lines);
            Assert.IsTrue(root.IsRoot);
            var single = root.Children.Single();
            Assert.AreEqual(2,single.Lines.Count());
            AssertChildCount(single,0);
        }

        [Test]
        public void CanBuildRecursiveVifWithExtralinesInBody()
        {
            var lines = new[] { "object VifPackage: TVifPackage", "object VifPackage: TVifPackage", "foo", "bar", "end", "foo", "bar", "end" };
            var vifBuilder = new VifObjectBuilder();
            var root = vifBuilder.Build(lines);
            var single = root.Children.Single();
            Assert.AreEqual(4, single.Lines.Count());
            AssertChildCount(single, 1);
        }

        [Test]
        public void CanBuildThreeLayerRecursiveVif()
        {
            var lines = new[] { "object foo", "object bar","object gombert", "end", "end", "end" };
            var vifBuilder = new VifObjectBuilder();
            var root = vifBuilder.Build(lines);
            var single = root.Children.Single();
            AssertChildCount(single, 1);
            var firstChild = single.Children.Single();
            var grandChild = firstChild.Children.Single();
            AssertChildCount(firstChild,1);
            AssertChildCount(grandChild, 0);
        }


    }
}
