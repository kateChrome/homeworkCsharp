namespace Calculator.Nodes.Operators
{
    public class Subtraction : Operator
    {
        public Subtraction(INode leftNode, INode rightNode) : base(leftNode, rightNode)
        { }

        protected sealed override char OperationSymbol => '-';

        public sealed override int Calculate() => LeftNode.Calculate() - RightNode.Calculate();
    }
}