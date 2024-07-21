using System.Security.Cryptography;

namespace SAS.Public.Def.Data
{
    public class DataCrypto
    {
        public static byte[] Encrypt(byte[] data, byte[] key, byte[] iv)
        {
            using var encryptAlgorithm = Aes.Create();
            encryptAlgorithm.Key = key;
            encryptAlgorithm.IV = iv;
            var encryptor = encryptAlgorithm.CreateEncryptor();

            using (var stream = new MemoryStream())
            {
                using (var encryptStream = new CryptoStream(stream, encryptor, CryptoStreamMode.Write))
                {
                    encryptStream.Write(data, 0, data.Length);

                    encryptStream.Close();
                    stream.Close();

                    return stream.ToArray();
                }
            }
        }

        public static byte[] Decrypt(byte[] data, byte[] key, byte[] iv)
        {
            using var encryptAlgorithm = Aes.Create();
            encryptAlgorithm.Key = key;
            encryptAlgorithm.IV = iv;
            var decryptor = encryptAlgorithm.CreateDecryptor();

            using (var plaindata = new MemoryStream())
            {
                using (var stream = new MemoryStream(data))
                {
                    using (var decryptStream = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
                    {
                        decryptStream.CopyTo(plaindata);

                        decryptStream.Close();
                        stream.Close();
                        plaindata.Close();

                        return plaindata.ToArray();
                    }
                }
            }
        }

        public static byte[] RandomBytes(int length)
        {
            return RandomNumberGenerator.GetBytes(length);
        }
    }
}
