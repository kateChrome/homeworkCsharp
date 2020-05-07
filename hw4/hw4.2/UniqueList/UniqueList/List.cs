using System;
using System.Collections.Generic;
using System.Text;

namespace UniqueList
{
    public class List<T>
    {
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

        public List()
        {
            Head = Tail = null;
            Count = 0;
        }

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

        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

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

        public void Insert(int index, T item)
        {
            var currentIndex = 0;
            for (var currentNode = Head; currentNode != null; currentNode = currentNode.NextNode)
            {
                if (currentIndex == index)
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