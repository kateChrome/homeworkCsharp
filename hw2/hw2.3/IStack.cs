namespace hwTwoDotThree
{
    interface IStack
    {
        bool IsEmpty();

        void Push(int value);

        int Pop();
    }
}