using System;
using NUnit.Framework;

namespace ProgramSources.Tests
{
    public class ListTests
    {
        private List list;

        [SetUp]
        public void Setup()
        {
            list = new List();
        }

        static object[] IsOnTheListCases =
        {
                new object[] { "0", true, true },
                new object[] { "-1", false, false },
                new object[] { " ", true, true },
                new object[] { "\x00", true, true },
                new object[] { "1000000000000000", false, false }
        };

        [TestCaseSource(nameof(IsOnTheListCases))]
        public void IsOnTheListTest(string data, bool addToList, bool result)
        {
            if (addToList)
            {
                list.Append(data);
            }
            Assert.AreEqual(list.IsOnTheList(data), result);
        }

        static object[] AppendCase =
        {
            new object[] {"1", true},
            new object[] {"-000000000000000000000000000", true},
            new object[] {"通常のテストはい", true},
            new object[] {"\x00\x01\x02\x03", true},
            new object[] {"<script>alert(1)</script>", true},
            new object[] {"\"test\"", true},
            new object[] {"AAAAAAAAAAAABBBBBBBBBBBBCCCCCCCCCCCCCCCCC", true},
        };

        [TestCaseSource(nameof(AppendCase))]
        public void AppendTest(string data, bool result)
        {
            list.Append(data);

            Assert.AreEqual(list.Size == 1, result);

        }

        static object[] DeleteDataCases =
        {
            new object[] {10, 10, 0, ""},
            new object[] {11, 10, 1, ""},
            new object[] {0, 0, 0, ""},
            new object[] {100000, 100000, 0, ""},
            new object[] {0, 10, 0, "list is empty now"},
            new object[] {10, 11, 0, "list is empty now"},
            new object[] {1000, 1001, 0, "list is empty now"}
        };

        [TestCaseSource(nameof(DeleteDataCases))]
        public void DeleteDataTest(int numberOfAppendedElements, int numberOfDeletedElement, int size, string errorMessage)
        {
            try
            {
                for (int i = 0; i < numberOfAppendedElements; i++)
                {
                    list.Append("1");
                }
                for (int i = 0; i < numberOfDeletedElement; i++)
                {
                    list.DeleteData("1");
                }
                Assert.AreEqual(list.Size, size);
            }
            catch (Exception exception)
            {
                Assert.AreEqual(errorMessage, exception.Message);
            }
        }

        [Test]
        public void ReturnAllNodesTest([Range(1, 1000, 100)] int numberOfElements)
        {
            for (int i = 0; i < numberOfElements; i++)
            {
                list.Append("1");
            }

            string[] returnedNodes = list.ReturnAllNodes();

            Assert.AreEqual(returnedNodes.Length, numberOfElements);
        }
    }
}