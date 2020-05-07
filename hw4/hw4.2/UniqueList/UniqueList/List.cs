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
        private class Node<T>
        {
            public T Data { private set; get; }
            public Node<T> NextNode { set; get; }

            public Node(T data)
            {
                this.Data = data;
                NextNode = null;
            }
        }

        private Node<T> Head { set; get; }
        private Node<T> Tail { set; get; }
        public int Count { set; get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="List{T}"/> class.
        /// </summary>
        public List()
        {
            Head = Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Adds the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Add(T item)
        {
            if (Head == null)
            {
                Head = Tail = new Node<T>(item);
            }
            else
            {
                Tail.NextNode = new Node<T>(item);
                Tail = Tail.NextNode;
            }

            Count++;
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Existses the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public bool Exists(T item)
        {
            for (var currentNode = Head; currentNode != null; currentNode = currentNode.NextNode)
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
        /// <returns></returns>
        public int FindIndex(T item)
        {
            var index = 0;
            for (var currentNode = Head; currentNode != null; currentNode = currentNode.NextNode)
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
        /// Inserts the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="item">The item.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Insert(int index, T item)
        {
            var currentIndex = 0;
            for (var currentNode = Head; currentNode != null; currentNode = currentNode.NextNode)
            {
                if (currentIndex == index - 1)
                {
                    var temporaryNode = currentNode.NextNode;
                    currentNode.NextNode = new Node<T>(item)
                    {
                        NextNode = temporaryNode
                    };
                    Count++;
                    return;
                }

                currentIndex++;
            }

            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Removes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            for (var currentNode = Head;
                currentNode.NextNode != null && currentNode != null;
                currentNode = currentNode.NextNode)
            {
                if (currentNode.NextNode.Data.Equals(item))
                {
                    currentNode.NextNode = currentNode.NextNode.NextNode;
                    Count--;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes by index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void RemoveAt(int index)
        {
            var currentIndex = 0;
            for (var currentNode = Head;
                currentNode.NextNode != null && currentNode != null;
                currentNode = currentNode.NextNode)
            {
                if (currentIndex == index - 1)
                {
                    currentNode.NextNode = currentNode.NextNode.NextNode;
                    Count--;
                    return;
                }

                currentIndex++;
            }

            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Prints the list.
        /// </summary>
        public void PrintList()
        {
            for (var currentNode = Head; currentNode != null; currentNode = currentNode.NextNode)
            {
                Console.Write($"{currentNode.Data} ");
            }
            Console.WriteLine();
        }
    }
}
