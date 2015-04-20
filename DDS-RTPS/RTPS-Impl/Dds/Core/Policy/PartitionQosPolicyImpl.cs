using Doopec.DDS.Core.Policy;
using org.omg.dds.core;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using System;
using System.Collections.Generic;

namespace Doopec.Dds.Core.Policy
{
    public class PartitionQosPolicyImpl : QosPolicyImpl, PartitionQosPolicy
    {
        private readonly ICollection<string> getName;
        public PartitionQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }

        public PartitionQosPolicyImpl(ICollection<string> getName, Bootstrap boostrap)
            : base(boostrap)
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
