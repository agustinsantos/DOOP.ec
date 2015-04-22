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

        public DurabilityServiceQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
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
            throw new NotImplementedException();
        }

        public int GetMaxInstances()
        {
            throw new NotImplementedException();
        }

        public int GetMaxSamplesPerInstance()
        {
            throw new NotImplementedException();
        }

        public ModifiableDurabilityServiceQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
