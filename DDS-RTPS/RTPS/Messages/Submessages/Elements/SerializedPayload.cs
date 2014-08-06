using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rtps.Messages.Submessages.Elements
{
    public class SerializedPayload
    {
        private DataEncapsulation dataEncapsulation;

        /// <summary>
        /// Checks whether this encapsulation holds data or key as serialized
        ///  payload.
        /// </summary>
        /// <returns>true, if this encapsulation holds data</returns>
        public bool ContainsData() // as opposed to key
        {
            return dataEncapsulation.ContainsData();
        }

        /// <summary>
        /// Gets the DataEncapsulation.
        /// </summary>
        public DataEncapsulation DataEncapsulation
        {
            get
            {
                return dataEncapsulation;
            }
            set
            {
                dataEncapsulation = value;
            }
        }
    }
}
