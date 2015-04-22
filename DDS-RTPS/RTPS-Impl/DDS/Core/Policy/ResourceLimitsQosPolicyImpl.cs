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
    public class ResourceLimitsQosPolicyImpl : QosPolicyImpl, ResourceLimitsQosPolicy
    {
        public int MaxSamplesQos { get; protected internal set; }

        public int MaxInstancesQos { get; protected internal set; }

        public int MaxSamplesPerInstanceQos { get; protected internal set; }
        public ResourceLimitsQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }
        public ResourceLimitsQosPolicyImpl (int getMaxSamples, int getMaxInstances, int getMaxSamplesPerInstance,Bootstrap boostrap)
            :base(boostrap)
        {
            this.MaxSamplesQos = getMaxSamples;
            this.MaxInstancesQos = getMaxInstances;
            this.MaxSamplesPerInstanceQos = getMaxSamplesPerInstance;
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


        public ModifiableResourceLimitsQosPolicy Modify()
        {
            return new ModifiableResourceLimitsQosPolicyImpl(this);
        }
    }
}
