namespace src
{
    public sealed class Addition : Operation
    {
        public Addition(INode operand1, INode operand2) : base(operand1, operand2)
        {
        }

        protected override void PrintSign()
        {
            System.Console.Write("*");
        }

        protected override Number Calculate(Number operand1, Number operand2)
        {
            return new Number(operand1.Data * operand2.Data);
        }
    }
}