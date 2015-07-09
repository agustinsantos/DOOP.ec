using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.omg.dds.core;
using org.omg.dds.domain;
using Doopec.Dds.Domain;
using org.omg.dds.domain.modifiable;
using org.omg.dds.core.policy;
using Doopec.DDS.Core.Policy;
using org.omg.dds.core.policy.modifiable;
using org.omg.dds.pub;
using org.omg.dds.topic;
using org.omg.dds.pub.modifiable;
using org.omg.dds.sub;
using org.omg.dds.sub.modifiable;
using org.omg.dds.topic.modifiable;
using Doopec.Dds.Core.Policy;

namespace DDSTests
{
    [TestClass]
    public class ChangeableQoSTests
    {
        [TestMethod]
        public void UserDataDomainsDisableTest01()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Assert.IsFalse(dp.IsEnabled);

            ModifiableDomainParticipantQos qos = dp.GetQos().Modify();

            ModifiableUserDataQosPolicy userData = new UserDataQosPolicyImpl(dp.GetBootstrap()).Modify();
            byte[] userValue = new byte[] { 0x0A };
            userData.SetValue(userValue, 0, userValue.Length);
            qos.SetUserData(userData);
            dp.SetQos(qos);

            Assert.IsNotNull(dp.GetQos());
            Assert.IsNotNull(dp.GetQos().GetUserData());

            byte[] userdataVal = new byte[userValue.Length];
            dp.GetQos().GetUserData().GetValue(userdataVal, 0);

            Assert.AreEqual(userValue.Length, userdataVal.Length);
            Assert.AreEqual(userValue[0], userdataVal[0]);

        }


        [TestMethod]
        public void UserDataDomainsDisableTest02()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Assert.IsFalse(dp.IsEnabled);

            ModifiableDomainParticipantQos qos = dp.GetQos().Modify();
            var olduserData = dp.GetQos().GetUserData();

            dp.SetQos(qos);
            var newuserData = dp.GetQos().GetUserData();

            Assert.IsNotNull(dp.GetQos());
            Assert.IsNotNull(olduserData);
            Assert.IsNotNull(newuserData);

            Assert.AreEqual(olduserData, newuserData);

        }

        [TestMethod]
        public void UserDataDomainsDisableTest03()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Assert.IsFalse(dp.IsEnabled);

            ModifiableDomainParticipantQos qos = dp.GetQos().Modify();
            var olduserData = dp.GetQos().GetUserData();

            dp.SetQos(null);
            var newuserData = dp.GetQos().GetUserData();

            Assert.IsNotNull(dp.GetQos());
            Assert.IsNotNull(olduserData);
            Assert.IsNotNull(newuserData);

            Assert.AreEqual(olduserData, newuserData);

        }

        [TestMethod]
        public void UserDataDomainsDisableTest04()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Assert.IsFalse(dp.IsEnabled);

            ModifiableDomainParticipantQos qos = dp.GetQos().Modify();

            ModifiableUserDataQosPolicy userData = new UserDataQosPolicyImpl(dp.GetBootstrap()).Modify();
            byte[] userValue = new byte[] { 0x0A };
            userData.SetValue(userValue, 0, userValue.Length);
            qos.SetUserData(userData);
            dp.SetQos(qos);

            Assert.IsNotNull(dp.GetQos());
            Assert.IsNotNull(dp.GetQos().GetUserData());

            byte[] userdataVal = new byte[userValue.Length];
            dp.GetQos().GetUserData().GetValue(userdataVal, 0);

            Assert.AreEqual(userValue.Length, userdataVal.Length);
            Assert.AreEqual(userValue[0], userdataVal[0]);


            byte[] userValue2 = new byte[] { 0x0C };
            userData.SetValue(userValue2, 0, userValue.Length);
            qos.SetUserData(userData);
            dp.SetQos(qos);

            Assert.IsNotNull(dp.GetQos());
            Assert.IsNotNull(dp.GetQos().GetUserData());

            userdataVal = new byte[userValue.Length];
            dp.GetQos().GetUserData().GetValue(userdataVal, 0);

            Assert.AreEqual(userValue2.Length, userdataVal.Length);
            Assert.AreEqual(userValue2[0], userdataVal[0]);

        }

        [TestMethod]
        public void UserDataDomainsEnableTest01()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            dp.Enable();
            Assert.IsTrue(dp.IsEnabled);

            ModifiableDomainParticipantQos qos = dp.GetQos().Modify();

            ModifiableUserDataQosPolicy userData = new UserDataQosPolicyImpl(dp.GetBootstrap()).Modify();
            byte[] userValue = new byte[] { 0x0A };
            userData.SetValue(userValue, 0, userValue.Length);
            qos.SetUserData(userData);
            dp.SetQos(qos);

            Assert.IsNotNull(dp.GetQos());
            Assert.IsNotNull(dp.GetQos().GetUserData());

            byte[] userdataVal = new byte[userValue.Length];
            dp.GetQos().GetUserData().GetValue(userdataVal, 0);

            Assert.AreEqual(userValue.Length, userdataVal.Length);
            Assert.AreEqual(userValue[0], userdataVal[0]);

        }

        [TestMethod]
        public void UserDataDomainsEnableTest02()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            dp.Enable();
            Assert.IsTrue(dp.IsEnabled);

            ModifiableDomainParticipantQos qos = dp.GetQos().Modify();

            ModifiableUserDataQosPolicy userData = new UserDataQosPolicyImpl(dp.GetBootstrap()).Modify();
            byte[] userValue = new byte[] { 0x0A };
            userData.SetValue(userValue, 0, userValue.Length);
            qos.SetUserData(userData);
            dp.SetQos(qos);

            Assert.IsNotNull(dp.GetQos());
            Assert.IsNotNull(dp.GetQos().GetUserData());

            byte[] userdataVal = new byte[userValue.Length];
            dp.GetQos().GetUserData().GetValue(userdataVal, 0);

            Assert.AreEqual(userValue.Length, userdataVal.Length);
            Assert.AreEqual(userValue[0], userdataVal[0]);


            byte[] userValue2 = new byte[] { 0x0C };
            userData.SetValue(userValue2, 0, userValue.Length);
            qos.SetUserData(userData);
            dp.SetQos(qos);

            Assert.IsNotNull(dp.GetQos());
            Assert.IsNotNull(dp.GetQos().GetUserData());

            userdataVal = new byte[userValue.Length];
            dp.GetQos().GetUserData().GetValue(userdataVal, 0);

            Assert.AreEqual(userValue2.Length, userdataVal.Length);
            Assert.AreEqual(userValue2[0], userdataVal[0]);

        }
        [TestMethod]
        public void UserDataDataWriterTest01()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
            Publisher pub = dp.CreatePublisher();
            DataWriter<Type> dw = pub.CreateDataWriter(tp);
            Assert.IsNotNull(dw);
            ModifiableDataWriterQos qos = dw.GetQos().Modify();

            ModifiableUserDataQosPolicy userData = new UserDataQosPolicyImpl(dw.GetBootstrap()).Modify();
            byte[] userValue = new byte[] { 0x0A };
            userData.SetValue(userValue, 0, userValue.Length);
            qos.SetUserData(userData);
            dw.SetQos(qos);

            Assert.IsNotNull(dw.GetQos());
            Assert.IsNotNull(dw.GetQos().GetUserData());

            byte[] userdataVal = new byte[userValue.Length];
            dw.GetQos().GetUserData().GetValue(userdataVal, 0);

            Assert.AreEqual(userValue.Length, userdataVal.Length);
            Assert.AreEqual(userValue[0], userdataVal[0]);
        }
        [TestMethod]
        public void UserDataDataWriterTest02()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
            Publisher pub = dp.CreatePublisher();
            DataWriter<Type> dw = pub.CreateDataWriter(tp);
            Assert.IsNotNull(dw);
            ModifiableDataWriterQos qos = dw.GetQos().Modify();

            ModifiableUserDataQosPolicy userData = new UserDataQosPolicyImpl(dw.GetBootstrap()).Modify();
            byte[] userValue = new byte[] { 0x0A };
            userData.SetValue(userValue, 0, userValue.Length);
            qos.SetUserData(userData);
            dw.SetQos(qos);

            Assert.IsNotNull(dw.GetQos());
            Assert.IsNotNull(dw.GetQos().GetUserData());

            byte[] userdataVal = new byte[userValue.Length];
            dw.GetQos().GetUserData().GetValue(userdataVal, 0);

            Assert.AreEqual(userValue.Length, userdataVal.Length);
            Assert.AreEqual(userValue[0], userdataVal[0]);

            byte[] userValue2 = new byte[] { 0x0C };
            userData.SetValue(userValue2, 0, userValue.Length);
            qos.SetUserData(userData);
            dw.SetQos(qos);

            Assert.IsNotNull(dw.GetQos());
            Assert.IsNotNull(dw.GetQos().GetUserData());

            userdataVal = new byte[userValue.Length];
            dw.GetQos().GetUserData().GetValue(userdataVal, 0);

            Assert.AreEqual(userValue2.Length, userdataVal.Length);
            Assert.AreEqual(userValue2[0], userdataVal[0]);
        }


        [TestMethod]
        public void UserDataDataReaderTest01()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
            Subscriber sub = dp.CreateSubscriber();
            DataReader<Type> dr = sub.CreateDataReader(tp);
            Assert.IsNotNull(dr);
            ModifiableDataReaderQos qos = dr.GetQos().Modify();

            ModifiableUserDataQosPolicy userData = new UserDataQosPolicyImpl(dr.GetBootstrap()).Modify();
            byte[] userValue = new byte[] { 0x0A };
            userData.SetValue(userValue, 0, userValue.Length);
            qos.SetUserData(userData);
            dr.SetQos(qos);

            Assert.IsNotNull(dr.GetQos());
            Assert.IsNotNull(dr.GetQos().GetUserData());

            byte[] userdataVal = new byte[userValue.Length];
            dr.GetQos().GetUserData().GetValue(userdataVal, 0);

            Assert.AreEqual(userValue.Length, userdataVal.Length);
            Assert.AreEqual(userValue[0], userdataVal[0]);
        }

        [TestMethod]
        public void UserDataDataReaderTest02()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
            Subscriber sub = dp.CreateSubscriber();
            DataReader<Type> dr = sub.CreateDataReader(tp);
            Assert.IsNotNull(dr);
            ModifiableDataReaderQos qos = dr.GetQos().Modify();

            ModifiableUserDataQosPolicy userData = new UserDataQosPolicyImpl(dr.GetBootstrap()).Modify();
            byte[] userValue = new byte[] { 0x0A };
            userData.SetValue(userValue, 0, userValue.Length);
            qos.SetUserData(userData);
            dr.SetQos(qos);

            Assert.IsNotNull(dr.GetQos());
            Assert.IsNotNull(dr.GetQos().GetUserData());

            byte[] userdataVal = new byte[userValue.Length];
            dr.GetQos().GetUserData().GetValue(userdataVal, 0);

            Assert.AreEqual(userValue.Length, userdataVal.Length);
            Assert.AreEqual(userValue[0], userdataVal[0]);

            byte[] userValue2 = new byte[] { 0x0C };
            userData.SetValue(userValue2, 0, userValue.Length);
            qos.SetUserData(userData);
            dr.SetQos(qos);

            Assert.IsNotNull(dr.GetQos());
            Assert.IsNotNull(dr.GetQos().GetUserData());

            userdataVal = new byte[userValue.Length];
            dr.GetQos().GetUserData().GetValue(userdataVal, 0);

            Assert.AreEqual(userValue2.Length, userdataVal.Length);
            Assert.AreEqual(userValue2[0], userdataVal[0]);
        }

        [TestMethod]
        public void TopicDataTest01()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Topic<Type> tp = dp.CreateTopic<Type>("Greetings Topic");
            Assert.IsNotNull(tp);
            ModifiableTopicQos qos = tp.GetQos().Modify();
            byte[] topicValue = new byte[] { 0x0A };
            TopicDataQosPolicy topicData = new TopicDataQosPolicyImpl(topicValue, tp.GetBootstrap()).Modify();
            qos.SetTopicData(topicData);
            tp.SetQos(qos);

            Assert.IsNotNull(tp.GetQos());
            Assert.IsNotNull(tp.GetQos().GetTopicData());
        }


        [TestMethod]
        public void GroupDataPublisherTest01()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Publisher pub = dp.CreatePublisher();
            Assert.IsNotNull(pub);
            ModifiablePublisherQos qos = pub.GetQos().Modify();

            ModifiableGroupDataQosPolicy groupData = new GroupDataQosPolicyImpl(pub.GetBootstrap()).Modify();
            byte[] userValue = new byte[] { 0x0A };
            groupData.SetValue(userValue, 0, userValue.Length);
            qos.SetGroupData(groupData);
            pub.SetQos(qos);

            Assert.IsNotNull(pub.GetQos());
            Assert.IsNotNull(pub.GetQos().GetGroupData());

            byte[] userdataVal = new byte[userValue.Length];
            pub.GetQos().GetGroupData().GetValue(userdataVal, 0);

            Assert.AreEqual(userValue.Length, userdataVal.Length);
            Assert.AreEqual(userValue[0], userdataVal[0]);
        }

        [TestMethod]
        public void GroupDataSubscriberTest01()
        {
            //PRECONDITIONS
            DomainParticipantFactory factory = DomainParticipantFactory.GetInstance(Bootstrap.CreateInstance());
            DomainParticipantImpl dp = factory.CreateParticipant() as DomainParticipantImpl;
            Subscriber sub = dp.CreateSubscriber();
            Assert.IsNotNull(sub);
            ModifiableSubscriberQos qos = sub.GetQos().Modify();

            ModifiableGroupDataQosPolicy groupData = new GroupDataQosPolicyImpl(sub.GetBootstrap()).Modify();
            byte[] userValue = new byte[] { 0x0A };
            groupData.SetValue(userValue, 0, userValue.Length);
            qos.SetGroupData(groupData);
            sub.SetQos(qos);

            Assert.IsNotNull(sub.GetQos());
            Assert.IsNotNull(sub.GetQos().GetGroupData());

            byte[] userdataVal = new byte[userValue.Length];
            sub.GetQos().GetGroupData().GetValue(userdataVal, 0);

            Assert.AreEqual(userValue.Length, userdataVal.Length);
            Assert.AreEqual(userValue[0], userdataVal[0]);
        }

    }
}
