namespace LinkedListApp
{
    public interface ILinkedListOperations<T>
    {
        void InsertAtBeginning(T value);
        bool Search(T value);
        bool Delete(T value);
    }
}