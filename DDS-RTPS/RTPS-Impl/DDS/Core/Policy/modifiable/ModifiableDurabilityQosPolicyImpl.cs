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
    class ModifiableDurabilityQosPolicyImpl : DurabilityQosPolicyImpl, ModifiableDurabilityQosPolicy
    {

        public ModifiableDurabilityQosPolicyImpl(DurabilityQosPolicy qos)
            : base(qos.GetKind(),qos.GetBootstrap())
        {
        }

        public ModifiableDurabilityQosPolicyImpl(DurabilityQosPolicyKind kind, Bootstrap boostrap)
            : base(kind,boostrap)
        {

        }
        public ModifiableDurabilityQosPolicy SetKind(DurabilityQosPolicyKind kind)
        {
            this.KindQos = kind;
            return this;
        }

        public ModifiableDurabilityQosPolicy CopyFrom(DurabilityQosPolicy other)
        {
            return new ModifiableDurabilityQosPolicyImpl(other.GetKind(), other.GetBootstrap()); 
        }

        public DurabilityQosPolicy FinishModification()
        {
            return new DurabilityQosPolicyImpl(this.GetKind(),this.GetBootstrap());
        }
    }
}
