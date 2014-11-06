using org.omg.dds.type.typeobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.XTypes
{
    public class StructureTypeImpl : TypeImpl, StructureType
    {
        public int BaseType { get; set; }
        public IList<Member> MemberList { get; set; }

        public int getBaseType()
        {
            return this.BaseType;
        }

        public StructureType setBaseType(int newBaseTypeId)
        {
            this.BaseType= newBaseTypeId;
            return this;
        }

        public IList<Member> getMember()
        {
            return this.MemberList;
        }

        public StructureType setMember(IList<Member> newMember)
        {
            this.MemberList = newMember;
            return this;
        }
    }
}
