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
    public class OwnershipQosPolicyImpl : QosPolicyImpl, OwnershipQosPolicy
    {
        
        public OwnershipQosPolicyKind KindQos { get; protected internal set; }

        public OwnershipQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
           
        }
        public OwnershipQosPolicyImpl(OwnershipQosPolicyKind kind, Bootstrap boostrap)
            :base(boostrap)
        {
            this.KindQos = kind;
        }
        public OwnershipQosPolicyKind GetKind()
        {
            return KindQos;
        }

        

        public ModifiableOwnershipQosPolicy Modify()
        {
            return new ModifiableOwnershipQosPolicyImpl(this);
        }
    }
}
