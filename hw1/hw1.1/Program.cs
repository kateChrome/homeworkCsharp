using System;

namespace Hw1._1
{
    class Factorial
    {
        static int computingFactorial(int value)
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

            int result = computingFactorial(number);

            Console.WriteLine($"Factorial of the number is: {result}");
        }
    }
}
