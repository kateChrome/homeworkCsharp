using System;

namespace UniqueList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            list.PrintList();

            list.Clear();

            list.PrintList();

            for (int i = 10; i > 0; i--)
            {
                list.Add(i);
            }

            list.PrintList();

            Console.WriteLine($"Does exist 3? {list.Exists(3)}");
            
            Console.WriteLine($"What index has 4? {list.FindIndex(4)}");

            list.Insert(4, 101);
            
            list.PrintList();

            list.Remove(101);
            
            list.PrintList();

            list.RemoveAt(6);

            list.PrintList();

            Console.WriteLine($"List has {list.Count} elements");
        }
    }
}
