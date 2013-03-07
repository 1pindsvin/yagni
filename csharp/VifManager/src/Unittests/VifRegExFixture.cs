using NUnit.Framework;
using System.Collections;
using System.IO;
using System.Linq;


namespace dk.magnus.VifManager
{
    [TestFixture]
    public class VifRegExFixture
    {
        [Test]
        public void CanResolveObjectAndType()
        {
            var lines = new[] {"object VifPackage: TVifPackage", "end"};
            var vif = new VifObjectBuilder().Build(lines);
            Assert.AreEqual("VifPackage", vif.Name);
            Assert.AreEqual("TVifPackage", vif.Clazz);
        }
    }
}