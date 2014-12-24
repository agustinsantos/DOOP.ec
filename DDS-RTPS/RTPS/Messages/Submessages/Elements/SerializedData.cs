using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rtps.Messages.Submessages.Elements
{
    /// <summary>
    /// SerializedData contains the serialized representation of the Value of a data-object. 
    /// The RTPS protocol does not interpret the serialized data-stream. Therefore, it is represented as opaque data. 
    /// </summary>
    public class SerializedData :  SubmessageElement
    {
        private byte[] value;

        /// <summary>
        /// Serialized data-stream
        /// </summary>
        public byte[] Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public int Size
        {
            get { return (this.value == null ? 0: this.value.Length) ; }
        }
    }
}
