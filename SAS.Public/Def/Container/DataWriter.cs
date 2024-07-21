using System.Text;

namespace SAS.Public.Def.Container
{
    public class DataWriter
    {
        private int dataLen = 0;
        private ICollection<byte[]> dataContainer = new List<byte[]>();

        private int flagCurrent;
        private int flagIndex = 0;
        private int flagTotal = 0;
        private ICollection<byte> flagContainer = new List<byte>();

        // Data types
        public void Add(bool data)
        {
            AddFlag(data == true);
        }

        public void Add(byte data)
        {
            dataLen += sizeof(byte);
            dataContainer.Add([data]);
        }

        public void Add(sbyte data)
        {
            dataLen += sizeof(byte);
            dataContainer.Add([(byte)data]);
        }

        public void Add(short data)
        {
            dataLen += sizeof(short);
            dataContainer.Add(BitConverter.GetBytes(data));
        }

        public void Add(ushort data)
        {
            dataLen += sizeof(ushort);
            dataContainer.Add(BitConverter.GetBytes(data));
        }

        public void Add(char data)
        {
            dataLen += sizeof(char);
            dataContainer.Add(BitConverter.GetBytes(data));
        }

        public void Add(int data)
        {
            dataLen += sizeof(int);
            dataContainer.Add(BitConverter.GetBytes(data));
        }

        public void Add(uint data)
        {
            dataLen += sizeof(uint);
            dataContainer.Add(BitConverter.GetBytes(data));
        }

        public void Add(float data)
        {
            dataLen += sizeof(float);
            dataContainer.Add(BitConverter.GetBytes(data));
        }

        public void Add(double data)
        {
            dataLen += sizeof(double);
            dataContainer.Add(BitConverter.GetBytes(data));
        }

        public void Add(nint data)
        {
            throw new NotImplementedException();
        }

        public void Add(long data)
        {
            dataLen += sizeof(long);
            dataContainer.Add(BitConverter.GetBytes(data));
        }

        public void Add(decimal data)
        {
            dataLen += sizeof(decimal);
            var ints = decimal.GetBits(data);
            foreach (var i in ints)
            {
                dataContainer.Add(BitConverter.GetBytes(i));
            }
        }

        // End Data types

        // Nullable types
        public void Add(string? str, Encoding? encoding = null)
        {
            AddFlag(str != null);

            if (str != null)
            {
                AddFlag(str.Length > 0);
                if (str.Length > 0)
                {
                    var _encoding = encoding ?? Encoding.UTF8;
                    var data = _encoding.GetBytes(str);

                    Add(data.Length);
                    dataContainer.Add(data);
                }
            }
        }

        public void Add(string? str, int strLength, Encoding? encoding = null)
        {
            AddFlag(str != null);

            if (str != null)
            {
                AddFlag(str.Length > 0);
                if (str.Length > 0)
                {
                    var _encoding = encoding ?? Encoding.UTF8;
                    var substring = str.Length <= strLength ? str : str.Substring(0, strLength);
                    var data = _encoding.GetBytes(substring);

                    Add(data.Length);
                    dataContainer.Add(data);
                }
            }
        }

        public void Add(Guid? guid)
        {
            AddFlag(guid != null);

            if (guid != null)
            {
                AddFlag(true);
                dataLen += 16;
                dataContainer.Add(guid?.ToByteArray()!);
            }
        }

        public void Add(DateTime? datetime)
        {
            AddFlag(datetime != null);

            if (datetime != null)
            {
                long datetimeNum = datetime?.ToBinary() ?? 0;
                dataLen += sizeof(long);
                dataContainer.Add(BitConverter.GetBytes(datetimeNum));
            }
        }
        // End Nullable types

        // Flags setting
        public void AddFlag(bool flag)
        {
            if (flag)
            {
                flagCurrent |= 1 << flagIndex;
            }
            flagIndex++;
            flagTotal++;

            if (flagIndex >= 8)
            {
                flagContainer.Add((byte)flagCurrent);
                flagCurrent = 0;
                flagIndex = 0;
            }
        }

        public void AddOption(byte option)
        {
            Add(option);
        }
        // End Flags setting

        // Functions
        /// <summary>
        /// Format [byte flagByteLength, byte... flags, int dataByteLength, byte... data]
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            // Commit flagCurrent
            if (flagTotal % 8 > 0)
            {
                flagContainer.Add((byte)flagCurrent);
            }
            // End Commit flagCurrent

            byte[] flagGroupAsBytes = [(byte)flagContainer.Count];
            var lengthAsBytes = BitConverter.GetBytes(dataLen);

            var bytes = flagGroupAsBytes
                .Concat(flagContainer.AsEnumerable())
                .Concat(lengthAsBytes)
                .Concat(dataContainer.SelectMany(item => item.AsEnumerable()));

            return bytes.ToArray();
        }
        // End Functions
    }
}
