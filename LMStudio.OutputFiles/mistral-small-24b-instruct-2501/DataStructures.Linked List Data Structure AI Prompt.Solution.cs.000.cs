namespace LinkedListDataStructure.Interfaces
{
    public interface ILinkedListNode<T>
    {
        T Data { get; set; }
        ILinkedListNode<T> Next { get; set; }
    }
}