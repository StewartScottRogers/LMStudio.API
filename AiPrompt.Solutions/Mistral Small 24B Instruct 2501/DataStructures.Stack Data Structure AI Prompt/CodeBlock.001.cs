namespace StackLibrary.Operations
{
    public interface IStackOperations<T>
    {
        bool IsEmpty { get; }
        bool IsFull { get; }
        void Push(T item);
        var PopTuple();
        T Peek();
    }
}