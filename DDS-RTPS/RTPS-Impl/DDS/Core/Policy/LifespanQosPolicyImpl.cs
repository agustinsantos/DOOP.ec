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
        private readonly Duration getDuration;


        public LifespanQosPolicyImpl(Duration getDuration)
        {
            this.getDuration = getDuration;

        }
        public Duration GetDuration()
        {
            return getDuration;
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
            throw new NotImplementedException();
        }
    }
}
