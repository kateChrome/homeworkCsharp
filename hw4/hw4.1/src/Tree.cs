using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace src
{
    public class Tree
    {
        private Node head;
        private string pattern = @"\(([+\-*/]) (\(.*\)|\d+) (\(.*\)|\d+)\)";

        public Tree() { head = new Node(); }

        private string[] ParseCurrentString(string stringOfExpression)
            => Regex.Split(stringOfExpression, pattern);

        private void MakeCurrentBranch(Node currentNode, string expression)
        {
            if (Regex.IsMatch(expression, @"\d+$"))
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

        
    }
}

