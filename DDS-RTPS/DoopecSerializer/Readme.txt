This code is based on the design and code of NetSerializer. 
It is a simple and very fast serializer for .Net languages.

The simpleness of NetSerializer has a drawback which must be considered by the
user: no versioning or other meta information is sent, which means that the
sender and the receiver have to have the same versions of the types being
serialized.  This means that it's a bad idea to save the serialized data for
longer periods of time, as a version upgrade could make the data
non-deserializable.

Supported Types

NetSerializer supports serializing the following types:

- All primitive types (Boolean, Byte, SByte, Int16, UInt16, Int32, UInt32,
  Int64, UInt64, IntPtr, UIntPtr, Char, Double, and Single)
- Strings
- Enums
- Single dimensional arrays
- Structs and classes marked as [Packet].

This code also supports creating custom serializers. Custom serializers can
be used to serialize types not directly supported by the serializer.