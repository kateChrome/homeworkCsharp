using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;

namespace src
{
    public class Tree
    {
        private Node head;
        private string pattern = @"\(([+\-*/]) (\(.*\)|\d+) (\(.*\)|\d+)\)";

        public Tree() { head = new Node(); }

        private string[] ParseCurrentString(string stringOfExpression)
            => Regex.Split(stringOfExpression, pattern);

        private bool isNumber(string inputString) => Regex.IsMatch(inputString, @"\d+$");

        private void MakeCurrentBranch(Node currentNode, string expression)
        {
            if (isNumber(expression))
            {
                currentNode.Data = expression;
            }
            else
            {
                string[] parsedExpression = ParseCurrentString(expression);

                currentNode.Data = parsedExpression[1];
                currentNode.LeftNode = new Node();
                currentNode.RightNode = new Node();

                MakeCurrentBranch(currentNode.LeftNode, parsedExpression[2]);
                MakeCurrentBranch(currentNode.RightNode, parsedExpression[3]);
            }
        }

        public void MakeTree(string expression)
        {
            MakeCurrentBranch(head, expression);
        }

        private string calulateSimpleExpression(string currentOperator, int operand1, int operand2)
        {
            switch (currentOperator)
            {
                case "+":
                    {
                        return (operand1 + operand2).ToString();
                    }
                case "-":
                    {
                        return (operand1 - operand2).ToString();
                    }
                case "*":
                    {
                        return (operand1 * operand2).ToString();
                    }
                case "/":
                    {
                        return (operand1 / operand2).ToString();
                    }
                default:
                    {
                        return "lol";
                    }
            }
        }

        private void CalculateCurrentBranch(Node currentNode)
        {
            if (isNumber(currentNode.Data) || currentNode == null || currentNode.LeftNode == null || currentNode.RightNode == null)
            {
                return;
            }

            CalculateCurrentBranch(currentNode.LeftNode);
            CalculateCurrentBranch(currentNode.RightNode);
            if (isNumber(currentNode.LeftNode.Data) && isNumber(currentNode.RightNode.Data))
            {
                currentNode.Data = calulateSimpleExpression(currentNode.Data, int.Parse(currentNode.LeftNode.Data), int.Parse(currentNode.RightNode.Data));
                currentNode.RightNode = null;
                currentNode.LeftNode = null;
            }
        }

        public string CalculateTree()
        {
            CalculateCurrentBranch(head);
            return head.Data;
        }

    }
}

