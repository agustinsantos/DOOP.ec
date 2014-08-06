using Rtps.Messages.Submessages.Elements;
using Rtps.Messages.Types;

namespace Doopec.Encoders.RTPS
{
    public class Sentinel : Parameter
    {
        public Sentinel()
            : base(ParameterId.PID_SENTINEL)
        {
        }
    }
}
