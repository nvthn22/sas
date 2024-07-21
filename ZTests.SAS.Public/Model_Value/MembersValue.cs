namespace ZTests.SAS.Public.Model_Value
{
    public class MembersValue
    {
        public bool mbool;
        public byte mbyte;
        public sbyte msbyte;
        public char mchar;
        public decimal mdecimal { get; set; }
        public double mdouble { get; set; }
        public float mfloat { get; set; }
        public int mint { get; set; }
        public uint muint { get; set; }
        public long mlong { get; set; }
        public short mshort { get; set; }
        public ushort mushort { get; set; }
        
        public string? mstring { get; set; }
        public DateTime? mdatetime { get; set; }
        public Guid? mguid { get; set; }
    }
}
