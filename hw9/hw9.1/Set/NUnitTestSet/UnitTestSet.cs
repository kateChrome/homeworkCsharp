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
        private string[] testArray = new string[] {"111", "222", "333"};

        [SetUp]
        public void Setup()
        {
            set = new Set<string>(new DefaultComparer<string>());
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
            var testArray = new string[] {"111", "222", "333"};
            foreach (var item in testArray)
            {
                set.Add(item);
            }

            Assert.Throws<ArgumentNullException>(() => set.CopyTo(null, 0));
        }

        [Test]
        public void TestCopyToNegativeIndex()
        {
            var testArray = new string[] {"111", "222", "333"};
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
            var testArray = new string[] {"111", "222", "333"};
            foreach (var item in testArray)
            {
                set.Add(item);
            }

            var distance = new string[3];
            Assert.Throws<ArgumentException>(() => set.CopyTo(distance, 12));
        }

        [Test]
        public void TestExceptWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => set.ExceptWith(null));
        }

        [Test]
        public void TestExceptWithCorrect()
        {
            foreach (var item in testArray)
            {
                set.Add(item);
            }

            set.ExceptWith(testArray);
            Assert.AreEqual(0, set.Count);
        }

        [Test]
        public void TestIntersectWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => set.IntersectWith(null));
        }

        [Test]
        public void TestIsProperSubsetOfNull()
        {
            Assert.Throws<ArgumentNullException>(() => set.IsProperSubsetOf(null));
        }

        [Test]
        public void TestIsProperSupersetOfhNull()
        {
            Assert.Throws<ArgumentNullException>(() => set.IsProperSupersetOf(null));
        }

        [Test]
        public void TestIsSubsetOfNull()
        {
            Assert.Throws<ArgumentNullException>(() => set.IsSubsetOf(null));
        }

        [Test]
        public void TestIsSupersetOfNull()
        {
            Assert.Throws<ArgumentNullException>(() => set.IsSupersetOf(null));
        }

        [Test]
        public void TestIsProperSubsetOfCorrectFalse()
        {
            foreach (var item in testArray)
            {
                set.Add(item);
            }

            Assert.False(set.IsProperSubsetOf(testArray));
        }

        [Test]
        public void TestIsProperSubsetOfCorrectFalse1()
        {
            foreach (var item in testArray)
            {
                set.Add(item);
            }

            set.Add("444");

            Assert.False(set.IsProperSubsetOf(testArray));
        }

        [Test]
        public void TestIsProperSubsetOfCorrectTrue()
        {
            set.Add("111");

            Assert.True(set.IsProperSubsetOf(testArray));
        }

        [Test]
        public void TestIsProperSupersetOfFalse()
        {
            foreach (var item in testArray)
            {
                set.Add(item);
            }

            Assert.False(set.IsProperSupersetOf(testArray));
        }

        [Test]
        public void TestIsProperSupersetOfTrue()
        {
            foreach (var item in testArray)
            {
                set.Add(item);
            }

            set.Add("444");

            Assert.True(set.IsProperSupersetOf(testArray));
        }

        [Test]
        public void TestIsSubsetOfFalse()
        {
            foreach (var item in testArray)
            {
                set.Add(item);
            }

            set.Add("444");

            Assert.False(set.IsSubsetOf(testArray));
        }

        [Test]
        public void TestIsSubsetOfTrue()
        {
            foreach (var item in testArray)
            {
                set.Add(item);
            }

            Assert.True(set.IsSubsetOf(testArray));
        }

        [Test]
        public void TestIsSubsetOfTrue1()
        {
            set.Add("111");

            Assert.True(set.IsSubsetOf(testArray));
        }

        [Test]
        public void TestIsSupersetOfTrue()
        {
            foreach (var item in testArray)
            {
                set.Add(item);
            }

            set.Add("444");

            Assert.True(set.IsSupersetOf(testArray));
        }

        [Test]
        public void TestIsSupersetOfTrue1()
        {
            foreach (var item in testArray)
            {
                set.Add(item);
            }

            Assert.True(set.IsSupersetOf(testArray));
        }

        [Test]
        public void TestIsSupersetOfFalse()
        {
            foreach (var item in testArray)
            {
                set.Add(item + item);
            }

            Assert.False(set.IsSupersetOf(testArray));
        }

        [Test]
        public void TestOverlapsNull()
        {
            Assert.Throws<ArgumentNullException>(() => set.Overlaps(null));
        }

        [Test]
        public void TestOverlapsFalse()
        {
            foreach (var item in testArray)
            {
                set.Add(item + item);
            }

            Assert.False(set.Overlaps(testArray));
        }

        [Test]
        public void TestOverlapsTrue()
        {
            foreach (var item in testArray)
            {
                set.Add(item);
            }

            Assert.True(set.Overlaps(testArray));
        }

        [Test]
        public void TestOverlapsTrue1()
        {
            set.Add("111");

            Assert.True(set.Overlaps(testArray));
        }

        [Test]
        public void TestRemoveAfterAdd()
        {
            set.Add("1");
            set.Remove("1");
            Assert.AreEqual(0, set.Count);
        }

        [Test]
        public void TestRemoveMuchAfterMuchAdd()
        {
            for (var i = 0; i < 10; i++)
            {
                set.Add(i.ToString());
            }

            for (var i = 0; i < 5; i++)
            {
                set.Remove(i.ToString());
            }

            Assert.AreEqual(5, set.Count);
        }

        [Test]
        public void TestRemoveFromEmptySet()
        {
            Assert.False(set.Remove("111"));
        }

        [Test]
        public void TestRemoveDoesNotExistElement()
        {
            for (var i = 0; i < 10; i++)
            {
                set.Add(i.ToString());
            }

            Assert.False(set.Remove("1337"));
        }

        [Test]
        public void TestSetEqualsTrue()
        {
            foreach (var item in testArray)
            {
                set.Add(item);
            }

            Assert.True(set.SetEquals(testArray));
        }

        [Test]
        public void TestSetEqualsFalse()
        {
            foreach (var item in testArray)
            {
                set.Add(item);
            }

            set.Add("444");

            Assert.False(set.SetEquals(testArray));
        }

        [Test]
        public void TestSymmetricExceptWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => set.SymmetricExceptWith(null));
        }

        [Test]
        public void TestSymmetricExceptWithCorrect()
        {
            foreach (var item in testArray)
            {
                set.Add(item);
            }
            Assert.AreEqual(3, set.Count);
        }

        [Test]
        public void TestUnionWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => set.UnionWith(null));
        }

        [Test]
        public void TestUnionWithCorrect()
        {
            foreach (var item in testArray)
            {
                set.Add(item);
            }
            Assert.AreEqual(3, set.Count);
        }

        [Test]
        public void TestForeach()
        {
            foreach (var item in testArray)
            {
                set.Add(item);
            }

            var count = 0;
            foreach (var item in set)
            {
                count++;
            }
            Assert.AreEqual(set.Count, count);
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