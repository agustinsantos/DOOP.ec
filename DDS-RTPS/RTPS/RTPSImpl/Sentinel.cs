using rtps.messages.elements;
using rtps.messages.submessage.attribute;

namespace RTPS.RTPSImpl
{
    public class Sentinel : Parameter
    {
        public Sentinel()
            : base(ParameterId.PID_SENTINEL)
        {
        }
    }
}
