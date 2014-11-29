using Rtps.Messages.Submessages.Elements;
using Rtps.Messages.Types;

namespace Doopec.Encoders.RTPS
{
    public class Sentinel : Parameter
    {
        private static Sentinel instance = new Sentinel();
        private Sentinel()
            : base(ParameterId.PID_SENTINEL)
        {
            this.Bytes = new byte[0];
        }

        public static Sentinel Instance { get { return instance; } }
    }
}
