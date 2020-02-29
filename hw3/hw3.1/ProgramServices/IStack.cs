namespace HwTreeDotOne
{
    public interface IStack
    {
        bool IsEmpty();

        void Push(double value);

        double Pop();
    }
}