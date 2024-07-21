namespace SAS.Public.Def.Container.v2
{
    public class DataNullableReader : DataReader
    {
        public DataNullableReader(byte[] bytes) : base(bytes)
        {
        }

        // Nullable data types
        public bool? ReadNullableBoolean()
        {
            if (ReadFlag())
            {
                return ReadBoolean();
            }
            return null;
        }

        public byte? ReadNullableByte()
        {
            if (ReadFlag())
            {
                return ReadByte();
            }
            return null;
        }

        public sbyte? ReadNullableSByte()
        {
            if (ReadFlag())
            {
                return ReadSByte();
            }
            return null;
        }

        public char? ReadNullableChar()
        {
            if (ReadFlag())
            {
                return ReadChar();
            }
            return null;
        }

        public decimal? ReadNullableDecimal()
        {
            if (ReadFlag())
            {
                return ReadDecimal();
            }
            return null;
        }

        public double? ReadNullableDouble()
        {
            if (ReadFlag())
            {
                return ReadDouble();
            }
            return null;
        }

        public float? ReadNullableFloat()
        {
            if (ReadFlag())
            {
                return ReadFloat();
            }
            return null;
        }

        public int? ReadNullableInt()
        {
            if (ReadFlag())
            {
                return ReadInt();
            }
            return null;
        }

        public uint? ReadNullableUInt()
        {
            if (ReadFlag())
            {
                return ReadUInt();
            }
            return null;
        }

        public nint? ReadNullableNInt()
        {
            throw new NotImplementedException();
        }

        public long? ReadNullableLong()
        {
            if (ReadFlag())
            {
                return ReadLong();
            }
            return null;
        }

        public short? ReadNullableShort()
        {
            if (ReadFlag())
            {
                return ReadShort();
            }
            return null;
        }

        public ushort? ReadNullableUShort()
        {
            if (ReadFlag())
            {
                return ReadUShort();
            }
            return null;
        }
        // End Nullable data types
    }
}
