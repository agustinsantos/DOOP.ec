
using Rtps.Structure.Types;

namespace Rtps.Structure
{

    /// <summary>
    /// From OMG RTPS Standard v2.1 p12: Base class for all RTPS entities. RTPS Entity
    /// represents the class of objects that are visible to other RTPS Entities on the
    /// network. As such, RTPS Entity objects have a globally-unique identifier (GUID)
    /// and can be referenced inside RTPS messages.
    /// Maps to the value of the DDS BuiltinTopicKey_t
    /// used to describe the corresponding DDS Entity.
    /// Refer to the DDS specification for more details.
    /// </summary>
    public class Entity
    {
        //RTPS Attributes
        protected GUID guid;

        public Entity(GuidPrefix guidPrefix, EntityId entityId)
        {
            this.guid = new GUID(guidPrefix, entityId);
        }

        public Entity(GUID guid)
        {
            this.guid = guid;
        }

        /// <summary>
        /// Type used to hold globally-unique RTPS-entity identifiers. These are identifiers used
        /// to uniquely refer to each RTPS Entity in the system.
        /// The following values are reserved by the protocol: GUID_UNKNOWN
        /// </summary>
        public GUID Guid
        {
            get { return guid; }
            protected set { guid = value; }
        }
    }
}