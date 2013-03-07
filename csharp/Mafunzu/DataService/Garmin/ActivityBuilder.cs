using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using DataService.DataAccess;
using DataService.Model;

namespace DataService.Garmin
{
    public class ActivityBuilder
    {
        public const string ActivityName = "Activity";
        private const string AuthorName = "Author";
        private const int EmptyIntValue = -1;

        public const string LapName = "Lap";

        private const string SportAttributeName = "Sport";
        private const string TrackName = "Track";
        private const string TrackpointName = "Trackpoint";
        private static readonly CultureInfo CultureInfo;
        private static readonly int DegreesMultiplyBy = (int) Math.Pow(10, DbConstants.DegressNoOfDecimals);
        private static readonly DateTime EmptyDateTimeValue;
        private static readonly int MetersMultiplyBy = (int) Math.Pow(10, DbConstants.MeterNoOfDecimals);
        private static readonly int SpeedMultiplyBy = (int) Math.Pow(10, DbConstants.SpeedNoOfDecimals);
        private readonly XElement _activityElement;
        private readonly bool _containsActivity;
        private readonly string _languageID;
        private readonly List<Lap> _laps;
        private readonly List<Trackpoint> _trackPoints;
        private readonly List<Track> _tracks;
        private Activity _activity;

        static ActivityBuilder()
        {
            EmptyDateTimeValue = DateTime.MinValue;
            CultureInfo = CultureInfo.GetCultureInfo("en-US");
        }

        public ActivityBuilder(string activityXml)
        {
            if (string.IsNullOrEmpty(activityXml))
            {
                throw new NullReferenceException("string.IsNullOrEmpty(activityXml)");
            }
            _laps = new List<Lap>();
            _tracks = new List<Track>();
            _trackPoints = new List<Trackpoint>();

            var xDoc = XDocument.Parse(activityXml);
            var activities = xDoc.Descendants(ActivityName);

            _languageID = xDoc.Descendants("LangID").Single().Value;
            if (_languageID != "EN")
            {
                throw new InvalidOperationException("_languageID!=\"EN\"");
            }

            if (activities.Count() > 1)
            {
                throw new NotImplementedException("More than on activity found in xml");
            }
            _containsActivity = activities.Count() == 1;
            if (!_containsActivity)
            {
                return;
            }

            _activityElement = activities.Single();
        }

        public bool ContainsActivity
        {
            get { return _containsActivity; }
        }

        public string LanguageID
        {
            get { return _languageID; }
        }

        public List<Lap> Laps
        {
            get { return _laps; }
        }

        public List<Track> Tracks
        {
            get { return _tracks; }
        }

        public List<Trackpoint> TrackPoints
        {
            get { return _trackPoints; }
        }

        public Activity Activity
        {
            get { return _activity; }
        }

        private int AsInteger(ActivityType type)
        {
            return (int) type;
        }

        private ActivityType AsActivityType(int type)
        {
            return (ActivityType) type;
        }

        private static int ConvertSport(string type)
        {
            try
            {
                return (int) Enum.Parse(typeof (ActivityType), type);
            }
            catch (ArgumentException)
            {
                throw new NotImplementedException(string.Format("ConvertSport(string {0})", type));
            }
        }

        private int GetAverageLapValue(Func<Lap, double?> selector)
        {
            var laps = Laps.Where(x => selector(x) != EmptyIntValue);
            var sum = laps.Sum(selector);
            if (sum == 0)
            {
                return EmptyIntValue;
            }
            return (int) Math.Round(sum.Value/laps.Count());
        }

        private int GetMaxLapValue(Func<Lap, double?> selector)
        {
            var laps = Laps.Where(x => selector(x) != EmptyIntValue);
            var max = laps.Max(selector);
            if (!max.HasValue || max.Value == 0)
            {
                return EmptyIntValue;
            }
            return (int) Math.Round(max.Value);
        }

        private int GetSumLapValue(Func<Lap, double?> selector)
        {
            var sum =
                Laps.
                    Where(x => selector(x) != EmptyIntValue).
                    Sum(selector);
            if (sum == 0)
            {
                return EmptyIntValue;
            }
            return (int) Math.Round(sum.Value);
        }

        public void Build()
        {
            _activity = BuildActivity();
            BuildLaps(Activity);
            _activity.AverageHeartRateBpm = GetAverageLapValue(x => x.AverageHeartRateBpm);

            _activity.MaximumSpeed = GetMaxLapValue(x => x.MaximumSpeed);
            _activity.MaximumHeartRateBpm = GetMaxLapValue(x => x.MaximumHeartRateBpm);

            _activity.TotalTimeSeconds = GetSumLapValue(x => x.TotalTimeSeconds);
            _activity.DistanceMeters = GetSumLapValue(x => x.DistanceMeters);
        }

        private static string GetValueOrDefault(XElement element, string name)
        {
            var subElement = element.Element(name);
            return subElement == null ? "" : subElement.Value;
        }

        private void BuildLaps(Activity activity)
        {
            foreach (var lapElement in _activityElement.Descendants(LapName))
            {
                var lap =
                    new Lap
                        {
                            Activity = activity,
                            AverageHeartRateBpm = RoundIntValueOrDefault(lapElement, "AverageHeartRateBpm"),
                            Calories = RoundIntValueOrDefault(lapElement, "Calories"),
                            DistanceMeters = RoundIntValueOrDefault(lapElement, "DistanceMeters", MetersMultiplyBy),
                            Intensity = GetValueOrDefault(lapElement, "Intensity"),
                            MaximumHeartRateBpm = RoundIntValueOrDefault(lapElement, "MaximumHeartRateBpm"),
                            MaximumSpeed = RoundIntValueOrDefault(lapElement, "MaximumSpeed", SpeedMultiplyBy),
                            TotalTimeSeconds = RoundIntValueOrDefault(lapElement, "TotalTimeSeconds"),
                            TriggerMethod = GetValueOrDefault(lapElement, "TriggerMethod"),
                        };
                BuildTracks(lapElement, lap);
                _laps.Add(lap);
            }
        }

        private void BuildTracks(XElement lapElement, Lap lap)
        {
            foreach (var trackElement in lapElement.Descendants(TrackName))
            {
                var track =
                    new Track
                        {
                            Lap = lap,
                        };
                BuildTrackpoints(trackElement, track);
                _tracks.Add(track);
            }
        }

        private void BuildTrackpoints(XElement trackElement, Track track)
        {
            foreach (var trackpointElement in trackElement.Descendants(TrackpointName))
            {
                var positionElement = trackpointElement.Element("Position");
                var trackpoint =
                    new Trackpoint
                        {
                            AltitudeMeters =
                                RoundIntValueOrDefault(trackpointElement, "AltitudeMeters", MetersMultiplyBy),
                            DistanceMeters =
                                RoundIntValueOrDefault(trackpointElement, "DistanceMeters", MetersMultiplyBy),
                            HeartRateBpm = RoundIntValueOrDefault(trackpointElement, "HeartRateBpm"),
                            LatitudeDegrees =
                                GetPositionValueOrDefault(positionElement, "LatitudeDegrees", DegreesMultiplyBy),
                            LongitudeDegrees =
                                GetPositionValueOrDefault(positionElement, "LongitudeDegrees", DegreesMultiplyBy),
                            SensorState = GetValueOrDefault(trackpointElement, "SensorState"),
                            Time = GetDateTimeValueOrDefault(trackpointElement, "Time"),
                            Track = track,
                        };
                _trackPoints.Add(trackpoint);
            }
        }

        private static int GetPositionValueOrDefault(XElement positionElement, string subElementname, int multiplyby)
        {
            if (positionElement == null)
            {
                return EmptyIntValue;
            }
            return RoundIntValueOrDefault(positionElement, subElementname, multiplyby);
        }

        private static DateTime GetDateTimeValueOrDefault(XElement element, string name)
        {
            var subElement = element.Element(name);
            if (subElement == null)
            {
                return EmptyDateTimeValue;
            }
            var dt = ParseXmlDate(subElement.Value);
            return dt;
        }

        private static DateTime ParseXmlDate(string value)
        {
            //"2010-03-01T17:08:01Z"
            var split = value.Split('T');
            var datePart = split[0].Split('-');
            var timePart = split[1].Split(':');
            return new DateTime(
                int.Parse(datePart[0]),
                int.Parse(datePart[1]),
                int.Parse(datePart[2]),
                int.Parse(timePart[0]),
                int.Parse(timePart[1]),
                int.Parse(timePart[2].TrimEnd('Z')));
        }

        private static int RoundIntValueOrDefault(XElement element, string name)
        {
            return RoundIntValueOrDefault(element, name, 1);
        }

        private static int RoundIntValueOrDefault(XElement element, string name, int multiplyBy)
        {
            var subElement = element.Element(name);
            if (subElement == null)
            {
                return EmptyIntValue;
            }
            var e = Convert.ToDecimal(subElement.Value, CultureInfo);
            var actual = Math.Round(e*multiplyBy);
            return (int) actual;
        }

        private Activity BuildActivity()
        {
            var creatorElement = _activityElement.Descendants("Creator").Single();

            var activity =
                new Activity
                    {
                        ActivityType = ConvertSport(_activityElement.Attribute(SportAttributeName).Value),
                        ForeignSystemID = _activityElement.Element("Id").Value,
                        Description = creatorElement.Element("Name").Value,
                        ActivitySubtype = -1,
                        AverageHeartRateBpm = -1,
                        Start = DateTime.Now,
                        DistanceMeters = -1,
                        Experience = -1,
                        Done = true,
                        Intensity = "",
                        Labels = 0,
                        LastChanged = DateTime.Now,
                        MaximumHeartRateBpm = -1,
                        MaximumSpeed = -1,
                        MinimumHeartRateBpm = -1,
                        Name = "",
                        TotalTimeSeconds = -1,
                        Weather = "",
                        Workload = -1,
                    };
            return activity;
        }

    }
}