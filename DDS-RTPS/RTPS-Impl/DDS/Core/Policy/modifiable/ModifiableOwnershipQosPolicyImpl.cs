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
            : base(qos.GetKind(),qos.GetBootstrap())
        {
        }

        public ModifiableOwnershipQosPolicyImpl(OwnershipQosPolicyKind kind,Bootstrap boostrap)
            : base(kind,boostrap)
        {

        }
        public ModifiableOwnershipQosPolicy SetKind(OwnershipQosPolicyKind kind)
        {
            this.KindQos=kind ;
            return this;
        }

        


        public ModifiableOwnershipQosPolicy CopyFrom(OwnershipQosPolicy other)
        {
            return new ModifiableOwnershipQosPolicyImpl(other);
        }

        public OwnershipQosPolicy FinishModification()
        {
            return new OwnershipQosPolicyImpl(this.GetKind(),this.GetBootstrap());
        }
    }
}
