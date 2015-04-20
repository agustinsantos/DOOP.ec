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
    public class OwnershipStrengthQosPolicyImpl : QosPolicy, OwnershipStrengthQosPolicy
    {
        public int StrengthQos { get; protected internal set; }

        public OwnershipStrengthQosPolicyImpl(int strength)
        {
            this.StrengthQos = strength;
        }

        public int GetValue()
        {
            return StrengthQos;
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public ModifiableOwnershipStrengthQosPolicy Modify()
        {
            return new ModifiableDataRepresentationQosPolicy(this);
        }
    }
}
