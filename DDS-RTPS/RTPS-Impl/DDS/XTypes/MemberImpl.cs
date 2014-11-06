using org.omg.dds.type.typeobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.XTypes
{
    public class MemberImpl : Member
    {
        public MemberProperty MemberProperty { get; set; }
        public IList<AnnotationUsage> AnnotationList { get; set; }

        public MemberProperty getProperty()
        {
            return this.MemberProperty;
        }

        public Member setProperty(MemberProperty newProperty)
        {
            this.MemberProperty = newProperty;
            return this;
        }

        public IList<AnnotationUsage> getAnnotation()
        {
            return this.AnnotationList;
        }

        public Member setAnnotation(IList<AnnotationUsage> newAnnotation)
        {
            this.AnnotationList = newAnnotation;
            return this;
        }

        public Member copyFrom(Member other)
        {
            throw new NotImplementedException();
        }

        public Member finishModification()
        {
            throw new NotImplementedException();
        }

        public Member modify()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.Bootstrap getBootstrap()
        {
            throw new NotImplementedException();
        }
    }
}
