using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace Set
{
    public class Set<T> : ISet<T>
    {
        private class SetElement<T> : IEnumerable<T>
        {
            public T Data { get; private set; }
            public SetElement<T> LeftSetElement { set; get; }
            public SetElement<T> RightSetElement { set; get; }

            public SetElement(T data)
            {
                this.Data = data;
                this.LeftSetElement = this.RightSetElement = null;
            }

            public SetElement()
            {
                this.Data = default;
                this.LeftSetElement = this.RightSetElement = null;
            }

            public IEnumerator<T> GetEnumerator()
            {
                if (this.LeftSetElement != null)
                {
                    foreach (var item in this.LeftSetElement)
                    {
                        yield return item;
                    }
                }

                yield return this.Data;

                if (this.RightSetElement != null)
                {
                    foreach (var item in this.RightSetElement)
                    {
                        yield return item;
                    }
                }
            }
        }

        public int Count { set; get; }
        public bool IsReadOnly { set; get; }

        private SetElement<T> root;
        private readonly IComparer<T> _comparer;

        public Set(IComparer<T> comparer, bool isReadOnly)
        {
            this.Count = 0;
            this.IsReadOnly = isReadOnly;
            this._comparer = comparer;
            this.root = new SetElement<T>();
        }

        private (SetElement<T> currentSetElement, SetElement<T> parentSetElement)
            FindCurrentElementAndThemParent(T data)
        {
            var currentSetElement = root;
            var parentSetElement = root;

            while (currentSetElement != null)
            {
                if (this._comparer.Compare(data, currentSetElement.Data) == 0)
                {
                    return (currentSetElement, parentSetElement);
                }
                else if (this._comparer.Compare(data, currentSetElement.Data) < 0)
                {
                    currentSetElement = currentSetElement.LeftSetElement;
                }
                else
                {
                    currentSetElement = currentSetElement.RightSetElement;
                }
            }

            return (null, parentSetElement);
        }

        private SetElement<T> Find(T data) => FindCurrentElementAndThemParent(data).currentSetElement;

        private SetElement<T> FindParent(T data) => FindCurrentElementAndThemParent(data).parentSetElement;

        public bool Add(T data)
        {
            if (Contains(data))
            {
                return false;
            }

            var parentSetElement = FindParent(data);
            Count++;
            if (this._comparer.Compare(data, parentSetElement.Data) < 0)
            {
                parentSetElement.LeftSetElement = new SetElement<T>(data);
                return true;
            }
            else
            {
                parentSetElement.RightSetElement = new SetElement<T>(data);
                return true;
            }
        }

        public void Clear()
        {
            this.root = null;
            this.Count = 0;
        }

        public bool Contains(T data) => Find(data) != null;
        
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"Array {nameof(array)} is a null.");
            }
            else if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException($"array index {nameof(arrayIndex)} isn't a positive number");
            }
            else if (array.Length - arrayIndex - 1 < Count)
            {
                throw new ArgumentException($"The number of elements in the source ICollection<T> is greater than the available space from {nameof(arrayIndex)} to the end of the destination {nameof(array)}");
            }
        }

    }
}