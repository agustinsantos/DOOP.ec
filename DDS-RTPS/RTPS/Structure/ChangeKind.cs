using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rtps.Structure
{
    /// <summary>
    /// Enumeration used to distinguish the kind of change that was made to a data-object.
    /// Includes changes to the data or the lifecycle of the data-object.
    /// </summary>
    public enum ChangeKind
    {

        /// <summary>
        /// Writer updates an instance.
        /// </summary>
        WRITE,

        /// <summary>
        /// Writer disposes an instance.
        /// </summary>
        DISPOSE,

        /// <summary>
        /// Writer unregisters an instance.
        /// </summary>
        UNREGISTER
    }
}