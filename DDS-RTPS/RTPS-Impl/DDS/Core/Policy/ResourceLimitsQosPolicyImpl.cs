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
    public class ResourceLimitsQosPolicyImpl : QosPolicy, ResourceLimitsQosPolicy
    {
        private readonly int getMaxSamples;

        private readonly int getMaxInstances;

        private readonly int getMaxSamplesPerInstance;

        public ResourceLimitsQosPolicyImpl (int getMaxSamples, int getMaxInstances, int getMaxSamplesPerInstance)
        {
            this.getMaxSamples = getMaxSamples;
            this.getMaxInstances = getMaxInstances;
            this.getMaxSamplesPerInstance = getMaxSamplesPerInstance;
        }
        public int GetMaxSamples()
        {
            return getMaxSamples;
        }

        public int GetMaxInstances()
        {
            return getMaxInstances;
        }

        public int GetMaxSamplesPerInstance()
        {
            return getMaxSamplesPerInstance;
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public ModifiableResourceLimitsQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
