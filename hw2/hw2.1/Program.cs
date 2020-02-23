using System;

namespace hw2._1
{
    public class Node
    {
        public int Data;
        public Node Next;

        public Node(int data) { Data = data; Next = null; }

    }

    public class List
    {
        public Node Head;

        public List() { Head = null; }
        public List(int Data) { Head = new Node(Data); }

        public void append(int data)
        {
            Node newNode = new Node(data);

            if (Head == null)
            {
                Head = newNode;
                return;
            }

            Node currentNode = Head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = newNode;
        }

        public void removeNodeFromEnd()
        {
            if (Head == null)
            {
                return;
            }
            else if (Head.Next == null)
            {
                Head = null;
                return;
            }

            Node currentNode = Head;

            while (currentNode.Next.Next != null)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = null;
        }

        public void insert(int data, int index)
        {
            if (index < 0)
            {
                return;
            }
            else if (Head == null && index != 0)
            {
                return;
            }
            else if (Head == null && index == 0)
            {
                Head = new Node(data);
                return;
            }
            else if (Head != null && index == 0)
            {
                Node oldHead = Head;
                Head = new Node(data);
                Head.Next = oldHead;
                return;
            }

            Node currentNode = Head;
            for (int i = 0; i < index - 1; i++)
            {
                if (currentNode.Next == null)
                {
                    return;
                }
                currentNode = currentNode.Next;
            }
            Node nextNode = currentNode.Next;
            currentNode.Next = new Node(data);
            currentNode.Next.Next = nextNode;
        }

        public void removeNodeByIndex(int index)
        {
            if (Head == null && index < 0)
            {
                return;
            }
            else if (Head != null && index == 0)
            {
                Head = Head.Next;
            }

            Node currentNode = Head;
            for (int i = 0; i < index - 1; i++)
            {
                if (currentNode.Next == null)
                {
                    return;
                }
                currentNode = currentNode.Next;
            }

            if (currentNode.Next == null)
            {
                return;
            }
            currentNode.Next = currentNode.Next.Next;
        }

        public bool isEmpty()
        {
            return (Head == null);
        }

        public int getSize()
        {
            if (isEmpty())
            {
                return 0;
            }

            int size = 1;
            Node currentNode = Head;
            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
                size++;
            }
            return size;
        }

        public int? getDataOfNodeByIndex(int index)
        {
            if (index < 0 || Head == null)
            {
                return null;
            }
            if (index == 0)
            {
                return Head.Data;
            }

            Node currentNode = Head;
            for (int i = 0; i < index; i++)
            {
                if (currentNode.Next == null)
                {
                    return null;
                }
                currentNode = currentNode.Next;
            }
            return currentNode.Data;
        }

        public void setDataOfNodeByIndex(int data, int index)
        {
            if (index < 0)
            {
                return;
            }
            else if (Head == null && index == 0)
            {
                Head = new Node(data);
            }
            else if (Head == null && index != 0)
            {
                return;
            }

            Node currentNode = Head;
            for (int i = 0; i < index; i++)
            {
                if (currentNode.Next == null)
                {
                    return;
                }
                currentNode = currentNode.Next;
            }
            currentNode.Data = data;
        }
        public void printList()
        {
            Node currentNode = Head;

            if (currentNode == null)
            {
                Console.WriteLine("null");
                return;
            }

            while (currentNode.Next != null)
            {
                Console.Write($"{currentNode.Data} ");
                currentNode = currentNode.Next;
            }
            Console.WriteLine($"{currentNode.Data} ");
        }


    }

    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            list.append(10);
            list.append(11);
            list.append(13);
            list.append(100);
            list.insert(1000, 2);
            list.printList();
            list.setDataOfNodeByIndex(100001,5);
            list.printList();
        }
    }
}
