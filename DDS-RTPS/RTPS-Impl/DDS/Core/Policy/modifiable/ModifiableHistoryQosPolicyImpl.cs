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
    class ModifiableHistoryQosPolicyImpl : HistoryQosPolicyImpl, ModifiableHistoryQosPolicy
    {
        public ModifiableHistoryQosPolicyImpl(HistoryQosPolicy qos)
            : base(qos.GetKind(), qos.GetDepth(),qos.GetBootstrap())
        {
        }

        public ModifiableHistoryQosPolicyImpl(HistoryQosPolicyKind kind, int getDepth,Bootstrap boostrap)
            : base(kind, getDepth,boostrap)
        {

        }
        public ModifiableHistoryQosPolicy SetKind(HistoryQosPolicyKind kind)
        {
            this.KindQos=kind;
            return this;
        }

        public ModifiableHistoryQosPolicy SetDepth(int depth)
        {
            this.DepthQos=depth;
            return this;
        }

        public ModifiableHistoryQosPolicy CopyFrom(HistoryQosPolicy other)
        {
            return new ModifiableHistoryQosPolicyImpl(other.GetKind(),other.GetDepth()
                ,other.GetBootstrap());
        }

        public HistoryQosPolicy FinishModification()
        {
            return new HistoryQosPolicyImpl(this.GetKind(),this.GetDepth(),this.GetBootstrap());
        }
    }
}
