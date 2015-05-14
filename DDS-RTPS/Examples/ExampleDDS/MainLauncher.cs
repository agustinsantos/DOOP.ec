using ExampleDDS.Common;
using ExampleDDS.DiscoveryExamples;
using ExampleDDS.PubSubExamples;
using System;

namespace ExampleDDS
{
    class MainLauncher
    {
        private const String Example = "03";

        public static void Main(string[] args)
        {
            ExampleApp app;
            switch (Example)
            {
                case "01":
                    app = new PubSubExample01();
                    break;
                case "02":
                    app = new PubSubExample02();
                    break;
                case "03":
                    app = new PubSubExample03();
                    break;
                case "04":
                    app = new PubSubExample04();
                    break;
                default:
                    app = new DiscoveryExample01();
                    break;
            }
            app.RunExample(args);
#if DEBUG
             Console.WriteLine("Press enter to Close...");
             Console.ReadLine();
#endif
        }
    }
}
