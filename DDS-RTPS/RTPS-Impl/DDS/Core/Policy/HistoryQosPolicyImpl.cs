using org.omg.dds.core.policy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.Core.Policy
{
    public class HistoryQosPolicyImpl : QosPolicy, HistoryQosPolicy
    {
        private readonly HistoryQosPolicyKind kind;
        private readonly int getDepth;

        public HistoryQosPolicyImpl(HistoryQosPolicyKind kind, int getDepth)
        {
            this.kind = kind;
            this.getDepth = getDepth;
        }

        public HistoryQosPolicyKind GetKind()
        {
            return kind;
        }

        public int GetDepth()
        {
            return getDepth ;
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.policy.modifiable.ModifiableHistoryQosPolicy Modify()
        {
            throw new NotImplementedException();
        }
    }
}
