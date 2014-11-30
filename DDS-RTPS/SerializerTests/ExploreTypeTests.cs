using Doopec.Serializer;
using Doopec.Serializer.Attributes;
using Doopec.XTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using org.omg.dds.type.typeobject;
using System.Linq;

namespace SerializerTests
{
    [TestClass]
    public class ExploreTypeTests
    {
        [TestInitialize]
        public void SetUp()
        {
            var rootTypes = typeof(U8Packet).Assembly.GetTypes().Where(t => PacketAttribute.IsCompatible(t)).ToArray();

            ITypeSerializer[] customSerializers = new ITypeSerializer[0];

            Serializer.Initialize(rootTypes, customSerializers);
        }

        /// <summary>
        /// There is a suite of tests in DDS tests project.
        /// This test is just to check that classes with annotations are annotated 
        /// acordingly for the serialization.
        /// </summary>
        [TestMethod]
        public void TestExploreMyClass1()
        {
            var ddsType = TypeExplorer.ExploreType(typeof(XMyClass1));
            Assert.IsNotNull(ddsType);

            Assert.IsNotNull(ddsType.getProperty());
            var propInfo = ddsType.getProperty();
            Assert.AreEqual("SerializerTests.XMyClass1", propInfo.Name);

            Assert.IsInstanceOfType(ddsType, typeof(StructureType));
            StructureType structType = ddsType as StructureType;
            var members = structType.GetMember();
            Assert.IsNotNull(members);
            Assert.AreEqual(3, members.Count);
            Assert.AreEqual("m_byte", members[0].getProperty().Name);
            Assert.AreEqual("m_int", members[1].getProperty().Name);
            Assert.AreEqual("m_short", members[2].getProperty().Name);

            Assert.AreEqual((uint)0x8001, members[0].getProperty().MemberId);
            Assert.AreEqual((uint)0x8002, members[1].getProperty().MemberId);
            Assert.AreEqual((uint)0x8003, members[2].getProperty().MemberId);
        }
    }
}
