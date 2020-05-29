using System;
using System.Collections.Generic;
using BubbleSortGeneric;
using NUnit.Framework;

namespace NUnitTestBubbleSort
{
    public class Tests
    {
        static object[] SortCase =
        {
            new object[]
            {
                new List<int>() {1, 2, 3, 4, 5, 6, 7}, new List<int>() {1, 1, 3, 4, 5, 6, 7},
            },
        };

        [TestCaseSource(nameof(SortCase))]
        public void Test1(List<int> unsortedList, List<int> sortedList)
        {
            var bubbleSort = new BubbleSort<int>(unsortedList, new DefaultComparer<int>());
            
            var result = bubbleSort.Sort();

            if (result.Count != sortedList.Count)
            {
                Assert.Fail();
            }

            for (var i = 0; i < result.Count; i++)
            {
                if (result[i] != sortedList[i])
                {
                    Assert.Fail();
                }
            }

            Assert.Pass();
        }
    }

    class DefaultComparer<T> : IComparer<T>
        where T : IComparable<T>
    {
        public int Compare(T first, T second)
        {
            return first.CompareTo(second);
        }
    }
}