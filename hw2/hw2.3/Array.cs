using System;

namespace hwTwoDotThree
{
    public class ArrayStack : IStack
    {
        private int[] stack;

        public ArrayStack() { stack = new int[0]; }

        public bool IsEmpty() => stack.Length == 0;

        public void Push(int data)
        {
            Array.Resize(ref stack, stack.Length + 1);
            stack[stack.Length - 1] = data;
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("stack does not exist now");
            }

            int data = stack[stack.Length - 1];
            Array.Resize(ref stack, stack.Length - 1);
            return data;
        }
    }
}