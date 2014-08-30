﻿using Doopec.Serializer.Attributes;
using System;

namespace SerializerTests
{
    [Packet]
    public sealed class BoolPacket
    {
        [Field]
        private bool m_val;

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
}