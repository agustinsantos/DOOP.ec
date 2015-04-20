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
        private readonly DurabilityQosPolicyKind kind;

        public DurabilityQosPolicyImpl(DurabilityQosPolicyKind kind, Bootstrap boostrap)
            : base(boostrap)
        {
            this.kind = kind;
        }

        public DurabilityQosPolicyKind GetKind()
        {
            return kind;
        }

        public ModifiableDurabilityQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
