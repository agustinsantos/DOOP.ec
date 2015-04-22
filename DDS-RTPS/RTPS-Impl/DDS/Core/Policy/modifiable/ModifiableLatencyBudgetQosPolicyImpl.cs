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
    class ModifiableLatencyBudgetQosPolicyImpl: LatencyBudgetQosPolicyImpl, ModifiableLatencyBudgetQosPolicy
    {
        public ModifiableLatencyBudgetQosPolicyImpl(LatencyBudgetQosPolicy qos)
            : base(qos.GetDuration())
        {
        }

        public ModifiableLatencyBudgetQosPolicyImpl(Duration duration)
            : base(duration)
        {

        }

        public ModifiableLatencyBudgetQosPolicy SetDuration(Duration duration)
        {
            this.GetDurationQos=duration;
            return this;
        }

        public ModifiableLatencyBudgetQosPolicy SetDuration(long duration, global::DDS.ConversionUtils.TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public ModifiableLatencyBudgetQosPolicy CopyFrom(LatencyBudgetQosPolicy other)
        {
            return new ModifiableLatencyBudgetQosPolicyImpl (other.GetDuration());
        }

        public LatencyBudgetQosPolicy FinishModification()
        {
            return new LatencyBudgetQosPolicyImpl(this.GetDuration());
        }
    }
}
