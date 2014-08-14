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
            // This should generate an error. A NormalClass is not a IDDSObject
            // This allows us to check an error condition by the compiler.
            //var obj1 = SimpleEngine.MakeDDSObject<NormalClass>("ADomain");

             // The object is intercepted when the app try to change a virtual field (property)
            var obj2 = SimpleEngine.MakeDDSObject<SampleClass>("ADomain");

            Console.WriteLine("The value of the object is = " + obj2.Value);
            Console.WriteLine("I'll try to modify the value to 3");

            obj2.Value = 3;

            Console.WriteLine("The value of the object is now = " + obj2.Value);

            Console.WriteLine("Press Enter to finish");
            Console.ReadLine();
        }
    }
}
