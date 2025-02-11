// IStackInterface.cs
public interface IStackInterface<T>
{
    void Push(T item);
    T Pop();
    T Peek();
    bool IsEmpty();
    bool IsFull();
}