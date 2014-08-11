using Doopec.Rtps;
using ExampleDDS.Common;
using log4net;
using System;
using System.Reflection;

namespace org.omg.example.dds.helloworld
{
    class MainHelloword : ExampleApp
    {

        private new static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void RunExample(string[] args)
        {
            RunPublishingApp(args);
        }

        private void RunPublishingApp(string[] args)
        {
            GreetingPublishingApp.RunExample(args);
        }

        private void RunSubscribingApp(string[] args)
        {
            GreetingSubscribingApp.RunExample(args);
        }

        private void RunQoSApp(string[] args)
        {
            QosExample.RunExample(args);
        }


    }
}
