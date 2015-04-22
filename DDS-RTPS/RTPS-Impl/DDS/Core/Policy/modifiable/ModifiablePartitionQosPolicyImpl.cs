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
    class ModifiablePartitionQosPolicyImpl : PartitionQosPolicyImpl, ModifiablePartitionQosPolicy
    {
          public ModifiablePartitionQosPolicyImpl(PartitionQosPolicy qos)
            : base(qos.GetName(), qos.GetBootstrap())
        {
        }

          public ModifiablePartitionQosPolicyImpl(ICollection<string> name, Bootstrap boostrap)
            : base(name, boostrap)
        {

        }


        public ModifiablePartitionQosPolicy SetName(ICollection<string> name)
        {
            this.GetNameQos=name;
            return this;
        }

        public ModifiablePartitionQosPolicy CopyFrom(PartitionQosPolicy other)
        {
            return new ModifiablePartitionQosPolicyImpl(other.GetName(),other.GetBootstrap());
        }

        public PartitionQosPolicy FinishModification()
        {
            return new PartitionQosPolicyImpl(this.GetName(),this.GetBootstrap());
        }
    }
}
