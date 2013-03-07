using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Unittests.Statistics
{
    [TestFixture, Ignore]
    public class SporgeskemaTester
    {

        public SporgeskemaTester()
        {

        }


        static readonly Regex AssemblyRegex = new Regex(@"[^\,]+");

        private static string ReadFromAssemblyResource(Assembly assembly, string filename)
        {
            string assemblyName = AssemblyRegex.Match(assembly.FullName).Value;
            filename = assemblyName + "." + filename;
            using (Stream stream = assembly.GetManifestResourceStream(filename))
            {
                long length = stream.Length;
                byte[] data = new byte[length];
                stream.Read(data, 0, (int)length);
                return Encoding.UTF8.GetString(data);
            }
        }

        [Test]
        public void SaveDeterminedAthletes()
        {
            var data = new RespondentData(LoadRespondentsFromFile());
            SaveRespondentsToFile("DeterminedAthletes.csv", data.DeterminedAthletes);
        }

        public static void SaveRespondentsToFile(string path, IEnumerable<Respondent> respondents)
        {
            var header = new string[] {"RespondentID","CollectorID","StartDate","EndDate","IpAddress","Postnummer","Email","Age","NumberOfRunsPerWeek","NumberOfRunsPerWeekComment","NumberOfYearsRunning","NumberOfYearsRunningComment","GoalText","Goal","NumberOfShoes","UsesTrainingpeaksCom","UsesIformDk","UsesDinFormDk","UsesToolFromPulseWatch","UsesNoTrainingTool","UsesOtherTrainingToolComment","RegisterRunDataWeight","RegisterShoeDataWeight","FetchDataFromWatchWeight","TrainerWeight","StatisticsBestRunsWeight","VisualWeightlossWeight","CompareResultsWithOthersWeight","RunCalendarWeight","TrainingProgramOtherWishesComment","MonthlyPayment","MonthlyPaymentText","WantsTrialProgramEdition"};
            var writer = new FileHelpers.FileHelperEngine<Respondent> {HeaderText = string.Join("\t", header)};
            writer.WriteFile(path,respondents);
        }


        public static Respondent[] LoadRespondentsFromFile()
        {
            const string csvPath = @"sporgeskema3.csv";

            var reader = new FileHelpers.FileHelperEngine<Respondent> { Options = { IgnoreFirstLines = 2 } };

            var respondents = reader.ReadString(ReadFromAssemblyResource(Assembly.GetExecutingAssembly(), csvPath));
            return respondents;            
        }


    }
}