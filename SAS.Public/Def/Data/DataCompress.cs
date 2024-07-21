using System.IO.Compression;

namespace SAS.Public.Def.Data
{
    public class DataCompress
    {
        public static byte[] Compress(byte[] data)
        {
            using (var stream = new MemoryStream())
            {
                using (var compressStream = new GZipStream(stream, CompressionMode.Compress))
                {
                    compressStream.Write(data, 0, data.Length);
                    compressStream.Flush();
                    return stream.ToArray();
                }
            }
        }

        public static byte[] Decompress(byte[] data)
        {
            using (var stream = new MemoryStream())
            {
                using (var dataStream = new MemoryStream(data))
                {
                    using var decompressStream = new GZipStream(dataStream, CompressionMode.Decompress);
                    decompressStream.CopyTo(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}
