using Doopec.Dds.Core.Policy.modifiable;
using Doopec.DDS.Core.Policy;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core.Policy
{
    public class DurabilityQosPolicyImpl : QosPolicyImpl, DurabilityQosPolicy
    {
        
        public DurabilityQosPolicyKind KindQos {get; protected internal set; }
        public DurabilityQosPolicyImpl(DurabilityQosPolicyKind kind, Bootstrap boostrap)
            : base(boostrap)
        {
            this.KindQos = kind;
        }

        public DurabilityQosPolicyKind GetKind()
        {
            return KindQos;
        }

        public ModifiableDurabilityQosPolicy Modify()
        {
            return new ModifiableDurabilityQosPolicyImpl(this);
        }
    }
}
