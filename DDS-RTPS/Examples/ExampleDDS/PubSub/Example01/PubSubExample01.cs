using DDS.ConversionUtils;
using Doopec.Rtps;
using ExampleDDS.Common;
using log4net;
using org.omg.dds.core;
using org.omg.dds.core.status;
using org.omg.dds.domain;
using org.omg.dds.pub;
using org.omg.dds.sub;
using org.omg.dds.topic;
using System;
using System.Reflection;

namespace ExampleDDS.PubSubExamples
{
    class PubSubExample01 : ExampleApp
    {
        public override void RunExample(string[] args)
        {
            base.RunExample(args);

            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipant dp = factory.CreateParticipant();

            // Implicitly create TypeSupport and register type:
            Topic<Greeting> tp = dp.CreateTopic<Greeting>("Greetings Topic");

            // Create the publisher
            Publisher pub = dp.CreatePublisher();
            DataWriter<Greeting> dw = pub.CreateDataWriter(tp);

            // Create the subscriber
            Subscriber sub = dp.CreateSubscriber();
            DataReaderListener<Greeting> ls = new MyListener();
            DataReader<Greeting> dr = sub.CreateDataReader<Greeting>(tp,
                                                                    sub.GetDefaultDataReaderQos(),
                                                                    ls,
                                                                    null /* all status changes */);

            // Now Publish some piece of data
            Greeting data = new Greeting("Hello, World with DDS.");
            Console.WriteLine("Sending data:\"{0}\"", data.Value);
            dw.Write(data);
            //and check that the reader has this data
            dr.WaitForHistoricalData(10, TimeUnit.SECONDS);
           
            
           
        


            dp.Close();
        }

        private class MyListener : DataReaderAdapter<Greeting>
        {
            private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            public override void OnDataAvailable(DataAvailableStatus<Greeting> status)
            {
                DataReader<Greeting> dr = status.GetSource();
                SampleIterator<Greeting> it = dr.Take();
                foreach (Sample<Greeting> smp in it)
                {
                    // SampleInfo stuff is built into Sample:
                    // InstanceHandle inst = smp.GetInstanceHandle();
                    // Data accessible from Sample; null if invalid:
                    Greeting dt = smp.GetData();
                    Console.WriteLine("Received data:\"{0}\"", dt.Value);
                }
            }
        }
    }
}
