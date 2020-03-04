using System;
using NUnit.Framework;

namespace ProgramSources.Tests
{
    [TestFixture]
    public class HashTests
    {
        static object[] HashSHA1Cases =
        {
            new object[] { new HashSHA1(), "AAAAAAAAA", 12, 9 },
            new object[] { new HashSHA1(), "\x00\x01\x02", 4, 2 },
            new object[] { new HashSHA1(), "テストテストテスト", 23, 16 }
        };

        static object[] HashMD5Cases =
        {
            new object[] { new HashMD5(), "AAAAAAAAA", 23, 1 },
            new object[] { new HashMD5(), "\x00\x01\x02", 12, 10 },
            new object[] { new HashMD5(), "テストテストテスト", 11, 4 }
        };

        [TestCaseSource(nameof(HashSHA1Cases))]
        [TestCaseSource(nameof(HashMD5Cases))]
        public void HashTest(IHash hash, string data, int size, int expectedHash)
        {
            Assert.AreEqual(expectedHash, hash.Hash(data, size));
        }
    }
}