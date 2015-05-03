
using Rtps.Structure.Types;
using System.Collections.Generic;

namespace Rtps.Structure
{

    /// <summary>
    /// From OMG RTPS Standard v2.1 p12: Specialization of RTPS Entity representing the
    /// objects that can be communication endpoints. That is, the objects that can be
    /// the sources or destinations of RTPS messages.
    /// </summary>
    public class Endpoint : Entity
    {
        private TopicKind topicKind;
        private ReliabilityKind reliabilityLevel;
        private IList<Locator> unicastLocatorList = new List<Locator>();
        private IList<Locator> multicastLocatorList = new List<Locator>();


        public Endpoint(GUID guid)
            : base(guid)
        {
        }

        /// <summary>
        /// The levels of reliability supported by the Endpoint
        /// </summary>
        public TopicKind TopicKind
        {
            get { return topicKind; }
            set { topicKind = value; }
        }

        /// <summary>
        ///  Used to indicate whether the Endpoint is associated with a DataType 
        ///  that has defined some fields as containing the DDS key.
        /// </summary>
        public ReliabilityKind ReliabilityLevel
        {
            get { return reliabilityLevel; }
            set { reliabilityLevel = value; }
        }

        /// <summary>
        /// List of unicast locators (transport, address, port combinations) that can 
        /// be used to send messages to the Endpoint. The list may be empty
        /// </summary>
        public IList<Locator> UnicastLocatorList
        {
            get { return unicastLocatorList; }
            set { unicastLocatorList = value; }
        }

        /// <summary>
        /// List of multicast locators (transport, address, port combinations) that can 
        /// be used to send messages to the Endpoint. The list may be empty.
        /// </summary>
        public IList<Locator> MulticastLocatorList
        {
            get { return multicastLocatorList; }
            set { multicastLocatorList = value; }
        }
    }
}
