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
    class ModifiableDurabilityServiceQosPolicyImpl : DurabilityServiceQosPolicyImpl, ModifiableDurabilityServiceQosPolicy
    {
        public ModifiableDurabilityServiceQosPolicy SetServiceCleanupDelay(Duration serviceCleanupDelay)
        {
            throw new NotImplementedException();
        }

        public ModifiableDurabilityServiceQosPolicy SetServiceCleanupDelay(long serviceCleanupDelay, global::DDS.ConversionUtils.TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public ModifiableDurabilityServiceQosPolicy SetHistoryKind(HistoryQosPolicyKind historyKind)
        {
            throw new NotImplementedException();
        }

        public ModifiableDurabilityServiceQosPolicy SetHistoryDepth(int historyDepth)
        {
            throw new NotImplementedException();
        }

        public ModifiableDurabilityServiceQosPolicy SetMaxSamples(int maxSamples)
        {
            throw new NotImplementedException();
        }

        public ModifiableDurabilityServiceQosPolicy SetMaxInstances(int maxInstances)
        {
            throw new NotImplementedException();
        }

        public ModifiableDurabilityServiceQosPolicy SetMaxSamplesPerInstance(int maxSamplesPerInstance)
        {
            throw new NotImplementedException();
        }

        public ModifiableDurabilityServiceQosPolicy CopyFrom(DurabilityServiceQosPolicy other)
        {
            throw new NotImplementedException();
        }

        public DurabilityServiceQosPolicy FinishModification()
        {
            throw new NotImplementedException();
        }
    }
}
