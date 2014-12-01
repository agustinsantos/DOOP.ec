using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Serializer.Attributes
{

    public enum Encapsulation
    {
        //OMG CDR Big Endian
        CDR_BE,

        //OMG CDR Little Endian
        CDR_LE,

        // Both the parameter list and its parameters are encapsulated using
        // OMG CDR Big Endian.
        PL_CDR_BE,

        // Both the parameter list and its parameters are encapsulated using
        // OMG CDR Little Endian.
        PL_CDR_LE,

        // HEADER DEFINED
        HEADER,

        // Not specified
        UNKNOWN
    }

    /// <summary>
    /// Indicates that a type is defined for packet serialization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Struct |
                    AttributeTargets.Enum | 
                    AttributeTargets.Interface,
                    AllowMultiple = false, Inherited = true)]
    public sealed class PacketAttribute : Attribute
    {
        public PacketAttribute()
        {
            this.HasHeader = true;
            this.EncapsulationScheme = Encapsulation.CDR_BE;
        }

        public bool HasHeader
        {
            get;
            set;
        }

        public Encapsulation EncapsulationScheme
        {
            get;
            set;
        }

        public static bool IsCompatible(Type type)
        {
            return type.GetCustomAttributes(typeof(PacketAttribute), false).Any();
        }
    }
}
