using Doopec.Dds.Core.Policy.modifiable;
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
        
        public ICollection<string> NameQos { get; protected internal set; }
        public PartitionQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }

        public PartitionQosPolicyImpl(ICollection<string> getName, Bootstrap boostrap)
            : base(boostrap)
        {
            this.NameQos = getName;
        }
        public ICollection<string> GetName()
        {
            return NameQos;
        }

        public ModifiablePartitionQosPolicy Modify()
        {
            return new ModifiablePartitionQosPolicyImpl(this);
        }
    }
}
