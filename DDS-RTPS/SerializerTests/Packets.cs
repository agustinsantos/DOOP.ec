using Doopec.Serializer.Attributes;
using System;

namespace SerializerTests
{
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
        private  long m_val;

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
}
