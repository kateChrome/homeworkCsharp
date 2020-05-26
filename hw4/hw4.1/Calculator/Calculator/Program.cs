using System;

namespace Calculator
{
    public class Program
    {
        public static void Main()
        {
            const string expression = "(* (+ 1 1) 2)";
            var tree = new Solver(expression);
            Console.WriteLine(tree.Print());
            Console.WriteLine(tree.Calculate());
        }
    }
}
