using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataService.Model;

namespace DataService.Io
{
    public class CsvLine
    {

        public string Time { get; set; }
        public string Distance { get; set; }
        public string Shoe { get; set; }
        public string RegisteredAt { get; set; }
        public string LastChanged { get; set; }
        public string Labels { get; set; }

        public string BuildHeaderCsv(char separator)
        {
            var header = new string[] { "Time", "Distance", "Shoe", "RegisteredAt", "LastChanged", "Labels" };
            return string.Join(char.ToString(separator), header);
        }

        public string AsCsvLine(char separator)
        {
            var result = new string[] { Time, Distance, Shoe, RegisteredAt, LastChanged, Labels };

            return string.Join(char.ToString(separator), result);
        }
    }

    public interface ICsvData
    {
        string AsFileContent(IEnumerable<Run> runs);
    }

    public class CsvData : ICsvData
    {
        public CsvData()
        {
            Separator = '\t';
            Locale = "da_DK";
        }

        public string Locale  { get; 
            set; }

        public char Separator { get; set; }

        private Func<DateTime, string> ConvertDateTime;

        public string AsFileContent(IEnumerable<Run> runs)
        {
            var b = new StringBuilder();
            if (Locale=="da_DK")
            {
                ConvertDateTime = DanishDateTimeAsString;
            }
            else
            {
                Error.NotImplementedException(Locale);
            }
            b.AppendLine(new CsvLine().BuildHeaderCsv(Separator));
            foreach (var run in runs)
            {
                b.AppendLine(AsCsvLine(run));
            }
            return b.ToString();
        }

        string LabelsToString(int labels)
        {
            var e = (LabelEnumeration) labels;
            if (e==LabelEnumeration.None)
            {
                return "";
            }
            if ((e & LabelEnumeration.Competition) == LabelEnumeration.Competition)
            {
                return Enum.GetName(typeof (LabelEnumeration), e);
            }
            throw new InvalidOperationException("LabelsToString(int labels)");
        }

        private string AsCsvLine(Run run)
        {
            var e = 
                new CsvLine
                    {
                        Distance = run.Distance.ToString(),
                        Labels = LabelsToString(run.Labels),
                        LastChanged = ConvertDateTime(run.LastChanged),
                        RegisteredAt = ConvertDateTime(run.Start),
                        Shoe = ShoeAsString(run.Shoe),
                        Time = run.Time.ToString()
                    };
            return e.AsCsvLine(Separator);
        }

        private string ShoeAsString(Shoe shoe)
        {
            return shoe == null ? "" : shoe.Brand;
        }

        private string DanishDateTimeAsString(DateTime dateTime)
        {
            return string.Format("{0}-{1}-{2} {3}:{4}:{5}", dateTime.Day, dateTime.Month, dateTime.Year, dateTime.Hour,ToTimeNumberString(dateTime.Minute), ToTimeNumberString(dateTime.Second));
        }

        private string ToTimeNumberString(int number)
        {
            return number > 9 ? number.ToString() : "0" + number;
        }
    }
}
