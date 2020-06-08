namespace Calculator.Nodes.Operators
{
    public abstract class Operator : INode
    {
        protected readonly INode LeftNode;
        protected readonly INode RightNode;

        protected abstract char OperationSymbol { get; }
        protected Operator(INode leftNode, INode rightNode)
        {
            LeftNode = leftNode;
            RightNode = rightNode;
        }

        public abstract double Calculate();

        public string Print() => $"({OperationSymbol} {LeftNode.Print()} {RightNode.Print()})";
    }
}
