using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core.Policy.modifiable
{
    class ModifiableOwnershipStrengthQosPolicyImpl : OwnershipStrengthQosPolicyImpl, ModifiableOwnershipStrengthQosPolicy
    {
        public ModifiableOwnershipStrengthQosPolicyImpl(OwnershipStrengthQosPolicy qos)
            : base(qos.GetValue())
        {
        } 

        public ModifiableOwnershipStrengthQosPolicyImpl(int strength)
            : base(strength)
        {
        } 

        public ModifiableOwnershipStrengthQosPolicy SetValue(int value)
        {
            this.StrengthQos = value;
            return this;
        }

        public ModifiableOwnershipStrengthQosPolicy CopyFrom(OwnershipStrengthQosPolicy other)
        {
            return new ModifiableOwnershipStrengthQosPolicyImpl(other.GetValue());
        }

        public OwnershipStrengthQosPolicy FinishModification()
        {
            return new OwnershipStrengthQosPolicyImpl(this.GetValue());
        }
    }
}
