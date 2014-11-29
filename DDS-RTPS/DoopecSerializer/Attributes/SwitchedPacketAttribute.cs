using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Serializer.Attributes
{
    /// <summary>
    /// Indicates that a type is defined for complex packet serialization.
    /// This packet has a header and several bodies that depend on a switch field
    /// </summary>
    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Struct |
                    AttributeTargets.Enum |
                    AttributeTargets.Interface,
                    AllowMultiple = false, Inherited = true)]
    public sealed class SwitchedPacketAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the name of the switch field.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String SwtichField { get; set; }

        public static bool IsCompatible(Type type)
        {
            return type.GetCustomAttributes(typeof(SwitchedPacketAttribute), false).Any();
        }
    }
}
