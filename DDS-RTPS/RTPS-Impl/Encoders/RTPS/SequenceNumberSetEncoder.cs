using Mina.Core.Buffer;
 using Rtps.Messages.Submessages.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Utils.Network.Encoders.Rtps
{
    public static class SequenceNumberSetEncoder
    {
        public static void PutSequenceNumberSet(this IoBuffer buffer, SequenceNumberSet obj)
        {
            buffer.PutSequenceNumber(obj.BitmapBase);

            // buffer.write_long(bitmaps.length);
            // buffer.write_long(bitmaps.length * 32);
            buffer.PutInt32(obj.NumBits);
            for (int i = 0; i < obj.Bitmaps.Length; i++)
            {
                buffer.PutInt32(obj.Bitmaps[i]);
            }
        }

        public static SequenceNumberSet GetSequenceNumberSet(this IoBuffer buffer)
        {
            SequenceNumberSet obj = new SequenceNumberSet();
            buffer.GetSequenceNumberSet(ref obj);
            return obj;
        }

        public static void GetSequenceNumberSet(this IoBuffer buffer, ref SequenceNumberSet obj)
        {
            obj.BitmapBase = buffer.GetSequenceNumber();

            obj.NumBits = buffer.GetInt32();
            int count = (obj.NumBits + 31) / 32;
            obj.Bitmaps = new int[count];

            for (int i = 0; i < obj.Bitmaps.Length; i++)
            {
                obj.Bitmaps[i] = buffer.GetInt32();
            }
        }
    }
}
