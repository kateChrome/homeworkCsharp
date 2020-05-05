using System;
using System.Collections.Generic;
using System.Linq;

namespace Set
{
    public class Set<T> : ISet<T>
    {
        private class SetElement<T>
        {
            public T Data { get; set; }
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
        }

        public int Count { set; get; }
        public bool IsReadOnly { set; get; }

        private SetElement<T> root;
        private IComparer<T> comparer;

        public Set(IComparer<T> comparer, bool isReadOnly)
        {
            this.Count = 0;
            this.IsReadOnly = isReadOnly;
            this.comparer = comparer;
            this.root = new SetElement<T>();
        }

        private SetElement<T> Find(T data)
        {
            var currentSetElement = root;
            while (currentSetElement != null)
            {
                if (this.comparer.Compare(data, currentSetElement.Data) == 0)
                {
                    return currentSetElement;
                }
                else if (this.comparer.Compare(data, currentSetElement.Data) < 0)
                {
                    currentSetElement = currentSetElement.LeftSetElement;
                }
                else
                {
                    currentSetElement = currentSetElement.RightSetElement;
                }
            }

            return null;
        }

        public bool Contains(T item) => Find(item) != null;

        public bool Add(T item)
        {

        }

    }
}