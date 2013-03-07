using DataService.DataAccess;

namespace DataService.Io
{
    public interface IFileSystem
    {
        bool FileExists(string path);
        bool DirectoryExists(string path);
        void CreateDirectory(string path);
        void SaveAsXml(AthleteData athleteData, string path);
        void WriteContent(string filepath, string content);
    }
}