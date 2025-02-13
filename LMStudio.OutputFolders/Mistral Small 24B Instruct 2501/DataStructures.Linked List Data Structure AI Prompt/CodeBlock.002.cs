namespace LinkedListProject
{
    public interface ILinkedList
    {
        void InsertAtBeginning(int value);
        bool DeleteElement(int value);
        bool SearchElement(int value);
        void PrintList();
    }
}