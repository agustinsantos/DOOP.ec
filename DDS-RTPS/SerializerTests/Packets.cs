using Doopec.Serializer.Attributes;
using System;
using org.omg.dds.type;
using System.Collections.Generic;
using System.Linq;

namespace SerializerTests
{
    #region Regular classes for testing
    [Packet]
    public sealed class BoolPacket
    {
        [Field]
        private bool m_val;

        public BoolPacket()
        { }

        public BoolPacket(bool v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            BoolPacket otherObj = (BoolPacket)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    [Packet]
    public sealed class CharPacket
    {
        [Field]
        private char m_val;
        public CharPacket()
        { }

        public CharPacket(char v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            CharPacket otherObj = (CharPacket)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    [Packet]
    public sealed class U8Packet
    {
        [Field]
        private byte m_val;

        public U8Packet()
        { }

        public U8Packet(byte v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            U8Packet otherObj = (U8Packet)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    [Packet]
    public sealed class U16Packet
    {
        [Field]
        private ushort m_val;
        public U16Packet()
        { }

        public U16Packet(ushort v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            U16Packet otherObj = (U16Packet)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    [Packet]
    public sealed class U32Packet
    {
        [Field]
        private uint m_val;

        public U32Packet(uint v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            U32Packet otherObj = (U32Packet)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    [Packet]
    public sealed class U64Packet
    {
        [Field]
        private ulong m_val;

        public U64Packet(ulong v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            U64Packet otherObj = (U64Packet)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    [Packet]
    public sealed class S8Packet
    {
        [Field]
        private sbyte m_val;

        public S8Packet(sbyte v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            S8Packet otherObj = (S8Packet)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    [Packet]
    public sealed class S16Packet
    {
        [Field]
        private short m_val;

        public S16Packet(short v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            S16Packet otherObj = (S16Packet)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    [Packet]
    public sealed class S32Packet
    {
        [Field]
        private int m_val;

        public S32Packet(int v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            S32Packet otherObj = (S32Packet)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    [Packet]
    public sealed class S64Packet
    {
        [Field]
        private long m_val;

        public S64Packet(long v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            S64Packet otherObj = (S64Packet)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    [Packet]
    public sealed class SinglePacket
    {
        [Field]
        private float m_val;

        public SinglePacket(float v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            SinglePacket otherObj = (SinglePacket)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    [Packet]
    public sealed class DoublePacket
    {
        [Field]
        private double m_val;

        public DoublePacket(double v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            DoublePacket otherObj = (DoublePacket)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    [Packet]
    public sealed class PrimitivesPacket
    {
        [Field]
        private bool m_bool;

        [Field]
        private char m_char;

        [Field]
        private byte m_byte;

        [Field]
        private ushort m_ushort;

        [Field]
        private uint m_uint;

        [Field]
        private ulong m_ulong;

        [Field]
        private sbyte m_sbyte;

        [Field]
        private short m_short;

        [Field]
        private int m_int;

        [Field]
        private long m_long;

        [Field]
        private float m_single;

        [Field]
        private double m_double;

        public PrimitivesPacket(int seed)
        {
            Random r = new Random(seed);
            m_bool = (r.Next() & 1) == 1;
            m_byte = (byte)r.Next();
            m_sbyte = (sbyte)r.Next();
            m_char = (char)r.Next();
            m_ushort = (ushort)r.Next();
            m_short = (short)r.Next();
            m_uint = (uint)r.Next();
            m_int = (int)r.Next();
            m_ulong = (ulong)r.Next();
            m_long = (long)r.Next();

            m_single = (float)r.NextDouble();
            m_double = r.NextDouble();
        }

        public static int Size()
        {
            return sizeof(bool) +
                   sizeof(byte) +
                   sizeof(sbyte) +
                   sizeof(char) +
                   sizeof(ushort) +
                   sizeof(short) +
                   sizeof(uint) +
                   sizeof(int) +
                   sizeof(ulong) +
                   sizeof(long) +
                   sizeof(float) +
                   sizeof(double);
        }

        public override bool Equals(object other)
        {
            PrimitivesPacket otherObj = (PrimitivesPacket)other;
            return this.m_bool == otherObj.m_bool &&
                    this.m_byte == otherObj.m_byte &&
                    this.m_sbyte == otherObj.m_sbyte &&
                    this.m_char == otherObj.m_char &&
                    this.m_ushort == otherObj.m_ushort &&
                    this.m_short == otherObj.m_short &&
                    this.m_uint == otherObj.m_uint &&
                    this.m_int == otherObj.m_int &&
                    this.m_ulong == otherObj.m_ulong &&
                    this.m_long == otherObj.m_long &&
                    this.m_single == otherObj.m_single &&
                    this.m_double == otherObj.m_double;
        }
        public override Int32 GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    public enum MyEnum
    {
        Zero = 0,
        One,
        Two,
        Three,
        Four,
        Five,
    }

    [Packet]
    public sealed class EnumPacket
    {
        [Field]
        private MyEnum m_val;

        public EnumPacket(MyEnum v)
        {
            m_val = v;
        }
        public static int Size()
        {
            return sizeof(MyEnum);
        }

        public override bool Equals(object other)
        {
            EnumPacket otherObj = (EnumPacket)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    [Packet]
    public struct MyStruct1
    {
        [Field]
        public byte m_byte;

        [Field]
        public int m_int;

        [Field]
        public long m_long;

        public static int Size()
        {
            return sizeof(byte) + sizeof(int) + sizeof(long);
        }

        public override bool Equals(object other)
        {
            MyStruct1 otherObj = (MyStruct1)other;
            return this.m_byte == otherObj.m_byte &&
                    this.m_int == otherObj.m_int &&
                    this.m_long == otherObj.m_long;
        }
        public override Int32 GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    [Packet]
    public struct MyStruct2
    {
        [Field]
        public MyEnum m_enum;

        [Field]
        public int m_int;

        public static int Size()
        {
            return sizeof(MyEnum) + sizeof(int);
        }

        public override bool Equals(object other)
        {
            MyStruct2 otherObj = (MyStruct2)other;
            return this.m_enum == otherObj.m_enum &&
                   this.m_int == otherObj.m_int;
        }
        public override Int32 GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    [Packet]
    public sealed class StructMessage
    {
        [Field]
        MyStruct1 m_struct1;

        [Field]
        MyStruct2 m_struct2;

        public StructMessage()
        {
        }
        public static int Size()
        {
            return MyStruct1.Size() + MyStruct2.Size();
        }

        public override bool Equals(object other)
        {
            StructMessage otherObj = (StructMessage)other;
            return this.m_struct1.Equals(otherObj.m_struct1) &&
                   this.m_struct2.Equals(otherObj.m_struct2);
        }
        public override Int32 GetHashCode()
        {
            throw new NotImplementedException();
        }
    }

    [Packet]
    public class MyClass1
    {
        [Field]
        public byte m_byte;

        [Field]
        public int m_int;

        [Field]
        public long m_long;

        public static int Size()
        {
            return sizeof(byte) + sizeof(int) + sizeof(long);
        }

        public override bool Equals(object other)
        {
            MyClass1 otherObj = (MyClass1)other;
            return this.m_byte == otherObj.m_byte &&
                    this.m_int == otherObj.m_int &&
                    this.m_long == otherObj.m_long;
        }
        public override Int32 GetHashCode()
        {
            throw new NotImplementedException();
        }
    }



    [Packet]
    public class MyClassList
    {
        [Field]
        public int m_int;

        [Field]
        public List<int> m_intlist;

        public static int Size()
        {
            return 16 + 4;
        }

        public override bool Equals(object other)
        {
            MyClassList otherObj = (MyClassList)other;
            return this.m_int == otherObj.m_int && m_intlist.Count == m_intlist.Count;
        }
        public override Int32 GetHashCode()
        {
            return this.m_intlist.GetHashCode();
        }
    }

    [Packet]
    public sealed class BoolSequencePacket
    {
        [Field]
        private bool[] m_val;

        public int Size
        {
            get { return m_val.Length * sizeof(bool); }
        }

        public BoolSequencePacket()
        { }

        public BoolSequencePacket(bool[] v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;

            BoolSequencePacket otherObj = (BoolSequencePacket)other;
            if (this.m_val == null && otherObj.m_val == null)
                return true;
            return Enumerable.SequenceEqual(this.m_val, otherObj.m_val);
        }

        public override Int32 GetHashCode()
        {
            int hc = this.m_val.Length;
            for (int i = 0; i < this.m_val.Length; ++i)
            {
                hc = unchecked(hc * 314159 + (this.m_val[i] ? 1 : 0));
            }
            return hc;
        }
    }

    [Packet]
    public sealed class ShortSequencePacket
    {
        [Field]
        private short[] m_val;

        public int Size
        {
            get { return m_val.Length * sizeof(short); }
        }
        public ShortSequencePacket()
        { }

        public ShortSequencePacket(short[] v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;

            ShortSequencePacket otherObj = (ShortSequencePacket)other;
            if (this.m_val == null && otherObj.m_val == null)
                return true;
            return Enumerable.SequenceEqual(this.m_val, otherObj.m_val);
        }

        public override Int32 GetHashCode()
        {
            int hc = this.m_val.Length;
            for (int i = 0; i < this.m_val.Length; ++i)
            {
                hc = unchecked(hc * 314159 + this.m_val[i]);
            }
            return hc;
        }
    }
    [Packet]
    public sealed class EnumSequencePacket
    {
        [Field]
        private MyEnum[] m_val;

        public int Size
        {
            get { return m_val.Length * sizeof(MyEnum); }
        }

        public EnumSequencePacket()
        { }

        public EnumSequencePacket(MyEnum[] v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;

            EnumSequencePacket otherObj = (EnumSequencePacket)other;
            if (this.m_val == null && otherObj.m_val == null)
                return true;
            return Enumerable.SequenceEqual(this.m_val, otherObj.m_val);
        }

        public override Int32 GetHashCode()
        {
            int hc = this.m_val.Length;
            for (int i = 0; i < this.m_val.Length; ++i)
            {
                hc = unchecked(hc * 314159 + (int)this.m_val[i]);
            }
            return hc;
        }
    }

    [Packet]
    public sealed class IntSequencePacket
    {
        [Field]
        public int[] m_val;

        public int Size
        {
            get { return m_val.Length * sizeof(int); }
        }

        public IntSequencePacket()
        { }

        public IntSequencePacket(int[] v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            if (other == null)
                return false;

            IntSequencePacket otherObj = (IntSequencePacket)other;
            if (this.m_val == null && otherObj.m_val == null)
                return true;
            return Enumerable.SequenceEqual(this.m_val, otherObj.m_val);
        }
        public override Int32 GetHashCode()
        {
            int hc = this.m_val.Length;
            for (int i = 0; i < this.m_val.Length; ++i)
            {
                hc = unchecked(hc * 314159 + this.m_val[i]);
            }
            return hc;
        }
    }
    #endregion

    #region Extended and Annotated Classes for testing
    [Packet]
    public class XMyClass1
    {
        [Field]
        [ID(0x8001)]
        public byte m_byte;

        [Field]
        [ID(0x8002)]
        public int m_int;

        [Field]
        [ID(0x8003)]
        public short m_short;

        public static int Size()
        {
            return sizeof(byte) + sizeof(int) + sizeof(long);
        }

        public override bool Equals(object other)
        {
            XMyClass1 otherObj = (XMyClass1)other;
            return this.m_byte == otherObj.m_byte &&
                    this.m_int == otherObj.m_int &&
                    this.m_short == otherObj.m_short;
        }
        public override Int32 GetHashCode()
        {
            return (int)(m_byte * m_int * m_short);
        }


        [Packet(EncapsulationScheme = Encapsulation.PL_CDR_BE)]
        public class XMyClass_PL_CDR_BE
        {
            [Field]
            [ID(0x8001)]
            public byte m_byte;

            [Field]
            [ID(0x8002)]
            public int m_int;

            [Field]
            [ID(0x8003)]
            public short m_short;

            public static int Size()
            {
                return sizeof(byte) + sizeof(int) + sizeof(long);
            }

            public override bool Equals(object other)
            {
                XMyClass_PL_CDR_BE otherObj = (XMyClass_PL_CDR_BE)other;
                return this.m_byte == otherObj.m_byte &&
                        this.m_int == otherObj.m_int &&
                        this.m_short == otherObj.m_short;
            }
            public override Int32 GetHashCode()
            {
                return (int)(m_byte * m_int * m_short);
            }
        }
    }
    #endregion
}
