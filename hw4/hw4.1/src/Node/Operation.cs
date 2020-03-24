namespace src
{
    public abstract class Operation : Node
    {
        private INode operand1;
        private INode operand2;

        public Operation(INode operand1, INode operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }

        public override Number Calculate()
        {
            return Calculate(operand1, operand2);
        }

        protected abstract void PrintSign();

        protected abstract Number Calculate(Number operand1, Number operand2);
    }
}