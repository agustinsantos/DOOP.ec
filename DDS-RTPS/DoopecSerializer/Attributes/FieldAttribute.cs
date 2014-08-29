using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doopec.Serializer.Attributes
{
    /// <summary>
    /// The most important attribute for a <field> element is the type attribute, which defines how the field length has to be calculated.
    /// </summary>
    public enum FieldType
    {
        Fixed,
        Bit,
        Variable,
        Pattern,
        Line,
        Eatall,
        Padding,
        Plugin,
        Custom,
        Byte,
        BitArray,
        SequenceNumberSet,
        FragmentNumberSet
    }

    /// <summary>
    /// Declares a member to be used in packet serialization, using the
    /// given Tag. A DataFormat may be used to optimise the serialization format
    /// (for instance, using zigzag encoding for negative numbers, or fixed-length
    /// encoding for large values.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class FieldAttribute : System.Attribute
    {


        /// <summary>
        /// (required) It defines the type of the field (i.e. fixed-length, variable length, etc.). More details will follow.
        /// </summary>
        /// <value>
        /// The type
        /// </value>
        public FieldType Fieldtype { get; protected set; }

        /// <summary>
        /// Gets or sets the name.
        /// It defines a unique name that identifies the object within its scope. 
        /// Name can contain alphanumeric characters and the underscore (i.e., [a-zA-Z0-9_]+)
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String Name { get; protected set; }

        /// <summary>
        /// Gets or sets the description.
        /// (required) It defines a 'human' description; it may be used when the object has to be shown.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public String Description { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Sxta.GenericProtocol.Field"/> big endian.
        /// It specifies if the current protocol stores fields in network byte order (i.e. big endian).
        /// For instance, most protocols (e.g. TCP/IP) use the network byte order for storing multibyte 
        /// fields, while some other (e.g. Bluetooth) use little-endian. 
        /// It can assume the following values: 
        ///    no (default): this protocol stores multibyte fields in network byte order 
        ///    yes: this protocol does not store multibyte fields in network byte order
        /// </summary>
        /// <value>
        /// <c>true</c> if big endian; otherwise, <c>false</c>.
        /// </value>
        public bool BigEndian { get; set; }

        public FieldAttribute(String name, FieldType fieldType)
        {
            this.Name = name;
            this.Fieldtype = fieldType;
        }

        public FieldAttribute()
        {
        }
    }
}
