using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core.Policy.modifiable
{
    class ModifiableDestinationOrderQosPolicyImpl : DestinationOrderQosPolicyImpl, ModifiableDestinationOrderQosPolicy
    {
        public ModifiableDestinationOrderQosPolicyImpl(DestinationOrderQosPolicy qos)
            : base(qos.GetKind(),qos.GetBootstrap())
        {
        }

        public ModifiableDestinationOrderQosPolicyImpl(DestinationOrderQosPolicyKind kind,Bootstrap boostrap)
            : base(kind,boostrap)
        {

        }

        public ModifiableDestinationOrderQosPolicy SetKind(DestinationOrderQosPolicyKind kind)
        {
            this.KindQos = kind;
            return this;
        }

        public ModifiableDestinationOrderQosPolicy CopyFrom(DestinationOrderQosPolicy other)
        {
            return new ModifiableDestinationOrderQosPolicyImpl(other.GetKind(),other.GetBootstrap ()); 
        }

        public DestinationOrderQosPolicy FinishModification()
        {
            return new DestinationOrderQosPolicyImpl(this.GetKind(),this.GetBootstrap());
        }
    }
}
