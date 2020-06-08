namespace Calculator.Nodes
{
    /// <summary>
    /// Implementation of the interface INode.
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Prints this Node.
        /// </summary>
        public string Print();

        /// <summary>
        /// Calculates this Node.
        /// </summary>
        public double Calculate();
    }
}
