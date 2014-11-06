using org.omg.dds.type.typeobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.XTypes
{
    public class EnumerationTypeImpl : TypeImpl, EnumerationType 
    {
        public int BitBound { get; set; }
        public IList<EnumeratedConstant> Constants { get; set; }

        public int getBitBound()
        {
            return this.BitBound;
        }

        public EnumerationType setBitBound(int newBitBound)
        {
            this.BitBound = newBitBound;
            return this;
        }

        public IList<EnumeratedConstant> getConstant()
        {
            return this.Constants;
        }

        public EnumerationType setConstant(IList<EnumeratedConstant> newConstant)
        {
            this.Constants = newConstant;
            return this;
        }
    }
}
