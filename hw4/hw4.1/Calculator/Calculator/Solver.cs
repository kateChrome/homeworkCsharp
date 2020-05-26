using System;
using System.Collections.Generic;
using Calculator.Nodes;
using Calculator.Nodes.Operators;

namespace Calculator
{
    public class Solver
    {
        public INode Expression { set; get; }

        public Solver(string expression)
        {
            this.Expression = BuildTree(expression);
        }

        /// <summary>
        /// Split the expression string into a tree.
        /// </summary>
        private static INode BuildTree(string expression)
        {
            var parsedExpression = expression.Replace("(", "").Replace(")", "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var queue = new Queue<string>(parsedExpression);

            return BuildSubtree(queue);
        }

        /// <summary>
        /// Builds the subtree.
        /// </summary>
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

        /// <summary>
        /// Prints this expression.
        /// </summary>
        public string Print() => Expression.Print();

        /// <summary>
        /// Calculates this expression.
        /// </summary>
        public int Calculate() => Expression.Calculate();
    }
}
