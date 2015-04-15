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
    public class TimeBasedFilterQosPolicyImpl : QosPolicy, TimeBasedFilterQosPolicy
    {
        private readonly Duration getMinimumSeparation;
        public TimeBasedFilterQosPolicyImpl(Duration getMinimumSeparation)
        {
            this.getMinimumSeparation = getMinimumSeparation;
        }
        public Duration GetMinimumSeparation()
        {
            return getMinimumSeparation;
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public ModifiableTimeBasedFilterQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
