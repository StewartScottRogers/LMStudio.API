// LinkedList.cs
using System;

namespace LinkedListDataStructure
{
    public class LinkedList
    {
        private LinkedListNode Head { get; set; }

        public LinkedList()
        {
            Head = null;
        }

        public void InsertAtBeginning(int data)
        {
            // Create a new node with the given data.
            LinkedListNode newNode = new LinkedListNode(data);

            // Make the new node point to the current head.
            newNode.Next = Head;

            // Update the head to be the new node.
            Head = newNode;
        }

        public void DeleteElement(int data)
        {
            // If the list is empty, there's nothing to delete.
            if (Head == null)
            {
                return;
            }

            // If the element to be deleted is at the beginning of the list.
            if (Head.Data == data)
            {
                Head = Head.Next;
                return;
            }

            // Traverse the list to find the element to delete.
            LinkedListNode current = Head;
            while (current.Next != null && current.Next.Data != data)
            {
                current = current.Next;
            }

            // If the element is found, remove it from the list.
            if (current.Next != null)
            {
                current.Next = current.Next.Next;
            }
        }

        public bool SearchElement(int data)
        {
            // Traverse the list to find the element.
            LinkedListNode current = Head;
            while (current != null)
            {
                if (current.Data == data)
                {
                    return true; // Element found.
                }
                current = current.Next;
            }

            return false; // Element not found.
        }

        public void DisplayList()
        {
            LinkedListNode current = Head;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
}