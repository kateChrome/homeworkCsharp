using System;
using System.Collections.Generic;

namespace Calculator
{
    public class Solver : INode
    {
        public INode Expression { set; get; }
        public Solver(string expression)
        {
            this.Expression = BuildTree(expression);
        }

        private static INode BuildTree(string expression)
        {
            var parsedExpression = expression.Replace("(", "").Replace(")", "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var queue = new Queue<string>(parsedExpression);

            return BuildSubtree(queue);
        }

        private static INode BuildSubtree(Queue<string> queue)
        {
            var currentToken = queue.Dequeue();

            if (int.TryParse(currentToken, out var number))
            {
                return new Number(number);
            }

            return currentToken switch
            {
                "+" => new Addition(BuildSubtree(queue), BuildSubtree(queue)),
                "-" => new Subtraction(BuildSubtree(queue), BuildSubtree(queue)),
                "*" => new Multiplication(BuildSubtree(queue), BuildSubtree(queue)),
                "/" => new Division(BuildSubtree(queue), BuildSubtree(queue)),
                _ => throw new ArgumentException($"Unknown character {currentToken}")
            };
        }

        public string Print() => Expression.Print();
        public int Calculate() => Expression.Calculate();
    }
}
