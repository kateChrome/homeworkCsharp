using System;
using System.Collections.Generic;
using System.Text;

namespace BubbleSortGeneric
{
    public class BubbleSort<T>
    {
        private readonly IComparer<T> _comparer;
        private readonly IList<T> _list;

        public BubbleSort(IList<T> unsortedList, IComparer<T> comparer)
        {
            this._list = unsortedList;
            this._comparer = comparer;
        }

        public IList<T> Sort()
        {
            for (var p = 0; p <= _list.Count - 2; p++)
            {
                for (var i = 0; i <= _list.Count - 2; i++)
                {
                    if (this._comparer.Compare(_list[i], _list[i + 1]) > 0)
                    {
                        var t = _list[i + 1];
                        _list[i + 1] = _list[i];
                        _list[i] = t;
                    }
                }
            }

            return _list;
        }
    }
}
