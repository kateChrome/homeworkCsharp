using System;

namespace hwTwoDotThree
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Console.Write("Enter stack mode (list = 0, array = 1): ");
            int mode = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter expression: ");
            string expression = Console.ReadLine();
            Console.WriteLine($"Expression is equal {calculator.Calculate(expression, mode)}");
        }
    }
}
    