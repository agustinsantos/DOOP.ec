using Mina.Core.Buffer;
using Rtps.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Rtps.Encoders
{
    public static class MessageStaticEncoder
    {
        public static void PutMessage(this IoBuffer buffer, Message msg)
        {
            buffer.PutHeader(msg.Header);
            int position = 0;
            int subMessageCount = 0;
            foreach (SubMessage submsg in msg.SubMessages)
            {
                int subMsgStartPosition = buffer.Position;
                position = buffer.PutSubMessage(submsg);
                subMessageCount++;
            }
            // Length of last submessage is 0, @see 8.3.3.2.3 submessageLength
            if (subMessageCount > 0)
                buffer.PutInt16(position - 2, (short)0);
        }

        public static Message GetMessage(this IoBuffer buffer)
        {
            Message obj = new Message();
            buffer.GetMessage(ref obj);
            return obj;
        }

        public static void GetMessage(this IoBuffer buffer, ref Message obj)
        {
            obj.Header = buffer.GetHeader();
            while (buffer.HasRemaining)
            {
                SubMessage submsg = buffer.GetSubMessage();
                obj.SubMessages.Add(submsg);
            }
        }
    }
}
