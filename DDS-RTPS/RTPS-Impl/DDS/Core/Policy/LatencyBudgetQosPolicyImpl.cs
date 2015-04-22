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
    public class LatencyBudgetQosPolicyImpl : QosPolicyImpl, LatencyBudgetQosPolicy
    {
        

        public Duration GetDurationQos { get; protected internal set; }

         public LatencyBudgetQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }
      



        public LatencyBudgetQosPolicyImpl(Duration getDuration, Bootstrap boostrap)
            : base(boostrap)
        {
            this.GetDurationQos= getDuration;

        }
        public Duration GetDuration()
        {
            return GetDurationQos;
        }

        

        public ModifiableLatencyBudgetQosPolicy Modify()
        {
            return new ModifiableLatencyBudgetQosPolicyImpl(this);
        }
    }
}
