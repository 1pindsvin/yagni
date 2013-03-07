using System;
using System.IO;
using DataService.DataAccess;

namespace DataService.Io
{
    public class RunTrackFileSystem : IFileSystem
    {

        public bool FileExists(string path)
        {
            throw new NotImplementedException();
        }

        public bool DirectoryExists(string path)
        {
            return Directory.Exists(path);
        }

        public void CreateDirectory(string path)
        {
            Directory.CreateDirectory(path);
        }

        public void SaveAsXml(AthleteData athleteData, string path)
        {
            XmlUtility.SerializeObject(athleteData, path);
        }

        public void WriteContent(string filepath, string content)
        {
            File.WriteAllText(filepath,content);
        }
    }
}