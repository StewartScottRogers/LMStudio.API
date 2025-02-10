using System;
using System.Collections.Generic;

namespace StackLibrary
{
    public class Stack<T> : IStack<T>
    {
        private readonly List<T> elements;
        private readonly int maxSize;

        // Constructor with a specified maximum size.
        public Stack(int maxSize)
        {
            this.maxSize = maxSize;
            elements = new List<T>(maxSize);
        }

        // Push an item onto the stack.
        public void Push(T item)
        {
            if (IsFull())
                throw new InvalidOperationException("Stack is full.");

            elements.Add(item);
        }

        // Pop an item from the stack.
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            var item = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);

            return item;
        }

        // Check if the stack is empty.
        public bool IsEmpty() => elements.Count == 0;

        // Check if the stack is full.
        public bool IsFull() => elements.Count >= maxSize;

        // Peek at the top item without removing it.
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            return elements[elements.Count - 1];
        }
    }
}