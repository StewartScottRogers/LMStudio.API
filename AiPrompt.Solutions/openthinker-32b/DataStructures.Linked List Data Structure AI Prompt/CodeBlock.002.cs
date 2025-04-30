namespace LinkedListSolution
{
    public interface IListOperations<T>
    {
        bool IsEmpty { get; }
        void InsertAtBeginning(T value);
        (bool Found, T? Value) FindElement(T value);
        bool DeleteElement(T value);
    }
}