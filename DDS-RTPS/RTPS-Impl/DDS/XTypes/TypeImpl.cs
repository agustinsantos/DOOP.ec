using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.omg.dds.type.typeobject;

namespace Doopec.Dds.XTypes
{
    public class TypeImpl : org.omg.dds.type.typeobject.Type
    {
        public TypeProperty Property { get; set; }

        public TypeProperty getProperty()
        {
            return this.Property;
        }

        public org.omg.dds.type.typeobject.Type setProperty(TypeProperty newProperty)
        {
            this.Property = newProperty;
            return this;
        }

        public IList<AnnotationUsage> getAnnotation()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.typeobject.Type setAnnotation(IList<AnnotationUsage> newAnnotation)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.typeobject.Type CopyFrom(org.omg.dds.type.typeobject.Type other)
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.typeobject.Type FinishModification()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.type.typeobject.Type Modify()
        {
            throw new NotImplementedException();
        }

        public org.omg.dds.core.Bootstrap GetBootstrap()
        {
            throw new NotImplementedException();
        }
    }
}
