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
using System.Collections;
using org.omg.dds.core.policy;
using org.omg.dds.core.policy.modifiable;
using Doopec.Dds.Core.Policy;
using org.omg.dds.pub.modifiable;
using org.omg.dds.sub.modifiable;

namespace ExampleDDS.PubSubExamples
{
    class PubSubExample05 : ExampleApp
    {
        public override void RunExample(string[] args)
        {
            base.RunExample(args);
            Bootstrap boostrap = Bootstrap.CreateInstance();
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(boostrap);
            DomainParticipant dp = factory.CreateParticipant(0);
            DomainParticipant dp1 = factory.CreateParticipant(1);
            DomainParticipant dp2 = factory.CreateParticipant(2);
            DomainParticipant dp3 = factory.CreateParticipant(3);
           
            // Implicitly create TypeSupport and register type:
            Topic<Greeting> tp = dp.CreateTopic<Greeting>("Greetings Topic");
            Topic<Greeting> tp1 = dp1.CreateTopic<Greeting>("Greetings Topic");
            Topic<Greeting> tp2 = dp2.CreateTopic<Greeting>("Greetings Topic");
            Topic<Greeting> tp3 = dp3.CreateTopic<Greeting>("Greetings Topic");

            // Create the publisher
            Publisher pub = dp.CreatePublisher();

            ModifiableDataWriterQos qosDW = pub.GetDefaultDataWriterQos().Modify();
            
            
            ModifiableDestinationOrderQosPolicy dpqMod = qosDW.GetDestinationOrder().Modify();
            dpqMod.SetKind(DestinationOrderQosPolicyKind.BY_SOURCE_TIMESTAMP);
            qosDW.SetDestinationOrder(dpqMod);

            DataWriterListener<Greeting> lis = new MyListener1();

            DataWriter<Greeting> dw = pub.CreateDataWriter(tp, qosDW, lis, null);

            // Create the publisher
            Publisher pub1 = dp3.CreatePublisher();

            ModifiableDataWriterQos qosDW1 = pub1.GetDefaultDataWriterQos().Modify();


            ModifiableDestinationOrderQosPolicy dpqMod1 = qosDW1.GetDestinationOrder().Modify();
            dpqMod.SetKind(DestinationOrderQosPolicyKind.BY_SOURCE_TIMESTAMP);
            qosDW.SetDestinationOrder(dpqMod);

            DataWriterListener<Greeting> lis3 = new MyListener1();
            DataWriter<Greeting> dw1 = pub.CreateDataWriter(tp3, qosDW1, lis3, null);

            // Create the subscriber1
            Subscriber sub = dp1.CreateSubscriber();
            ModifiableDataReaderQos qosDR = sub.GetDefaultDataReaderQos().Modify();
            ModifiableDestinationOrderQosPolicy dsqMod = qosDR.GetDestinationOrder().Modify();
            dsqMod.SetKind(DestinationOrderQosPolicyKind.BY_SOURCE_TIMESTAMP);
            qosDR.SetDestinationOrder(dsqMod);
            DataReaderListener<Greeting> ls = new MyListener();
            DataReader<Greeting> dr = sub.CreateDataReader<Greeting>(tp1,
                                                                    qosDR,
                                                                    ls, null /* all status changes */);
           
            // Create the subscriber2
            Subscriber sub1 = dp2.CreateSubscriber();
            
            ModifiableDataReaderQos qosDR1 = sub1.GetDefaultDataReaderQos().Modify();
            ModifiableDestinationOrderQosPolicy dsqMod1 = qosDR1.GetDestinationOrder().Modify();
            dsqMod1.SetKind(DestinationOrderQosPolicyKind.BY_SOURCE_TIMESTAMP);
            qosDR.SetDestinationOrder(dsqMod1);
            DataReaderListener<Greeting> ls1 = new MyListener();
            DataReader<Greeting> dr1 = sub1.CreateDataReader<Greeting>(tp2,
                                                                    qosDR1,
                                                                    ls, null /* all status changes */);
            int i = 0;
            // Now Publish some piece of data
            //Greeting data = new Greeting("Hola Mundo"+ i.ToString());
            //log.InfoFormat("Sending data:\"{0}\"", data.Value);

            for (i = 0; i < 3; i++)
            {
                Greeting data = new Greeting("Hola Mundo dw1" + i.ToString());
                Greeting data1 = new Greeting("Hola Mundo dw2" + i.ToString());
                log.InfoFormat("Sending data:\"{0},{1}\"", data.Value, i);
                dw.Write(data);
                log.InfoFormat("Sending data:\"{0},{1}\"", data1.Value, i);
                
                dw1.Write(data1);
                dr.WaitForHistoricalData(1000, TimeUnit.MILLISECONDS);
                dr1.WaitForHistoricalData(1000, TimeUnit.MILLISECONDS);
                

              
                
            }


            //and check that the reader has this data
            //dr.WaitForHistoricalData(10000, TimeUnit.SECONDS);

            dp.Close();
        }

        private class MyListener : DataReaderAdapter<Greeting>
        {
            private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            int j = 0;
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
                    log.InfoFormat("Suscriber Received data:\"{0},{1}\"", dt.Value, j);
                    j = j + 1;
                }
            }
        }
       
        
        private class MyListener1 : DataWriterAdapter<Greeting>
        {
            private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            /*public override void OnPublicationMatched(PublicationMatchedStatus<Greeting> status)
            {
                DataWriter<Greeting> dw = status.GetSource();
               /* SampleIterator<Greeting> it = dw.
                foreach (Sample<Greeting> smp in it)
                {
                    // SampleInfo stuff is built into Sample:
                    // InstanceHandle inst = smp.GetInstanceHandle();
                    // Data accessible from Sample; null if invalid:
                    Greeting dt = smp.GetData();
                    log.InfoFormat("Received data:\"{0}\"", dt.Value);
                }
            }*/
        }

    }
}
