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
    public class ReliabilityQosPolicyImpl : QosPolicyImpl, ReliabilityQosPolicy
    {
        private readonly ReliabilityQosPolicyKind kind;
        private readonly Duration maxBlockingTime;

        public ReliabilityQosPolicyImpl(ReliabilityQosPolicyKind kind, Duration maxBlockingTime)
        {
            this.kind = kind;
            this.maxBlockingTime = maxBlockingTime;
        }

        public ReliabilityQosPolicyKind getKind()
        {
            return kind;
        }

        public Duration getMaxBlockingTime()
        {
            return maxBlockingTime;
        }

        public ModifiableReliabilityQosPolicy modify()
        {
            throw new NotImplementedException();
        }
    }
}
