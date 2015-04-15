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
        private readonly OwnershipQosPolicyKind kind;

        public OwnershipQosPolicyImpl(OwnershipQosPolicyKind kind)
        {
            this.kind = kind;
        }
        public OwnershipQosPolicyKind GetKind()
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

        public ModifiableOwnershipQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
