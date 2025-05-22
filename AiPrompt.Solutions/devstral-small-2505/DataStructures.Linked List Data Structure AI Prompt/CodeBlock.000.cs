namespace MyLinkedList
{
    /// <summary>
    /// Represents a single node in the linked list.
    /// </summary>
    public class LinkedListNode
    {
        public readonly int Value;
        public readonly LinkedListNode Next;

        public LinkedListNode(int value, LinkedListNode next = null)
        {
            Value = value;
            Next = next;
        }
    }
}