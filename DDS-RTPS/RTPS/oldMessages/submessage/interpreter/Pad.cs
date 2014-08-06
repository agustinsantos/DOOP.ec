


using Rtps.messages.elements;
namespace Rtps.messages.submessage.interpreter
{
    /// <summary>
    /// From OMG RTPS Standard v2.1 p44: Used to add padding to a Message if needed for memory alignment.
    ///  <p>
    ///  From OMG RTPS Standard v2.1 p62: The purpose of this Submessage is to allow the introduction of 
    ///  any padding necessary to meet any desired memory- alignment requirements. Its has no other meaning.
    /// </summary>
    public class Pad : SubMessage
    {
        private byte[] bytes;

        public Pad()
            : base(SubMessageKind.PAD)
        {
        }

        public byte[] Bytes
        {
            get { return bytes; }
            set { bytes = value; }
        }


    }
}
