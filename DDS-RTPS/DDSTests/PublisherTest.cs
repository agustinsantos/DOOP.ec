using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.omg.dds.domain;
using org.omg.dds.core;
using org.omg.dds.core.status;
using org.omg.dds.type.builtin;
using Doopec.Dds.Domain;
using Doopec.Dds.Pub;
using org.omg.dds.pub;
using org.omg.dds.topic;
using System.Collections.Generic;

namespace DDSTests
{
    [TestClass]
    public class PublisherTest
    {
        /// <summary>
        /// 2.2.2.4.1.5 create_ datawriter
        /// This operation creates a DataWriter. 
        /// The returned DataWriter will be attached and belongs to the Publisher. Pag. 44
        /// Method: DataWriter<TYPE> CreateDataWriter<TYPE>(Topic<TYPE> topic);
        /// </summary>
        [TestMethod]
        public void TestCreateDataWriter()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Publisher publisher = dp.CreatePublisher();
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
            DataWriter<Type> dw = publisher.CreateDataWriter(tp);
            Assert.IsNotNull(dw);
        }

        /// <summary>
        /// 2.2.2.4.1.5 create_ datawriter
        /// This operation creates a DataWriter. 
        /// The returned DataWriter will be attached and belongs to the Publisher. Pag. 44
        /// Method: DataWriter<TYPE> CreateDataWriter<TYPE>(Topic<TYPE> topic,
        ///                                                 DataWriterQos qos,
        ///                                                 DataWriterListener<TYPE> listener,
        ///                                                 ICollection<Type> statuses);
        /// </summary>
        [TestMethod]
        public void TestCreateDataWriter02()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Publisher publisher = dp.CreatePublisher();
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
            DataWriterQos qosdw = new DataWriterQosImpl(Bootstrap.CreateInstance());
            DataWriterListener<Type> listener = null;
            ICollection<Type> statuses = null;
            DataWriter<Type> dw = publisher.CreateDataWriter(tp, qosdw, listener, statuses);
            Assert.IsNotNull(dw);
        }

        /// <summary>
        /// 2.2.2.4.1.16 get_default_datawriter_qos
        /// This operation retrieves the default value of the DataWriter QoS, that is, 
        /// the QoS policies which will be used for newly created DataWriter entities in the 
        /// case where the QoS policies are defaulted in the create_datawriter operation. Pag.47
        /// Method: DataWriterQos GetDefaultDataWriterQos();
        /// </summary>
        [TestMethod]
        public void TestGetDefaultDataWriterQoS()
        {
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Publisher publisher = dp.CreatePublisher();        
            DataWriterQos dwqos = publisher.GetDefaultDataWriterQos();
            Assert.IsNotNull(dwqos);
        }
        
    }
}
