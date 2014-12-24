using ExampleDDS.Common;
using ExampleDDS.DiscoveryExamples;
using ExampleDDS.PubSubExamples;
using System;

namespace ExampleDDS
{
    class MainLauncher
    {
        public static void Main(string[] args)
        {
            //ExampleApp app = new DiscoveryExample01();
            ExampleApp app = new PubSubExample02();
            app.RunExample(args);
#if DEBUG
             Console.WriteLine("Press enter to Close...");
             Console.ReadLine();
#endif
        }
    }
}
