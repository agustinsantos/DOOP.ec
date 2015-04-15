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
    public class DurabilityServiceQosPolicyImpl : QosPolicy, DurabilityServiceQosPolicy
    {
        
       
        public Duration GetServiceCleanupDelay()
        {
            throw new NotImplementedException();
        }

        public HistoryQosPolicyKind GetHistoryKind()
        {
            throw new NotImplementedException();
        }

        public int GetHistoryDepth()
        {
            throw new NotImplementedException();
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

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public ModifiableDurabilityServiceQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
