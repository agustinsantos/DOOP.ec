
using rtps.messages.elements;
using System.Collections.Generic;
namespace rtps.messages.submessage.interpreter
{
    /// <summary>
    /// This message is sent from an RTPS Reader to an RTPS Writer. It contains
    /// explicit information on where to send a reply to the Submessages that follow
    /// it within the same message.
    /// 
    /// see 9.4.5.9 InfoReply Submessage, 8.3.7.8 InfoReply
    /// From OMG RTPS Standard v2.1 p44: Provides information about where to reply to the 
    ///  entities that appear in subsequent Submessages
    ///  
    ///  From OMG RTPS Standard v2.1 p57: This message is sent from an RTPS Reader to an 
    ///  RTPS Writer. It contains explicit information on where to send a reply to the 
    ///  Submessages that follow it within the same message.
    /// </summary>
    public class InfoReplyIp4 : SubMessage
    {
        private LocatorUDPv4 unicastLocator;
        private LocatorUDPv4 multicastLocator;

        public InfoReplyIp4()
            : this(null, null)
        {
        }

        public InfoReplyIp4(LocatorUDPv4 unicastLocator, LocatorUDPv4 multicastLocator)
            : base(SubMessageKind.INFO_REPLY_IP4)
        {
            this.unicastLocator = unicastLocator;
            this.multicastLocator = multicastLocator;

            if (multicastLocator != null)
            {
                Header.Flags.SetMulticastFlag();
            }
        }

        /// <summary>
        /// Returns the MulticastFlag. If true, message contains MulticastLocator
        /// true, if message contains multicast locator
        /// </summary>
        public bool HasMulticastFlag
        {
            get
            {
                return Header.Flags.HasMulticastFlag;
            }
        }


        /// <summary>
        /// Gets the unicast locator, if present
        /// </summary>
        public LocatorUDPv4 UnicastLocator
        {
            get
            {
                return unicastLocator;
            }
            set
            {
                unicastLocator = value;
            }
        }

        /// <summary>
        /// Returns the MulticastFlag. If true, message contains MulticastLocator
        /// </summary>
        public LocatorUDPv4 MulticastLocator
        {
            get
            {
                return multicastLocator;
            }
            set
            {
                multicastLocator = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + ", " + unicastLocator + ", " + multicastLocator;
        }
    }
}
