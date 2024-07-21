using System.Text;

namespace SAS.Public.Def.Container
{
    public class DataReader
    {
        // Data
        private byte[] buffer;
        // End Data

        // Data read
        private int flagLength;
        private int flagStart;
        private int flagIter;
        private int flagBitIndex;

        private int dataLength;
        private int dataStart;
        private int dataIter;
        // End Data read

        protected DataReader() { }
        public DataReader(byte[] bytes)
        {
            buffer = bytes;

            flagLength = buffer[0];
            flagStart = sizeof(byte);
            flagIter = flagStart;
            flagBitIndex = 0;

            dataLength = BitConverter.ToInt32(buffer, flagStart + flagLength);
            dataStart = flagStart + flagLength + sizeof(int);
            dataIter = dataStart;
        }

        // Data types
        public bool ReadBoolean()
        {
            var data = ReadFlag();
            return data;
        }

        public byte ReadByte()
        {
            var data = buffer[dataIter];
            dataIter += sizeof(byte);
            return data;
        }

        public sbyte ReadSByte()
        {
            var data = buffer[dataIter];
            dataIter += sizeof(byte);
            return (sbyte)data;
        }

        public short ReadShort()
        {
            var data = BitConverter.ToInt16(buffer, dataIter);
            dataIter += sizeof(short);
            return data;
        }

        public ushort ReadUShort()
        {
            var data = BitConverter.ToUInt16(buffer, dataIter);
            dataIter += sizeof(ushort);
            return data;
        }

        public char ReadChar()
        {
            var data = BitConverter.ToChar(buffer, dataIter);
            dataIter += sizeof(char);
            return data;
        }

        public int ReadInt()
        {
            var data = BitConverter.ToInt32(buffer, dataIter);
            dataIter += sizeof(int);
            return data;
        }

        public uint ReadUInt()
        {
            var data = BitConverter.ToUInt32(buffer, dataIter);
            dataIter += sizeof(uint);
            return data;
        }

        public double ReadDouble()
        {
            var data = BitConverter.ToDouble(buffer, dataIter);
            dataIter += sizeof(double);
            return data;
        }

        public float ReadFloat()
        {
            var data = BitConverter.ToSingle(buffer, dataIter);
            dataIter += sizeof(float);
            return data;
        }

        public nint ReadNInt()
        {
            throw new NotImplementedException();
        }

        public long ReadLong()
        {
            var data = BitConverter.ToInt64(buffer, dataIter);
            dataIter += sizeof(long);
            return data;
        }

        public decimal ReadDecimal()
        {
            var int1 = ReadInt();
            var int2 = ReadInt();
            var int3 = ReadInt();
            var int4 = ReadInt();
            var data = new decimal([int1, int2, int3, int4]);
            return data;
        }
        // End Data types

        // Nullable types
        public string? ReadString(Encoding? encoding = null)
        {
            if (ReadFlag())
            {
                if (ReadFlag())
                {
                    var byteLength = ReadInt();
                    var bytes = new ReadOnlySpan<byte>(buffer, dataIter, byteLength);
                    var _encoding = encoding ?? Encoding.UTF8;
                    var data = _encoding.GetString(bytes);
                    dataIter += byteLength;
                    return data;
                }
                return string.Empty;
            }
            return null;
        }

        public Guid? ReadGuid()
        {
            if (ReadFlag())
            {
                var bytes = new ReadOnlySpan<byte>(buffer, dataIter, 16);
                var data = new Guid(bytes);
                dataIter += 16;
                return data;
            }
            return null;
        }

        public DateTime? ReadDateTime()
        {
            if (ReadFlag())
            {
                var datetimeNum = ReadLong();
                var data = DateTime.FromBinary(datetimeNum);
                return data;
            }
            return null;
        }
        // End Nullable types

        // Flag setting
        public bool ReadFlag()
        {
            var flag = (buffer[flagIter] & 1 << flagBitIndex) == 0 ? false : true;
            flagBitIndex++;
            if (flagBitIndex >= 8)
            {
                flagBitIndex = 0;
                flagIter++;
            }
            return flag;
        }

        public byte ReadOption()
        {
            return ReadByte();
        }
        // End Flag setting
    }
}
