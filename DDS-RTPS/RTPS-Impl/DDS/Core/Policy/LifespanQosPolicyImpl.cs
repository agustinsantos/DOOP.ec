using Doopec.Dds.Core.Policy.modifiable;
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
    public class LifespanQosPolicyImpl : QosPolicy, LifespanQosPolicy
    {
        

        public Duration GetDurationQos { get; protected internal set; }
        public LifespanQosPolicyImpl(Duration getDuration)
        {
            this.GetDurationQos = getDuration;

        }
        public Duration GetDuration()
        {
            return GetDurationQos;
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public ModifiableLifespanQosPolicy Modify()
        {
            return new ModifiableLifespanQosPolicyImpl(this);
        }
    }
}
