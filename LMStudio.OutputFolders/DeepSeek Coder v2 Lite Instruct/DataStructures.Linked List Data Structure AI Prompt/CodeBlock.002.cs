using System;

namespace LinkedListApp
{
    public class SinglyLinkedList<T> : ILinkedListOperations<T>
    {
        private LinkedListNode<T> head;

        public SinglyLinkedList()
        {
            head = null;
        }

        public void InsertAtBeginning(T value)
        {
            var newNode = new LinkedListNode<T>(value);
            newNode.Next = head;
            head = newNode;
        }

        public bool Search(T value)
        {
            var current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public bool Delete(T value)
        {
            if (head == null) return false;

            if (head.Value.Equals(value))
            {
                head = head.Next;
                return true;
            }

            var current = head;
            while (current.Next != null && !current.Next.Value.Equals(value))
            {
                current = current.Next;
            }

            if (current.Next == null) return false;

            current.Next = current.Next.Next;
            return true;
        }
    }
}