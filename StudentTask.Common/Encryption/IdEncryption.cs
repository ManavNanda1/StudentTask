using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class EncryptionHelper
{
    private static readonly byte[] EncryptionKey = Encoding.UTF8.GetBytes("YourEncryptionKey");

    public static string EncryptId(int id)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = EncryptionKey;
            byte[] encryptedBytes;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(id);
                    }

                    encryptedBytes = memoryStream.ToArray();
                }
            }

            return Convert.ToBase64String(encryptedBytes);
        }
    }

    public static int DecryptId(string encryptedId)
    {
        byte[] encryptedBytes = Convert.FromBase64String(encryptedId);

        using (Aes aes = Aes.Create())
        {
            aes.Key = EncryptionKey;
            int decryptedId;

            using (MemoryStream memoryStream = new MemoryStream(encryptedBytes))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader(cryptoStream))
                    {
                        decryptedId = int.Parse(streamReader.ReadToEnd());
                    }
                }
            }

            return decryptedId;
        }
    }
}
