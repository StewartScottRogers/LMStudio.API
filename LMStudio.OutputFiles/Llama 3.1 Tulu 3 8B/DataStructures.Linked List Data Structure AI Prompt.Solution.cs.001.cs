using System.Collections.Generic;

public interface ILinkedList<T>
{
    void AddFirst(T item);
    bool Contains(T item);
    void Remove(T item);
    int Count { get; }
}