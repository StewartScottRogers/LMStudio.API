namespace StackLibrary
{
    public interface IStack
    {
        void Push(int element);
        int Pop();
        bool IsEmpty();
        bool IsFull();
        int Peek();
    }
}