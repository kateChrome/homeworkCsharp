using System;
using System.Collections.Generic;
using System.Text;


namespace Task2
{
    /// <summary>
    /// List class implementation.
    /// </summary>
    public class List<T>
    {
        /// <summary>
        /// Node class implementation.
        /// </summary>
        private class Node
        {
            public T Data { private set; get; }
            public Node NextNode { set; get; }

            public Node(T data)
            {
                this.Data = data;
                NextNode = null;
            }
        }

        private Node _head;
        private Node _tail;
        public int Count { set; get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="List{T}"/> class.
        /// </summary>
        public List()
        {
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(T item)
        {
            if (_head == null)
            {
                _head = new Node(item);
                _tail = _head;
            }
            else
            {
                _tail.NextNode = new Node(item);
                _tail = _tail.NextNode;
            }

            Count++;
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        /// <summary>
        /// Existses the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public bool Exists(T item)
        {
            for (var currentNode = _head; currentNode != null; currentNode = currentNode.NextNode)
            {
                if (currentNode.Data.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Finds the index.
        /// </summary>
        /// <param name="item">The item.</param>
        public int FindIndex(T item)
        {
            var index = 0;
            for (var currentNode = _head; currentNode != null; currentNode = currentNode.NextNode)
            {
                if (currentNode.Data.Equals(item))
                {
                    return index;
                }

                index++;
            }

            return -1;
        }

        /// <summary>
        /// Inserts item by index. The item will have the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            else if (index == 0)
            {
                var currentNode = new Node(item)
                {
                    NextNode = _head
                };
                _head = currentNode;
            }
            else if (index == Count)
            {
                _tail.NextNode = new Node(item);
                _tail = _tail.NextNode;
            }
            else
            {
                var currentNode = _head;
                for (var i = 0; i != index - 1; i++, currentNode = currentNode.NextNode) ;
                currentNode.NextNode = new Node(item)
                {
                    NextNode = currentNode.NextNode
                };
            }

            Count++;
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public bool Remove(T item)
        {
            var index = FindIndex(item);

            if (index == -1)
            {
                return false;
            }
            RemoveAt(index);
            return true;
        }


        /// <summary>
        /// Removes by index.
        /// </summary>
        /// <param name="index">The index.</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            else if (index == 0 && Count == 1)
            {
                Clear();
            }
            else if (index == 0)
            {
                _head = _head.NextNode;
                Count--;
            }
            else
            {
                var currentNode = _head;
                for (var i = 0; i != index - 1; i++, currentNode = currentNode.NextNode);
                if (index == Count - 1)
                {
                    currentNode.NextNode = null;
                    _tail = currentNode;
                }
                else
                {
                    currentNode.NextNode = currentNode.NextNode.NextNode;
                }
                Count--;
            }
        }

        /// <summary>
        /// Prints the list.
        /// </summary>
        public void PrintList()
        {
            for (var currentNode = _head;
                currentNode != null;
                currentNode = currentNode.NextNode)
            {
                Console.Write($"{currentNode.Data} ");
            }

            Console.WriteLine();
        }
    }
}