using System;
using DataService.DataAccess;

namespace DataService.Io
{
    public class DummyFileSystem : IFileSystem
    {
        public DummyFileSystem()
        {
            SaveXmlWasCalled = false;
        }

        public bool FileExists(string path)
        {
            throw new NotImplementedException();
        }

        public bool DirectoryExists(string path)
        {
            return true;
        }

        public void CreateDirectory(string path)
        {
            throw new NotImplementedException();
        }


        public void SaveAsXml(AthleteData athleteData, string path)
        {
            //this.Xml = XmlUtility.SerializeAsXml(athleteData);
            SaveXmlWasCalled = true;
        }

        public void WriteContent(string filepath, string content)
        {
            //throw new NotImplementedException();
        }

        public bool SaveXmlWasCalled { get; set; }

        public string Xml
        {
            get; set;
        }
    }
}