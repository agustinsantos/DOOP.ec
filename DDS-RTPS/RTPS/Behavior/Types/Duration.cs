using System;
namespace Rtps.Behavior.Types
{
    /// <summary>
    /// Type used to hold time-differences.
    /// Should have at least nano-second resolution.
    /// </summary>
    public class Duration : IComparable<Duration>
    {
        // INFINITE: dds v1.2, IDL DURATION_INFINITE_SEC, DURATION_INFINITE_NSEC,
        public static readonly Duration INFINITE = new Duration(Int32.MaxValue, Int32.MaxValue);
        private int sec;
        private int nano;


        /// <summary>
        /// Constructor for Duration
        /// </summary>
        /// <param name="millis">Duration expressed in milliseconds.</param>
        public Duration(int millis)
        {
            this.sec = (int)(millis / 1000);
            this.nano = 0;
        }
        /// <summary>
        /// Constructor for Duration
        /// </summary>
        /// <param name="millis">Duration expressed in milliseconds.</param>
        public Duration(long millis)
        {
            this.sec = (int)(millis / 1000);
            this.nano = 0;
        }

        /// <summary>
        /// Constructor for Duration
        /// </summary>
        /// <param name="sec">seconds</param>
        /// <param name="nano">nanoseconds</param>
        public Duration(int sec, int nano)
        {
            this.sec = sec;
            this.nano = nano;
        }

        /// <summary>
        /// Gets this duration as milliseconds.
        /// </summary>
        /// <returns>duration as milliseconds</returns>
        public long AsMillis()
        {
            long n = 0;
            if (nano != 0)
            {
                n = nano / 1000000;
            }
            return (long)sec * 1000 + n;
        }


        public int CompareTo(Duration o)
        {
            return (int)(AsMillis() - o.AsMillis());
        }


        public override bool Equals(Object o)
        {
            if (o is Duration)
            {
                Duration other = (Duration)o;
                if (sec == other.sec && nano == other.nano)
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (int)this.AsMillis();
        }

        public override string ToString()
        {
            return "[" + sec + ":" + nano + "]";
        }
    }
}