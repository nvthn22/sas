using SAS.Public.Def.Container;

namespace ZTests.SAS.Public.Def_Tests.Container
{
    [TestClass]
    public class RWDataTypes
    {
        [TestMethod]
        public void RW_data_mbool()
        {
            var template = Model_Template.TypesTemplate.TypesValueRandom;
            var dataWriter = new DataWriter();
            dataWriter.Add(template.mbool);

            var dataReader = new DataReader(dataWriter.ToBytes());
            Assert.AreEqual(template.mbool, dataReader.ReadBoolean());
        }

        [TestMethod]
        public void RW_data_mbyte()
        {
            var template = Model_Template.TypesTemplate.TypesValueRandom;
            var dataWriter = new DataWriter();
            dataWriter.Add(template.mbyte);

            var dataReader = new DataReader(dataWriter.ToBytes());
            Assert.AreEqual(template.mbyte, dataReader.ReadByte());
        }

        [TestMethod]
        public void RW_data_msbyte()
        {
            var template = Model_Template.TypesTemplate.TypesValueRandom;
            var dataWriter = new DataWriter();
            dataWriter.Add(template.msbyte);

            var dataReader = new DataReader(dataWriter.ToBytes());
            Assert.AreEqual(template.msbyte, dataReader.ReadSByte());
        }

        [TestMethod]
        public void RW_data_mchar()
        {
            var template = Model_Template.TypesTemplate.TypesValueRandom;
            var dataWriter = new DataWriter();
            dataWriter.Add(template.mchar);

            var dataReader = new DataReader(dataWriter.ToBytes());
            Assert.AreEqual(template.mchar, dataReader.ReadChar());
        }

        [TestMethod]
        public void RW_data_mdecimal()
        {
            var template = Model_Template.TypesTemplate.TypesValueRandom;
            var dataWriter = new DataWriter();
            dataWriter.Add(template.mdecimal);

            var dataReader = new DataReader(dataWriter.ToBytes());
            Assert.AreEqual(template.mdecimal, dataReader.ReadDecimal());
        }

        [TestMethod]
        public void RW_data_mdouble()
        {
            var template = Model_Template.TypesTemplate.TypesValueRandom;
            var dataWriter = new DataWriter();
            dataWriter.Add(template.mdouble);

            var dataReader = new DataReader(dataWriter.ToBytes());
            Assert.AreEqual(template.mdouble, dataReader.ReadDouble());
        }

        [TestMethod]
        public void RW_data_mfloat()
        {
            var template = Model_Template.TypesTemplate.TypesValueRandom;
            var dataWriter = new DataWriter();
            dataWriter.Add(template.mfloat);

            var dataReader = new DataReader(dataWriter.ToBytes());
            Assert.AreEqual(template.mfloat, dataReader.ReadFloat());
        }

        [TestMethod]
        public void RW_data_mint()
        {
            var template = Model_Template.TypesTemplate.TypesValueRandom;
            var dataWriter = new DataWriter();
            dataWriter.Add(template.mint);

            var dataReader = new DataReader(dataWriter.ToBytes());
            Assert.AreEqual(template.mint, dataReader.ReadInt());
        }

        [TestMethod]
        public void RW_data_muint()
        {
            var template = Model_Template.TypesTemplate.TypesValueRandom;
            var dataWriter = new DataWriter();
            dataWriter.Add(template.muint);

            var dataReader = new DataReader(dataWriter.ToBytes());
            Assert.AreEqual(template.muint, dataReader.ReadUInt());
        }

        [TestMethod]
        public void RW_data_mlong()
        {
            var template = Model_Template.TypesTemplate.TypesValueRandom;
            var dataWriter = new DataWriter();
            dataWriter.Add(template.mlong);

            var dataReader = new DataReader(dataWriter.ToBytes());
            Assert.AreEqual(template.mlong, dataReader.ReadLong());
        }

        [TestMethod]
        public void RW_data_mshort()
        {
            var template = Model_Template.TypesTemplate.TypesValueRandom;
            var dataWriter = new DataWriter();
            dataWriter.Add(template.mshort);

            var dataReader = new DataReader(dataWriter.ToBytes());
            Assert.AreEqual(template.mshort, dataReader.ReadShort());
        }

        [TestMethod]
        public void RW_data_mushort()
        {
            var template = Model_Template.TypesTemplate.TypesValueRandom;
            var dataWriter = new DataWriter();
            dataWriter.Add(template.mushort);

            var dataReader = new DataReader(dataWriter.ToBytes());
            Assert.AreEqual(template.mushort, dataReader.ReadUShort());
        }

        [TestMethod]
        public void RW_data_types()
        {
            var template = Model_Template.TypesTemplate.TypesValueRandom;
            var dataWriter = new DataWriter();
            dataWriter.Add(template.mbool);
            dataWriter.Add(template.mbyte);
            dataWriter.Add(template.msbyte);
            dataWriter.Add(template.mchar);
            dataWriter.Add(template.mdecimal);
            dataWriter.Add(template.mdouble);
            dataWriter.Add(template.mfloat);
            dataWriter.Add(template.mint);
            dataWriter.Add(template.muint);
            dataWriter.Add(template.mlong);
            dataWriter.Add(template.mshort);
            dataWriter.Add(template.mushort);

            var dataReader = new DataReader(dataWriter.ToBytes());
            Assert.AreEqual(template.mbool, dataReader.ReadBoolean());
            Assert.AreEqual(template.mbyte, dataReader.ReadByte());
            Assert.AreEqual(template.msbyte, dataReader.ReadSByte());
            Assert.AreEqual(template.mchar, dataReader.ReadChar());
            Assert.AreEqual(template.mdecimal, dataReader.ReadDecimal());
            Assert.AreEqual(template.mdouble, dataReader.ReadDouble());
            Assert.AreEqual(template.mfloat, dataReader.ReadFloat());
            Assert.AreEqual(template.mint, dataReader.ReadInt());
            Assert.AreEqual(template.muint, dataReader.ReadUInt());
            Assert.AreEqual(template.mlong, dataReader.ReadLong());
            Assert.AreEqual(template.mshort, dataReader.ReadShort());
            Assert.AreEqual(template.mushort, dataReader.ReadUShort());
        }
    }
}
