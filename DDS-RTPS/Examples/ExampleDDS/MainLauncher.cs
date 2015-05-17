using ExampleDDS.Common;
using ExampleDDS.DiscoveryExamples;
using ExampleDDS.PubSubExamples;
using System;

namespace ExampleDDS
{
    class MainLauncher
    {
        private const String Example = "07";

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
                case "05":
                    app = new PubSubExample05();
                    break;
                case "06":
                    app = new PubSubExample06();
                    break;
                case "07":
                    app = new PubSubExample07();
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
