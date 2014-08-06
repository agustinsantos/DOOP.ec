
using Rtps.Structure.Types;
namespace Rtps.Behavior.Types
{
    /// <summary>
    /// Type used to hold data exchanged between Participants. The most notable use 
    /// of this type is for the Writer Liveliness Protocol.
    /// </summary>
    public class ParticipantMessageData
    {
        private GUID guid;
        private byte[] data;

        public GUID Guid
        {
            get { return guid; }
            set { guid = value; }
        }


        public byte[] Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
