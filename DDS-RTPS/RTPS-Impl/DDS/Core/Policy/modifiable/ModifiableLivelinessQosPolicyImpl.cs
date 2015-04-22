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
    class ModifiableLivelinessQosPolicyImpl : LivelinessQosPolicyImpl, ModifiableLivelinessQosPolicy
    {
        public ModifiableLivelinessQosPolicyImpl(LivelinessQosPolicy qos)
            : base(qos.GetKind(),qos.GetLeaseDuration())
        {
        }

        public ModifiableLivelinessQosPolicyImpl(LivelinessQosPolicyKind kind, Duration leaseDuration)
            : base(kind,leaseDuration)
        {

        }


        public ModifiableLivelinessQosPolicy SetKind(LivelinessQosPolicyKind kind)
        {
            this.KindQos =kind ;
            return this;
        }

        public ModifiableLivelinessQosPolicy SetLeaseDuration(Duration leaseDuration)
        {
            this.GetLeaseDurationQos =leaseDuration ;
            return this;
        }

        public ModifiableLivelinessQosPolicy SetLeaseDuration(long leaseDuration, global::DDS.ConversionUtils.TimeUnit unit)
        {
            throw new NotImplementedException();
        }

        public ModifiableLivelinessQosPolicy CopyFrom(LivelinessQosPolicy other)
        {
            return new ModifiableLivelinessQosPolicyImpl (other.GetKind(),other.GetLeaseDuration());
        }

        public LivelinessQosPolicy FinishModification()
        {
            return new LivelinessQosPolicyImpl (this.GetKind(),this.GetLeaseDuration());
        }
    }
}
