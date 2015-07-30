using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.omg.dds.domain;
using org.omg.dds.core;
using org.omg.dds.core.status;
using org.omg.dds.type.builtin;
using Doopec.Dds.Domain;
using Doopec.Dds.Sub;
using org.omg.dds.sub;
using org.omg.dds.topic;
using System.Collections.Generic;
using Doopec.DDS.Sub;

namespace DDSTests
{
    [TestClass]
    public class SubscriberTest
    {
        /// <summary>
        /// 2.2.2.5.2.5 create_datareader
        /// This operation creates a DataReader. The returned DataReader 
        /// will be attached and belong to the Subscriber. Pag. 66
        /// Method: DataReader<TYPE> CreateDataReader<TYPE>(TopicDescription<TYPE> topic);
        /// </summary>
        [TestMethod]
        public void TestCreateDataReader()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Subscriber subscriber = dp.CreateSubscriber();
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
            DataReader<Type> dr = subscriber.CreateDataReader(tp);
            Assert.IsNotNull(dr);
        }

        /// <summary>
        /// 2.2.2.5.2.5 create_datareader
        /// This operation creates a DataReader. The returned DataReader 
        /// will be attached and belong to the Subscriber. Pag. 66
        /// Method: DataReader<TYPE> CreateDataReader<TYPE>(TopicDescription<TYPE> topic,
        ///  	                                             DataReaderQos qos,
        ///   	                                             DataReaderListener<TYPE> listener,
        ///   	                                             ICollection<Type> statuses);
        /// </summary>
        [TestMethod]
        public void TestCreateDataReader02()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Subscriber subscriber = dp.CreateSubscriber();
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
            DataReaderQos qosdr = new DataReaderQosImpl(Bootstrap.CreateInstance());
            DataReaderListener<Type> listener = null;
            ICollection<Type> statuses = null;
            DataReader<Type> dr = subscriber.CreateDataReader(tp, qosdr, listener, statuses);
            Assert.IsNotNull(dr);
        }

        /// <summary>
        /// 2.2.2.5.2.16 get_default_datareader_qos
        /// This operation retrieves the default value of the DataReader QoS, that is, the QoS policies 
        /// which will be used for newly created DataReader entities in the case where the QoS policies 
        /// are defaulted in the create_datareader operation. Pag. 70
        /// Method: DataReaderQos GetDefaultDataReaderQos();
        /// </summary>
        [TestMethod]
        public void TestGetDefaultDataReaderQoS()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Subscriber subscriber = dp.CreateSubscriber();
            DataReaderQos drqos = subscriber.GetDefaultDataReaderQos();
            Assert.IsNotNull(drqos);
        }


    }
}
