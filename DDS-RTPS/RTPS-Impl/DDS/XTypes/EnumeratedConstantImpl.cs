using org.omg.dds.type.typeobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.XTypes
{
    public class EnumeratedConstantImpl : EnumeratedConstant
    {
        public int Value { get; set; }
        public string Name { get; set; }

        public EnumeratedConstant SetValue(int value)
        {
            this.Value = value;
            return this;
        }

        public int getValue()
        {
            return this.Value;
        }

        public EnumeratedConstant SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public string getName()
        {
            return this.Name;
        }

        public EnumeratedConstant CopyFrom(EnumeratedConstant other)
        {
            throw new NotImplementedException();
        }

        public EnumeratedConstant FinishModification()
        {
            throw new NotImplementedException();
        }

        public EnumeratedConstant Modify()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }
    }
}
