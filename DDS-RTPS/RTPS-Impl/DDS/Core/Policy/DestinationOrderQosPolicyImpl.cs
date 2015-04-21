using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using org.omg.dds.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doopec.Dds.Core.Policy.modifiable;

namespace Doopec.Dds.Core.Policy
{
    public class DestinationOrderQosPolicyImpl: QosPolicy, DestinationOrderQosPolicy
    {
       
        public DestinationOrderQosPolicyKind KindQos { get; protected internal set; }
        public DestinationOrderQosPolicyImpl(DestinationOrderQosPolicyKind kind)
        {
            this.KindQos = kind;
        }
        public DestinationOrderQosPolicyKind GetKind()
        {
            return KindQos;
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
            return new ModifiableDestinationOrderQosPolicyImpl(this);
        }
    }
}
