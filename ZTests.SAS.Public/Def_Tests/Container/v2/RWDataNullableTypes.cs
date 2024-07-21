using SAS.Public.Def.Container.v2;
using ZTests.SAS.Public.Model_Template.v2;
using ZTests.SAS.Public.Model_Value.v2;

namespace ZTests.SAS.Public.Def_Tests.Container.v2
{
    [TestClass]
    public class RWDataNullableTypes
    {

        [TestMethod]
        public void RW_data_nullable_mbool()
        {
            MembersNullableValue[] templates = [
                MembersNullableTemplate.MembersNullableValueNull,
                MembersNullableTemplate.MembersNullableValueRandom,
            ];

            foreach (var template in templates)
            {
                var dataWriter = new DataNullableWriter();
                dataWriter.AddNullable(template.mbool);

                var dataReader = new DataNullableReader(dataWriter.ToBytes());
                Assert.AreEqual(template.mbool, dataReader.ReadNullableBoolean());
            }
        }

        [TestMethod]
        public void RW_data_nullable_mbyte()
        {
            MembersNullableValue[] templates = [
                MembersNullableTemplate.MembersNullableValueNull,
                MembersNullableTemplate.MembersNullableValueRandom,
            ];

            foreach (var template in templates)
            {
                var dataWriter = new DataNullableWriter();
                dataWriter.AddNullable(template.mbyte);

                var dataReader = new DataNullableReader(dataWriter.ToBytes());
                Assert.AreEqual(template.mbyte, dataReader.ReadNullableByte());
            }
        }

        [TestMethod]
        public void RW_data_nullable_msbyte()
        {
            MembersNullableValue[] templates = [
                MembersNullableTemplate.MembersNullableValueNull,
                MembersNullableTemplate.MembersNullableValueRandom,
            ];

            foreach (var template in templates)
            {
                var dataWriter = new DataNullableWriter();
                dataWriter.AddNullable(template.msbyte);

                var dataReader = new DataNullableReader(dataWriter.ToBytes());
                Assert.AreEqual(template.msbyte, dataReader.ReadNullableSByte());
            }
        }

        [TestMethod]
        public void RW_data_nullable_mchar()
        {
            MembersNullableValue[] templates = [
                MembersNullableTemplate.MembersNullableValueNull,
                MembersNullableTemplate.MembersNullableValueRandom,
            ];

            foreach (var template in templates)
            {
                var dataWriter = new DataNullableWriter();
                dataWriter.AddNullable(template.mchar);

                var dataReader = new DataNullableReader(dataWriter.ToBytes());
                Assert.AreEqual(template.mchar, dataReader.ReadNullableChar());
            }
        }

        [TestMethod]
        public void RW_data_nullable_mshort()
        {
            MembersNullableValue[] templates = [
                MembersNullableTemplate.MembersNullableValueNull,
                MembersNullableTemplate.MembersNullableValueRandom,
            ];

            foreach (var template in templates)
            {
                var dataWriter = new DataNullableWriter();
                dataWriter.AddNullable(template.mshort);

                var dataReader = new DataNullableReader(dataWriter.ToBytes());
                Assert.AreEqual(template.mshort, dataReader.ReadNullableShort());
            }
        }

        [TestMethod]
        public void RW_data_nullable_mushort()
        {
            MembersNullableValue[] templates = [
                MembersNullableTemplate.MembersNullableValueNull,
                MembersNullableTemplate.MembersNullableValueRandom,
            ];

            foreach (var template in templates)
            {
                var dataWriter = new DataNullableWriter();
                dataWriter.AddNullable(template.mushort);

                var dataReader = new DataNullableReader(dataWriter.ToBytes());
                Assert.AreEqual(template.mushort, dataReader.ReadNullableUShort());
            }
        }

        [TestMethod]
        public void RW_data_nullable_mint()
        {
            MembersNullableValue[] templates = [
                MembersNullableTemplate.MembersNullableValueNull,
                MembersNullableTemplate.MembersNullableValueRandom,
            ];

            foreach (var template in templates)
            {
                var dataWriter = new DataNullableWriter();
                dataWriter.AddNullable(template.mint);

                var dataReader = new DataNullableReader(dataWriter.ToBytes());
                Assert.AreEqual(template.mint, dataReader.ReadNullableInt());
            }
        }

        [TestMethod]
        public void RW_data_nullable_muint()
        {
            MembersNullableValue[] templates = [
                MembersNullableTemplate.MembersNullableValueNull,
                MembersNullableTemplate.MembersNullableValueRandom,
            ];

            foreach (var template in templates)
            {
                var dataWriter = new DataNullableWriter();
                dataWriter.AddNullable(template.muint);

                var dataReader = new DataNullableReader(dataWriter.ToBytes());
                Assert.AreEqual(template.muint, dataReader.ReadNullableUInt());
            }
        }

        [TestMethod]
        public void RW_data_nullable_mfloat()
        {
            MembersNullableValue[] templates = [
                MembersNullableTemplate.MembersNullableValueNull,
                MembersNullableTemplate.MembersNullableValueRandom,
            ];

            foreach (var template in templates)
            {
                var dataWriter = new DataNullableWriter();
                dataWriter.AddNullable(template.mfloat);

                var dataReader = new DataNullableReader(dataWriter.ToBytes());
                Assert.AreEqual(template.mfloat, dataReader.ReadNullableFloat());
            }
        }

        [TestMethod]
        public void RW_data_nullable_mdouble()
        {
            MembersNullableValue[] templates = [
                MembersNullableTemplate.MembersNullableValueNull,
                MembersNullableTemplate.MembersNullableValueRandom,
            ];

            foreach (var template in templates)
            {
                var dataWriter = new DataNullableWriter();
                dataWriter.AddNullable(template.mdouble);

                var dataReader = new DataNullableReader(dataWriter.ToBytes());
                Assert.AreEqual(template.mdouble, dataReader.ReadNullableDouble());
            }
        }

        [TestMethod]
        public void RW_data_nullable_mlong()
        {
            MembersNullableValue[] templates = [
                MembersNullableTemplate.MembersNullableValueNull,
                MembersNullableTemplate.MembersNullableValueRandom,
            ];

            foreach (var template in templates)
            {
                var dataWriter = new DataNullableWriter();
                dataWriter.AddNullable(template.mlong);

                var dataReader = new DataNullableReader(dataWriter.ToBytes());
                Assert.AreEqual(template.mlong, dataReader.ReadNullableLong());
            }
        }

        [TestMethod]
        public void RW_data_nullable_mdecimal()
        {
            MembersNullableValue[] templates = [
                MembersNullableTemplate.MembersNullableValueNull,
                MembersNullableTemplate.MembersNullableValueRandom,
            ];

            foreach (var template in templates)
            {
                var dataWriter = new DataNullableWriter();
                dataWriter.AddNullable(template.mdecimal);

                var dataReader = new DataNullableReader(dataWriter.ToBytes());
                Assert.AreEqual(template.mdecimal, dataReader.ReadNullableDecimal());
            }
        }
    }
}
