using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using DataService.DataAccess;
using DataService.Garmin;
using DataService.Io;
using DataService.Model;

namespace RunTrack
{
    public class DownloadService
    {
        public static Func<IFileSystem> ResolveFileSystem = () => new RunTrackFileSystem();
        public static Func<ICsvData> ResolveCsvData = () => new CsvData();

        public string DownloadMyRuns(Athlete athlete)
        {
            var fileSystem = ResolveFileSystem();
            var csvData = ResolveCsvData();
            var rundataAccess = new RunDataAccess();

            var runs = rundataAccess.GetRuns(athlete);
            var fileName = athlete.User.UserName + ".csv";

            var filepath =
                Path.Combine(
                    RunTrackEnvironment.MappedFullyQualifiedDownloadDirectory,
                    fileName);

            var content = csvData.AsFileContent(runs);
            fileSystem.WriteContent(filepath, content);

            var downloadPathForClient = RunTrackEnvironment.FullyQualifiedDownloadDirectoryUrl + "/" + fileName;

            return downloadPathForClient;
        }

        public string UploadWatchData(string uuencoded, string userID)
        {
/*
            using (var b = new BackgroundWorker { WorkerReportsProgress = false, WorkerSupportsCancellation = false })
            {
                b.DoWork += (worker, workEventArgument) => new WorkoutDataAcces().AddWatchData(uuencoded, userID);
                b.RunWorkerAsync();
            }
            return userID;
*/

            var workoutDataAccess = new WorkoutDataAcces();
            return workoutDataAccess.AddWatchData(uuencoded, userID);
        }

    }
}