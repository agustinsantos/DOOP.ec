using org.omg.dds.type.typeobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.XTypes
{
    public class MemberPropertyImpl : MemberProperty
    {
        public MemberFlag Flag { get; set; }
        public uint MemberId { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public bool IsProperty { get; set; }

        public MemberProperty SetFlag(MemberFlag flag)
        {
            this.Flag = flag;
            return this;
        }

        public MemberProperty SetMemberId(uint memberId)
        {
            this.MemberId = memberId;
            return this;
        }

        public MemberProperty SetType(int type)
        {
            this.Type = type;
            return this;
        }

        public MemberProperty SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public MemberProperty CopyFrom(MemberProperty other)
        {
            throw new NotImplementedException();
        }

        public MemberProperty finishModification()
        {
            throw new NotImplementedException();
        }

        public MemberProperty Modify()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.Bootstrap getBootstrap()
        {
            throw new NotImplementedException();
        }
    }
}
