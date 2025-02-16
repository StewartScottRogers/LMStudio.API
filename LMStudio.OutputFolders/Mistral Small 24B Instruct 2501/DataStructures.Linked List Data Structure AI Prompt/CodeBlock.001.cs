namespace Interfaces
{
    /// <summary>
    /// Defines the interface for a linked list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public interface ILinkedList<T>
    {
        void InsertAtBeginning(T value);
        bool DeleteElement(T value);
        LinkedListElement<T> SearchElement(T value);

        var TupleGetAllElements();
    }
}