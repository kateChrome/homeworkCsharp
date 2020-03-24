using System;

namespace src
{
    public abstract class Node
    {
        public abstract Number Calculate();

        public abstract void Print();

        public Number Number()
        {
            return Calculate();
        }
    }
}