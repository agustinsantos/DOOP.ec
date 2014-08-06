
namespace Rtps.Messages.Submessages.Elements
{
    /// <summary>
    /// SerializedDataFragment contains the serialized representation of a data-object that 
    /// has been fragmented. Like for unfragmented SerializedData, the RTPS protocol does 
    /// not interpret the fragmented serialized data-stream. Therefore, it is 
    /// represented as opaque data.
    /// </summary>
    public class SerializedDataFragment : SubmessageElement
    {
        private byte[] value;

        /// <summary>
        /// Serialized data-stream
        /// </summary>
        public byte[] Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public int Size
        {
            get { return (this.value == null ? 0 : this.value.Length); }
        }
    }
}
