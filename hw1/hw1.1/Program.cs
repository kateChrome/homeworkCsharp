using System;

namespace hw1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter value: ");
            int number = Convert.ToInt32(Console.ReadLine());

            int result = 1;
            while (number != 1)
            {
                result = result * number;
                number = number - 1;
            }

            Console.WriteLine("Factorial of the number is: " + result);
        }
    }
}
