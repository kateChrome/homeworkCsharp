using System;
using System.Security.Cryptography;
using System.Text;

namespace ProgramSources
{
    public class HashSHA1 : IHash
    {
        public int Hash(string data, int size)
        {
            var hash = new StringBuilder();
            var md5provider = new SHA1CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(data));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return Convert.ToInt32(hash.ToString().Substring(0, 5), 16) % size;
        }
    }
}