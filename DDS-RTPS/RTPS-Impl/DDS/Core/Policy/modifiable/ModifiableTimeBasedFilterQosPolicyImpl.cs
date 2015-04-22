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
    class ModifiableTimeBasedFilterQosPolicyImpl : TimeBasedFilterQosPolicyImpl, ModifiableTimeBasedFilterQosPolicy
    {
        public ModifiableTimeBasedFilterQosPolicyImpl(TimeBasedFilterQosPolicy qos)
            : base(qos.GetMinimumSeparation(),qos.GetBootstrap())
        {
        }

        public ModifiableTimeBasedFilterQosPolicyImpl(Duration minimumSeparation, Bootstrap boostrap)
            : base(minimumSeparation , boostrap)
        {

        }

        public ModifiableTimeBasedFilterQosPolicy SetMinimumSeparation(Duration minimumSeparation)
        {
            this.MinimumSeparationQos =minimumSeparation ;
            return this;
        }

        public ModifiableTimeBasedFilterQosPolicy SetMinimumSeparation(long minimumSeparation, global::DDS.ConversionUtils.TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public ModifiableTimeBasedFilterQosPolicy CopyFrom(TimeBasedFilterQosPolicy other)
        {
            return new ModifiableTimeBasedFilterQosPolicyImpl (other);
        }

        public TimeBasedFilterQosPolicy FinishModification()
        {
            return new TimeBasedFilterQosPolicyImpl(this.GetMinimumSeparation(), this.GetBootstrap());
        }
    }
}
