using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.RTPSImpl.Parameters
{
    /// <summary>
    /// An interface used to denote a Parameter as a Quality of Service policy
    /// parameter.
    /// </summary>
    public interface QosPolicy
    {
        /// <summary>
        /// Checks, if this QosPolicy is compatible with other QosPolicy. 'this'
        /// QosPolicy should be considered as 'offered' policy, and 'other' should be
        /// considered as 'requested' policy.
        /// </summary>
        /// <param name="requested">Requested QosPolicy</param>
        /// <returns>if QosPolicy is compatible</returns>
        bool IsCompatible(QosPolicy requested);
    }

    public interface QosPolicy<T> : QosPolicy
    {
        /// <summary>
        /// Checks, if this QosPolicy is compatible with other QosPolicy. 'this'
        /// QosPolicy should be considered as 'offered' policy, and 'other' should be
        /// considered as 'requested' policy.
        /// </summary>
        /// <param name="requested">Requested QosPolicy</param>
        /// <returns>if QosPolicy is compatible</returns>
        bool IsCompatible(T requested);
    }
}
