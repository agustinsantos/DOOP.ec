using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Doopec.XTypes;
using org.omg.dds.type.typeobject;
using Doopec.Dds.XTypes;

namespace DDSTests.XTypes
{
    [TestClass]
    public class TypeExplorerTest
    {
        #region ENUM TESTS
        [TestMethod]
        public void TestExploreMyEnum()
        {
            var exploredType = TypeExplorer.ExploreType(typeof(MyEnum));

            Assert.IsTrue(exploredType is EnumerationTypeImpl);
            EnumerationType enumType = exploredType as EnumerationType;

            Assert.IsNotNull(enumType.GetProperty());
            Assert.AreEqual("DDSTests.XTypes.MyEnum", enumType.GetProperty().Name);
            Assert.AreEqual(32, enumType.BitBound);
            Assert.IsNotNull(enumType.Constants);
            Assert.AreEqual(6, enumType.Constants.Count);
            Assert.AreEqual("Zero", enumType.Constants[0].Name);
            Assert.AreEqual(0, enumType.Constants[0].Value);
            Assert.AreEqual("Five", enumType.Constants[5].Name);
            Assert.AreEqual(5, enumType.Constants[5].Value);
        }
        #endregion

        #region ANNOTATE ENUM TESTS
        [TestMethod]
        public void TestExploreMyAnnotatedEnum()
        {
            var exploredType = TypeExplorer.ExploreType(typeof(MyAnnotatedEnum));

            Assert.IsTrue(exploredType is EnumerationTypeImpl);
            EnumerationType enumType = exploredType as EnumerationType;

            Assert.IsNotNull(enumType.GetProperty());
            Assert.AreEqual("DDSTests.XTypes.MyAnnotatedEnum", enumType.GetProperty().Name);
            Assert.AreEqual(16, enumType.BitBound);
            Assert.IsNotNull(enumType.Constants);
            Assert.AreEqual(6, enumType.Constants.Count);
            Assert.AreEqual("Zero", enumType.Constants[0].Name);
            Assert.AreEqual(0, enumType.Constants[0].Value);
            Assert.AreEqual("Five", enumType.Constants[5].Name);
            Assert.AreEqual(5, enumType.Constants[5].Value);
        }
        #endregion

        #region SEALED CLASS TESTS
        [TestMethod]
        public void TestExploreBoolSealedClass()
        {
            var exploredType = TypeExplorer.ExploreType(typeof(BoolSealedClass));

            Assert.IsTrue(exploredType is StructureType);
            StructureType classType = exploredType as StructureType;
            Assert.IsNotNull(classType.GetProperty());
            Assert.AreEqual("DDSTests.XTypes.BoolSealedClass", classType.GetProperty().Name);
            Assert.IsNotNull(classType.GetMember());
            Assert.AreEqual(1, classType.GetMember().Count);
            Assert.AreEqual("m_val", classType.GetMember()[0].GetProperty().Name);
        }
        #endregion

        #region NON SEALED CLASS TESTS
        [TestMethod]
        public void TestExploreBoolClass()
        {
            var exploredType = TypeExplorer.ExploreType(typeof(BoolClass));

            Assert.IsTrue(exploredType is StructureType);
            StructureType classType = exploredType as StructureType;
            Assert.IsNotNull(classType.GetProperty());
            Assert.AreEqual("DDSTests.XTypes.BoolClass", classType.GetProperty().Name);
            Assert.IsNotNull(classType.GetMember());
            Assert.AreEqual(1, classType.GetMember().Count);
            Assert.AreEqual("m_val", classType.GetMember()[0].GetProperty().Name);
        }
        #endregion

        #region ANNOTATED CLASS TESTS PrimitivesAnnotatedClass
        [TestMethod]
        public void TestExploreBoolAnnotatedClass()
        {
            var exploredType = TypeExplorer.ExploreType(typeof(BoolAnnotatedClass));

            Assert.IsTrue(exploredType is StructureType);
            StructureType classType = exploredType as StructureType;
            Assert.IsNotNull(classType.GetProperty());
            Assert.AreEqual("DDSTests.XTypes.BoolAnnotatedClass", classType.GetProperty().Name);
            Assert.IsNotNull(classType.GetMember());
            Assert.AreEqual(1, classType.GetMember().Count);
            Assert.AreEqual("m_val", classType.GetMember()[0].GetProperty().Name);
            Assert.AreEqual(0x0010, classType.GetMember()[0].GetProperty().MemberId);
        }

        [TestMethod]
        public void TestExplorePrimitivesAnnotatedClass()
        {
            var exploredType = TypeExplorer.ExploreType(typeof(PrimitivesAnnotatedClass));

            Assert.IsTrue(exploredType is StructureType);
            StructureType classType = exploredType as StructureType;
            Assert.IsNotNull(classType.GetProperty());
            Assert.AreEqual("DDSTests.XTypes.PrimitivesAnnotatedClass", classType.GetProperty().Name);
            Assert.IsNotNull(classType.GetMember());
            Assert.AreEqual(12, classType.GetMember().Count);
            Assert.AreEqual("m_bool", classType.GetMember()[0].GetProperty().Name);
            Assert.AreEqual("m_char", classType.GetMember()[1].GetProperty().Name);
            Assert.AreEqual("m_byte", classType.GetMember()[2].GetProperty().Name);
            Assert.AreEqual("m_ushort", classType.GetMember()[3].GetProperty().Name);
            Assert.AreEqual("m_uint", classType.GetMember()[4].GetProperty().Name);
            Assert.AreEqual("m_ulong", classType.GetMember()[5].GetProperty().Name);
            Assert.AreEqual("m_sbyte", classType.GetMember()[6].GetProperty().Name);
            Assert.AreEqual("m_short", classType.GetMember()[7].GetProperty().Name);
            Assert.AreEqual("m_int", classType.GetMember()[8].GetProperty().Name);
            Assert.AreEqual("m_long", classType.GetMember()[9].GetProperty().Name);
            Assert.AreEqual("m_single", classType.GetMember()[10].GetProperty().Name);
            Assert.AreEqual("m_double", classType.GetMember()[11].GetProperty().Name);
            
            Assert.AreEqual(0x0010, classType.GetMember()[0].GetProperty().MemberId);
            Assert.AreEqual(0x0011, classType.GetMember()[1].GetProperty().MemberId);
            Assert.AreEqual(0x0012, classType.GetMember()[2].GetProperty().MemberId);
            Assert.AreEqual(0x0013, classType.GetMember()[3].GetProperty().MemberId);
            Assert.AreEqual(0x0014, classType.GetMember()[4].GetProperty().MemberId);
            Assert.AreEqual(0x0015, classType.GetMember()[5].GetProperty().MemberId);
            Assert.AreEqual(0x0016, classType.GetMember()[6].GetProperty().MemberId);
            Assert.AreEqual(0x0017, classType.GetMember()[7].GetProperty().MemberId);
            Assert.AreEqual(0x0018, classType.GetMember()[8].GetProperty().MemberId);
            Assert.AreEqual(0x0019, classType.GetMember()[9].GetProperty().MemberId);
            Assert.AreEqual(0x001A, classType.GetMember()[10].GetProperty().MemberId);
            Assert.AreEqual(0x001B, classType.GetMember()[11].GetProperty().MemberId);

            Assert.AreEqual(false, classType.GetMember()[0].GetProperty().Flag.IsKey());
            Assert.AreEqual(false, classType.GetMember()[1].GetProperty().Flag.IsKey());
            Assert.AreEqual(false, classType.GetMember()[2].GetProperty().Flag.IsKey());
            Assert.AreEqual(false, classType.GetMember()[3].GetProperty().Flag.IsKey());
            Assert.AreEqual(true, classType.GetMember()[4].GetProperty().Flag.IsKey());
            Assert.AreEqual(true, classType.GetMember()[5].GetProperty().Flag.IsKey());
            Assert.AreEqual(false, classType.GetMember()[6].GetProperty().Flag.IsKey());
            Assert.AreEqual(false, classType.GetMember()[7].GetProperty().Flag.IsKey());
            Assert.AreEqual(false, classType.GetMember()[8].GetProperty().Flag.IsKey());
            Assert.AreEqual(false, classType.GetMember()[9].GetProperty().Flag.IsKey());
            Assert.AreEqual(false, classType.GetMember()[10].GetProperty().Flag.IsKey());
            Assert.AreEqual(false, classType.GetMember()[11].GetProperty().Flag.IsKey());

            Assert.AreEqual(true, classType.GetMember()[0].GetProperty().Flag.IsOptional());
            Assert.AreEqual(true, classType.GetMember()[1].GetProperty().Flag.IsOptional());
            Assert.AreEqual(false, classType.GetMember()[2].GetProperty().Flag.IsOptional());
            Assert.AreEqual(false, classType.GetMember()[3].GetProperty().Flag.IsOptional());
            Assert.AreEqual(false, classType.GetMember()[4].GetProperty().Flag.IsOptional());
            Assert.AreEqual(false, classType.GetMember()[5].GetProperty().Flag.IsOptional());
            Assert.AreEqual(false, classType.GetMember()[6].GetProperty().Flag.IsOptional());
            Assert.AreEqual(false, classType.GetMember()[7].GetProperty().Flag.IsOptional());
            Assert.AreEqual(false, classType.GetMember()[8].GetProperty().Flag.IsOptional());
            Assert.AreEqual(false, classType.GetMember()[9].GetProperty().Flag.IsOptional());
            Assert.AreEqual(false, classType.GetMember()[10].GetProperty().Flag.IsOptional());
            Assert.AreEqual(false, classType.GetMember()[11].GetProperty().Flag.IsOptional());
        }
        #endregion
    }
}
