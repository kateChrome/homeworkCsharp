namespace src
{
    public class Number : Node
    {
        public int Data { get; set; }
        public override Number Calculate()
        {
            return this;
        }

        public override void Print()
        {
            System.Console.Write(Data);
        }
    }
}