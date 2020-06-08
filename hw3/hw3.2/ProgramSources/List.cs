using System;

namespace ProgramSources
{
    /// <summary>
    /// Class with implementation list structure 
    /// </summary>
    public class List
    {
        /// <summary>
        /// Class with implementation node of <see cref="List" /> structure
        /// </summary>
        private class Node
        {
            public string data;
            public Node next;

            public Node(string data) { this.data = data; next = null; }

            public Node(string data, Node next) { this.data = data; this.next = next; }
        }

        private Node head;
        private Node tail;

        private int size;

        /// <summary>
        /// Initializes a new instance of the <see cref="List"/> class
        /// </summary>
        public List() { head = null; tail = null; size = 0; }

        /// <summary>
        /// check that the item is in the list 
        /// </summary>
        /// <param name="data">data of checkable item</param>
        public bool IsOnTheList(string data)
        {
            Node currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.data == data)
                {
                    return true;
                }
                currentNode = currentNode.next;
            }

            return false;
        }

        /// <summary>
        /// append data to <see cref="List"> instance
        /// </summary>
        /// <param name="data"></param>
        public void Append(string data)
        {
            var newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
                tail = head;
                size++;
                return;
            }

            tail.next = newNode;
            tail = newNode;
            size++;
        }

        /// <summary>
        /// delete data from <see cref="List"> instance
        /// </summary>
        /// <param name="data">data to be delete</param>
        public bool DeleteData(string data)
        {
            if (head == null)
            {
                throw new Exception("list is empty now");
            }
            else if (head.data == data)
            {
                head = head.next;
                size--;
                return true;
            }

            var currentNode = head;
            while (currentNode != tail)
            {
                if (currentNode.next.data == data)
                {
                    if (currentNode.next == tail)
                    {
                        tail = currentNode;
                    }
                    currentNode.next = currentNode.next.next;
                    size--;
                    return true;
                }
                currentNode = currentNode.next;
            }
            return false;
        }

        /// <summary>
        /// Сheck the list for emptiness 
        /// </summary>
        public bool IsEmpty() => head == null;

        /// <summary>
        /// print <see cref="List"> <see cref="Node"> by <see cref="Node">
        /// </summary>
        public void PrintList()
        {
            var currentNode = head;

            if (currentNode == null)
            {
                throw new Exception("list does not exist now");
            }

            while (currentNode.next != null)
            {
                Console.Write($"{currentNode.data} ");
                currentNode = currentNode.next;
            }
            Console.WriteLine($"{currentNode.data} ");
        }

        /// <summary>
        /// return all <see cref="Node"> of <see cref="List"> instance
        /// </summary>
        /// <returns>string array of <see cref="Node"></returns>
        public string[] ReturnAllNodes()
        {
            var currentNode = head;

            if (currentNode == null)
            {
                throw new Exception("list does not exist now");
            }

            var allNodes = new string[size];
            for (int i = 0; i < size; i++)
            {
                allNodes[i] = currentNode.data;
                currentNode = currentNode.next;
            }

            return allNodes;
        }

        /// <summary>
        /// return value of head <see cref="Node"> of <see cref="List"> instance
        /// </summary>
        public string ReturnHeadValue()
        {
            return head.data;
        }

        /// <summary>
        /// get size of <see cref="List"> instance
        /// </summary>
        public int Size
        {
            get
            {
                return size;
            }
        }

    }
}