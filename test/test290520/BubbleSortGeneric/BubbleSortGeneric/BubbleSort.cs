using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleSortGeneric
{
    /// <summary>
    /// An implementation of the generic class containing the bubble sort method.
    /// </summary>
    public class BubbleSort<T>
    {
        private readonly IComparer<T> _comparer;
        private readonly IList<T> _list;

        /// <summary>
        /// Initializes a new instance of the <see cref="BubbleSort{T}"/> class.
        /// </summary>
        /// <param name="unsortedList">The unsorted list.</param>
        /// <param name="comparer">The comparer.</param>
        public BubbleSort(IList<T> unsortedList, IComparer<T> comparer)
        {
            this._list = unsortedList;
            this._comparer = comparer;
        }

        /// <summary>
        /// An implement of Bubble Sort.
        /// </summary>
        /// <returns>Sorted list</returns>
        public IList<T> Sort()
        {
            for (var j = 0; j < _list.Count - 1; j++)
            {
                for (var i = 0; i < _list.Count - j - 1; i++)
                {
                    if (this._comparer.Compare(_list[i], _list[i + 1]) > 0)
                    {
                        (_list[i + 1], _list[i]) = (_list[i], _list[i + 1]);
                    }
                }
            }

            return _list;
        }
    }
}
