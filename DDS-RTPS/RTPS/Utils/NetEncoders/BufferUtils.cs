using Mina.Core.Buffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTPS.Utils.NetEncoders
{
    public static class BufferUtils
    {
         /// <summary>
        /// Aligns this buffer to given byteBoundary.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="byteBoundary"></param>
        public static void Align(this IoBuffer buffer, int byteBoundary)
        {
            int position = buffer.Position;
            int adv = (position % byteBoundary);

            if (adv != 0)
            {
                buffer.Position = position + (byteBoundary - adv);
            }
        }
    }
}
