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
    class ModifiableLifespanQosPolicyImpl : LifespanQosPolicyImpl, ModifiableLifespanQosPolicy
    {
        public ModifiableLifespanQosPolicyImpl(LifespanQosPolicy qos)
            : base(qos.GetDuration(),qos.GetBootstrap())
        {
        }

        public ModifiableLifespanQosPolicyImpl(Duration duration,Bootstrap boostrap)
            : base(duration,boostrap )
        {

        }


        public ModifiableLifespanQosPolicy SetDuration(Duration duration)
        {
            this.GetDurationQos = duration;
            return this;
        }

        public ModifiableLifespanQosPolicy SetDuration(long duration, global::DDS.ConversionUtils.TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public ModifiableLifespanQosPolicy CopyFrom(LifespanQosPolicy other)
        {
            return new ModifiableLifespanQosPolicyImpl(other);
        }

        public LifespanQosPolicy FinishModification()
        {
            return new LifespanQosPolicyImpl (this.GetDuration(),this.GetBootstrap());
        }
    }
}
