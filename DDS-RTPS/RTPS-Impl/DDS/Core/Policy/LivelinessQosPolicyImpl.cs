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
    public class LivelinessQosPolicyImpl : QosPolicy,LivelinessQosPolicy
    {
      
        public LivelinessQosPolicyKind KindQos { get; protected internal set; }
        public Duration GetLeaseDurationQos { get; protected internal set; }

        public LivelinessQosPolicyImpl(LivelinessQosPolicyKind kind, Duration getLeaseDuration)
        {
            this.KindQos  = kind;
            this.GetLeaseDurationQos = getLeaseDuration;

        }
        public LivelinessQosPolicyKind GetKind()
        {
            return KindQos ;
        }

        public Duration GetLeaseDuration()
        {
            return GetLeaseDurationQos;
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
            return new ModifiableLivelinessQosPolicyImpl(this);
        }
    }
}
