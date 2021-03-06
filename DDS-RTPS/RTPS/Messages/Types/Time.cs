
using System;

namespace Rtps.Messages.Types
{
    /// <summary>
    /// The representation of the time is the one defined by the IETF Network Time Protocol (NTP)
    /// Standard (IETF RFC 1305). In this representation, time is expressed in seconds and fraction
    /// of seconds using the formula, 
    ///        time = seconds + (fraction / 2^32)
    /// </summary>
    public class Time : IComparable<Time>
    {
        protected int seconds;
        protected uint fraction;

        public static readonly Time TIME_ZERO = new Time(0, 0);
        public static readonly Time TIME_INVALID = new Time(-1, 0xffffffff);
        public static readonly Time TIME_INFINITE = new Time(0x7fffffff, 0xffffffff);

        // conversion factor from nanoseconds to NTP fractional (2^-32) seconds
        public const double NANOS_TO_RTPS_FRACS = 4.294967296;

        public Time(int sec, uint frac)
        {
            this.seconds = sec;
            this.fraction = frac;
        }

        public Time(long systemCurrentMillis)
        {
            this.TimeMillis = systemCurrentMillis;
        }

        public Time()
            : this(0, 0)
        {
        }

        public long TimeMillis
        {
            get
            {
                return ((long)Seconds * 1000) + (((long)Fraction * 1000) / 0x100000000L);
            }
            set
            {
                this.seconds = (int)(value / 1000);

                long scm = ((long)this.seconds) * 1000;

                this.fraction = (uint)(value - scm);
            }
        }

        /// <summary>
        /// Gets/Sets the seconds
        /// </summary>
        public int Seconds
        {
            get
            {
                return seconds;
            }
            set
            {
                seconds = value;
            }
        }
        /// <summary>
        /// Gets/Sets the fraction
        /// </summary>
        public uint Fraction
        {
            get
            {
                return fraction;
            }
            set
            {
                fraction = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} [{1}:{2}]", ToUTCDateTime(), this.seconds, this.fraction);
        }

        public DateTime ToUTCDateTime()
        {
            //**UTC** time
            var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds(TimeMillis);
            return networkDateTime;
        }

        public int CompareTo(Time other)
        {
            if (other != null)
            {
                if (this.seconds > other.seconds)
                {
                    return 1;
                }
                else if (this.seconds < other.seconds)
                {
                    return -1;
                }
                else
                {
                    if (this.fraction > other.fraction)
                    {
                        return 1;
                    }
                    else if (this.fraction < other.fraction)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return 1;
        }
    }
}

