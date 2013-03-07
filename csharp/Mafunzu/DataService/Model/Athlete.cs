using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Security.Principal;

namespace DataService.Model
{
    public partial class Athlete
    {
        public const int NullIntValue = -1;

        private static int AsInteger(int? value)
        {
            return value.HasValue ? value.Value : NullIntValue; 
        }

        internal AthleteHealth HealthSnapshot
        {
            get
            {
                var e = new AthleteHealth
                            {
                                Athlete = this,
                                Arm = AsInteger(Arm),
                                MaximumHeartRate = AsInteger(MaximumHeartRate),
                                RestingHeartRate = AsInteger(RestingHeartRate),
                                Thigh = AsInteger(Thigh),
                                ThresholdHeartRate = AsInteger(ThresholdHeartRate),
                                Waist = AsInteger(Waist),
                                Weight = AsInteger(Weight)
                            };

                return e;
            }
        }

        public bool HasSameHealthAs(Athlete other)
        {
            var myHealth = HealthSnapshot;
            var otherHealth = other.HealthSnapshot;
            return myHealth.HasSameHealthDataAs(otherHealth);
        }

        public static void CopyPropertiesExceptVersion(Athlete from, Athlete to)
        {
            foreach (
                var info in 
                from.GetType().GetProperties().
                Where(x => x.CanWrite && x.Name != "RtVersion" && x.Name != "Version")
                )
            {
                info.SetValue(to, info.GetValue(from, null), null);
            }
        }

        public ulong RtVersion
        {
            get
            {
                return System.BitConverter.ToUInt64(Version.ToArray(), 0);
            }
            set
            {
                this.Version = System.BitConverter.GetBytes(value);
            }
        }

        public string Name
        {
            get { return FirstName + " " + LastName; }
            set { }
        }

    }
}