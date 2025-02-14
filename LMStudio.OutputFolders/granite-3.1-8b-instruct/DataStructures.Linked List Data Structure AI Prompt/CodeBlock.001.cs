public interface ILinkedList<T> where T: notnull
{
    bool Search(T item, out Node? foundNode);
    void InsertAtBeginning(T item);
    void Delete(Node nodeToDelete);
}