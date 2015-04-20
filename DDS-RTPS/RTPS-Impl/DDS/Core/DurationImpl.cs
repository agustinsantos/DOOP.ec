using DDS.ConversionUtils;
using org.omg.dds.core;
using org.omg.dds.core.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core
{
    internal class DurationImpl : Duration
    {
        internal Bootstrap Boostrap { get; private set; }

        // in ticks values
        private TimeSpan durationValue;

        public DurationImpl(Bootstrap boostrap, long ticks)
        {
            this.Boostrap = boostrap;
            durationValue = new TimeSpan(ticks);
        }

        public override long GetDuration(TimeUnit inThisUnit)
        {
            switch (inThisUnit)
            {
                case TimeUnit.DAYS:
                    return (long)durationValue.TotalDays;
                case TimeUnit.HOURS:
                    return (long)durationValue.TotalHours;
                case TimeUnit.MICROSECONDS:
                    return (long)(durationValue.Ticks  / (TimeSpan.TicksPerMillisecond / 1000));
                case TimeUnit.MILLISECONDS:
                    return (long)durationValue.TotalMilliseconds;
                case TimeUnit.MINUTES:
                    return (long)durationValue.TotalMinutes;
                case TimeUnit.NANOSECONDS:
                    return (long)(durationValue.Ticks / (TimeSpan.TicksPerMillisecond / 1000000.0));
                case TimeUnit.SECONDS:
                    return (long)durationValue.TotalSeconds;

                default:
                    throw new ArgumentException("Invalid Time Unit");
            }
        }

        public double GetDurationInUnits(TimeUnit inThisUnit)
        {
            switch (inThisUnit)
            {
                case TimeUnit.DAYS:
                    return durationValue.TotalDays;
                case TimeUnit.HOURS:
                    return durationValue.TotalHours;
                case TimeUnit.MICROSECONDS:
                    return durationValue.Ticks / 1000.0;
                case TimeUnit.MILLISECONDS:
                    return durationValue.TotalMilliseconds;
                case TimeUnit.MINUTES:
                    return durationValue.TotalMinutes;
                case TimeUnit.NANOSECONDS:
                    return durationValue.Ticks;
                case TimeUnit.SECONDS:
                    return durationValue.TotalSeconds;

                default:
                    throw new ArgumentException("Invalid Time Unit");
            }
        }

        public override long GetRemainder(TimeUnit primaryUnit, TimeUnit remainderUnit)
        {
            double remainer = this.GetDurationInUnits(primaryUnit) - GetDuration(primaryUnit);

            throw new NotImplementedException();
        }

        public override bool IsZero()
        {
            return durationValue.Ticks == 0;
        }

        public override bool IsInfinite()
        {
            return durationValue.Ticks == long.MaxValue;
        }

        public override ModifiableDuration Modify()
        {
            throw new NotImplementedException();
        }

        public override Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }
    }
}
