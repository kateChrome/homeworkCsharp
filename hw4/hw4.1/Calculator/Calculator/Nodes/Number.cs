namespace Calculator.Nodes
{
    /// <summary>
    /// Implementation of the class number.
    /// </summary>
    /// <seealso cref="Calculator.Nodes.INode" />
    public class Number : INode
    {
        private readonly int _value;
        public Number(int value) => this._value = value;

        public double Calculate() => _value;

        public string Print() => _value.ToString();
    }
}
