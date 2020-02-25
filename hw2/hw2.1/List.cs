using System;

namespace HwTwoDotOne
{
    public class List
    {
        private class Node
        {
            public int data;
            public Node next;

            public Node(int data) { this.data = data; next = null; }
            public Node(int data, Node next) { this.data = data; this.next = next; }
        }

        private Node head;

        public List() { head = null; }
        public List(int Data) { head = new Node(Data); }

        private Node FindNeededNode(int index)
        {
            var currentNode = head;
            for (int i = 0; i < index - 1; i++)
            {
                if (currentNode.next == null)
                {
                    throw new Exception("index more than size of current list");
                }
                currentNode = currentNode.next;
            }
            return currentNode;
        }

        public void Insert(int data, int index)
        {
            if (index < 0)
            {
                throw new Exception("index < 0");
            }
            else if (head == null && index != 0)
            {
                throw new Exception("list does not exist now");
            }
            else if (head == null && index == 0)
            {
                head = new Node(data);
                return;
            }
            else if (head != null && index == 0)
            {
                head = new Node(data, head);
                return;
            }

            var currentNode = FindNeededNode(index);
            currentNode.next = new Node(data, currentNode.next);
        }

        public void RemoveNodeByIndex(int index)
        {
            if (index < 0)
            {
                throw new Exception("index < 0");
            }
            else if (head == null)
            {
                throw new Exception("list does not exist now");
            }
            else if (index < 0)
            {
                throw new Exception("index < 0");
            }
            else if (head != null && index == 0)
            {
                head = head.next;
            }

            var currentNode = FindNeededNode(index);

            if (currentNode.next == null)
            {
                return;
            }
            currentNode.next = currentNode.next.next;
        }

        public bool IsEmpty() => (head == null);

        public int GetSize()
        {
            if (IsEmpty())
            {
                return 0;
            }

            int size = 1;
            var currentNode = head;
            while (currentNode.next != null)
            {
                currentNode = currentNode.next;
                size++;
            }
            return size;
        }

        public int GetDataOfNodeByIndex(int index)
        {
            if (index < 0)
            {
                throw new Exception("index < 0");
            }
            else if (head == null)
            {
                throw new Exception("list does not exist now");
            }
            else if (index == 0)
            {
                return head.data;
            }

            var currentNode = FindNeededNode(index);
            return currentNode.data;
        }

        public void SetDataOfNodeByIndex(int data, int index)
        {
            if (index < 0)
            {
                throw new Exception("index < 0");
            }
            else if (head == null && index == 0)
            {
                head = new Node(data);
            }
            else if (head == null && index != 0)
            {
                throw new Exception("list does not exist now & index != 0");
            }

            var currentNode = FindNeededNode(index);
            currentNode.data = data;
        }

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