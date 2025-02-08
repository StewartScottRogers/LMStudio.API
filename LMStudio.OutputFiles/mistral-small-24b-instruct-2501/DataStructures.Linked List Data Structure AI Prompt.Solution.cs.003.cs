using LinkedListDataStructure.Interfaces;

namespace LinkedListDataStructure.Classes
{
    public class LinkedListNode<T> : ILinkedListNode<T>
    {
        public T Data { get; set; }
        public ILinkedListNode<T> Next { get; set; }

        public LinkedListNode(T data)
        {
            this.Data = data;
            this.Next = null;
        }
    }
}