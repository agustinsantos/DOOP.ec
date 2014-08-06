using Mina.Core.Buffer;
using rtps.messages.submessage.attribute;
using System;

namespace RTPS.Messages.submessage.attribute
{

    /// <summary>
    /// ParameterListEncapsulation is a specialization of DataEncapsulation which is
    /// used by discovery.
    /// </summary>
    public class ParameterListEncapsulation : DataEncapsulation
    {
        private ParameterList parameters;
        private short options;

        public ParameterListEncapsulation(ParameterList parameters)
        {
            this.parameters = parameters;
            this.options = 0;

        }

        internal ParameterListEncapsulation(IoBuffer bb)
        {
#if TODO
        this.options = bb.GetInt16();
        this.parameters = bb.GetParameterList();
#endif
            throw new NotImplementedException();
        }

        public ParameterList getParameterList()
        {
            return parameters;
        }

        public override bool ContainsData()
        {
            return true; // TODO: how do we represent key in serialized payload
        }

        public override byte[] SerializedPayload
        {
            get
            {
#if TODO
             IoBuffer bb = IoBuffer.Allocate(1024); // TODO: hardcoded
             bb.Order = ByteOrder.BIG_ENDIAN;
 
             bb.Put(PL_CDR_BE_HEADER);

             bb.PutParametersList(parameters);

             byte[] serializedPayload = new byte[buffer.position()];
             System.arraycopy(bb.getBuffer().array(), 0, serializedPayload, 0, serializedPayload.length);

             return serializedPayload;
#endif
                throw new NotImplementedException();
            }
        }
    }
}