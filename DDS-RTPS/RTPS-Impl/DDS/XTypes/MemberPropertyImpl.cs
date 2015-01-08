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
        public int MemberId { get; set; }
        public int MemberType { get; set; }
        public string Name { get; set; }

        public MemberProperty setFlag(MemberFlag flag)
        {
            this.Flag = flag;
            return this;
        }

        public MemberFlag getFlag()
        {
            return this.Flag;
        }

        public MemberProperty setMemberId(int memberId)
        {
            this.MemberId = memberId;
            return this;
        }

        public int getMemberId()
        {
            return this.MemberId;
        }

        public MemberProperty setType(int type)
        {
            this.MemberType = type;
            return this;
        }

        public int getType()
        {
            return this.MemberType;
        }

        public MemberProperty setName(string name)
        {
            this.Name = name;
            return this;
        }

        public string getName()
        {
            return this.Name;
        }

        public MemberProperty copyFrom(MemberProperty other)
        {
            throw new NotImplementedException();
        }

        public MemberProperty finishModification()
        {
            throw new NotImplementedException();
        }

        public MemberProperty modify()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.Bootstrap GetBootstrap
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
