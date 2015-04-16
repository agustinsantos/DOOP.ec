using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using org.omg.dds.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core.Policy
{
    public class DestinationOrderQosPolicyImpl: QosPolicy, DestinationOrderQosPolicy
    {
        private readonly DestinationOrderQosPolicyKind kind;

        public DestinationOrderQosPolicyImpl(DestinationOrderQosPolicyKind kind)
        {
            this.kind = kind;
        }
        public DestinationOrderQosPolicyKind GetKind()
        {
            return kind;
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public ModifiableDestinationOrderQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
