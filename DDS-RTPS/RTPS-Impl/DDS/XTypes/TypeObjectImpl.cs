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

        public TypeObject setLibrary(TypeLibrary library)
        {
            Library = library;
            throw new NotImplementedException();
        }

        public TypeLibrary getLibrary()
        {
            return Library;
        }

        public TypeObject setTheType(int the_type)
        {
            TypeId = the_type;
            throw new NotImplementedException();
        }

        public int getTheType()
        {
            return TypeId;
        }

        public TypeObject CopyFrom(TypeObject other)
        {
            throw new NotImplementedException();
        }

        public TypeObject finishModification()
        {
            throw new NotImplementedException();
        }

        public TypeObject Modify()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.Bootstrap getBootstrap()
        {
            throw new NotImplementedException();
        }
    }
}
