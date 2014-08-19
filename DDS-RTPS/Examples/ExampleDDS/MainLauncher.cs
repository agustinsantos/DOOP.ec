using ExampleDDS.Common;
using ExampleDDS.DiscoveryExamples;
using System;

namespace ExampleDDS
{
    class MainLauncher
    {
        public static void Main(string[] args)
        {
            ExampleApp app = new DiscoveryExample01();
             app.RunExample(args);
#if DEBUG
             Console.WriteLine("Press enter to close...");
             Console.ReadLine();
#endif
        }
    }
}
