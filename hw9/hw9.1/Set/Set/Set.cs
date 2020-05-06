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
            public T Data { get; set; }
            public SetElement<T>? LeftSetElement { set; get; }
            public SetElement<T>? RightSetElement { set; get; }

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

        private SetElement<T>? root;
        private readonly IComparer<T> _comparer;

        public Set(IComparer<T> comparer, bool isReadOnly)
        {
            this.Count = 0;
            this.IsReadOnly = isReadOnly;
            this._comparer = comparer;
            this.root = new SetElement<T>();
        }

        private (SetElement<T>? currentSetElement, SetElement<T>? parentSetElement)
            FindCurrentElementAndThemParent(T data)
        {
            SetElement<T>? currentSetElement = root;
            var parentSetElement = root;

            while (currentSetElement != null)
            {
                if (this._comparer.Compare(data, currentSetElement.Data) == 0)
                {
                    return (currentSetElement, parentSetElement);
                }
                else if (this._comparer.Compare(data, currentSetElement.Data) < 0)
                {
                    parentSetElement = currentSetElement;
                    currentSetElement = currentSetElement.LeftSetElement;
                }
                else
                {
                    parentSetElement = currentSetElement;
                    currentSetElement = currentSetElement.RightSetElement;
                }
            }

            return (null, parentSetElement);
        }

        public bool Add(T data)
        {
            if (root == null)
            {
                root = new SetElement<T>(data);
                return true;
            }


            var parentAndCurrentElements = FindCurrentElementAndThemParent(data);
            var parentSetElement = parentAndCurrentElements.parentSetElement;
            if (parentAndCurrentElements.currentSetElement != null || parentSetElement == null)
            {
                return false;
            }

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

        public bool Contains(T data) => FindCurrentElementAndThemParent(data).currentSetElement != null;

        public void CopyTo(T[]? array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"Array {nameof(array)} is a null.");
            }
            else if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException($"array index {nameof(arrayIndex)} isn't a positive number.");
            }
            else if (array.Length - arrayIndex - 1 < Count)
            {
                throw new ArgumentException(
                    $"The number of elements in the source ICollection<T> is greater than the available space from {nameof(arrayIndex)} to the end of the destination {nameof(array)}.");
            }

            foreach (var item in this)
            {
                array[arrayIndex] = item;
                arrayIndex++;
            }
        }

        public void ExceptWith(System.Collections.Generic.IEnumerable<T>? other)
        {
            if (other == null)
            {
                throw new ArgumentNullException($"Array {nameof(other)} is a null.");
            }

            foreach (var item in other)
            {
                this.Remove(item);
            }
        }

        public IEnumerator<T> GetEnumerator() =>
            this.root != null ? this.root.GetEnumerator() : Enumerable.Empty<T>().GetEnumerator();

        public void IntersectWith(System.Collections.Generic.IEnumerable<T>? other)
        {
            if (other == null)
            {
                throw new ArgumentNullException($"Array {nameof(other)} is a null.");
            }

            var temporarySet = new Set<T>(_comparer, IsReadOnly);

            foreach (var item in other)
            {
                if (this.Contains(item))
                {
                    temporarySet.Add(item);
                }
            }

            Count = temporarySet.Count;
            root = temporarySet.root;
        }

        public bool IsSubsetOf(System.Collections.Generic.IEnumerable<T> other)
        {

        }

        private T GetMinimumDataFromCurrentSetElement(SetElement<T> currentSetElement)
        {
            while (currentSetElement.LeftSetElement != null)
            {
                currentSetElement = currentSetElement.LeftSetElement;
            }

            return currentSetElement.Data;
        }

        private SetElement<T>? RemoveFromCurrentSetElement(SetElement<T>? currentSetElement, T data)
        {
            if (currentSetElement == null)
            {
                return null;
            }
            else if (this._comparer.Compare(data, currentSetElement.Data) < 0)
            {
                currentSetElement.LeftSetElement = RemoveFromCurrentSetElement(currentSetElement.LeftSetElement, data);
            }
            else if (this._comparer.Compare(data, currentSetElement.Data) > 0)
            {
                currentSetElement.RightSetElement =
                    RemoveFromCurrentSetElement(currentSetElement.RightSetElement, data);
            }
            else if (currentSetElement.RightSetElement != null && currentSetElement.RightSetElement != null)
            {
                currentSetElement.Data = GetMinimumDataFromCurrentSetElement(currentSetElement.RightSetElement);
                currentSetElement.RightSetElement =
                    RemoveFromCurrentSetElement(currentSetElement.RightSetElement, currentSetElement.Data);
            }
            else
            {
                if (currentSetElement.LeftSetElement != null)
                {
                    currentSetElement = currentSetElement.LeftSetElement;
                }
                else if (currentSetElement.RightSetElement != null)
                {
                    currentSetElement = currentSetElement.RightSetElement;
                }
                else
                {
                    currentSetElement = root;
                }
            }

            return currentSetElement;
        }

        public bool Remove(T data)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("The ICollection<T> is read-only.");
            }
            else if (!Contains(data))
            {
                return false;
            }

            RemoveFromCurrentSetElement(root, data);
            Count--;
            return true;
        }
    }
}