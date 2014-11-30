using Doopec.DDS.Core.Policy;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;
using System.Collections.Generic;

namespace Doopec.Dds.Core.Policy
{
    public class PartitionQosPolicyImpl : QosPolicyImpl, PartitionQosPolicy
    {
        public ICollection<string> getName()
        {
            throw new NotImplementedException();
        }

        public ModifiablePartitionQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
