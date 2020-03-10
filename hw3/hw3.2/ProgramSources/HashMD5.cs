using System;
using System.Security.Cryptography;
using System.Text;

namespace ProgramSources
{
    /// <summary>
    /// calculate hash MD5
    /// </summary>
    public class HashMD5 : IHash
    {
        /// <summary>
        /// This method calculate hash of input data
        /// </summary>
        /// <param name="data">input data</param>
        /// <returns>hash of input data</returns>
        public int Hash(string data)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(data));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return Convert.ToInt32(hash.ToString().Substring(0, 5), 16);
        }
    }
}