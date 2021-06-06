using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OnlineBookingAggregatorApp.Infrastructure.Utils
{
    public class CryptoUtils
    {
        private const string Key = "c1rpt0k3yf0r5h0wr348m2bbc85973659487";
        
        public static string EncryptString(string plainInput)
        {
            var iv = new byte[16];
            byte[] array;
            using (var aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = iv;
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainInput);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string cipherText)
        {
            var iv = new byte[16];
            var buffer = Convert.FromBase64String(cipherText);
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = iv;
            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var memoryStream = new MemoryStream(buffer);
            using var cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read);
            using var streamReader = new StreamReader((Stream)cryptoStream);
            return streamReader.ReadToEnd();
        }
    }
}