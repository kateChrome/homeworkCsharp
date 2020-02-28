using System;

namespace HwTwoDotThree
{
    public class ListStack : IStack
    {
        private class Node
        {
            public double data;
            public Node previousNode;

            public Node(double data, Node previousNode) { this.data = data; this.previousNode = previousNode; }
        }

        private Node top;

        public bool IsEmpty() => top == null;
        public void Push(double data)
        {
            top = new Node(data, top);
        }

        public double Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("stack does not exist now");
            }

            var data = top.data;
            top = top.previousNode;
            return data;
        }
    }
}