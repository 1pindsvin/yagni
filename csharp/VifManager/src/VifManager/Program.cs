using System.Collections;
using System.IO;
using System.Linq;

namespace dk.magnus.VifManager
{
    class Program
    {


        private const string Path = @"c:\proj\Dantax\Dev\Op\Sk\Vif";
        static void Main(string[] args)
        {

            var vifObjects = new VifObjects();
            var fileEnumerator = new FileEnumerator(Path, "*.vif");
            var builder = new VifObjectBuilder();
            foreach (var path in fileEnumerator.EnumerateFiles())
            {
                builder.BuildVifRoot(File.ReadAllLines(path));
            }
        }
    }
}
