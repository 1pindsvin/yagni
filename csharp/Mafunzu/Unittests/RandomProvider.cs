using System;

namespace Unittests
{
    public class RandomProvider
    {
        private Random _random;
        private double _storedUniformDeviate;
        private bool _storedUniformDeviateIsGood;


        public RandomProvider()
        {
            Reset();
        }

        public void Reset()
        {
            _random = new Random(Environment.TickCount);
        }


        public double Next()
        {
            return _random.NextDouble();
        }


        public bool NextBoolean()
        {
            return _random.Next(0, 2) != 0;
        }


        public double NextDouble()
        {
            var rn = _random.NextDouble();
            return rn;
        }


        public Int16 Next(Int16 min, Int16 max)
        {
            if (max <= min)
            {
                var message = "Max must be greater than min.";
                throw new ArgumentException(message);
            }
            var rn = (max*1.0 - min*1.0)*_random.NextDouble() + min*1.0;
            return Convert.ToInt16(rn);
        }


        public int Next(int min, int max)
        {
            return _random.Next(min, max);
        }


        public Int64 Next(Int64 min, Int64 max)
        {
            if (max <= min)
            {
                var message = "Max must be greater than min.";
                throw new ArgumentException(message);
            }

            var rn = (max*1.0 - min*1.0)*_random.NextDouble() + min*1.0;
            return Convert.ToInt64(rn);
        }


        public Single Next(Single min, Single max)
        {
            if (max <= min)
            {
                var message = "Max must be greater than min.";
                throw new ArgumentException(message);
            }

            var rn = (max*1.0 - min*1.0)*_random.NextDouble() + min*1.0;
            return Convert.ToSingle(rn);
        }


        public double Next(double min, double max)
        {
            if (max <= min)
            {
                var message = "Max must be greater than min.";
                throw new ArgumentException(message);
            }

            var rn = (max - min)*_random.NextDouble() + min;
            return rn;
        }


        public DateTime Next(DateTime min, DateTime max)
        {
            if (max <= min)
            {
                var message = "Max must be greater than min.";
                throw new ArgumentException(message);
            }
            var minTicks = min.Ticks;
            var maxTicks = max.Ticks;
            var rn = (Convert.ToDouble(maxTicks)
                      - Convert.ToDouble(minTicks))*_random.NextDouble()
                     + Convert.ToDouble(minTicks);
            return new DateTime(Convert.ToInt64(rn));
        }


        public TimeSpan Next(TimeSpan min, TimeSpan max)
        {
            if (max <= min)
            {
                var message = "Max must be greater than min.";
                throw new ArgumentException(message);
            }

            var minTicks = min.Ticks;
            var maxTicks = max.Ticks;
            var rn = (Convert.ToDouble(maxTicks)
                      - Convert.ToDouble(minTicks))*_random.NextDouble()
                     + Convert.ToDouble(minTicks);
            return new TimeSpan(Convert.ToInt64(rn));
        }


        public double NextUniform()
        {
            return Next();
        }


        public int NextEnum(Type enumType)
        {
            var values = (int[]) Enum.GetValues(enumType);
            var randomIndex = Next(0, values.Length);
            return values[randomIndex];
        }


        public double NextExponential()
        {
            var dum = 0.0;
            while (dum == 0.0)
                dum = NextUniform();
            return -1.0*System.Math.Log(dum, System.Math.E);
        }


        public double NextNormal()
        {
            if (_storedUniformDeviateIsGood)
            {
                _storedUniformDeviateIsGood = false;
                return _storedUniformDeviate;
            }
            else
            {
                var rsq = 0.0;
                double v1 = 0.0, v2 = 0.0, fac = 0.0;
                while (rsq >= 1.0 || rsq == 0.0)
                {
                    v1 = 2.0*Next() - 1.0;
                    v2 = 2.0*Next() - 1.0;
                    rsq = v1*v1 + v2*v2;
                }
                fac = System.Math.Sqrt(-2.0
                                       *System.Math.Log(rsq, System.Math.E)/rsq);
                _storedUniformDeviate = v1*fac;
                _storedUniformDeviateIsGood = true;
                return v2*fac;
            }
        }
    }
}