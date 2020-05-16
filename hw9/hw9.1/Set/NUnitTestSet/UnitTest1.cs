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