using Rtps.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rtps.Behavior
{
    /// <summary>
    /// Specialization of RTPS Reader. The RTPS StatelessReader has no knowledge of the number of matched writers, nor does 
    /// it maintain any state for each matched RTPS Writer.
    /// In the current Reference Implementation, the StatelessReader does not add any configuration attributes or operations to 
    /// those inherited from the Reader super class. Both classes are therefore identical.
    /// </summary>
    public class StatelessReader : Reader
    {
        public StatelessReader(Participant participant)
            : base(participant)
        {
        }
    }
}
