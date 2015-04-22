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
    public class ModifiableDurabilityServiceQosPolicyImpl : DurabilityServiceQosPolicyImpl, ModifiableDurabilityServiceQosPolicy
    {
        public ModifiableDurabilityServiceQosPolicyImpl(DurabilityServiceQosPolicy qos)
            : base(qos.GetHistoryKind(),qos.GetServiceCleanupDelay(), qos.GetHistoryDepth(),
            qos.GetMaxSamples(),qos.GetMaxInstances(),qos.GetMaxSamplesPerInstance(),qos.GetBootstrap())
        {
        }

        public ModifiableDurabilityServiceQosPolicyImpl(HistoryQosPolicyKind historyKind, Duration serviceCleanupDelay, int historyDepth
            , int maxSamples, int maxInstances,int maxSamplesPerInstance, Bootstrap boostrap)
            : base(historyKind,serviceCleanupDelay,historyDepth,maxSamples,maxInstances,maxSamplesPerInstance,boostrap)
        {

        }

        public ModifiableDurabilityServiceQosPolicy SetServiceCleanupDelay(Duration serviceCleanupDelay)
        {
            this.ServiceCleanupDelay = serviceCleanupDelay;
            return this;
        }

        public ModifiableDurabilityServiceQosPolicy SetServiceCleanupDelay(long serviceCleanupDelay, global::DDS.ConversionUtils.TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public ModifiableDurabilityServiceQosPolicy SetHistoryKind(HistoryQosPolicyKind historyKind)
        {
            this.HistoryQosPolicyKind = historyKind;
            return this;
        }

        public ModifiableDurabilityServiceQosPolicy SetHistoryDepth(int historyDepth)
        {
            this.HistoryDepth = historyDepth;
            return this;
        }

        public ModifiableDurabilityServiceQosPolicy SetMaxSamples(int maxSamples)
        {
            this.MaxInstancesQos=maxSamples ;
            return this;
        }

        public ModifiableDurabilityServiceQosPolicy SetMaxInstances(int maxInstances)
        {
            this.MaxInstancesQos =maxInstances ;
            return this;
        }

        public ModifiableDurabilityServiceQosPolicy SetMaxSamplesPerInstance(int maxSamplesPerInstance)
        {
           this.MaxSamplesPerInstanceQos =maxSamplesPerInstance ;
           return this;
        }

        public ModifiableDurabilityServiceQosPolicy CopyFrom(DurabilityServiceQosPolicy other)
        {
            return new ModifiableDurabilityServiceQosPolicyImpl(other);
        }

        public DurabilityServiceQosPolicy FinishModification()
        {
            return new DurabilityServiceQosPolicyImpl(this.GetHistoryKind(),this.GetServiceCleanupDelay()
                ,this.GetHistoryDepth(),this.GetMaxSamples(),this.GetMaxInstances()
                ,this.GetMaxSamplesPerInstance(),this.GetBootstrap());
        }
    }
}
