namespace StackLibrary;

public interface IStack<T>
{
    void Push(T item);
    T Pop();
    T Peek();
    bool IsEmpty { get; }
    bool IsFull { get; }
}