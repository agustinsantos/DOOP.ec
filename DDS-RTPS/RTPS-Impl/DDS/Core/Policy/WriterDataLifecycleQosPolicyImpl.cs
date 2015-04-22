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
    public class WriterDataLifecycleQosPolicyImpl : QosPolicyImpl, WriterDataLifecycleQosPolicy
    {
        public bool IsAutDisposeUnregisteredInstancesQos { get; protected internal set; }

        public WriterDataLifecycleQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }
        public WriterDataLifecycleQosPolicyImpl(bool isAutDisposeUnregisteredInstancesQos, Bootstrap boostrap)
            :base(boostrap)
        {
            this.IsAutDisposeUnregisteredInstancesQos =isAutDisposeUnregisteredInstancesQos;
        }

        public bool IsAutDisposeUnregisteredInstances()
        {
            return IsAutDisposeUnregisteredInstancesQos;
        }

        public ModifiableWriterDataLifecycleQosPolicy Modify()
        {
            return new ModifiableWriterDataLifecycleQosPolicyImpl(this);
        }
    }
}
