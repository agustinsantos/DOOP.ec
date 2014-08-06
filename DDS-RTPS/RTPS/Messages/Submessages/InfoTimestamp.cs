
using Rtps.Messages.Types;
namespace Rtps.Messages.Submessages
{
    /// <summary>
    /// From OMG RTPS Standard v2.1 p44: Provides a source timestamp for subsequent Entity Submessages
    /// From OMG RTPS Standard v2.1 p59: This Submessage is used to send a timestamp which applies to
    /// the Submessages that follow within the same message.
    /// </summary>
    public class InfoTimestamp : SubMessage
    {

        /// <summary>
        /// Present only if the InvalidateFlag is not set in the header. Contains the
        /// timestamp that should be used to interpret the subsequent Submessages.
        /// </summary>
        /// <param name="systemCurrentMillis"></param>
        private Time timestamp;

        public InfoTimestamp()
            : this(0)
        {
        }


        public InfoTimestamp(long systemCurrentMillis)
            : base(SubMessageKind.INFO_TS)
        {
            this.timestamp = new Time(systemCurrentMillis);
        }

        /// <summary>
        /// Indicates whether subsequent Submessages should be considered as having a
        /// timestamp or not. Timestamp is present in _this_ submessage only if the
        /// InvalidateFlag is not set in the header.
        /// </summary>
        /// <returns></returns>
        public bool HasInvalidateFlag
        {
            get
            {
                return Header.Flags.HasInvalidateFlag;
            }
        }

        /// <summary>
        /// Gets/Sets the timestamp
        /// </summary>
        public Time TimeStamp
        {
            get
            {
                return timestamp;
            }
            set
            {
                timestamp = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + ", " + timestamp;
        }
    }
}
