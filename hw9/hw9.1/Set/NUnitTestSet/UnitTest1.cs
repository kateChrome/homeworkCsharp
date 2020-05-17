using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Set;

namespace NUnitTestSet
{
    public class Tests
    {
        private Set<string> set;

        [SetUp]
        public void Setup()
        {
            set = new Set<string>(new DefaultComparer<string>(), false);
        }

        [Test]
        public void TestAddOneItem()
        {
            set.Add("111");
            Assert.AreEqual(1, set.Count);
        }

        [Test]
        public void TestAddOneItemAndClear()
        {
            set.Add("111");
            set.Clear();
            Assert.AreEqual(0, set.Count);
        }

        [Test]
        public void TestClearInReadOnly()
        {
            set = new Set<string>(new DefaultComparer<string>(), true)
            {
                "111"
            };
            Assert.Throws<NotSupportedException>(() => set.Clear());
        }

        [Test]
        public void TestContains()
        {
            set.Add("111");
            Assert.True(set.Contains("111"));
        }

        [Test]
        public void TestNotContains()
        {
            set.Add("111");
            Assert.False(set.Contains("112"));
        }

        [Test]
        public void TestCopyTo()
        {
            var testArray = new string[] {"111", "222", "333"};
            foreach (var item in testArray)
            {
                set.Add(item);
            }

            var distance = new string[3];
            set.CopyTo(distance, 0);
            Assert.AreEqual(testArray, distance);
        }

        [Test]
        public void TestCopyToNullArray()
        {
            var testArray = new string[] { "111", "222", "333" };
            foreach (var item in testArray)
            {
                set.Add(item);
            }

            Assert.Throws<ArgumentNullException>(() => set.CopyTo(null, 0));
        }

        [Test]
        public void TestCopyToNegativeIndex()
        {
            var testArray = new string[] { "111", "222", "333" };
            foreach (var item in testArray)
            {
                set.Add(item);
            }
            var distance = new string[3];
            Assert.Throws<ArgumentOutOfRangeException>(() => set.CopyTo(distance, -1));
        }

        [Test]
        public void TestCopyToIncorrectSize()
        {
            var testArray = new string[] { "111", "222", "333" };
            foreach (var item in testArray)
            {
                set.Add(item);
            }
            var distance = new string[3];
            Assert.Throws<ArgumentException>(() => set.CopyTo(distance, 12));
        }

        [Test]
        public void TestExceptWith()
        {

        }

        private class DefaultComparer<T> : IComparer<T>
            where T : IComparable<T>
        {
            public int Compare(T first, T second)
            {
                return first.CompareTo(second);
            }
        }
    }
}