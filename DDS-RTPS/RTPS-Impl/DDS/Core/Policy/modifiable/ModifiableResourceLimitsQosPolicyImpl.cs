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
    class ModifiableResourceLimitsQosPolicyImpl : ResourceLimitsQosPolicyImpl, ModifiableResourceLimitsQosPolicy
    {
        public ModifiableResourceLimitsQosPolicyImpl(ResourceLimitsQosPolicy qos)
            : base(qos.GetMaxSamples(),qos.GetMaxInstances(),qos.GetMaxSamplesPerInstance(),qos.GetBootstrap())
        {
        }

        public ModifiableResourceLimitsQosPolicyImpl(int maxSamples, int maxInstances, int maxSamplesPerInstance, Bootstrap boostrap)
            : base(maxSamples,maxInstances,maxSamplesPerInstance , boostrap)
        {

        }

        public ModifiableResourceLimitsQosPolicy SetMaxSamples(int maxSamples)
        {
            this.MaxSamplesQos =maxSamples ;
            return this;
        }

        public ModifiableResourceLimitsQosPolicy SetMaxInstances(int maxInstances)
        {
            this.MaxInstancesQos =maxInstances ;
            return this;
        }

        public ModifiableResourceLimitsQosPolicy SetMaxSamplesPerInstance(int maxSamplesPerInstance)
        {
            this.MaxSamplesPerInstanceQos =maxSamplesPerInstance ;
            return this;
        }

        public ModifiableResourceLimitsQosPolicy CopyFrom(ResourceLimitsQosPolicy other)
        {
            return new ModifiableResourceLimitsQosPolicyImpl(other);
        }

        public ResourceLimitsQosPolicy FinishModification()
        {
            return new ResourceLimitsQosPolicyImpl (this.GetMaxSamples (),this.GetMaxInstances (),
                this.GetMaxSamplesPerInstance(),this.GetBootstrap());
        }
    }
}
