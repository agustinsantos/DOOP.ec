using Mina.Core.Buffer;
using Rtps.messages.elements;
using Rtps.messages.submessage;
using System.Collections.Generic;

namespace Rtps.messages.message
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="prefix"></param>
        public Message(GuidPrefix prefix)
        {
            header = new Header(prefix);
        }

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
