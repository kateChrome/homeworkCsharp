using System;

namespace hwTwoDotThree
{
    public class ListStack : IStack
    {
        private class Node
        {
            public int data;
            public Node previousNode;

            public Node(int data, Node previousNode) { this.data = data; this.previousNode = previousNode; }
        }

        private Node top;

        public bool IsEmpty() => top == null;
        public void Push(int data)
        {
            top = new Node(data, top);
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("stack does not exist now");
            }

            int data = top.data;
            top = top.previousNode;
            return data;
        }
    }
}