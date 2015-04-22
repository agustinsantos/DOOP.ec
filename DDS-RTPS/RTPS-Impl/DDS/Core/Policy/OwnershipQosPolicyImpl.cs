using Doopec.Dds.Core.Policy.modifiable;
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
    public class OwnershipQosPolicyImpl : QosPolicy, OwnershipQosPolicy
    {
        
        public OwnershipQosPolicyKind KindQos { get; protected internal set; }
        public OwnershipQosPolicyImpl(OwnershipQosPolicyKind kind)
        {
            this.KindQos = kind;
        }
        public OwnershipQosPolicyKind GetKind()
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

        public ModifiableOwnershipQosPolicy Modify()
        {
            return new ModifiableOwnershipQosPolicyImpl(this);
        }
    }
}
