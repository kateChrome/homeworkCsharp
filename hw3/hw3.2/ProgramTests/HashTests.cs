using System;
using NUnit.Framework;

namespace ProgramSources.Tests
{
    [TestFixture]
    public class HashTests
    {
        static object[] HashSHA1Cases =
        {
            new object[] { new HashSHA1(), "AAAAAAAAA", 117693 },
            new object[] { new HashSHA1(), "\x00\x01\x02", 51110 },
            new object[] { new HashSHA1(), "テストテストテスト", 934506 }
        };

        static object[] HashMD5Cases =
        {
            new object[] { new HashMD5(), "AAAAAAAAA", 444729 },
            new object[] { new HashMD5(), "\x00\x01\x02", 759286 },
            new object[] { new HashMD5(), "テストテストテスト", 501219 }
        };

        [TestCaseSource(nameof(HashSHA1Cases))]
        [TestCaseSource(nameof(HashMD5Cases))]
        public void HashTest(IHash hash, string data, int expectedHash)
        {
            Assert.AreEqual(expectedHash, hash.Hash(data));
        }
    }
}