namespace hwTwoDotThree
{
    interface IStack
    {
        bool IsEmpty();

        void Push(double value);

        double Pop();
    }
}