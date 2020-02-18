using System;

namespace Hw1._1
{
    class Factorial
    {
        static int ComputeFactorial(int value)
        {
            int result = 1;
            while (value != 1)
            {
                result = result * value;
                value--;
            }
            return result;
        }
        
        static void Main(string[] args)
        {
            Console.Write("Enter value: ");
            int number = Convert.ToInt32(Console.ReadLine());

            int result = ComputeFactorial(number);

            Console.WriteLine($"Factorial of the number is: {result}");
        }
    }
}
