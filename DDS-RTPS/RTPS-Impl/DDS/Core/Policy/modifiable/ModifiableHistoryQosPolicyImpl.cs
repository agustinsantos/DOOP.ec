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
            : base(qos.GetKind(), qos.GetDepth())
        {
        }

        public ModifiableHistoryQosPolicyImpl(HistoryQosPolicyKind kind, int getDepth)
            : base(kind, getDepth)
        {

        }
        public ModifiableHistoryQosPolicy SetKind(HistoryQosPolicyKind kind)
        {
            this.KindQos=kind;
            return this;
        }

        public ModifiableHistoryQosPolicy SetDepth(int depth)
        {
            this.GetDepthQos=depth;
            return this;
        }

        public ModifiableHistoryQosPolicy CopyFrom(HistoryQosPolicy other)
        {
            return new ModifiableHistoryQosPolicyImpl(other.GetKind(),other.GetDepth());
        }

        public HistoryQosPolicy FinishModification()
        {
            return new HistoryQosPolicyImpl(this.GetKind(),this.GetDepth());
        }
    }
}
