using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Set
{
    public class Set<T> : ISet<T>
    {
        private class SetElement : IEnumerable<T>
        {
            public T Data { get; set; }
            public SetElement? LeftSetElement { set; get; }
            public SetElement? RightSetElement { set; get; }

            public SetElement(T data)
            {
                this.Data = data;
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

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        public int Count { set; get; }
        public bool IsReadOnly { set; get; }

        private SetElement? _root;
        private readonly IComparer<T> _comparer;

        public Set(IComparer<T> comparer, bool isReadOnly)
        {
            this.Count = 0;
            this.IsReadOnly = isReadOnly;
            this._comparer = comparer;
        }

        private (SetElement? currentSetElement, SetElement? parentSetElement)
            FindCurrentElementAndThemParent(T data)
        {
            SetElement? currentSetElement = _root;
            var parentSetElement = _root;

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
            if (_root == null)
            {
                _root = new SetElement(data);
                Count++;
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
                parentSetElement.LeftSetElement = new SetElement(data);
                return true;
            }
            else
            {
                parentSetElement.RightSetElement = new SetElement(data);
                return true;
            }
        }

        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("The ICollection object is read-only.");
            }

            this._root = null;
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
            else if (array.Length - arrayIndex < Count)
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
            this._root != null ? this._root.GetEnumerator() : Enumerable.Empty<T>().GetEnumerator();

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
            _root = temporarySet._root;
        }

        public bool IsProperSubsetOf(IEnumerable<T>? other)
        {
            if (other == null)
            {
                throw new ArgumentNullException($"{nameof(other)} is a null.");
            }

            return this.IsSubsetOf(other) && !this.SetEquals(other);
        }

        public bool IsProperSupersetOf(IEnumerable<T>? other)
        {
            if (other == null)
            {
                throw new ArgumentNullException($"{nameof(other)} is a null.");
            }

            return this.IsSupersetOf(other) && !this.SetEquals(other);
        }

        public bool IsSubsetOf(IEnumerable<T>? other)
        {
            if (other == null)
            {
                throw new ArgumentNullException($"{nameof(other)} is a null.");
            }

            var counter = 0;

            foreach (var item in other)
            {
                if (this.Contains(item))
                {
                    counter++;
                }
            }

            return counter == this.Count;
        }

        public bool IsSupersetOf(IEnumerable<T>? other)
        {
            if (other == null)
            {
                throw new ArgumentNullException($"{nameof(other)} is a null.");
            }

            var comparedSet = new Set<T>(this._comparer, this.IsReadOnly);

            foreach (var item in other)
            {
                if (!this.Contains(item))
                {
                    return false;
                }

                if (!comparedSet.Add(item))
                {
                    return false;
                }
            }

            return true;
        }

        public bool Overlaps(IEnumerable<T>? other)
        {
            if (other == null)
            {
                throw new ArgumentNullException($"{nameof(other)} is a null.");
            }

            foreach (var item in other)
            {
                if (this.Contains(item))
                {
                    return true;
                }
            }

            return false;
        }

        private static T GetMinimumDataFromCurrentSetElement(SetElement currentSetElement)
        {
            while (currentSetElement.LeftSetElement != null)
            {
                currentSetElement = currentSetElement.LeftSetElement;
            }

            return currentSetElement.Data;
        }

        private SetElement? RemoveFromCurrentSetElement(SetElement? currentSetElement, T data)
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
            else if (currentSetElement.RightSetElement != null && currentSetElement.LeftSetElement != null)
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
                    currentSetElement = _root;
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

            RemoveFromCurrentSetElement(_root, data);
            Count--;
            return true;
        }

        public bool SetEquals(IEnumerable<T>? other)
        {
            if (other == null)
            {
                throw new ArgumentNullException($"{nameof(other)} is a null.");
            }

            var comparedSet = new Set<T>(this._comparer, this.IsReadOnly);

            foreach (var item in other)
            {
                if (!this.Contains(item))
                {
                    return false;
                }

                if (!comparedSet.Add(item))
                {
                    return false;
                }
            }

            return this.Count != comparedSet.Count;
        }

        public void SymmetricExceptWith(IEnumerable<T>? other)
        {
            if (other == null)
            {
                throw new ArgumentNullException($"{nameof(other)} is a null.");
            }

            foreach (var item in other)
            {
                if (!this.Add(item))
                {
                    this.Remove(item);
                }
            }
        }

        public void UnionWith(IEnumerable<T>? other)
        {
            if (other == null)
            {
                throw new ArgumentNullException($"{nameof(other)} is a null.");
            }

            foreach (var item in other)
            {
                this.Add(item);
            }
        }

        void ICollection<T>.Add(T item)
        {
            this.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}