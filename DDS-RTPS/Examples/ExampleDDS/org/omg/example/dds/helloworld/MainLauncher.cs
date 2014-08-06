using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace org.omg.example.dds.helloworld
{
    class MainLauncher
    {
        public static void Main(string[] args)
        {
            GreetingSubscribingApp.RunExample(args);
           // GreetingPublishingApp.RunExample(args);
           // QosExample.RunExample(args);
        }
    }
}
