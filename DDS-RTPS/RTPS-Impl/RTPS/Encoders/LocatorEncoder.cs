using Doopec.Serializer;
using Mina.Core.Buffer;
using Rtps.Structure.Types;
using System;
using System.Reflection;

namespace Doopec.Rtps.Encoders
{
    public static class LocatorEncoder
    {
        public static void PutLocator(this IoBuffer buffer, Locator obj)
        {
            buffer.PutInt32((int)obj.Kind);
            buffer.PutInt32(obj.Port);
            buffer.Put(obj.SocketAddressBytes);
        }

        public static void WriteLocator(IoBuffer buffer, Locator obj)
        {
            buffer.PutInt32((int)obj.Kind);
            buffer.PutInt32(obj.Port);
            buffer.Put(obj.SocketAddressBytes);
        }

        public static Locator GetLocator(this IoBuffer buffer)
        {
            Locator obj = new Locator();
            buffer.GetLocator(ref obj);
            return obj;
        }

        public static void GetLocator(this IoBuffer buffer, ref Locator obj)
        {
            obj.Kind = (LocatorKind)buffer.GetInt32();
            obj.Port = (int)buffer.GetInt32(); ;
            byte[] tmp = new byte[16];

            buffer.Get(tmp, 0, 16);
            obj.SocketAddressBytes = tmp;
        }

        public static void ReadLocator(IoBuffer buffer, ref Locator obj)
        {
            if (obj == null)
                obj = new Locator();
            obj.Kind = (LocatorKind)buffer.GetInt32();
            obj.Port = (int)buffer.GetInt32(); ;
            byte[] tmp = new byte[16];

            buffer.Get(tmp, 0, 16);
            obj.SocketAddressBytes = tmp;
        }
    }
    public class LocatorSerializer : IStaticTypeSerializer
    {
        delegate void WriterDelegate(IoBuffer buffer, Locator obj);
        delegate void ReaderDelegate(IoBuffer buffer, ref Locator obj);

        public void GetStaticMethods(System.Type type, out MethodInfo writer, out MethodInfo reader)
        {
            WriterDelegate writerDelegate = LocatorEncoder.WriteLocator;
            ReaderDelegate readerDelegate = LocatorEncoder.ReadLocator;
            writer = writerDelegate.Method;
            reader = readerDelegate.Method;
        }

        public bool Handles(System.Type type)
        {
            return type == typeof(Locator);
        }

        public System.Collections.Generic.IEnumerable<System.Type> GetSubtypes(System.Type type)
        {
            yield break;
        }
    }
}
