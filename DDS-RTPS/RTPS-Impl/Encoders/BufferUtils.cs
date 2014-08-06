using Mina.Core.Buffer;

namespace Doopec.Utils.Network.Encoders
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
