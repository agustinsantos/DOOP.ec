using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Serializer.Attributes
{
    /// <summary>
    /// Indicates that a type is defined for packet serialization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface,
                    AllowMultiple = false, Inherited = true)]
    public sealed class PacketAttribute : Attribute
    {
        public static bool IsCompatible(Type type)
        {
            return type.GetCustomAttributes(typeof(PacketAttribute), false).Any();
        }
    }
}
