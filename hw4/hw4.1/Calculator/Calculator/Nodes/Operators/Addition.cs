﻿namespace Calculator.Nodes.Operators
{
    public class Addition : Operator
    {
        public Addition(INode leftNode, INode rightNode) : base(leftNode, rightNode)
        {
        }

        protected sealed override char OperationSymbol => '+';

        public sealed override double Calculate() => LeftNode.Calculate() + RightNode.Calculate();
    }
}