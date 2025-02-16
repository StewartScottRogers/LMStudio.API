using System;

namespace LinkedListApp
{
    public class LinkedList<T> : ILinkedList<T>
    {
        private LinkedListNode<T> head;

        public LinkedList()
        {
            head = null;
        }

        public void InsertAtBeginning(T value)
        {
            var newNode = new LinkedListNode<T>(value)
            {
                Next = head
            };
            head = newNode;
        }

        public bool Search(T value)
        {
            var current = head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Delete(T value)
        {
            if (head == null) return;

            if (head.Value.Equals(value))
            {
                head = head.Next;
                return;
            }

            var current = head;
            while (current.Next != null && !current.Next.Value.Equals(value))
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
            }
        }
    }
}