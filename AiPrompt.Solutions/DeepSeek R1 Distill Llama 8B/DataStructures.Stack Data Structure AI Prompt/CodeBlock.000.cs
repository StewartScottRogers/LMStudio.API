using System.Collections.Generic;

public interface IStack<T>
{
    void Push(T value);
    T Pop();
    bool IsEmpty();
    bool IsFull();
    T Peek();
}