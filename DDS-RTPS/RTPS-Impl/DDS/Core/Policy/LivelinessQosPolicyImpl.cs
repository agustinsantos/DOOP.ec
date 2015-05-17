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
    public class LivelinessQosPolicyImpl : QosPolicyImpl,LivelinessQosPolicy
    {
      
        public LivelinessQosPolicyKind KindQos { get; protected internal set; }
        public Duration LeaseDurationQos { get; protected internal set; }

        public LivelinessQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }
        public LivelinessQosPolicyImpl(LivelinessQosPolicyKind kind, Duration getLeaseDuration, Bootstrap boostrap)
            :base(boostrap)
        {
            this.KindQos  = kind;
            this.LeaseDurationQos = getLeaseDuration;

        }

        public LivelinessQosPolicyImpl(LivelinessQosPolicyKind kind, Bootstrap boostrap)
            : this(boostrap)
        {
            this.KindQos = kind;
        }
        public LivelinessQosPolicyKind GetKind()
        {
            return KindQos ;
        }

        public Duration GetLeaseDuration()
        {
            return LeaseDurationQos;
        }

        

        public ModifiableLivelinessQosPolicy Modify()
        {
            return new ModifiableLivelinessQosPolicyImpl(this);
        }
    }
}
