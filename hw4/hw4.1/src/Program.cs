using System;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = "(* (+ 1 10) (- 3 (/ 10 5)))";
            Tree tree = new Tree();
            tree.MakeTree(expression);
            var result = tree.CalculateTree();
            Console.WriteLine(result);
        }
    }
}
