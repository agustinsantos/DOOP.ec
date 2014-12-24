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

        public MemberProperty GetProperty()
        {
            return this.MemberProperty;
        }

        public Member SetProperty(MemberProperty newProperty)
        {
            this.MemberProperty = newProperty;
            return this;
        }

        public IList<AnnotationUsage> GetAnnotation()
        {
            return this.AnnotationList;
        }

        public Member SetAnnotation(IList<AnnotationUsage> newAnnotation)
        {
            this.AnnotationList = newAnnotation;
            return this;
        }

        public Member CopyFrom(Member other)
        {
            throw new NotImplementedException();
        }

        public Member FinishModification()
        {
            throw new NotImplementedException();
        }

        public Member Modify()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }
    }
}
