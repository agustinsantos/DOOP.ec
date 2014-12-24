using org.omg.dds.type.typeobject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Dds.XTypes
{
    public class TypeObjectImpl : TypeObject
    {
        private TypeLibrary Library { get; set; }
        private int TypeId { get; set; }

        public TypeObject SetLibrary(TypeLibrary library)
        {
            Library = library;
            throw new NotImplementedException();
        }

        public TypeLibrary GetLibrary()
        {
            return Library;
        }

        public TypeObject SetTheType(int the_type)
        {
            TypeId = the_type;
            throw new NotImplementedException();
        }

        public int GetTheType()
        {
            return TypeId;
        }

        public TypeObject CopyFrom(TypeObject other)
        {
            throw new NotImplementedException();
        }

        public TypeObject FinishModification()
        {
            throw new NotImplementedException();
        }

        public TypeObject Modify()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }
    }
}
