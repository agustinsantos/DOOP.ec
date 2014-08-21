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

            Console.WriteLine("I'll call Method1");
            obj2.Method1();

            Console.WriteLine("I'll modify some value");
            obj2.SomeValue = "Hello";

            Console.WriteLine("I'll get the value");
            Console.WriteLine("The value is :" + obj2.SomeValue);

            Console.WriteLine("Press Enter to finish");
            Console.ReadLine();
        }
    }
}
