using System;
using System.Collections;
using System.Collections.Generic;

namespace Set
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var set = new Set<string>(new DefaultComparer<string>())
            {
                "111",
                "222",
                "333"
            };

            Console.WriteLine($"{set.Count} {set.IsReadOnly}");

            set.Clear();

            Console.WriteLine($"{set.Count} {set.IsReadOnly}");

            set.Add("111");

            Console.WriteLine($"{set.Count} {set.IsReadOnly}");

            set.Remove("111");

            Console.WriteLine($"{set.Count} {set.IsReadOnly}");
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
