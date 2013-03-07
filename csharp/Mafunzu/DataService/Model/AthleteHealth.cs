using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataService.Model
{
    public partial class AthleteHealth 
    {
        partial void OnCreated() 
        {
            _Arm = Athlete.NullIntValue;
            _MaximumHeartRate = Athlete.NullIntValue;
            _RestingHeartRate = Athlete.NullIntValue;
            _Thigh = Athlete.NullIntValue;
            _ThresholdHeartRate = Athlete.NullIntValue;
            _Waist = Athlete.NullIntValue;
            _Weight = Athlete.NullIntValue;
        }

        internal bool HasSameHealthDataAs(AthleteHealth other)
        {
            return Arm.Equals(other.Arm) &&
                   MaximumHeartRate.Equals(other.MaximumHeartRate) &&
                   RestingHeartRate.Equals(other.RestingHeartRate) &&
                   Thigh.Equals(other.Thigh) &&
                   ThresholdHeartRate.Equals(other.ThresholdHeartRate) &&
                   Waist.Equals(other.Waist) &&
                   Weight.Equals(other.Weight);
        }

        internal bool HasSomeHealthDataSet
        {
            get
            {
                var hasNoDataSet = Arm.Equals(Athlete.NullIntValue) &&
                       MaximumHeartRate.Equals(Athlete.NullIntValue) &&
                       RestingHeartRate.Equals(Athlete.NullIntValue) &&
                       Thigh.Equals(Athlete.NullIntValue) &&
                       ThresholdHeartRate.Equals(Athlete.NullIntValue) &&
                       Waist.Equals(Athlete.NullIntValue) &&
                       Weight.Equals(Athlete.NullIntValue);
                return !hasNoDataSet;
            }
        }

    }
}
