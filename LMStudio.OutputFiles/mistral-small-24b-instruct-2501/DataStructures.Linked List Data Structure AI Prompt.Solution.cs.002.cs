using System.Collections.Generic;
using LinkedList.DataStructures;
using LinkedList.Interfaces;

namespace LinkedList.DataStructures
{
    public class LinkedList<T> : ILinkedList<T>
    {
        private readonly LinkedListNode<T>? Head;

        public LinkedList()
        {
            this.Head = null;
        }

        // Inserts a new node at the beginning of the list.
        public void InsertAtBeginning(T value)
        {
            var newNode = new LinkedListNode<T>(value, this.Head);
            this.Head = newNode;
        }

        // Deletes the first occurrence of the specified value from the list.
        public bool Delete(T value)
        {
            if (this.Head == null) return false;

            if (this.Head.Value.Equals(value))
            {
                this.Head = this.Head.Next;
                return true;
            }

            var currentNode = this.Head;
            while (currentNode?.Next != null)
            {
                if (currentNode.Next.Value.Equals(value))
                {
                    currentNode.Next = currentNode.Next.Next;
                    return true;
                }
                currentNode = currentNode.Next;
            }

            return false;
        }

        // Searches for a specific element in the list.
        public bool Search(T value)
        {
            var currentNode = this.Head;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value)) return true;
                currentNode = currentNode.Next;
            }
            return false;
        }

        // Returns all elements in the list.
        public IEnumerable<T> GetAllElements()
        {
            var currentNode = this.Head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
        }
    }
}