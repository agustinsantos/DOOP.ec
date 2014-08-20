using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxyTutorial03
{
    class Program
    {
        static void Main(string[] args)
        {
            // The object is intercepted when the app try to change a virtual field (property)
            var obj2 = SimpleEngine.MakeDDSObject<SampleClass>("ADomain");

            Console.WriteLine("I'll call Method1 (intercepted)");
            obj2.Method1();

            Console.WriteLine("I'll call Method2 (not intercepted)");
            obj2.Method2();

            Console.WriteLine("Press Enter to finish");
            Console.ReadLine();
        }
    }
}
