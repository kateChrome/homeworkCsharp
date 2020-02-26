using System;

namespace hwTwoDotThree
{
    public class Calculator
    {
        private static IStack stack;
        private int systemBase = 10;

        public int Calculate(string expression, int choise)
        {
            switch (choise)
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
                    throw new Exception("type does not exist");
            }

            int number = 0;
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
                            int value1 = stack.Pop();
                            int value2 = stack.Pop();
                            stack.Push(value2 + value1);
                            break;
                        }
                    case '-':
                        {
                            int value1 = stack.Pop();
                            int value2 = stack.Pop();
                            stack.Push(value2 - value1);
                            break;
                        }
                    case '*':
                        {
                            int value1 = stack.Pop();
                            int value2 = stack.Pop();
                            stack.Push(value2 * value1);
                            break;
                        }
                    case '/':
                        {
                            int value1 = stack.Pop();
                            int value2 = stack.Pop();
                            stack.Push(value2 / value1);
                            break;
                        }
                    case ' ':
                        {
                            continue;
                        }
                    default:
                        {
                            throw new Exception("Unknown character");
                        }
                }
            }
            return stack.Pop();
        }
    }
}