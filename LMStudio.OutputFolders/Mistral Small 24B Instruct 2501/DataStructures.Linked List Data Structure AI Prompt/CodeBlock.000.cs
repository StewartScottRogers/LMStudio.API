using System;
using Microsoft.VisualBasic;

namespace LinkedListProject
{
    public class LinkedList : ILinkedList
    {
        private Node Head { get; set; }

        // Method to insert an element at the beginning of the linked list.
        public void InsertAtBeginning(int value)
        {
            var newNode = new Node(value);
            newNode.Next = Head;
            Head = newNode;
        }

        // Method to delete a specific element from the linked list.
        public bool DeleteElement(int value)
        {
            if (Head == null) return false;

            if (Head.Value == value)
            {
                Head = Head.Next;
                return true;
            }

            var current = Head;
            while (current.Next != null && current.Next.Value != value)
            {
                current = current.Next;
            }

            if (current.Next == null) return false;

            current.Next = current.Next.Next;
            return true;
        }

        // Method to search for a specific element in the linked list.
        public bool SearchElement(int value)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Value == value) return true;
                current = current.Next;
            }
            return false;
        }

        // Method to print all elements in the linked list.
        public void PrintList()
        {
            var current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
            }
        }
    }
}