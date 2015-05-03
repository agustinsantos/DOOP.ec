using Rtps.Behavior;
using Rtps.Structure;
using Rtps.Structure.Types;

namespace Doopec.Rtps.Discovery
{
    public class SEDPbuiltinPublicationsWriter : StatefulWriter<DiscoveredWriterData>
    {
        public SEDPbuiltinPublicationsWriter(GUID guid)
            : base(guid)
        {
            this.guid = new GUID(guid.Prefix, EntityId.ENTITYID_SEDP_BUILTIN_PUBLICATIONS_WRITER);
        }

    }
}
