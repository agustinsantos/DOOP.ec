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
    class ModifiableQosPolicyCountImpl : QosPolicyCountImpl, QosPolicyCount
    {
        public ModifiableQosPolicyCountImpl(QosPolicyCount qos)
            : base(qos.GetBootstrap())
        {
        }

        public ModifiableQosPolicyCountImpl(Bootstrap boostrap)
            : base(boostrap)
        {

        }
    }
}
