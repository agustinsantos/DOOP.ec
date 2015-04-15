using Doopec.DDS.Core.Policy;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;
using System.Collections.Generic;

namespace Doopec.Dds.Core.Policy
{
    public class PartitionQosPolicyImpl : QosPolicyImpl, PartitionQosPolicy
    {
        private readonly ICollection<string> getName;
        public PartitionQosPolicyImpl ()
        {

        }
        public PartitionQosPolicyImpl(ICollection<string> getName)
        {
            this.getName = getName;
        }
        public ICollection<string> GetName()
        {
            return getName;
        }

        public ModifiablePartitionQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
