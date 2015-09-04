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
           /* DataWriter<Greeting> dw = pub.CreateDataWriter(tp);

*/
           
            DataWriter<Greeting> dw = pub.CreateDataWriter<Greeting>(tp,
                                                                    pub.GetDefaultDataWriterQos(),null,  null);
            // Create the subscriber
            Subscriber sub = dp.CreateSubscriber();
            DataReaderListener<Greeting> ls = new MyListener();
            /*DataReader<Greeting> dr = sub.CreateDataReader(tp);*/

            DataReader<Greeting> dr = sub.CreateDataReader<Greeting>(tp,
                                                                    sub.GetDefaultDataReaderQos(),
                                                                    ls,
                                                                    null  );
            /*
            // Now Publish some piece of data
            Greeting data = new Greeting("Hello, World with DDS.");
            Console.WriteLine("Sending data:\"{0}\"", data.Value);
            dw.Write(data);
            //and check that the reader has this data
            dr.WaitForHistoricalData(10, TimeUnit.SECONDS);

            */
            int i = 0;
            // Now Publish some piece of data
            //Greeting data = new Greeting("Hola Mundo"+ i.ToString());
            //log.InfoFormat("Sending data:\"{0}\"", data.Value);

            for (i = 0; i < 10; i++)
            {
                Greeting data = new Greeting("Hola Mundo" + i.ToString());
                log.InfoFormat("Sending data:\"{0},{1}\"", data.Value, i);
                dw.Write(data);
                dr.WaitForHistoricalData(1000, TimeUnit.MILLISECONDS);
            }


            //and check that the reader has this data
            //dr.WaitForHistoricalData(10000, TimeUnit.SECONDS);

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
