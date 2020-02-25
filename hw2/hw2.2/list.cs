using System;

namespace hwTwoDotTwo
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

        private string hash;

        public string Hash
        {
            get 
            {
                return hash;
            }
            set
            {
                hash = value;
            }
        }
        private Node head;
        private Node tail;

        public List() { hash = ""; head = null; tail = null; }
        public List(string Data) { hash = ""; head = new Node(Data); tail = head; }

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
                return;
            }

            tail.next = newNode;
            tail = newNode;
        }

        public bool DeleteData(string data)
        {
            if (head == null)
            {
                throw new Exception("head == null");
            }
            else if (head.data == data)
            {
                head = head.next;
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
                    return true;
                }
                currentNode = currentNode.next;
            }
            return false;
        }

        public bool isEmpty() => head == null;

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
    }
}