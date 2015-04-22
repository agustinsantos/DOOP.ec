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
    public class TimeBasedFilterQosPolicyImpl : QosPolicyImpl, TimeBasedFilterQosPolicy
    {
        public Duration MinimumSeparationQos { get; protected internal set; }
        public TimeBasedFilterQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }
        public TimeBasedFilterQosPolicyImpl(Duration getMinimumSeparation,Bootstrap boostrap)
            :base(boostrap)
        {
            this.MinimumSeparationQos = getMinimumSeparation;
        }
        public Duration GetMinimumSeparation()
        {
            return MinimumSeparationQos;
        }

       
        public ModifiableTimeBasedFilterQosPolicy Modify()
        {
            return new ModifiableTimeBasedFilterQosPolicyImpl(this);
        }
    }
}
