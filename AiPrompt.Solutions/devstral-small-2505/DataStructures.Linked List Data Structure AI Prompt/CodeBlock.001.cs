using System;

namespace MyLinkedList
{
    /// <summary>
    /// Implements a singly linked list.
    /// </summary>
    public class LinkedList
    {
        private readonly LinkedListNode head;
        private int count;

        public LinkedList()
        {
            this.head = null;
            this.count = 0;
        }

        /// <summary>
        /// Adds an element at the beginning of the linked list.
        /// </summary>
        /// <param name="value">The value to be added.</param>
        public void InsertAtBeginning(int value)
        {
            var newNode = new LinkedListNode(value, this.head);
            this.head = newNode;
            count++;
        }

        /// <summary>
        /// Deletes the first occurrence of a specific element from the linked list.
        /// </summary>
        /// <param name="value">The value to be deleted.</param>
        public void Delete(int value)
        {
            if (head == null) return;

            if (this.head.Value == value)
            {
                this.head = head.Next;
                count--;
                return;
            }

            var currentNode = head;
            while (currentNode.Next != null && currentNode.Next.Value != value)
            {
                currentNode = currentNode.Next;
            }

            if (currentNode.Next != null)
            {
                currentNode.Next = currentNode.Next.Next;
                count--;
            }
        }

        /// <summary>
        /// Searches for a specific element in the linked list.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>True if found, otherwise false.</returns>
        public bool Search(int value)
        {
            var currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Value == value) return true;
                currentNode = currentNode.Next;
            }

            return false;
        }
    }
}