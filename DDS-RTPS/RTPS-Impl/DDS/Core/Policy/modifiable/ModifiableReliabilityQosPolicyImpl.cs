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
    class ModifiableReliabilityQosPolicyImpl : ReliabilityQosPolicyImpl, ModifiableReliabilityQosPolicy
    {
        public ModifiableReliabilityQosPolicyImpl(ReliabilityQosPolicy qos)
            : base(qos.GetKind(),qos.GetMaxBlockingTime(),qos.GetBootstrap())
        {
        }

        public ModifiableReliabilityQosPolicyImpl(ReliabilityQosPolicyKind kind, Duration maxBlockingTime, Bootstrap boostrap)
            : base(kind,maxBlockingTime, boostrap)
        {

        }

        public ModifiableReliabilityQosPolicy SetKind(ReliabilityQosPolicyKind kind)
        {
            this.KindQos=kind ;
            return this;
        }

        public ModifiableReliabilityQosPolicy SetMaxBlockingTime(Duration maxBlockingTime)
        {
            this.MaxBlockingTimeQos =maxBlockingTime;
            return this;
        }

        public ModifiableReliabilityQosPolicy SetMaxBlockingTime(long maxBlockingTime, global::DDS.ConversionUtils.TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public ModifiableReliabilityQosPolicy CopyFrom(ReliabilityQosPolicy other)
        {
            return new ModifiableReliabilityQosPolicyImpl(other) ;
        }

        public ReliabilityQosPolicy FinishModification()
        {
            return new ReliabilityQosPolicyImpl(this.GetKind(), this.GetMaxBlockingTime(), this.GetBootstrap());
        }
    }
}
