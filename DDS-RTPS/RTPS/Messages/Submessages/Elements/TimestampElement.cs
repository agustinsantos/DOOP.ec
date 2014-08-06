using Rtps.Messages.Types;
using System;

namespace Rtps.Messages.Submessages.Elements
{
    /// <summary>
    /// Timestamp is used to represent time. The representation should be capable of having a resolution
    /// of nano-seconds or better.
    /// </summary>
    public class TimestampElement : SubmessageElement<Time>
    {
        public static int TIMESTAMP_SIZE = 8;

        public TimestampElement(Time val)
            : base(TIMESTAMP_SIZE, val)
        {
        }

        public TimestampElement()
            : this(new Time())
        {
        }
    }
}
