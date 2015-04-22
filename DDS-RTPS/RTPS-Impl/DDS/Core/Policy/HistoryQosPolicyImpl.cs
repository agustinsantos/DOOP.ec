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
    public class HistoryQosPolicyImpl : QosPolicy, HistoryQosPolicy
    {
       


        public HistoryQosPolicyKind KindQos { get; protected internal set; }
        public int GetDepthQos { get; protected internal set; }

        public HistoryQosPolicyImpl(HistoryQosPolicyKind kind, int getDepth)
        {
            this.KindQos  = kind;
            this.GetDepthQos = getDepth;
        }

        public HistoryQosPolicyKind GetKind()
        {
            return KindQos;
        }

        public int GetDepth()
        {
            return GetDepthQos ;
        }

        public QosPolicyId GetId()
        {
            throw new NotImplementedException();
        }

        public Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }

        public ModifiableHistoryQosPolicy Modify()
        {
            return new ModifiableHistoryQosPolicyImpl(this);
        }
    }
}
