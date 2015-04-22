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
    class ModifiableOwnershipQosPolicyImpl : OwnershipQosPolicyImpl, ModifiableOwnershipQosPolicy
    {
        public ModifiableOwnershipQosPolicyImpl(OwnershipQosPolicy qos)
            : base(qos.GetKind())
        {
        }

        public ModifiableOwnershipQosPolicyImpl(OwnershipQosPolicyKind kind)
            : base(kind)
        {

        }
        public ModifiableOwnershipQosPolicy SetKind(OwnershipQosPolicyKind kind)
        {
            this.KindQos=kind ;
            return this;
        }

        public OwnershipQosPolicyKind GetKind()
        {
            throw new NotImplementedException();
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public bool Equals(object other)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode()
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

        public ModifiableOwnershipQosPolicy CopyFrom(OwnershipQosPolicy other)
        {
            return new ModifiableOwnershipQosPolicyImpl(other.GetKind());
        }

        public OwnershipQosPolicy FinishModification()
        {
            return new OwnershipQosPolicyImpl(this.GetKind());
        }
    }
}
