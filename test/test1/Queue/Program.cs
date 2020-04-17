using System;
namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> q = new Queue<string>("8 0", 8);
            q.Enqueue("9 1", 9);
            q.Enqueue("8 2", 8);
            q.Enqueue("8 3", 8);
            q.Enqueue("6 4", 6);
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
        }
    }
}