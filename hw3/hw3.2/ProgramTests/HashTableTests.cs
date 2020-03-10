using System;
using NUnit.Framework;

namespace ProgramSources.Tests
{
    [TestFixture]
    public class HashTableTests
    {
        private HashTable hashTable;

        [SetUp]
        public void SetUp()
        {
            hashTable = new HashTable(new HashMD5());
        }

        static object[] AddValueCases =
        {
            new object[] {"A", true},
            new object[] {"\x00", true},
            new object[] {"ス", true},
            new object[] {"A", false},
            new object[] {"\x00", false},
            new object[] {"ス", false}
        };

        [TestCaseSource(nameof(AddValueCases))]
        public void AddValueTest(string data, bool addValue)
        {
            if (addValue)
            {
                hashTable.AddValue(data);
            }
            else
            {
                hashTable.AddValue("1");
            }
            Assert.AreEqual(addValue, hashTable.IsInTheHashTable(data));
        }

        [TestCase(10, 10, ExpectedResult = 0)]
        [TestCase(10, 9, ExpectedResult = 1)]
        [TestCase(10, 11, ExpectedResult = 0)]
        public int RemoveValueTest(int numberOfAddedElements, int numberOfRemovedElements)
        {
            for (int i = 0; i < numberOfAddedElements; i++)
            {
                hashTable.AddValue("0");
            }

            for (int i = 0; i < numberOfRemovedElements; i++)
            {
                hashTable.RemoveValue("0");
            }

            return hashTable.NumberOfItems;
        }

        static object[] ChangeHashFunctionCases =
        {
            new object[] {10, "test", new HashMD5(), new HashSHA1()},
            new object[] {10, "test", new HashSHA1(), new HashMD5()}
        };

        [TestCaseSource(nameof(ChangeHashFunctionCases))]
        public void ChangeHashFunctionTest(int numberOfElements, string data, IHash beginHashFunction, IHash endHashFunction)
        {
            for (int i = 0; i < numberOfElements; i++)
            {
                hashTable.AddValue("0");
            }

            hashTable.ChangeHashFunction(beginHashFunction);
            int beginHash = hashTable.GetHash(data);
            hashTable.ChangeHashFunction(endHashFunction);
            int endHash = hashTable.GetHash(data);

            Assert.IsFalse(beginHash == endHash);
        }

    }
}