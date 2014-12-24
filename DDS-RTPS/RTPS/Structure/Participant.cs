using Rtps.Structure.Types;
using System.Collections.Generic;
namespace Rtps.Structure
{

    /// <summary>
    /// From OMG RTPS Standard v2.1 p13: Container of all RTPS entities that share 
    /// common properties and are located in a single address space.
    /// Participant is the main entry point to RTPS (DDS) domain. Participant is
    /// responsible for creating readers and writers and setting up network
    /// receivers.
    /// </summary>
    public abstract class Participant : Entity
    {
        private ProtocolVersion protocolVersion = ProtocolVersion.PROTOCOLVERSION;
        private VendorId vendorId = VendorId.VENDORID_UNKNOWN;
        private IList<Locator> defaultUnicastLocatorList = new List<Locator>();
        private IList<Locator> defaultMulticastLocatorList = new List<Locator>();


        private IList<Endpoint> endpoints_ = new List<Endpoint>();

        /// <summary>
        /// Maps that stores discovered participants. discovered participant is
        /// shared with all entities created by this participant.
        /// </summary>
        //private readonly Dictionary<GuidPrefix, Participant> discoveredParticipants;

        public Participant()
        {
            this.Guid.EntityId = EntityId.ENTITYID_PARTICIPANT;
        }

        /// <summary>
        /// Identifies the version of the RTPS protocol that the Participant uses to 
        /// communicate.
        /// </summary>
        public ProtocolVersion ProtocolVersion
        {
            get { return protocolVersion; }
            set { protocolVersion = value; }
        }

        /// <summary>
        ///  Identifies the vendor of the RTPS middleware that contains the 
        /// Participant.
        /// </summary>
        public VendorId VendorId
        {
            get { return vendorId; }
            set { vendorId = value; }
        }

        /// <summary>
        /// Default list of unicast locators (transport, address, port combinations) 
        // that can be used to send messages to the Endpoints contained in the Participant.
        // These are the unicast locators that will be used in case the Endpoint does not 
        // specify its own Set of Locators
        /// </summary>
        public IList<Locator> DefaultUnicastLocatorList
        {
            get { return defaultUnicastLocatorList; }
            set { defaultUnicastLocatorList = value; }
        }

        /// <summary>
        /// Default list of multicast locators (transport, address, port combinations) 
        /// that can be used to send messages to the Endpoints contained in the Participant.
        /// These are the multicast locators that will be used in case the Endpoint does not 
        /// specify its own Set of Locators.
        /// </summary>
        public IList<Locator> DefaultMulticastLocatorList
        {
            get { return defaultMulticastLocatorList; }
            set { defaultMulticastLocatorList = value; }
        }
    }
}