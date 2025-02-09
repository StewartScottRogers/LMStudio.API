namespace LinkedListDataStructure
{
    public interface ILinkedList<T>
    {
        void InsertAtBeginning(T value);
        bool Search(T value);
        bool Delete(T value);
        string Display();
    }
}