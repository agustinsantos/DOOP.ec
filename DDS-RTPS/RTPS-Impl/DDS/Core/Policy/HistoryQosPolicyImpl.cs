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
    public class HistoryQosPolicyImpl : QosPolicyImpl, HistoryQosPolicy
    {
       


        public HistoryQosPolicyKind KindQos { get; protected internal set; }
        public int DepthQos { get; protected internal set; }


         public HistoryQosPolicyImpl(Bootstrap boostrap)
            : base(boostrap)
        {
        }
    

        public HistoryQosPolicyImpl(HistoryQosPolicyKind kind, int getDepth,Bootstrap boostrap)
            : base(boostrap)
        {
            this.KindQos  = kind;
            this.DepthQos = getDepth;
        }

        public HistoryQosPolicyKind GetKind()
        {
            return KindQos;
        }

        public int GetDepth()
        {
            return DepthQos ;
        }

        
        public ModifiableHistoryQosPolicy Modify()
        {
            return new ModifiableHistoryQosPolicyImpl(this);
        }
    }
}
