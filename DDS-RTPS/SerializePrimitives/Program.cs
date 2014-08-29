using Mina.Core.Buffer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializePrimitives
{
    class Program
    {
        static void Main(string[] args)
        {

            double v1 = 1.0;
            double v2 = 0.00000024312;
            double v3 = 38423423434.434;
            double v4 = .0;

            int loops = 100000;
            var stream = ByteBufferAllocator.Instance.Allocate(loops * 4 * sizeof(double));

            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                var sw = Stopwatch.StartNew();

                for (int i = 0; i < loops; ++i)
                {
                    Doopec.Serializer.Primitives.WritePrimitive(stream, v1);
                    Doopec.Serializer.Primitives.WritePrimitive(stream, v2);
                    Doopec.Serializer.Primitives.WritePrimitive(stream, v3);
                    Doopec.Serializer.Primitives.WritePrimitive(stream, v4);
                }

                sw.Stop();

                Console.WriteLine("Writing {0} ms", sw.ElapsedMilliseconds);
            }

            long size = stream.Position;

            Console.WriteLine("Size {0}", size);

            stream.Position = 0;

            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                var sw = Stopwatch.StartNew();

                for (int i = 0; i < loops; ++i)
                {
                    Doopec.Serializer.Primitives.ReadPrimitive(stream, out v1);
                    Doopec.Serializer.Primitives.ReadPrimitive(stream, out v2);
                    Doopec.Serializer.Primitives.ReadPrimitive(stream, out v3);
                    Doopec.Serializer.Primitives.ReadPrimitive(stream, out v4);
                }

                sw.Stop();

                Console.WriteLine("Reading {0} ms", sw.ElapsedMilliseconds);
            }

            Console.WriteLine("done");
            Console.ReadLine();
        }
    }
}
