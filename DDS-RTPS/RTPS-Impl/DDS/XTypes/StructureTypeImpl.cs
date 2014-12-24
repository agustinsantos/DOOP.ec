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

        public int GetBaseType()
        {
            return this.BaseType;
        }

        public StructureType SetBaseType(int newBaseTypeId)
        {
            this.BaseType= newBaseTypeId;
            return this;
        }

        public IList<Member> GetMember()
        {
            return this.MemberList;
        }

        public StructureType SetMember(IList<Member> newMember)
        {
            this.MemberList = newMember;
            return this;
        }
    }
}
