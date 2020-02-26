using System;

namespace hwTwoDotThree
{
    public class Calculator
    {
        private static IStack stack;
        private int systemBase = 10;

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
        public double Calculate(string expression, int mode)
        {
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
                else if (!char.IsDigit(item) && isNumber == true)
                {
                    stack.Push(number);
                    number = 0;
                    isNumber = false;
                }

                switch (item)
                {
                    case '+':
                        {
                            var twoValues = getTwoValuesFromStack();
                            var value1 = twoValues.Item1;
                            var value2 = twoValues.Item2;
                            stack.Push(value2 + value1);
                            break;
                        }
                    case '-':
                        {
                            var twoValues = getTwoValuesFromStack();
                            var value1 = twoValues.Item1;
                            var value2 = twoValues.Item2;
                            stack.Push(value2 - value1);
                            break;
                        }
                    case '*':
                        {
                            var twoValues = getTwoValuesFromStack();
                            var value1 = twoValues.Item1;
                            var value2 = twoValues.Item2;
                            stack.Push(value2 * value1);
                            break;
                        }
                    case '/':
                        {
                            var twoValues = getTwoValuesFromStack();
                            var value1 = twoValues.Item1;
                            var value2 = twoValues.Item2;
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