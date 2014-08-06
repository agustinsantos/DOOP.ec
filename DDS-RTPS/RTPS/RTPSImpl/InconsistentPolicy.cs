using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.RTPSImpl
{
    public class InconsistentPolicy : ApplicationException
    {
        public InconsistentPolicy(string msg)
            : base(msg)
        { }

        public InconsistentPolicy()
            : base()
        { }
    }
}
