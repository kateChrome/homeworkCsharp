using System;

namespace HwTreeDotOne
{
    class StartCalculate
    {
        public int GetMode() => Convert.ToInt32(Console.ReadLine());

        public string GetExpression() => Console.ReadLine();

        public StartCalculate(Calculator calculator, string expression) 
        => calculator(expression);

        static void Main(string[] args)
        {
            Console.Write("Enter stack mode (list = 0, array = 1): ");
            int mode = getMode();

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
            string expression = getExpression();
            double result = startCalculate(calculator, expression);
            Console.WriteLine($"Expression is equal {result}");
        }
    }
}
