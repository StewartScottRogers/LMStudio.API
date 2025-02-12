namespace DataStructures;

public interface ILinkedList<T>
{
    void InsertAtBeginning(T value);
    bool DeleteElement(T value);
    Node<T> SearchElement(T value);
    int Count { get; }
}