using SAS.Public.Def.Container;
using System.Text;

namespace ZTests.SAS.Public.Def_Tests.Container
{
    [TestClass]
    public class RWDataReferences
    {
        [TestMethod]
        public void RW_data_String()
        {
            var template = Model_Template.ReferencesTemplate.StringSamples;
            var dataWriter = new DataWriter();
            foreach (var item in template)
            {
                dataWriter.Add(item);
            }

            var dataReader = new DataReader(dataWriter.ToBytes());
            foreach (var item in template)
            {
                Assert.AreEqual(item, dataReader.ReadString());
            }
        }

        [TestMethod]
        public void RW_data_String_Length()
        {
            var dataWriter = new DataWriter();
            dataWriter.Add(null, 5);
            dataWriter.Add("", 5);
            dataWriter.Add("123", 5);
            dataWriter.Add("12345", 5);
            dataWriter.Add("12345678", 5);

            var dataReader = new DataReader(dataWriter.ToBytes());
            Assert.AreEqual(null, dataReader.ReadString());
            Assert.AreEqual("", dataReader.ReadString());
            Assert.AreEqual("123", dataReader.ReadString());
            Assert.AreEqual("12345", dataReader.ReadString());
            Assert.AreEqual("12345", dataReader.ReadString());
        }

        [TestMethod]
        public void RW_data_String_Unicode()
        {
            var template = Model_Template.ReferencesTemplate.StringUnicodeSamples;
            var dataWriter = new DataWriter();
            foreach (var item in template)
            {
                dataWriter.Add(item, Encoding.UTF32);
            }

            var dataReader = new DataReader(dataWriter.ToBytes());
            foreach (var item in template)
            {
                Assert.AreEqual(item, dataReader.ReadString(Encoding.UTF32));
            }
        }

        [TestMethod]
        public void RW_data_String_Length_Unicode()
        {
            var dataWriter = new DataWriter();
            dataWriter.Add(null, 5, Encoding.UTF32);
            dataWriter.Add("", 5, Encoding.UTF32);
            dataWriter.Add("¢£¤", 5, Encoding.UTF32);
            dataWriter.Add("ϭϱ©ª«", 5, Encoding.UTF32);
            dataWriter.Add("ʢʤʨϫϭϱ©ª«®µ¶", 5, Encoding.UTF32);

            var dataReader = new DataReader(dataWriter.ToBytes());
            Assert.AreEqual(null, dataReader.ReadString(Encoding.UTF32));
            Assert.AreEqual("", dataReader.ReadString(Encoding.UTF32));
            Assert.AreEqual("¢£¤", dataReader.ReadString(Encoding.UTF32));
            Assert.AreEqual("ϭϱ©ª«", dataReader.ReadString(Encoding.UTF32));
            Assert.AreEqual("ʢʤʨϫϭ", dataReader.ReadString(Encoding.UTF32));
        }

        [TestMethod]
        public void RW_data_DateTime()
        {
            var template = Model_Template.ReferencesTemplate.DateTimeSamples;
            var dataWriter = new DataWriter();
            foreach (var item in template)
            {
                dataWriter.Add(item);
            }

            var dataReader = new DataReader(dataWriter.ToBytes());
            foreach (var item in template)
            {
                Assert.AreEqual(item, dataReader.ReadDateTime());
            }
        }

        [TestMethod]
        public void RW_data_Guid()
        {
            var template = Model_Template.ReferencesTemplate.GuidSamples;
            var dataWriter = new DataWriter();
            foreach (var item in template)
            {
                dataWriter.Add(item);
            }

            var dataReader = new DataReader(dataWriter.ToBytes());
            foreach (var item in template)
            {
                Assert.AreEqual(item, dataReader.ReadGuid());
            }
        }
    }
}
