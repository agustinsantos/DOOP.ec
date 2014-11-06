using org.omg.dds.type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDSTests.XTypes
{
    #region SEALED CLASSES
    public sealed class BoolSealedClass
    {
        private bool m_val;

        public BoolSealedClass(bool v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            BoolSealedClass otherObj = (BoolSealedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public sealed class CharSealedClass
    {
        private char m_val;

        public CharSealedClass(char v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            CharSealedClass otherObj = (CharSealedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public sealed class U8SealedClass
    {
        private byte m_val;

        public U8SealedClass(byte v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            U8SealedClass otherObj = (U8SealedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public sealed class U16SealedClass
    {
        private ushort m_val;

        public U16SealedClass(ushort v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            U16SealedClass otherObj = (U16SealedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public sealed class U32SealedClass
    {
        private uint m_val;

        public U32SealedClass(uint v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            U32SealedClass otherObj = (U32SealedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public sealed class U64SealedClass
    {
        private ulong m_val;

        public U64SealedClass(ulong v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            U64SealedClass otherObj = (U64SealedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public sealed class S8SealedClass
    {
        private sbyte m_val;

        public S8SealedClass(sbyte v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            S8SealedClass otherObj = (S8SealedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public sealed class S16SealedClass
    {
        private short m_val;

        public S16SealedClass(short v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            S16SealedClass otherObj = (S16SealedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public sealed class S32SealedClass
    {
        private int m_val;

        public S32SealedClass(int v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            S32SealedClass otherObj = (S32SealedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public sealed class S64SealedClass
    {
        private long m_val;

        public S64SealedClass(long v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            S64SealedClass otherObj = (S64SealedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public sealed class SingleSealedClass
    {
        private float m_val;

        public SingleSealedClass(float v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            SingleSealedClass otherObj = (SingleSealedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public sealed class DoubleSealedClass
    {
        private double m_val;

        public DoubleSealedClass(double v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            DoubleSealedClass otherObj = (DoubleSealedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public sealed class PrimitivesSealedClass
    {
        private bool m_bool;

        private char m_char;

        private byte m_byte;

        private ushort m_ushort;

        private uint m_uint;

        private ulong m_ulong;

        private sbyte m_sbyte;

        private short m_short;

        private int m_int;

        private long m_long;

        private float m_single;

        private double m_double;

        public PrimitivesSealedClass(int seed)
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
            PrimitivesSealedClass otherObj = (PrimitivesSealedClass)other;
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


    public sealed class EnumSealedClass
    {
        private MyEnum m_val;

        public EnumSealedClass(MyEnum v)
        {
            m_val = v;
        }
        public static int Size()
        {
            return sizeof(MyEnum);
        }

        public override bool Equals(object other)
        {
            EnumSealedClass otherObj = (EnumSealedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    #endregion

    #region NOT SEALED CLASSES
    public class BoolClass
    {
        private bool m_val;

        public BoolClass(bool v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            BoolClass otherObj = (BoolClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class CharClass
    {
        private char m_val;

        public CharClass(char v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            CharClass otherObj = (CharClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class U8Class
    {
        private byte m_val;

        public U8Class(byte v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            U8Class otherObj = (U8Class)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class U16Class
    {
        private ushort m_val;

        public U16Class(ushort v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            U16Class otherObj = (U16Class)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class U32Class
    {
        private uint m_val;

        public U32Class(uint v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            U32Class otherObj = (U32Class)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class U64Class
    {
        private ulong m_val;

        public U64Class(ulong v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            U64Class otherObj = (U64Class)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class S8Class
    {
        private sbyte m_val;

        public S8Class(sbyte v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            S8Class otherObj = (S8Class)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class S16Class
    {
        private short m_val;

        public S16Class(short v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            S16Class otherObj = (S16Class)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class S32Class
    {
        private int m_val;

        public S32Class(int v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            S32Class otherObj = (S32Class)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class S64Class
    {
        private long m_val;

        public S64Class(long v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            S64Class otherObj = (S64Class)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class SingleClass
    {
        private float m_val;

        public SingleClass(float v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            SingleClass otherObj = (SingleClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class DoubleClass
    {
        private double m_val;

        public DoubleClass(double v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            DoubleClass otherObj = (DoubleClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class PrimitivesClass
    {
        private bool m_bool;

        private char m_char;

        private byte m_byte;

        private ushort m_ushort;

        private uint m_uint;

        private ulong m_ulong;

        private sbyte m_sbyte;

        private short m_short;

        private int m_int;

        private long m_long;

        private float m_single;

        private double m_double;

        public PrimitivesClass(int seed)
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
            PrimitivesClass otherObj = (PrimitivesClass)other;
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

    public class EnumClass
    {
        private MyEnum m_val;

        public EnumClass(MyEnum v)
        {
            m_val = v;
        }
        public static int Size()
        {
            return sizeof(MyEnum);
        }

        public override bool Equals(object other)
        {
            EnumClass otherObj = (EnumClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }
    #endregion

    #region ANNOTATED CLASSES
    public class BoolAnnotatedClass
    {
        [ID(0x0010)]
        public bool m_val;

        public BoolAnnotatedClass(bool v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            BoolAnnotatedClass otherObj = (BoolAnnotatedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class CharAnnotatedClass
    {
        private char m_val;

        public CharAnnotatedClass(char v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            CharAnnotatedClass otherObj = (CharAnnotatedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class U8AnnotatedClass
    {
        private byte m_val;

        public U8AnnotatedClass(byte v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            U8AnnotatedClass otherObj = (U8AnnotatedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class U16AnnotatedClass
    {
        private ushort m_val;

        public U16AnnotatedClass(ushort v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            U16AnnotatedClass otherObj = (U16AnnotatedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class U32AnnotatedClass
    {
        private uint m_val;

        public U32AnnotatedClass(uint v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            U32AnnotatedClass otherObj = (U32AnnotatedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class U64AnnotatedClass
    {
        private ulong m_val;

        public U64AnnotatedClass(ulong v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            U64AnnotatedClass otherObj = (U64AnnotatedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class S8AnnotatedClass
    {
        private sbyte m_val;

        public S8AnnotatedClass(sbyte v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            S8AnnotatedClass otherObj = (S8AnnotatedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class S16AnnotatedClass
    {
        private short m_val;

        public S16AnnotatedClass(short v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            S16AnnotatedClass otherObj = (S16AnnotatedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class S32AnnotatedClass
    {
        private int m_val;

        public S32AnnotatedClass(int v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            S32AnnotatedClass otherObj = (S32AnnotatedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class S64AnnotatedClass
    {
        private long m_val;

        public S64AnnotatedClass(long v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            S64AnnotatedClass otherObj = (S64AnnotatedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class SingleAnnotatedClass
    {
        private float m_val;

        public SingleAnnotatedClass(float v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            SingleAnnotatedClass otherObj = (SingleAnnotatedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class DoubleAnnotatedClass
    {
        private double m_val;

        public DoubleAnnotatedClass(double v)
        {
            m_val = v;
        }

        public override bool Equals(object other)
        {
            DoubleAnnotatedClass otherObj = (DoubleAnnotatedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }

    public class PrimitivesAnnotatedClass
    {
        [ID(0x0010)]
        [Optional]
        public bool m_bool;

        [ID(0x0011)]
        [Optional]
        public char m_char;

        [ID(0x0012)]
        public byte m_byte;

        [ID(0x0013)]
        public ushort m_ushort;

        [ID(0x0014)]
        [Key]
        public uint m_uint;

        [ID(0x0015)]
        [Key]
        public ulong m_ulong;

        [ID(0x0016)]
        public sbyte m_sbyte;

        [ID(0x0017)]
        public short m_short;

        [ID(0x0018)]
        public int m_int;

        [ID(0x0019)]
        public long m_long;

        [ID(0x001A)]
        public float m_single;

        [ID(0x001B)]
        public double m_double;

        public PrimitivesAnnotatedClass(int seed)
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
            PrimitivesAnnotatedClass otherObj = (PrimitivesAnnotatedClass)other;
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

    public class EnumAnnotatedClass
    {
        private MyEnum m_val;

        public EnumAnnotatedClass(MyEnum v)
        {
            m_val = v;
        }
        public static int Size()
        {
            return sizeof(MyEnum);
        }

        public override bool Equals(object other)
        {
            EnumAnnotatedClass otherObj = (EnumAnnotatedClass)other;
            return this.m_val == otherObj.m_val;
        }
        public override Int32 GetHashCode()
        {
            return this.m_val.GetHashCode();
        }
    }
    #endregion
}
