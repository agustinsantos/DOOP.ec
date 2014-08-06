using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProxyTutorial02
{
    class Program
    {
        static void Main(string[] args)
        { 
             // THIS OBJECT IS INTERCEPTED, BUT ONLY THE VIRTUAL METHOD
            var obj2 = SimpleEngine.MakeObject<SampleClass>();

            Console.WriteLine("The intercepted method returns = " + obj2.SayIntercepted());
            Console.WriteLine("The non-intercepted method returns = " + obj2.SayNoIntercepted());
            Console.WriteLine("The non-intercepted method 2 returns = " + obj2.SayNoIntercepted2());

            Console.WriteLine("Press Enter to finish");
            Console.ReadLine();
        }
    }
}
