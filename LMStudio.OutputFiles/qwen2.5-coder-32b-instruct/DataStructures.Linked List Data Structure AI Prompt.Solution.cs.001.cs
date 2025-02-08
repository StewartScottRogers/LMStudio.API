using System.Collections.Generic;

public interface ILinkedList<T>
{
    bool IsEmpty { get; }
    void InsertAtBeginning(T data);
    bool Search(T data);
    bool Delete(T data);
    IEnumerable<T> Traverse();
}