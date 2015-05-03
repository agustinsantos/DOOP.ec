using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Doopec.XTypes;
using org.omg.dds.topic;
using org.omg.dds.type.typeobject;
using Doopec.Dds.Domain;
using System.Linq;
using Doopec.Serializer.Attributes;
using Doopec.Serializer;
using Mina.Core.Buffer;
using Doopec.Rtps.Messages;
using Rtps.Discovery.Spdp;
using Rtps.Structure;
using Doopec.Rtps.Structure;

namespace SerializerTests
{
    [TestClass]
    public class BuiltinTopicTests
    {
        [TestInitialize]
        public void SetUp()
        {
            List<System.Type> rootTypes = new List<System.Type>();
            rootTypes.Add(typeof(ParticipantBuiltinTopicData));

            ITypeSerializer[] customSerializers = new ITypeSerializer[0];
            
            Serializer.Initialize(rootTypes, customSerializers);
        }
        private const int headerSize = 4 + 4; //including length
        private const int paramHeaderSize = 4;
        private const int paramSentinelSize = 4;
        private const int byteBoundary = 4;

        [TestMethod]
        public void TestParticipantBuiltinTopicData()
        {
            var ddsType = TypeExplorer.ExploreType(typeof(ParticipantBuiltinTopicData));
            Assert.IsNotNull(ddsType);
            Assert.IsNotNull(ddsType.GetProperty());
            var propInfo = ddsType.GetProperty();
            Assert.AreEqual("org.omg.dds.topic.ParticipantBuiltinTopicData", propInfo.Name);

            Assert.IsInstanceOfType(ddsType, typeof(StructureType));
            StructureType structType = ddsType as StructureType;
            var members = structType.GetMember();
            Assert.IsNotNull(members);
            Assert.AreEqual(2, members.Count);
            Assert.AreEqual("Key", members[0].GetProperty().Name);
            Assert.AreEqual("UserData", members[1].GetProperty().Name);

            Assert.AreEqual((uint)0x0050, members[0].GetProperty().MemberId);
            Assert.AreEqual((uint)0x002C, members[1].GetProperty().MemberId);
        }

        [TestMethod]
        public void TestSerializeParticipantBuiltinTopicData()
        {
            Participant participant = new ParticipantImpl(0, 0);
            SPDPdiscoveredParticipantData v1 = new SPDPdiscoveredParticipantData(participant);
            int expectedSize = headerSize + paramHeaderSize + byteBoundary + paramSentinelSize;
            string expectedRst = "00 03 00 00 0C 00 00 00 " + // Header 
                                 "00 80 04 00 01 00 00 00 " + // Parameter
                                 "01 00 00 00";               // Sentinel
            var buffer = ByteBufferAllocator.Instance.Allocate(expectedSize);
            ParameterListEncapsulation.Serialize(buffer, v1, ByteOrder.LittleEndian);
            Assert.AreEqual(expectedSize, buffer.Position);

            buffer.Rewind();
            Assert.AreEqual(expectedRst, buffer.GetHexDump(expectedSize));
            SPDPdiscoveredParticipantData v2 = ParameterListEncapsulation.Deserialize<SPDPdiscoveredParticipantData>(buffer);
            Assert.AreEqual(v1, v2);
            Assert.AreEqual(expectedSize, buffer.Position);
        }

        [TestMethod]
        public void TestPublicationBuiltinTopicData()
        {
            var ddsType = TypeExplorer.ExploreType(typeof(PublicationBuiltinTopicData));
            Assert.IsNotNull(ddsType);
            Assert.IsNotNull(ddsType.GetProperty());
            var propInfo = ddsType.GetProperty();
            Assert.AreEqual("org.omg.dds.topic.PublicationBuiltinTopicData", propInfo.Name);

            Assert.IsInstanceOfType(ddsType, typeof(StructureType));
            StructureType structType = ddsType as StructureType;
            var members = structType.GetMember();
            Assert.IsNotNull(members);
            Assert.AreEqual(24, members.Count);
            Assert.AreEqual("Key", members[0].GetProperty().Name);
            Assert.AreEqual("ParticipantKey", members[1].GetProperty().Name);
            Assert.AreEqual("TopicName", members[2].GetProperty().Name);
            Assert.AreEqual("TypeName", members[3].GetProperty().Name);
            Assert.AreEqual("EquivalentTypeName", members[4].GetProperty().Name);
            Assert.AreEqual("BaseTypeName", members[5].GetProperty().Name);
            Assert.AreEqual("Type", members[6].GetProperty().Name);
            Assert.AreEqual("Durability", members[7].GetProperty().Name);
            Assert.AreEqual("DurabilityService", members[8].GetProperty().Name);
            Assert.AreEqual("Deadline", members[9].GetProperty().Name);
            Assert.AreEqual("LatencyBudget", members[10].GetProperty().Name);
            Assert.AreEqual("Liveliness", members[11].GetProperty().Name);
            Assert.AreEqual("Reliability", members[12].GetProperty().Name);
            Assert.AreEqual("Lifespan", members[13].GetProperty().Name);
            Assert.AreEqual("UserData", members[14].GetProperty().Name);
            Assert.AreEqual("Ownership", members[15].GetProperty().Name);
            Assert.AreEqual("OwnershipStrength", members[16].GetProperty().Name);
            Assert.AreEqual("DestinationOrder", members[17].GetProperty().Name);
            Assert.AreEqual("Presentation", members[18].GetProperty().Name);
            Assert.AreEqual("Partition", members[19].GetProperty().Name);
            Assert.AreEqual("TopicData", members[20].GetProperty().Name);
            Assert.AreEqual("GroupData", members[21].GetProperty().Name);
            Assert.AreEqual("Representation", members[22].GetProperty().Name);
            Assert.AreEqual("TypeConsistency", members[23].GetProperty().Name);

            Assert.AreEqual((uint)0x005A, members[0].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0050, members[1].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0005, members[2].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0007, members[3].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0075, members[4].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0076, members[5].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0072, members[6].GetProperty().MemberId);
            Assert.AreEqual((uint)0x001D, members[7].GetProperty().MemberId);
            Assert.AreEqual((uint)0x001E, members[8].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0023, members[9].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0027, members[10].GetProperty().MemberId);
            Assert.AreEqual((uint)0x001B, members[11].GetProperty().MemberId);
            Assert.AreEqual((uint)0x001A, members[12].GetProperty().MemberId);
            Assert.AreEqual((uint)0x002B, members[13].GetProperty().MemberId);
            Assert.AreEqual((uint)0x002C, members[14].GetProperty().MemberId);
            Assert.AreEqual((uint)0x001F, members[15].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0006, members[16].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0025, members[17].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0021, members[18].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0029, members[19].GetProperty().MemberId);
            Assert.AreEqual((uint)0x002E, members[20].GetProperty().MemberId);
            Assert.AreEqual((uint)0x002D, members[21].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0073, members[22].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0074, members[23].GetProperty().MemberId);
        }

        [TestMethod]
        public void TestSubscriptionBuiltinTopicData()
        {
            var ddsType = TypeExplorer.ExploreType(typeof(SubscriptionBuiltinTopicData));
            Assert.IsNotNull(ddsType);
            Assert.IsNotNull(ddsType.GetProperty());
            var propInfo = ddsType.GetProperty();
            Assert.AreEqual("org.omg.dds.topic.SubscriptionBuiltinTopicData", propInfo.Name);

            Assert.IsInstanceOfType(ddsType, typeof(StructureType));
            StructureType structType = ddsType as StructureType;
            var members = structType.GetMember();
            Assert.IsNotNull(members);
            Assert.AreEqual(22, members.Count);
            Assert.AreEqual("Key", members[0].GetProperty().Name);
            Assert.AreEqual("ParticipantKey", members[1].GetProperty().Name);
            Assert.AreEqual("TopicName", members[2].GetProperty().Name);
            Assert.AreEqual("TypeName", members[3].GetProperty().Name);
            Assert.AreEqual("EquivalentTypeName", members[4].GetProperty().Name);
            Assert.AreEqual("BaseTypeName", members[5].GetProperty().Name);
            Assert.AreEqual("Type", members[6].GetProperty().Name);
            Assert.AreEqual("Durability", members[7].GetProperty().Name);
            Assert.AreEqual("Deadline", members[8].GetProperty().Name);
            Assert.AreEqual("LatencyBudget", members[9].GetProperty().Name);
            Assert.AreEqual("Liveliness", members[10].GetProperty().Name);
            Assert.AreEqual("Reliability", members[11].GetProperty().Name);
            Assert.AreEqual("Ownership", members[12].GetProperty().Name);
            Assert.AreEqual("DestinationOrder", members[13].GetProperty().Name);
            Assert.AreEqual("UserData", members[14].GetProperty().Name);
            Assert.AreEqual("TimeBasedFilter", members[15].GetProperty().Name);
            Assert.AreEqual("Presentation", members[16].GetProperty().Name);
            Assert.AreEqual("Partition", members[17].GetProperty().Name);
            Assert.AreEqual("TopicData", members[18].GetProperty().Name);
            Assert.AreEqual("GroupData", members[19].GetProperty().Name);
            Assert.AreEqual("Representation", members[20].GetProperty().Name);
            Assert.AreEqual("TypeConsistency", members[21].GetProperty().Name);

            Assert.AreEqual((uint)0x005A, members[0].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0050, members[1].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0005, members[2].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0007, members[3].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0075, members[4].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0076, members[5].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0072, members[6].GetProperty().MemberId);
            Assert.AreEqual((uint)0x001D, members[7].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0023, members[8].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0027, members[9].GetProperty().MemberId);
            Assert.AreEqual((uint)0x001B, members[10].GetProperty().MemberId);
            Assert.AreEqual((uint)0x001A, members[11].GetProperty().MemberId);
            Assert.AreEqual((uint)0x001F, members[12].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0025, members[13].GetProperty().MemberId);
            Assert.AreEqual((uint)0x002C, members[14].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0004, members[15].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0021, members[16].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0029, members[17].GetProperty().MemberId);
            Assert.AreEqual((uint)0x002E, members[18].GetProperty().MemberId);
            Assert.AreEqual((uint)0x002D, members[19].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0073, members[20].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0074, members[21].GetProperty().MemberId);
        }

        [TestMethod]
        public void TestTopicBuiltinTopicData()
        {
            var ddsType = TypeExplorer.ExploreType(typeof(TopicBuiltinTopicData));
            Assert.IsNotNull(ddsType);
            Assert.IsNotNull(ddsType.GetProperty());
            var propInfo = ddsType.GetProperty();
            Assert.AreEqual("org.omg.dds.topic.TopicBuiltinTopicData", propInfo.Name);

            Assert.IsInstanceOfType(ddsType, typeof(StructureType));
            StructureType structType = ddsType as StructureType;
            var members = structType.GetMember();
            Assert.IsNotNull(members);
            Assert.AreEqual(21, members.Count);
            Assert.AreEqual("Key", members[0].GetProperty().Name);
            Assert.AreEqual("Name", members[1].GetProperty().Name);
            Assert.AreEqual("TypeName", members[2].GetProperty().Name);
            Assert.AreEqual("EquivalentTypeName", members[3].GetProperty().Name);
            Assert.AreEqual("BaseTypeName", members[4].GetProperty().Name);
            Assert.AreEqual("Type", members[5].GetProperty().Name);
            Assert.AreEqual("Durability", members[6].GetProperty().Name);
            Assert.AreEqual("DurabilityService", members[7].GetProperty().Name);
            Assert.AreEqual("Deadline", members[8].GetProperty().Name);
            Assert.AreEqual("LatencyBudget", members[9].GetProperty().Name);
            Assert.AreEqual("Liveliness", members[10].GetProperty().Name);
            Assert.AreEqual("Reliability", members[11].GetProperty().Name);
            Assert.AreEqual("TransportPriority", members[12].GetProperty().Name);
            Assert.AreEqual("Lifespan", members[13].GetProperty().Name);
            Assert.AreEqual("DestinationOrder", members[14].GetProperty().Name);
            Assert.AreEqual("History", members[15].GetProperty().Name);
            Assert.AreEqual("ResourceLimits", members[16].GetProperty().Name);
            Assert.AreEqual("Ownership", members[17].GetProperty().Name);
            Assert.AreEqual("TopicData", members[18].GetProperty().Name);
            Assert.AreEqual("Representation", members[19].GetProperty().Name);
            Assert.AreEqual("TypeConsistency", members[20].GetProperty().Name);


            Assert.AreEqual((uint)0x005A, members[0].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0005, members[1].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0007, members[2].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0075, members[3].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0076, members[4].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0072, members[5].GetProperty().MemberId);
            Assert.AreEqual((uint)0x001D, members[6].GetProperty().MemberId);
            Assert.AreEqual((uint)0x001E, members[7].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0023, members[8].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0027, members[9].GetProperty().MemberId);
            Assert.AreEqual((uint)0x001B, members[10].GetProperty().MemberId);
            Assert.AreEqual((uint)0x001A, members[11].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0049, members[12].GetProperty().MemberId);
            Assert.AreEqual((uint)0x002B, members[13].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0025, members[14].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0040, members[15].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0041, members[16].GetProperty().MemberId);
            Assert.AreEqual((uint)0x001F, members[17].GetProperty().MemberId);
            Assert.AreEqual((uint)0x002E, members[18].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0073, members[19].GetProperty().MemberId);
            Assert.AreEqual((uint)0x0074, members[20].GetProperty().MemberId);
        }
    }
}
