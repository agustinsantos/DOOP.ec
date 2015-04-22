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
    public class DurabilityServiceQosPolicyImpl : QosPolicyImpl, DurabilityServiceQosPolicy
    {
        public HistoryQosPolicyKind HistoryQosPolicyKind { get; protected internal set; }
        public Duration ServiceCleanupDelay { get; protected internal set; }

        public int HistoryDepth { get; protected internal set; }

        public int MaxSamplesQos { get; protected internal set; }
        public int MaxInstancesQos { get; protected internal set; }
        public int MaxSamplesPerInstanceQos { get; protected internal set; }


        public DurabilityServiceQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }

        public DurabilityServiceQosPolicyImpl(HistoryQosPolicyKind kind, Duration serviceCleanupDelay
            , int historyDepth, int getMaxSamplesQos, int getMaxInstancesQos, int getMaxSamplesPerInstanceQos, Bootstrap boostrap)
            : base(boostrap)
        {
            this.HistoryQosPolicyKind = kind;
            this.ServiceCleanupDelay = serviceCleanupDelay;
            this.HistoryDepth = historyDepth;
            this.MaxSamplesQos = getMaxSamplesQos;
            this.MaxInstancesQos = getMaxInstancesQos;
            this.MaxSamplesPerInstanceQos = getMaxSamplesPerInstanceQos;
        }


        public Duration GetServiceCleanupDelay()
        {
            return ServiceCleanupDelay;
        }

        public HistoryQosPolicyKind GetHistoryKind()
        {
            return HistoryQosPolicyKind;
        }

        public int GetHistoryDepth()
        {
            return HistoryDepth;
        }

        public int GetMaxSamples()
        {
            return MaxSamplesQos;
        }

        public int GetMaxInstances()
        {
            return MaxInstancesQos;
        }

        public int GetMaxSamplesPerInstance()
        {
            return MaxSamplesPerInstanceQos;
        }

        public ModifiableDurabilityServiceQosPolicy Modify()
        {
            return new ModifiableDurabilityServiceQosPolicyImpl(this);
        }
    }
}
