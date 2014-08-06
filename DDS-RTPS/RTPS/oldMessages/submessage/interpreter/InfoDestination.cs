

using Rtps.messages.elements;
namespace Rtps.messages.submessage.interpreter
{
    /// <summary>
    /// From OMG RTPS Standard v2.1 p44: Provides information about the final destination
    ///  of subsequent Entity Submessages. This Submessage is primarily used for relaying 
    ///  RTPS Submessages. This is not discussed in the current specification.
    ///  From OMG RTPS Standard v2.1 p56: This message is sent from an RTPS Writer to an 
    /// RTPS Reader to modify the GuidPrefix used to interpret the Reader entityIds appearing
    ///  in the Submessages that follow it.
    /// </summary>
    public class InfoDestination : SubMessage
    {
        private GuidPrefix guidPrefix;

        /// <summary>
        /// Sets GuidPrefix to UNKNOWN.
        /// </summary>
        public InfoDestination()
            : this(GuidPrefix.GUIDPREFIX_UNKNOWN)
        {
        }


        /// <summary>
        /// This constructor is used when the intention is to send data into network.
        /// </summary>
        /// <param name="guidPrefix"></param>
        public InfoDestination(GuidPrefix guidPrefix)
            : base(SubMessageKind.INFO_DST)
        {
            this.guidPrefix = guidPrefix;
        }

        /// <summary>
        /// Provides the GuidPrefix that should be used to reconstruct the GUIDs of
        /// all the RTPS Reader entities whose EntityIds appears in the Submessages
        /// that follow.
        /// </summary>
        /// <returns></returns>
        public GuidPrefix GuidPrefix
        {
            get
            {
                return guidPrefix;
            }
            set
            {
                guidPrefix = value;
            }

        }


        public override string ToString()
        {
            return base.ToString() + ", " + guidPrefix;
        }
    }
}
