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

        public int GetBitBound()
        {
            return this.BitBound;
        }

        public EnumerationType SetBitBound(int newBitBound)
        {
            this.BitBound = newBitBound;
            return this;
        }

        public IList<EnumeratedConstant> GetConstant()
        {
            return this.Constants;
        }

        public EnumerationType SetConstant(IList<EnumeratedConstant> newConstant)
        {
            this.Constants = newConstant;
            return this;
        }
    }
}
