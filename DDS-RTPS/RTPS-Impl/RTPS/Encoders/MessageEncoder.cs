using Mina.Core.Buffer;
using Mina.Core.Session;
using Mina.Filter.Codec;
using Rtps.Messages;
using System;

namespace Doopec.Rtps.Encoders
{
    public class MessageEncoder : IProtocolEncoder
    {

        public void Encode(IoSession session, object message, IProtocolEncoderOutput output)
        {
            Message msg = (Message)message;
            IoBuffer buffer = IoBuffer.Allocate(1024);
            buffer.PutMessage(msg);
            buffer.Flip();
            output.Write(buffer);
        }

        public void Dispose(IoSession session)
        {
            // nothing to dispose
        }
    }

    public class MessageDecoder : CumulativeProtocolDecoder
    {
        protected override Boolean DoDecode(IoSession session, IoBuffer input, IProtocolDecoderOutput output)
        {
            if (input.Remaining >= 4)
            {
                Message request = input.GetMessage();
                output.Write(request);
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class MessageCodecFactory : IProtocolCodecFactory
    {
        public static MessageEncoder encoder = new MessageEncoder();
        public static MessageDecoder decoder = new MessageDecoder();

        public IProtocolEncoder GetEncoder(IoSession session)
        {
            return encoder;
        }

        public IProtocolDecoder GetDecoder(IoSession session)
        {
            return decoder;
        }
    }
}
