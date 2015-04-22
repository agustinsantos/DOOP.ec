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
    class ModifiableWriterDataLifecycleQosPolicyImpl:WriterDataLifecycleQosPolicyImpl, ModifiableWriterDataLifecycleQosPolicy
    {
        public ModifiableWriterDataLifecycleQosPolicyImpl(WriterDataLifecycleQosPolicy qos)
            : base(qos.IsAutDisposeUnregisteredInstances(),qos.GetBootstrap())
        {
        }

        public ModifiableWriterDataLifecycleQosPolicyImpl(bool autDisposeUnregisteredInstances, Bootstrap boostrap)
            : base(autDisposeUnregisteredInstances,boostrap)
        {

        }

        public ModifiableWriterDataLifecycleQosPolicy SetAutDisposeUnregisteredInstances(bool autDisposeUnregisteredInstances)
        {
            this.IsAutDisposeUnregisteredInstancesQos=autDisposeUnregisteredInstances ;
            return this;
        }

        public ModifiableWriterDataLifecycleQosPolicy CopyFrom(WriterDataLifecycleQosPolicy other)
        {
            return new ModifiableWriterDataLifecycleQosPolicyImpl(other);
        }

        public WriterDataLifecycleQosPolicy FinishModification()
        {
            return new WriterDataLifecycleQosPolicyImpl(this.IsAutDisposeUnregisteredInstances(),this.GetBootstrap());
        }
    }
}
