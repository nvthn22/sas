using SAS.Public.Def.Convert;
using SAS.Public.Def.Data;
using SAS.Public.Def.Extensions;
using ZTests.SAS.Public.Model_Value;

namespace ZTests.SAS.Public.Def_Tests.Extensions
{
    [TestClass]
    public class PropsCompareClass
    {
        [TestMethod]
        public void Props_fill_min()
        {
            var value = new MembersValue();
            DataRandom.Instance.FillMembersMin(value);

            var bytes = DataConvert.Instance.ToBytes(value);
            var rended = DataConvert.Instance.ToClass<MembersValue>(bytes);
            var compare = MembersCompare.Compare(value, rended);

            Assert.IsTrue(compare.IsEqual);
        }

        [TestMethod]
        public void Props_fill_max()
        {
            var value = new MembersValue();
            DataRandom.Instance.FillMembersMax(value);

            var bytes = DataConvert.Instance.ToBytes(value);
            var rended = DataConvert.Instance.ToClass<MembersValue>(bytes);
            var compare = MembersCompare.Compare(value, rended);

            Assert.IsTrue(compare.IsEqual);
        }

        [TestMethod]
        public void Props_fill_random()
        {
            var value = new MembersValue();
            DataRandom.Instance.FillMembersRandom(value);

            var bytes = DataConvert.Instance.ToBytes(value);
            var rended = DataConvert.Instance.ToClass<MembersValue>(bytes);
            var compare = MembersCompare.Compare(value, rended);

            Assert.IsTrue(compare.IsEqual);
        }
    }
}
