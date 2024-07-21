namespace SAS.Public.Def.Container.v2
{
    public class DataNullableWriter : DataWriter
    {
        // Nullable data types
        public void AddNullable(bool? data)
        {
            AddFlag(data != null);
            if (data != null)
            {
                AddFlag((bool)data);
            }
        }

        public void AddNullable(byte? data)
        {
            AddFlag(data != null);
            if (data != null)
            {
                Add((byte)data);
            }
        }

        public void AddNullable(sbyte? data)
        {
            AddFlag(data != null);
            if (data != null)
            {
                Add((sbyte)data);
            }
        }

        public void AddNullable(char? data)
        {
            AddFlag(data != null);
            if (data != null)
            {
                Add((char)data);
            }
        }

        public void AddNullable(decimal? data)
        {
            AddFlag(data != null);
            if (data != null)
            {
                Add((decimal)data);
            }
        }

        public void AddNullable(double? data)
        {
            AddFlag(data != null);
            if (data != null)
            {
                Add((double)data);

            }
        }

        public void AddNullable(float? data)
        {
            AddFlag(data != null);
            if (data != null)
            {
                Add((float)data);
            }
        }

        public void AddNullable(int? data)
        {
            AddFlag(data != null);
            if (data != null)
            {
                Add((int)data);
            }
        }

        public void AddNullable(uint? data)
        {
            AddFlag(data != null);
            if (data != null)
            {
                Add((uint)data);
            }
        }

        public void AddNullable(nint? data)
        {
            throw new NotImplementedException();
        }

        public void AddNullable(long? data)
        {
            AddFlag(data != null);
            if (data != null)
            {
                Add((long)data);
            }
        }

        public void AddNullable(short? data)
        {
            AddFlag(data != null);
            if (data != null)
            {
                Add((short)data);
            }
        }

        public void AddNullable(ushort? data)
        {
            AddFlag(data != null);
            if (data != null)
            {
                Add((ushort)data);
            }
        }
        // End Nullable data types
    }
}
