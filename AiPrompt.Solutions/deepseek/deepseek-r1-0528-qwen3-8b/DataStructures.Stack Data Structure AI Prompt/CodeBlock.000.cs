// IStack.cs
namespace StackInterface;

public interface IStack<T>
{
    bool IsEmpty();
    
    void Push(T item);
    
    T Pop();
    
    T Peek();

    // Favor use of Records for complex data structures
    record struct StackResult<T>(int Success, string Message, int Count) { }
}