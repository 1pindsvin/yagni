using System;
using System.Collections.Generic;
using System.IO;
using DataService.DataAccess;
using DataService.Model;

namespace DataService.Io
{
    public class XmlBuilder
    {
        public static Func<IFileSystem> ResolveFileSystem = () => new RunTrackFileSystem();


        private readonly AthleteData _athleteData;

        public XmlBuilder(AthleteData athleteData)
        {
            FileSystem = ResolveFileSystem();
            _athleteData = athleteData;
        }

        private IFileSystem FileSystem { get; set; }

        public string Save()
        {
            var directoryPath = RunTrackEnvironment.MappedFullyQualifiedDownloadDirectory;

            var athleteDataPath = Path.Combine(directoryPath, _athleteData.UniqueID + ".xml" );

            FileSystem.SaveAsXml(_athleteData, athleteDataPath);

            return athleteDataPath;

        }
    }
}