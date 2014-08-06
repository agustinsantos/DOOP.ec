using Rtps.Messages.Types;
namespace Rtps.Messages.Submessages.Elements
{
    /// <summary>
    /// Counter for progressive message counting
    /// Count is used by several Submessages and enables a receiver to detect duplicates of the same Submessage.
    /// </summary>
    public class CountElement : SubmessageElement<Count>
    {
        public static int COUNT_SIZE = 4;

        public CountElement(Count value)
            : base(COUNT_SIZE, value)
        {
        }

        public CountElement()
            : this(new Count())
        {
        }
    }
}
