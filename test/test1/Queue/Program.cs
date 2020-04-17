using System;
namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>("8 0", 8);
            queue.Enqueue("9 1", 9);
            queue.Enqueue("8 2", 8);
            queue.Enqueue("8 3", 8);
            queue.Enqueue("6 4", 6);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
        }
    }
}