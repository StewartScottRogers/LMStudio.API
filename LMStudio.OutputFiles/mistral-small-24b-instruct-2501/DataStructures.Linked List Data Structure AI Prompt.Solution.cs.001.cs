using System.Collections.Generic;

namespace LinkedList.Interfaces
{
    public interface ILinkedList<T>
    {
        void InsertAtBeginning(T value);
        bool Delete(T value);
        bool Search(T value);
        IEnumerable<T> GetAllElements();
    }
}