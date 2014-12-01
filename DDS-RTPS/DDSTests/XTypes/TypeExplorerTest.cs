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

            Assert.IsNotNull(enumType.getProperty());
            Assert.AreEqual("DDSTests.XTypes.MyEnum", enumType.getProperty().getName());
            Assert.AreEqual(32, enumType.getBitBound());
            Assert.IsNotNull(enumType.getConstant());
            Assert.AreEqual(6, enumType.getConstant().Count);
            Assert.AreEqual("Zero", enumType.getConstant()[0].getName());
            Assert.AreEqual(0, enumType.getConstant()[0].getValue());
            Assert.AreEqual("Five", enumType.getConstant()[5].getName());
            Assert.AreEqual(5, enumType.getConstant()[5].getValue());
        }
        #endregion

        #region ANNOTATE ENUM TESTS
        [TestMethod]
        public void TestExploreMyAnnotatedEnum()
        {
            var exploredType = TypeExplorer.ExploreType(typeof(MyAnnotatedEnum));

            Assert.IsTrue(exploredType is EnumerationTypeImpl);
            EnumerationType enumType = exploredType as EnumerationType;

            Assert.IsNotNull(enumType.getProperty());
            Assert.AreEqual("DDSTests.XTypes.MyAnnotatedEnum", enumType.getProperty().getName());
            Assert.AreEqual(16, enumType.getBitBound());
            Assert.IsNotNull(enumType.getConstant());
            Assert.AreEqual(6, enumType.getConstant().Count);
            Assert.AreEqual("Zero", enumType.getConstant()[0].getName());
            Assert.AreEqual(0, enumType.getConstant()[0].getValue());
            Assert.AreEqual("Five", enumType.getConstant()[5].getName());
            Assert.AreEqual(5, enumType.getConstant()[5].getValue());
        }
        #endregion

        #region SEALED CLASS TESTS
        [TestMethod]
        public void TestExploreBoolSealedClass()
        {
            var exploredType = TypeExplorer.ExploreType(typeof(BoolSealedClass));

            Assert.IsTrue(exploredType is StructureType);
            StructureType classType = exploredType as StructureType;
            Assert.IsNotNull(classType.getProperty());
            Assert.AreEqual("DDSTests.XTypes.BoolSealedClass", classType.getProperty().getName());
            Assert.IsNotNull(classType.GetMember());
            Assert.AreEqual(1, classType.GetMember().Count);
            Assert.AreEqual("m_val", classType.GetMember()[0].getProperty().getName());
        }
        #endregion

        #region NON SEALED CLASS TESTS
        [TestMethod]
        public void TestExploreBoolClass()
        {
            var exploredType = TypeExplorer.ExploreType(typeof(BoolClass));

            Assert.IsTrue(exploredType is StructureType);
            StructureType classType = exploredType as StructureType;
            Assert.IsNotNull(classType.getProperty());
            Assert.AreEqual("DDSTests.XTypes.BoolClass", classType.getProperty().getName());
            Assert.IsNotNull(classType.GetMember());
            Assert.AreEqual(1, classType.GetMember().Count);
            Assert.AreEqual("m_val", classType.GetMember()[0].getProperty().getName());
        }
        #endregion

        #region ANNOTATED CLASS TESTS PrimitivesAnnotatedClass
        [TestMethod]
        public void TestExploreBoolAnnotatedClass()
        {
            var exploredType = TypeExplorer.ExploreType(typeof(BoolAnnotatedClass));

            Assert.IsTrue(exploredType is StructureType);
            StructureType classType = exploredType as StructureType;
            Assert.IsNotNull(classType.getProperty());
            Assert.AreEqual("DDSTests.XTypes.BoolAnnotatedClass", classType.getProperty().getName());
            Assert.IsNotNull(classType.GetMember());
            Assert.AreEqual(1, classType.GetMember().Count);
            Assert.AreEqual("m_val", classType.GetMember()[0].getProperty().getName());
            Assert.AreEqual(0x0010, classType.GetMember()[0].getProperty().getMemberId());
        }

        [TestMethod]
        public void TestExplorePrimitivesAnnotatedClass()
        {
            var exploredType = TypeExplorer.ExploreType(typeof(PrimitivesAnnotatedClass));

            Assert.IsTrue(exploredType is StructureType);
            StructureType classType = exploredType as StructureType;
            Assert.IsNotNull(classType.getProperty());
            Assert.AreEqual("DDSTests.XTypes.PrimitivesAnnotatedClass", classType.getProperty().getName());
            Assert.IsNotNull(classType.GetMember());
            Assert.AreEqual(12, classType.GetMember().Count);
            Assert.AreEqual("m_bool", classType.GetMember()[0].getProperty().getName());
            Assert.AreEqual("m_char", classType.GetMember()[1].getProperty().getName());
            Assert.AreEqual("m_byte", classType.GetMember()[2].getProperty().getName());
            Assert.AreEqual("m_ushort", classType.GetMember()[3].getProperty().getName());
            Assert.AreEqual("m_uint", classType.GetMember()[4].getProperty().getName());
            Assert.AreEqual("m_ulong", classType.GetMember()[5].getProperty().getName());
            Assert.AreEqual("m_sbyte", classType.GetMember()[6].getProperty().getName());
            Assert.AreEqual("m_short", classType.GetMember()[7].getProperty().getName());
            Assert.AreEqual("m_int", classType.GetMember()[8].getProperty().getName());
            Assert.AreEqual("m_long", classType.GetMember()[9].getProperty().getName());
            Assert.AreEqual("m_single", classType.GetMember()[10].getProperty().getName());
            Assert.AreEqual("m_double", classType.GetMember()[11].getProperty().getName());
            
            Assert.AreEqual(0x0010, classType.GetMember()[0].getProperty().getMemberId());
            Assert.AreEqual(0x0011, classType.GetMember()[1].getProperty().getMemberId());
            Assert.AreEqual(0x0012, classType.GetMember()[2].getProperty().getMemberId());
            Assert.AreEqual(0x0013, classType.GetMember()[3].getProperty().getMemberId());
            Assert.AreEqual(0x0014, classType.GetMember()[4].getProperty().getMemberId());
            Assert.AreEqual(0x0015, classType.GetMember()[5].getProperty().getMemberId());
            Assert.AreEqual(0x0016, classType.GetMember()[6].getProperty().getMemberId());
            Assert.AreEqual(0x0017, classType.GetMember()[7].getProperty().getMemberId());
            Assert.AreEqual(0x0018, classType.GetMember()[8].getProperty().getMemberId());
            Assert.AreEqual(0x0019, classType.GetMember()[9].getProperty().getMemberId());
            Assert.AreEqual(0x001A, classType.GetMember()[10].getProperty().getMemberId());
            Assert.AreEqual(0x001B, classType.GetMember()[11].getProperty().getMemberId());

            Assert.AreEqual(false, classType.GetMember()[0].getProperty().getFlag().IsKey());
            Assert.AreEqual(false, classType.GetMember()[1].getProperty().getFlag().IsKey());
            Assert.AreEqual(false, classType.GetMember()[2].getProperty().getFlag().IsKey());
            Assert.AreEqual(false, classType.GetMember()[3].getProperty().getFlag().IsKey());
            Assert.AreEqual(true, classType.GetMember()[4].getProperty().getFlag().IsKey());
            Assert.AreEqual(true, classType.GetMember()[5].getProperty().getFlag().IsKey());
            Assert.AreEqual(false, classType.GetMember()[6].getProperty().getFlag().IsKey());
            Assert.AreEqual(false, classType.GetMember()[7].getProperty().getFlag().IsKey());
            Assert.AreEqual(false, classType.GetMember()[8].getProperty().getFlag().IsKey());
            Assert.AreEqual(false, classType.GetMember()[9].getProperty().getFlag().IsKey());
            Assert.AreEqual(false, classType.GetMember()[10].getProperty().getFlag().IsKey());
            Assert.AreEqual(false, classType.GetMember()[11].getProperty().getFlag().IsKey());

            Assert.AreEqual(true, classType.GetMember()[0].getProperty().getFlag().IsOptional());
            Assert.AreEqual(true, classType.GetMember()[1].getProperty().getFlag().IsOptional());
            Assert.AreEqual(false, classType.GetMember()[2].getProperty().getFlag().IsOptional());
            Assert.AreEqual(false, classType.GetMember()[3].getProperty().getFlag().IsOptional());
            Assert.AreEqual(false, classType.GetMember()[4].getProperty().getFlag().IsOptional());
            Assert.AreEqual(false, classType.GetMember()[5].getProperty().getFlag().IsOptional());
            Assert.AreEqual(false, classType.GetMember()[6].getProperty().getFlag().IsOptional());
            Assert.AreEqual(false, classType.GetMember()[7].getProperty().getFlag().IsOptional());
            Assert.AreEqual(false, classType.GetMember()[8].getProperty().getFlag().IsOptional());
            Assert.AreEqual(false, classType.GetMember()[9].getProperty().getFlag().IsOptional());
            Assert.AreEqual(false, classType.GetMember()[10].getProperty().getFlag().IsOptional());
            Assert.AreEqual(false, classType.GetMember()[11].getProperty().getFlag().IsOptional());
        }
        #endregion
    }
}
