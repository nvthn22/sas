using SAS.Public.Def.Container.v2;

namespace SAS.Public.Def.Convert.v2
{
    public class DataNullableConvert
    {
        public static DataNullableConvert Instance = new DataNullableConvert();
        protected DataNullableConvert() { }

        public byte[] ToBytes<T>(T? o) where T : class
        {
            var writer = new DataNullableWriter();

            writer.AddFlag(o != null);
            if (o == null)
            {
                return writer.ToBytes();
            }

            var members = DataTypes.Instance.CheckMembers<T>();
            foreach (var member in members)
            {
                var value = member.GetValue(o);

                writer.AddFlag(value != null);
                if (value == null) continue;

                switch (member.TypeFullName)
                {
                    // 1
                    case DataNames.FullName_Boolean: writer.Add((bool)value!); break;
                    case DataNames.FullName_Byte: writer.Add((byte)value!); break;
                    case DataNames.FullName_SByte: writer.Add((sbyte)value!); break;

                    // 2
                    case DataNames.FullName_Char: writer.Add((char)value!); break;
                    case DataNames.FullName_Int16: writer.Add((short)value!); break;
                    case DataNames.FullName_UInt16: writer.Add((ushort)value!); break;

                    // 4
                    case DataNames.FullName_Int32: writer.Add((int)value!); break;
                    case DataNames.FullName_UInt32: writer.Add((uint)value!); break;
                    case DataNames.FullName_Single: writer.Add((float)value!); break;

                    // 8
                    case DataNames.FullName_Double: writer.Add((double)value!); break;
                    case DataNames.FullName_Int64: writer.Add((long)value!); break;

                    // 16
                    case DataNames.FullName_Decimal: writer.Add((decimal)value!); break;

                    // ref
                    case DataNames.FullName_String: writer.Add((string?)value); break;
                    case DataNames.FullName_DateTime: writer.Add((DateTime?)value); break;
                    case DataNames.FullName_Guid: writer.Add((Guid?)value); break;

                    default: break;
                }
            }

            return writer.ToBytes();
        }

        public T? ToClass<T>(byte[] bytes) where T : class, new()
        {
            var reader = new DataNullableReader(bytes);
            if (!reader.ReadFlag())
            {
                return null;
            }

            var result = new T();
            var members = DataTypes.Instance.CheckMembers<T>();

            foreach (var member in members)
            {
                if (!reader.ReadFlag())
                {
                    member.SetValue(result, null);
                    continue;
                }

                switch (member.TypeFullName)
                {
                    // 1
                    case DataNames.FullName_Boolean: member.SetValue(result, reader.ReadBoolean()); break;
                    case DataNames.FullName_Byte: member.SetValue(result, reader.ReadByte()); break;
                    case DataNames.FullName_SByte: member.SetValue(result, reader.ReadSByte()); break;

                    // 2
                    case DataNames.FullName_Char: member.SetValue(result, reader.ReadChar()); break;
                    case DataNames.FullName_Int16: member.SetValue(result, reader.ReadShort()); break;
                    case DataNames.FullName_UInt16: member.SetValue(result, reader.ReadUShort()); break;

                    // 4
                    case DataNames.FullName_Int32: member.SetValue(result, reader.ReadInt()); break;
                    case DataNames.FullName_UInt32: member.SetValue(result, reader.ReadUInt()); break;
                    case DataNames.FullName_Single: member.SetValue(result, reader.ReadFloat()); break;

                    // 8
                    case DataNames.FullName_Double: member.SetValue(result, reader.ReadDouble()); break;
                    case DataNames.FullName_Int64: member.SetValue(result, reader.ReadLong()); break;

                    // 16
                    case DataNames.FullName_Decimal: member.SetValue(result, reader.ReadDecimal()); break;

                    // ref
                    case DataNames.FullName_String: member.SetValue(result, reader.ReadString()); break;
                    case DataNames.FullName_DateTime: member.SetValue(result, reader.ReadDateTime()); break;
                    case DataNames.FullName_Guid: member.SetValue(result, reader.ReadGuid()); break;

                    default: break;
                }
            }

            return result;
        }
    }
}
