using System;
using System.Security.Cryptography;
using System.Text;

namespace HwThreeDotTwo
{
    public class HashFunctionMD4 : IHashFunction
    {
        public int Hash(string data, int size)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(data));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return Convert.ToInt32(hash.ToString().Substring(0, 5), 16) % size;
        }
    }
}