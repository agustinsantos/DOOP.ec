using Rtps.Messages.Types;
using Rtps.Structure.Types;
using System.Collections.Generic;
namespace Rtps.Messages.Submessages
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
    public class InfoReply : SubMessage
    {
        private IList<Locator> unicastLocatorList;
        private IList<Locator> multicastLocatorList;

        public InfoReply()
            : this(new List<Locator>(), new List<Locator>())
        {
        }

        public InfoReply(IList<Locator> unicastLocators, IList<Locator> multicastLocators)
            : base(SubMessageKind.INFO_REPLY)
        {
            this.unicastLocatorList = unicastLocators;
            this.multicastLocatorList = multicastLocators;

            if (multicastLocatorList != null && multicastLocatorList.Count > 0)
            {
                Header.Flags.SetMulticastFlag();
            }
        }

        /// <summary>
        /// Returns the MulticastFlag. If true, message contains MulticastLocatorList
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
        /// Indicates an alternative set of unicast addresses that the Writer should
        /// use to reach the Readers when replying to the Submessages that follow.
        /// </summary>
        public IList<Locator> UnicastLocatorList
        {
            get
            {
                return unicastLocatorList;
            }
        }

        /// <summary>
        /// Indicates an alternative set of multicast addresses that the Writer
        /// should use to reach the Readers when replying to the Submessages that
        /// follow. Only present when the MulticastFlag is set.
        /// </summary>
        public IList<Locator> MulticastLocatorList
        {
            get
            {
                return multicastLocatorList;
            }
        }

        public override string ToString()
        {
            return base.ToString() + ", " + unicastLocatorList + ", " + multicastLocatorList;
        }
    }
}
