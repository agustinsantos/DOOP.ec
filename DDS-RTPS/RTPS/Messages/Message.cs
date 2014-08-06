using System.Collections.Generic;

namespace Rtps.Messages
{
    /// <summary>
    /// This class represents a RTPS message.
    /// </summary>
    public class Message
    {
        public Message()
        {
            header = new Header();
        }

        private Header header;
        private IList<SubMessage> subMessages_ = new List<SubMessage>();

        public Header Header
        {
            get { return header; }
            set { header = value; }
        }

        public IList<SubMessage> SubMessages
        {
            get { return subMessages_; }
        }
    }
}
