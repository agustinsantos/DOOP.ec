using System;

namespace DynamicProxyTutorial01
{
    class Program
    {
        static void Main(string[] args)
        {
            // THIS OBJECT IS A REGULAR ONE
            var obj1 = new SampleClass();
            
            obj1.IntegerData = 1;
            Console.WriteLine("The interger data of (non-intercepted) obj is = " + obj1.IntegerData);

            // THIS OBJECT IS INTERCEPTED
            var obj2 = SimpleEngine.MakeObject<SampleClass>();

            obj2.IntegerData = 1;
            Console.WriteLine("The interger data of (intercepted) obj is = " + obj2.IntegerData);

            Console.WriteLine("Press Enter to finish");
            Console.ReadLine();
        }
    }
}
