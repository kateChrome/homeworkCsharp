using System;
using System.Collections.Generic;

namespace BubbleSortGeneric
{
    public class Program
    {
        public static void Main()
        {
            var list = new List<string>()
            {
                "111",
                "777",
                "222",
                "3",
                "000",
                "222",
                "333"
            };
            var comparer = new BubbleSort<string>(list, new DefaultComparer<string>());
            var result = comparer.Sort();

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// An implementation of the generic of comparator object class. You can use your comparator.
        /// </summary>
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