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
    public class OwnershipStrengthQosPolicyImpl : QosPolicyImpl, OwnershipStrengthQosPolicy
    {
        public int StrengthQos { get; protected internal set; }


        public OwnershipStrengthQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
            
        }
        public OwnershipStrengthQosPolicyImpl(int strength,Bootstrap boostrap)
            :base(boostrap)
        {
            this.StrengthQos = strength;
        }

        public int GetValue()
        {
            return StrengthQos;
        }

        

        public ModifiableOwnershipStrengthQosPolicy Modify()
        {
            return new ModifiableOwnershipStrengthQosPolicyImpl(this);
        }
    }
}
