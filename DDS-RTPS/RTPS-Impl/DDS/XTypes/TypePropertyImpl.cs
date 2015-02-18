using org.omg.dds.type.typeobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.XTypes
{
    public class TypePropertyImpl : TypeProperty
    {
        public TypeFlag Flag { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }

        public TypeProperty SetFlag(TypeFlag flag)
        {
            this.Flag = flag;
            return this;
        }

        public TypeFlag GetFlag()
        {
            return this.Flag;
        }

        public TypeProperty SetTypeId(int typeId)
        {
            this.TypeId = typeId;
            return this;
        }

        public int GetTypeId()
        {
            return this.TypeId;
        }

        public TypeProperty SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public string GetName()
        {
            return this.Name;
        }

        public TypeProperty CopyFrom(TypeProperty other)
        {
            throw new NotImplementedException();
        }

        public TypeProperty FinishModification()
        {
            throw new NotImplementedException();
        }

        public TypeProperty Modify()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }
    }
}
