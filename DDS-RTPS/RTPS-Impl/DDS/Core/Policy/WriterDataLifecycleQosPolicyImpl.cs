﻿using org.omg.dds.core.policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core.Policy
{
    public class WriterDataLifecycleQosPolicyImpl :QosPolicy,WriterDataLifecycleQosPolicy
    {
        public bool IsAutDisposeUnregisteredInstances()
        {
            throw new NotImplementedException();
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.policy.modifiable.ModifiableWriterDataLifecycleQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}