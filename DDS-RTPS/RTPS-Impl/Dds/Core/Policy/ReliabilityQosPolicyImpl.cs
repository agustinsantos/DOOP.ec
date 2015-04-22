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
    public class ReliabilityQosPolicyImpl : QosPolicyImpl, ReliabilityQosPolicy
    {
        public ReliabilityQosPolicyKind KindQos { get; protected internal set; }
        public Duration MaxBlockingTimeQos { get; protected internal set; }

        public ReliabilityQosPolicyImpl( Bootstrap boostrap)
            : base(boostrap)
        {
            MaxBlockingTimeQos = Duration.ZeroDuration(boostrap);
        }

        public ReliabilityQosPolicyImpl(ReliabilityQosPolicyKind kind, Duration maxBlockingTime, Bootstrap boostrap)
            : this(boostrap)
        {
            this.KindQos = kind;
            this.MaxBlockingTimeQos = maxBlockingTime;
        }

        public ReliabilityQosPolicyImpl(ReliabilityQosPolicyKind kind, Bootstrap boostrap)
            : this(boostrap)
        {
            this.KindQos = kind;
        }

        public ReliabilityQosPolicyKind GetKind()
        {
            return KindQos;
        }

        public Duration GetMaxBlockingTime()
        {
            return MaxBlockingTimeQos;
        }

        public ModifiableReliabilityQosPolicy Modify()
        {
            return new ModifiableReliabilityQosPolicyImpl(this);
        }
    }



    /*
    public class ReliabilityQosPolicyImpl : QosPolicyImpl, ReliabilityQosPolicy
    {
        private readonly ReliabilityQosPolicyKind kind = ReliabilityQosPolicyKind.RELIABLE;
        private readonly Duration maxBlockingTime;

        public ReliabilityQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
            maxBlockingTime = Duration.ZeroDuration(boostrap);
        }

        public ReliabilityQosPolicyImpl(ReliabilityQosPolicyKind kind, Duration maxBlockingTime, Bootstrap boostrap)
            : this(boostrap)
        {
            this.kind = kind;
            this.maxBlockingTime = maxBlockingTime;
        }

        public ReliabilityQosPolicyImpl(ReliabilityQosPolicyKind kind, Bootstrap boostrap)
            : this(boostrap)
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
    }*/
}
