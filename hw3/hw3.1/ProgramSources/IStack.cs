namespace Program.Services
{
    public interface IStack
    {
        bool IsEmpty();

        void Push(double value);

        double Pop();
    }
}