using System;

namespace HwTreeDotOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter stack mode (list = 0, array = 1): ");
            int mode = Convert.ToInt32(Console.ReadLine());

            IStack stack;
            switch (mode)
            {
                case 0:
                    {
                        stack = new ListStack();
                        break;
                    }
                case 1:
                    {
                        stack = new ArrayStack();
                        break;
                    }
                default:
                    throw new Exception("mode does not exist");
            }

            Calculator calculator = new Calculator(stack);
            Console.Write("Enter expression: ");
            string expression = Console.ReadLine();
            Console.WriteLine($"Expression is equal {calculator.Calculate(expression)}");
        }
    }
}
