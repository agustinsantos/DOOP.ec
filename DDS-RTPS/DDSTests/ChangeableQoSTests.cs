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

namespace DDSTests
{
    [TestClass]
    public class ChangeableQoSTests
    {
        [TestMethod]
        public void UserDataDomainsDisable01()
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
        public void UserDataDomainsDisable02()
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
        public void UserDataDomainsEnable01()
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
        public void UserDataDomainsEnable02()
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
        public void UserDataDataReader01()
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
        
    }
}
