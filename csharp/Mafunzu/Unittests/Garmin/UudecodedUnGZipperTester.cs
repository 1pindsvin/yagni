using System;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace DataService.Garmin
{
    [TestFixture]
    public class UudecodedUnGZipperTester
    {
        private const string GarminXml = TestConstants.GarminXml;

        private const string UuncodedCompressedData =
            "begin-base64 644 data.xml.gz" + "\n" +
            "H4sIAAAAAAAAC+1dW0/jRhR+51dYeWqlEs/4bit4xUK3jQQULeyq6ks1JKPgNrFT2wnw7zu22cTZ" + "\n" +
            "ZNXuUqnfJ8ETnotjf3POnOscj948LubWWpdVVuQnAzkUA0vnk2Ka5bOTwYfbd8fRwKpqlU/VvMj1" + "\n" +
            "ySAvBtab9Gh0W6osN4POdF7r8lzV6k5V2jJ3y6uTwX1dLxPbfnh4GM5Uucjy4aRY2Kazmtzrhars" + "\n" +
            "w9PttTPobpE8VtnObR7cYVHObEcIaf96eXHT3uc4y5tnm2gzq8qS7uYXxUTV7dt8+1NY3zh17Qwf" + "\n" +
            "q+kgPTqyrNHppM7WWZ3pKjWX24Yn62ZZlPXJ4Jf6XpeDrtN0j6epI6Q4Fs6xE91KN/HCRMrfRrbp" + "\n" +
            "+DTmQi2tm1qV9W22MKtxaPzmhmb4bVGreTP0Rk+KfFql0nW9YeyJ5m9k73VvZ55nHbKX2rxelYqh" + "\n" +
            "EM+TPuvZTrlUj9litbhZaj3tT9hp3w4/MxRVNuCYIZv/t92nhijVTP+szcu+V7V+u1y0i1w/Lc2L" + "\n" +
            "b5rH+Vut6upal5dZvqr173Xv/c1tPqr5SqdSOCO7+3f7C/aBn9h/nf/oAZzgwAMc+Ile99hQVl4Z" + "\n" +
            "eklbwtGGEDYtvSUus9nM/Liu74tpeqnylZqbld1p7Y9Wkz93nq9tWRZZXvebmw5DF18gyLZrd/TX" + "\n" +
            "00s77YXo9hCO/D2AO5APo9v23Rg0i9LwU63T07vKsPLI7rf1cbIPA/XV+Dmo+AkO/NxX/F6EX4CK" + "\n" +
            "n0uBnxOi4rcvYBDxc1H3v1hy4Beh4udR4OfB0l9EgZ/vgeInBQMDR4kjYAFk4OAo8VAtEBYK9F8p" + "\n" +
            "8CUAxolAlcFShBQAurAUKBmsuBh4D5QMZlwMrMZIAjvOF4njwwIYEwAoExfVESOdfV85IoCwlpx0" + "\n" +
            "CFzRvpMIXAAZKNDB9UVz7IFO4sICSEGBbuLAChEKCjSqICyAFBToJQ6sIk0hhb3Eg1WkKSjQT2QM" + "\n" +
            "CyADBfrAQoSEAl3YPZBCCvvAppzkYGFcISI5WNhDTeuQgoSFcWMiHCzsw+6BB3Jn8QAMEoEaE4kZ" + "\n" +
            "ODhIJCoHxwwRkQDXDokJQnIGPweWfwliwgY/WBUmIkhKaPBD5V+GzGg/xM2KYciM9oFP1lDsfyFu" + "\n" +
            "YiWF/DX4oQbjWOgP1Y1KIX/DxEWVvyT056HyL4n89VHpL2LwH0TA/hcG/5XBDzWKFDPIjyiRqPhJ" + "\n" +
            "wSBADICwQSSGcyE+9NEuDhGCe6xBMOgwEXA6m2AwgiOjB8ICyECBcSJw90AGCjQAoppxHGqMARB1" + "\n" +
            "D6TQow1+qFsghR0HfDqYBD/YUzUxQyJRDJzHwWCExMBxEA4NEDYOQhGHi4HzODj4F7a8CUOFygY/" + "\n" +
            "VCdMRFAhq8EPVn7AlyfyEiGA4yDwXugOP1j9D97+bfGTqPKXoL5YCyBuaRj8OFILIHAYBF4EdwCi" + "\n" +
            "ihCCw0gdgK974MsAhD3NhV9mtsMP1onAwcA+rBLIwL8yEajJgBRGiAQ+zMBghEjcz4QQRIE7AFFV" + "\n" +
            "QBYCRNUASTZA3CgIhwB2UAUw/mmaFj/c76xwyA/YTEoS+oNNpIwY5IeDGwWhoD/g2rwU+5/zWs3k" + "\n" +
            "hfjB1kWlsD8cXP2ZwwA2AKJ6AAkS8TsAUXdAjigccnV3yWADO7iZWBwU6CIfRmIII7m4WjRBUcoO" + "\n" +
            "QFg1ED6Zt8MPVQ2kcEMDfyCEwg3tAudxcNAf7Hf2KMxgF9eNymEGu7iJMBwqoIebCcOhAnq4OjSF" + "\n" +
            "CugBq4Dw5zE7/FAZmEIF9BIX1QuDfx6uww/1OAj+eUyDn497ngv/PHCLH2wqJX5d1A4/WP5liCP5" + "\n" +
            "uPU4Qgb54eNWVYwY9BeDH+z+x+DC8nGPs1JkYvm4iQgUmVg+sP7MQX+w38Yk0V9wv4vEoT/D1oMh" + "\n" +
            "sd9wQ0gM/mcfNwJCQX/I3xVloL8AuB4vg/8vwPX/UZSSCJADmAwOhAD3LL8UDBZIgOuB5iiIFeBm" + "\n" +
            "UUrJ4EMIcH34LAA6sHlYksGLEOB6sVgoELgoIIcUhvUDskhh2JIILIo07HkuEkvOR+VgCk8C8hfm" + "\n" +
            "GTxZIW4mL4UnNcS1QigyAUPcmmwRCf+ielJDBhsuxM0kJ8EPNhMrZIikh7hf5qLIBAxxaxJRZAKG" + "\n" +
            "uDUVSejPRXUgkNAfrAuQIhMwxD3MT0F/EW4mDMX+FwGfZOCgP1j9mWL/i3D1Pwr/X5S4sPgx+K8i" + "\n" +
            "XP2PIv5h8EP1X3FEMCNcBZojhh7hfluZI4sjTgRqCISDAmPgVECKssYxbhCJohxRDJwJ+L9kwTy3" + "\n" +
            "fmoY2Rdqubk4K82zF2Xvvc71OpvsvsToShkw3xWlLld5rktX+NZ3H/KstsbnlhuEbiCFH4vvR3Y7" + "\n" +
            "cDuvGTOeptshI/u5aTvmuiymq0k9Pk+9xsjdXm6HfDSLkhX5zqs+t12qP4oybYyT/vWhgVluOtoD" + "\n" +
            "xf2G/si3q2w+7W5ghvWu9ge1czeDdu+0+YUt4s8odw0j+3RSZ+usfmquN1eZNoTXNJyu6vudFTld" + "\n" +
            "LufZRNXmlptl6ZbkJ1Uustw6KxaLVd4MMfOu56vZ8Tjvr0X30JvH2YPzX4L5GZRfQrKPozyM4z+i" + "\n" +
            "uI/hrYEifa/nWlXaUHRztelqWP2qWFuWbzlCxD9Ysvm6SOIFu9tA96u6TKu/1POP6s2a9CAaXah8" + "\n" +
            "Zgjwx6uGV9p/u/Zrw6RXq8WdmSVEcHwqZGB2HvMCvY5uSdslNMvZ8l6WZ/nszDCuLs9Vre7MG6RH" + "\n" +
            "fwMLtNHC19kAAA==" + "\n" +
            "====";

        [Test]
        public void AssertCanDecompress()
        {
            //var userid = "peter.wihlborg@gmail.com";
            var e = new UudecodedUnGZipper(UuncodedCompressedData);

            var bytes = e.UnGZip();

            var contentXml = Encoding.UTF8.GetString(bytes);
            Assert.AreEqual(GarminXml, contentXml);
        }

        [Test, Category("slow")]
        public void AssertCanDecompressFiles()
        {
            var fileNames = new[] { "garmin-uuencoded.txt" };
            foreach (var fileName in fileNames)
            {
                var filePath = Path.Combine(Environment.CurrentDirectory, fileName);
                var fileData = File.ReadAllText(filePath);
                var e = new UudecodedUnGZipper(fileData);
                var bytes = e.UnGZip();
                Assert.IsNotNull(bytes);
                var outFileName = fileName + ".xml";
                File.WriteAllBytes(outFileName, bytes);
            }
        }
    }
}