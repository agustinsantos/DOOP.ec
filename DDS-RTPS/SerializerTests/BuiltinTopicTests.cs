using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Doopec.XTypes;
using org.omg.dds.topic;
using org.omg.dds.type.typeobject;

namespace SerializerTests
{
    [TestClass]
    public class BuiltinTopicTests
    {
        [TestMethod]
        public void TestParticipantBuiltinTopicData()
        {
            var ddsType = TypeExplorer.ExploreType(typeof(ParticipantBuiltinTopicData));
            Assert.IsNotNull(ddsType);
            Assert.IsNotNull(ddsType.getProperty());
            var propInfo = ddsType.getProperty();
            Assert.AreEqual("org.omg.dds.topic.ParticipantBuiltinTopicData", propInfo.Name);

            Assert.IsInstanceOfType(ddsType, typeof(StructureType));
            StructureType structType = ddsType as StructureType;
            var members = structType.GetMember();
            Assert.IsNotNull(members);
            Assert.AreEqual(2, members.Count);
            Assert.AreEqual("Key", members[0].getProperty().Name);
            Assert.AreEqual("UserData", members[1].getProperty().Name);

            Assert.AreEqual((uint)0x0050, members[0].getProperty().MemberId);
            Assert.AreEqual((uint)0x002C, members[1].getProperty().MemberId);
        }

        [TestMethod]
        public void TestPublicationBuiltinTopicData()
        {
            var ddsType = TypeExplorer.ExploreType(typeof(PublicationBuiltinTopicData));
            Assert.IsNotNull(ddsType);
            Assert.IsNotNull(ddsType.getProperty());
            var propInfo = ddsType.getProperty();
            Assert.AreEqual("org.omg.dds.topic.PublicationBuiltinTopicData", propInfo.Name);

            Assert.IsInstanceOfType(ddsType, typeof(StructureType));
            StructureType structType = ddsType as StructureType;
            var members = structType.GetMember();
            Assert.IsNotNull(members);
            Assert.AreEqual(24, members.Count);
            Assert.AreEqual("Key", members[0].getProperty().Name);
            Assert.AreEqual("ParticipantKey", members[1].getProperty().Name);
            Assert.AreEqual("TopicName", members[2].getProperty().Name);
            Assert.AreEqual("TypeName", members[3].getProperty().Name);
            Assert.AreEqual("EquivalentTypeName", members[4].getProperty().Name);
            Assert.AreEqual("BaseTypeName", members[5].getProperty().Name);
            Assert.AreEqual("Type", members[6].getProperty().Name);
            Assert.AreEqual("Durability", members[7].getProperty().Name);
            Assert.AreEqual("DurabilityService", members[8].getProperty().Name);
            Assert.AreEqual("Deadline", members[9].getProperty().Name);
            Assert.AreEqual("LatencyBudget", members[10].getProperty().Name);
            Assert.AreEqual("Liveliness", members[11].getProperty().Name);
            Assert.AreEqual("Reliability", members[12].getProperty().Name);
            Assert.AreEqual("Lifespan", members[13].getProperty().Name);
            Assert.AreEqual("UserData", members[14].getProperty().Name);
            Assert.AreEqual("Ownership", members[15].getProperty().Name);
            Assert.AreEqual("OwnershipStrength", members[16].getProperty().Name);
            Assert.AreEqual("DestinationOrder", members[17].getProperty().Name);
            Assert.AreEqual("Presentation", members[18].getProperty().Name);
            Assert.AreEqual("Partition", members[19].getProperty().Name);
            Assert.AreEqual("TopicData", members[20].getProperty().Name);
            Assert.AreEqual("GroupData", members[21].getProperty().Name);
            Assert.AreEqual("Representation", members[22].getProperty().Name);
            Assert.AreEqual("TypeConsistency", members[23].getProperty().Name);

            Assert.AreEqual((uint)0x005A, members[0].getProperty().MemberId);
            Assert.AreEqual((uint)0x0050, members[1].getProperty().MemberId);
            Assert.AreEqual((uint)0x0005, members[2].getProperty().MemberId);
            Assert.AreEqual((uint)0x0007, members[3].getProperty().MemberId);
            Assert.AreEqual((uint)0x0075, members[4].getProperty().MemberId);
            Assert.AreEqual((uint)0x0076, members[5].getProperty().MemberId);
            Assert.AreEqual((uint)0x0072, members[6].getProperty().MemberId);
            Assert.AreEqual((uint)0x001D, members[7].getProperty().MemberId);
            Assert.AreEqual((uint)0x001E, members[8].getProperty().MemberId);
            Assert.AreEqual((uint)0x0023, members[9].getProperty().MemberId);
            Assert.AreEqual((uint)0x0027, members[10].getProperty().MemberId);
            Assert.AreEqual((uint)0x001B, members[11].getProperty().MemberId);
            Assert.AreEqual((uint)0x001A, members[12].getProperty().MemberId);
            Assert.AreEqual((uint)0x002B, members[13].getProperty().MemberId);
            Assert.AreEqual((uint)0x002C, members[14].getProperty().MemberId);
            Assert.AreEqual((uint)0x001F, members[15].getProperty().MemberId);
            Assert.AreEqual((uint)0x0006, members[16].getProperty().MemberId);
            Assert.AreEqual((uint)0x0025, members[17].getProperty().MemberId);
            Assert.AreEqual((uint)0x0021, members[18].getProperty().MemberId);
            Assert.AreEqual((uint)0x0029, members[19].getProperty().MemberId);
            Assert.AreEqual((uint)0x002E, members[20].getProperty().MemberId);
            Assert.AreEqual((uint)0x002D, members[21].getProperty().MemberId);
            Assert.AreEqual((uint)0x0073, members[22].getProperty().MemberId);
            Assert.AreEqual((uint)0x0074, members[23].getProperty().MemberId);
        }

        [TestMethod]
        public void TestSubscriptionBuiltinTopicData()
        {
            var ddsType = TypeExplorer.ExploreType(typeof(SubscriptionBuiltinTopicData));
            Assert.IsNotNull(ddsType);
            Assert.IsNotNull(ddsType.getProperty());
            var propInfo = ddsType.getProperty();
            Assert.AreEqual("org.omg.dds.topic.SubscriptionBuiltinTopicData", propInfo.Name);

            Assert.IsInstanceOfType(ddsType, typeof(StructureType));
            StructureType structType = ddsType as StructureType;
            var members = structType.GetMember();
            Assert.IsNotNull(members);
            Assert.AreEqual(22, members.Count);
            Assert.AreEqual("Key", members[0].getProperty().Name);
            Assert.AreEqual("ParticipantKey", members[1].getProperty().Name);
            Assert.AreEqual("TopicName", members[2].getProperty().Name);
            Assert.AreEqual("TypeName", members[3].getProperty().Name);
            Assert.AreEqual("EquivalentTypeName", members[4].getProperty().Name);
            Assert.AreEqual("BaseTypeName", members[5].getProperty().Name);
            Assert.AreEqual("Type", members[6].getProperty().Name);
            Assert.AreEqual("Durability", members[7].getProperty().Name);
            Assert.AreEqual("Deadline", members[8].getProperty().Name);
            Assert.AreEqual("LatencyBudget", members[9].getProperty().Name);
            Assert.AreEqual("Liveliness", members[10].getProperty().Name);
            Assert.AreEqual("Reliability", members[11].getProperty().Name);
            Assert.AreEqual("Ownership", members[12].getProperty().Name);
            Assert.AreEqual("DestinationOrder", members[13].getProperty().Name);
            Assert.AreEqual("UserData", members[14].getProperty().Name);
            Assert.AreEqual("TimeBasedFilter", members[15].getProperty().Name);
            Assert.AreEqual("Presentation", members[16].getProperty().Name);
            Assert.AreEqual("Partition", members[17].getProperty().Name);
            Assert.AreEqual("TopicData", members[18].getProperty().Name);
            Assert.AreEqual("GroupData", members[19].getProperty().Name);
            Assert.AreEqual("Representation", members[20].getProperty().Name);
            Assert.AreEqual("TypeConsistency", members[21].getProperty().Name);

            Assert.AreEqual((uint)0x005A, members[0].getProperty().MemberId);
            Assert.AreEqual((uint)0x0050, members[1].getProperty().MemberId);
            Assert.AreEqual((uint)0x0005, members[2].getProperty().MemberId);
            Assert.AreEqual((uint)0x0007, members[3].getProperty().MemberId);
            Assert.AreEqual((uint)0x0075, members[4].getProperty().MemberId);
            Assert.AreEqual((uint)0x0076, members[5].getProperty().MemberId);
            Assert.AreEqual((uint)0x0072, members[6].getProperty().MemberId);
            Assert.AreEqual((uint)0x001D, members[7].getProperty().MemberId);
            Assert.AreEqual((uint)0x0023, members[8].getProperty().MemberId);
            Assert.AreEqual((uint)0x0027, members[9].getProperty().MemberId);
            Assert.AreEqual((uint)0x001B, members[10].getProperty().MemberId);
            Assert.AreEqual((uint)0x001A, members[11].getProperty().MemberId);
            Assert.AreEqual((uint)0x001F, members[12].getProperty().MemberId);
            Assert.AreEqual((uint)0x0025, members[13].getProperty().MemberId);
            Assert.AreEqual((uint)0x002C, members[14].getProperty().MemberId);
            Assert.AreEqual((uint)0x0004, members[15].getProperty().MemberId);
            Assert.AreEqual((uint)0x0021, members[16].getProperty().MemberId);
            Assert.AreEqual((uint)0x0029, members[17].getProperty().MemberId);
            Assert.AreEqual((uint)0x002E, members[18].getProperty().MemberId);
            Assert.AreEqual((uint)0x002D, members[19].getProperty().MemberId);
            Assert.AreEqual((uint)0x0073, members[20].getProperty().MemberId);
            Assert.AreEqual((uint)0x0074, members[21].getProperty().MemberId);
        }

        [TestMethod]
        public void TestTopicBuiltinTopicData()
        {
            var ddsType = TypeExplorer.ExploreType(typeof(TopicBuiltinTopicData));
            Assert.IsNotNull(ddsType);
            Assert.IsNotNull(ddsType.getProperty());
            var propInfo = ddsType.getProperty();
            Assert.AreEqual("org.omg.dds.topic.TopicBuiltinTopicData", propInfo.Name);

            Assert.IsInstanceOfType(ddsType, typeof(StructureType));
            StructureType structType = ddsType as StructureType;
            var members = structType.GetMember();
            Assert.IsNotNull(members);
            Assert.AreEqual(21, members.Count);
            Assert.AreEqual("Key", members[0].getProperty().Name);
            Assert.AreEqual("Name", members[1].getProperty().Name);
            Assert.AreEqual("TypeName", members[2].getProperty().Name);
            Assert.AreEqual("EquivalentTypeName", members[3].getProperty().Name);
            Assert.AreEqual("BaseTypeName", members[4].getProperty().Name);
            Assert.AreEqual("Type", members[5].getProperty().Name);
            Assert.AreEqual("Durability", members[6].getProperty().Name);
            Assert.AreEqual("DurabilityService", members[7].getProperty().Name);
            Assert.AreEqual("Deadline", members[8].getProperty().Name);
            Assert.AreEqual("LatencyBudget", members[9].getProperty().Name);
            Assert.AreEqual("Liveliness", members[10].getProperty().Name);
            Assert.AreEqual("Reliability", members[11].getProperty().Name);
            Assert.AreEqual("TransportPriority", members[12].getProperty().Name);
            Assert.AreEqual("Lifespan", members[13].getProperty().Name);
            Assert.AreEqual("DestinationOrder", members[14].getProperty().Name);
            Assert.AreEqual("History", members[15].getProperty().Name);
            Assert.AreEqual("ResourceLimits", members[16].getProperty().Name);
            Assert.AreEqual("Ownership", members[17].getProperty().Name);
            Assert.AreEqual("TopicData", members[18].getProperty().Name);
            Assert.AreEqual("Representation", members[19].getProperty().Name);
            Assert.AreEqual("TypeConsistency", members[20].getProperty().Name);


            Assert.AreEqual((uint)0x005A, members[0].getProperty().MemberId);
            Assert.AreEqual((uint)0x0005, members[1].getProperty().MemberId);
            Assert.AreEqual((uint)0x0007, members[2].getProperty().MemberId);
            Assert.AreEqual((uint)0x0075, members[3].getProperty().MemberId);
            Assert.AreEqual((uint)0x0076, members[4].getProperty().MemberId);
            Assert.AreEqual((uint)0x0072, members[5].getProperty().MemberId);
            Assert.AreEqual((uint)0x001D, members[6].getProperty().MemberId);
            Assert.AreEqual((uint)0x001E, members[7].getProperty().MemberId);
            Assert.AreEqual((uint)0x0023, members[8].getProperty().MemberId);
            Assert.AreEqual((uint)0x0027, members[9].getProperty().MemberId);
            Assert.AreEqual((uint)0x001B, members[10].getProperty().MemberId);
            Assert.AreEqual((uint)0x001A, members[11].getProperty().MemberId);
            Assert.AreEqual((uint)0x0049, members[12].getProperty().MemberId);
            Assert.AreEqual((uint)0x002B, members[13].getProperty().MemberId);
            Assert.AreEqual((uint)0x0025, members[14].getProperty().MemberId);
            Assert.AreEqual((uint)0x0040, members[15].getProperty().MemberId);
            Assert.AreEqual((uint)0x0041, members[16].getProperty().MemberId);
            Assert.AreEqual((uint)0x001F, members[17].getProperty().MemberId);
            Assert.AreEqual((uint)0x002E, members[18].getProperty().MemberId);
            Assert.AreEqual((uint)0x0073, members[19].getProperty().MemberId);
            Assert.AreEqual((uint)0x0074, members[20].getProperty().MemberId);
        }
    }
}
