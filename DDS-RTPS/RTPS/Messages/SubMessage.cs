using Rtps.Messages.Types;
using System.Collections.Generic;
namespace Rtps.Messages
{

    public class SubMessage
    {
        protected SubMessageHeader header_ ;
        protected IList<SubmessageElement> elements_ = new List<SubmessageElement>();

        public SubMessage()
        {
            header_ = new SubMessageHeader();
        }

        public SubMessage(SubMessageKind k)
        {
            header_ = new SubMessageHeader(k);
        }

        public SubMessageKind Kind
        {
            get { return header_.SubMessageKind; }
        }

        public SubMessageHeader Header
        {
            get { return header_; }
            set { header_ = value; }
        }

        public IList<SubmessageElement> SubMessageElements
        {
            get { return elements_; }
         }

        public override string ToString()
        {
            return this.GetType().Name + ":" + Header.ToString();
        }
    }
}
