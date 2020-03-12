using System;

namespace src
{
    class Program
    {
        static void Main(string[] args)
        {
            // string expression = "(* (+ 1 10) (- 3 (/ 10 5)))";
            string expression = "(+ (/ (* (+ 1 10) (- 3 (/ 10 5))) 11) (- 5 3))";
            Tree tree = new Tree();
            tree.MakeTree(expression);
            var result = tree.CalculateTree();
            Console.WriteLine(result);
        }
    }
}
