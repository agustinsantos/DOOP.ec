using rtps.messages.elements;
using System.Collections.Generic;
namespace rtps.messages.submessage
{

    public class SubMessage
    {
        protected SubMessageHeader header_ ;
        protected IList<SubMessageElement> elements_ = new List<SubMessageElement>();

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

        public IList<SubMessageElement> SubMessageElements
        {
            get { return elements_; }
         }

        public override string ToString()
        {
            return this.GetType().Name + ":" + Header.ToString();
        }
    }
}
