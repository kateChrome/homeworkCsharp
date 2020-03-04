using System;

namespace ProgramSources
{
    public class List
    {
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

        public List() { head = null; tail = null; size = 0; }
        
        public List(string Data) { head = new Node(Data); tail = head; size = 1; }

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

        public bool IsEmpty() => head == null;

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
        public string ReturnHeadValue()
        {
            return head.data;
        }

        public int Size
        {
            set
            {
            }
            get
            {
                return size;
            }
        }

    }
}