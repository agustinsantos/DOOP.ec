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
        private readonly ReliabilityQosPolicyKind kind = ReliabilityQosPolicyKind.RELIABLE;
        private readonly Duration maxBlockingTime = Duration.ZeroDuration(null);

        public ReliabilityQosPolicyImpl()
        { }

        public ReliabilityQosPolicyImpl(ReliabilityQosPolicyKind kind, Duration maxBlockingTime)
        {
            this.kind = kind;
            this.maxBlockingTime = maxBlockingTime;
        }

        public ReliabilityQosPolicyImpl(ReliabilityQosPolicyKind kind)
        {
            this.kind = kind;
        }

        public ReliabilityQosPolicyKind GetKind()
        {
            return kind;
        }

        public Duration GetMaxBlockingTime()
        {
            return maxBlockingTime;
        }

        public ModifiableReliabilityQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
