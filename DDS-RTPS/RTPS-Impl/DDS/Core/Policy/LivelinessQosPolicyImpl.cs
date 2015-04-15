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
    public class LivelinessQosPolicyImpl : QosPolicy,LivelinessQosPolicy
    {
        private readonly LivelinessQosPolicyKind kind;
        private readonly Duration getLeaseDuration;

        public LivelinessQosPolicyImpl(LivelinessQosPolicyKind kind, Duration getLeaseDuration)
        {
            this.kind = kind;
            this.getLeaseDuration = getLeaseDuration;

        }
        public LivelinessQosPolicyKind GetKind()
        {
            return kind;
        }

        public Duration GetLeaseDuration()
        {
            return getLeaseDuration;
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public ModifiableLivelinessQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
