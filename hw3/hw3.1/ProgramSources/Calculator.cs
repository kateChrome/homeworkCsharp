using System;

namespace Program.Services
{
    public class Calculator
    {
        private IStack stack;
        private int systemBase = 10;

        public Calculator(IStack stack) { this.stack = stack; }
        private void CheckStackForUnemptiness()
        {
            if (!stack.IsEmpty())
            {
                throw new Exception("incorrect expression");
            }
        }
        private void CheckStackForEmptiness()
        {
            if (stack.IsEmpty())
            {
                throw new Exception("incorrect expression");
            }
        }

        private (double, double) getTwoValuesFromStack()
        {
            CheckStackForEmptiness();
            var value1 = stack.Pop();
            CheckStackForEmptiness();
            var value2 = stack.Pop();

            return (value1, value2);
        }
        public double Calculate(string expression)
        {

            var number = 0;
            bool isNumber = true;
            foreach (var item in expression)
            {
                if (char.IsDigit(item))
                {
                    isNumber = true;
                    number = number * systemBase + int.Parse(item.ToString());
                    continue;
                }
                else if (isNumber)
                {
                    stack.Push(number);
                    number = 0;
                    isNumber = false;
                }

                switch (item)
                {
                    case '+':
                        {
                            var (value1, value2) = getTwoValuesFromStack();
                            stack.Push(value2 + value1);
                            break;
                        }
                    case '-':
                        {
                            var (value1, value2) = getTwoValuesFromStack();
                            stack.Push(value2 - value1);
                            break;
                        }
                    case '*':
                        {
                            var (value1, value2) = getTwoValuesFromStack();
                            stack.Push(value2 * value1);
                            break;
                        }
                    case '/':
                        {
                            var (value1, value2) = getTwoValuesFromStack();
                            stack.Push(value2 / value1);
                            break;
                        }
                    case ' ':
                        {
                            continue;
                        }
                    default:
                        {
                            throw new Exception("unknown character");
                        }
                }
            }
            CheckStackForEmptiness();
            var result = stack.Pop();
            CheckStackForUnemptiness();
            return result;
        }
    }
}