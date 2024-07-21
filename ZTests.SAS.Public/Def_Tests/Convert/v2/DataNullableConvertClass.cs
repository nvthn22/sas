using SAS.Public.Def.Convert.v2;
using ZTests.SAS.Public.Model_Template.v2;
using ZTests.SAS.Public.Model_Value.v2;

namespace ZTests.SAS.Public.Def_Tests.Convert.v2
{
    [TestClass]
    public class DataNullableConvertClass
    {
        [TestMethod]
        public void Class_member()
        {
            var template = MembersNullableTemplate.MembersNullableValueRandom;
            var bytes = DataNullableConvert.Instance.ToBytes(template);
            var output = DataNullableConvert.Instance.ToClass<MembersNullableValue>(bytes);

            Assert.AreEqual(template.mbool, output.mbool);
            Assert.AreEqual(template.mbyte, output.mbyte);
            Assert.AreEqual(template.msbyte, output.msbyte);
            Assert.AreEqual(template.mchar, output.mchar);
            Assert.AreEqual(template.mdecimal, output.mdecimal);
            Assert.AreEqual(template.mdouble, output.mdouble);
            Assert.AreEqual(template.mfloat, output.mfloat);
            Assert.AreEqual(template.mint, output.mint);
            Assert.AreEqual(template.muint, output.muint);
            Assert.AreEqual(template.mlong, output.mlong);
            Assert.AreEqual(template.mshort, output.mshort);
            Assert.AreEqual(template.mushort, output.mushort);
            Assert.AreEqual(template.mstring, output.mstring);
            Assert.AreEqual(template.mdatetime, output.mdatetime);
            Assert.AreEqual(template.mguid, output.mguid);
        }

        [TestMethod]
        public void Class_members_large()
        {
            for (var i = 0; i < 1_000_000; i++)
            {
                var template = MembersNullableTemplate.MembersNullableValueRandom;
                var bytes = DataNullableConvert.Instance.ToBytes(template);
                var output = DataNullableConvert.Instance.ToClass<MembersNullableValue>(bytes);

                Assert.AreEqual(template.mbool, output.mbool);
                Assert.AreEqual(template.mbyte, output.mbyte);
                Assert.AreEqual(template.msbyte, output.msbyte);
                Assert.AreEqual(template.mchar, output.mchar);
                Assert.AreEqual(template.mdecimal, output.mdecimal);
                Assert.AreEqual(template.mdouble, output.mdouble);
                Assert.AreEqual(template.mfloat, output.mfloat);
                Assert.AreEqual(template.mint, output.mint);
                Assert.AreEqual(template.muint, output.muint);
                Assert.AreEqual(template.mlong, output.mlong);
                Assert.AreEqual(template.mshort, output.mshort);
                Assert.AreEqual(template.mushort, output.mushort);
                Assert.AreEqual(template.mstring, output.mstring);
                Assert.AreEqual(template.mdatetime, output.mdatetime);
                Assert.AreEqual(template.mguid, output.mguid);
            }
        }
    }
}
