using Rtps.Behavior;
using Rtps.Structure;
using Rtps.Structure.Types;

namespace Doopec.Rtps.Discovery
{
    public class SEDPbuiltinPublicationsReader : StatefulReader<DiscoveredWriterData>
    {
        public SEDPbuiltinPublicationsReader(GUID guid)
            : base(guid)
        {
            this.guid = new GUID(guid.Prefix, EntityId.ENTITYID_SEDP_BUILTIN_PUBLICATIONS_READER);
        }
    }
}
