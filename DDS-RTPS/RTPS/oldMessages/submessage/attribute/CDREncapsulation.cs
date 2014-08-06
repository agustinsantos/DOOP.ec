using Mina.Core.Buffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.Messages.submessage.attribute
{
    /// <summary>
    /// CDREncapsulation is a general purpose binary DataEncapsulation. It holds a IoBuffer,
    ///  which can be used by marshallers.
    /// </summary>
    public class CDREncapsulation : DataEncapsulation
    {

        private readonly IoBuffer bb;
        private short options;
        private int posStart;

        internal CDREncapsulation(IoBuffer bb)
        {
            this.bb = bb;
            this.posStart = bb.Position - 2;
            //this.options = bb.GetInt16(); // NOT Used
        }

        public CDREncapsulation(int size)
        {
            this.bb = IoBuffer.Allocate(size);
            bb.Order = ByteOrder.LittleEndian;
            this.posStart = 0;
            bb.Put(CDR_LE_HEADER);
            // bb.write_short(options); // bb is positioned to start of actual data
        }

        public override bool ContainsData()
        {
            return true;
        }

        public override byte[] SerializedPayload
        {
            get
            {
                bb.Position = posStart;
                byte[] serializedPayload = new byte[bb.Remaining];
                bb.Get(serializedPayload, 0, serializedPayload.Length);

                return serializedPayload;
            }
        }

        /// <summary>
        /// Gets a IoBuffer, which can be used to marshall/unmarshall data.
        /// </summary>
        public IoBuffer Buffer
        {
            get
            {
                return bb;
            }
        }
    }
}
