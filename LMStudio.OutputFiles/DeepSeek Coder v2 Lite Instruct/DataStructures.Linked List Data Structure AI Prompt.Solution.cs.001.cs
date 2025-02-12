using System;
using LinkedListNamespace.Interfaces;

namespace LinkedListNamespace
{
    public class LinkedList<T> : ILinkedList<T>
    {
        private Node<T> head;

        public void AddFirst(T value)
        {
            var newNode = new Node<T>(value);
            newNode.Next = head;
            head = newNode;
        }

        // Implement other methods like Remove, Search, etc.
    }
}