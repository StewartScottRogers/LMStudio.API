namespace LinkedListApp
{
    public interface ILinkedList<T>
    {
        void InsertAtBeginning(T value);
        bool Search(T value);
        void Delete(T value);
    }
}