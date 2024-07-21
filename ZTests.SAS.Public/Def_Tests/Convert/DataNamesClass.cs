using SAS.Public.Def.Convert;

namespace ZTests.SAS.Public.Def_Tests.Convert
{
    [TestClass]
    public class DataNamesClass
    {
        [TestMethod]
        public void Datatypes_const()
        {
            Assert.AreEqual(DataNames.FullName_Boolean, DataNames.GetTypeFullName<Boolean>());
            Assert.AreEqual(DataNames.FullName_Byte, DataNames.GetTypeFullName<Byte>());
            Assert.AreEqual(DataNames.FullName_SByte, DataNames.GetTypeFullName<SByte>());
            Assert.AreEqual(DataNames.FullName_Char, DataNames.GetTypeFullName<Char>());
            Assert.AreEqual(DataNames.FullName_Int16, DataNames.GetTypeFullName<Int16>());
            Assert.AreEqual(DataNames.FullName_UInt16, DataNames.GetTypeFullName<UInt16>());
            Assert.AreEqual(DataNames.FullName_Int32, DataNames.GetTypeFullName<Int32>());
            Assert.AreEqual(DataNames.FullName_UInt32, DataNames.GetTypeFullName<UInt32>());
            Assert.AreEqual(DataNames.FullName_Single, DataNames.GetTypeFullName<Single>());
            Assert.AreEqual(DataNames.FullName_Double, DataNames.GetTypeFullName<Double>());
            Assert.AreEqual(DataNames.FullName_Int64, DataNames.GetTypeFullName<Int64>());
            Assert.AreEqual(DataNames.FullName_Decimal, DataNames.GetTypeFullName<Decimal>());
            Assert.AreEqual(DataNames.FullName_String, DataNames.GetTypeFullName<String>());
            Assert.AreEqual(DataNames.FullName_DateTime, DataNames.GetTypeFullName<DateTime>());
            Assert.AreEqual(DataNames.FullName_Guid, DataNames.GetTypeFullName<Guid>());
            Assert.AreEqual(DataNames.Name_NulableGeneric, DataNames.GetTypeName<int?>());
        }
    }
}
