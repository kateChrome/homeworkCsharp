using System;
using System.IO;

namespace Calculator
{
    public class Program
    {
        public static void Main()
        {
            var expression = File.ReadAllText("expression.txt");
            var tree = new Solver(expression);
            Console.WriteLine(tree.Print());
            Console.WriteLine(tree.Calculate());
        }
    }
}
