using System;
using System.Collections.Generic;

namespace StackDataStructureLibrary
{
    public class Stack<T> : IStack<T>
    {
        private readonly List<T> elements = new List<T>();
        private readonly int capacity;

        public Stack(int capacity)
        {
            this.capacity = capacity;
        }

        public void Push(T item)
        {
            if (IsFull())
                throw new InvalidOperationException("Stack is full.");

            elements.Add(item);
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            T item = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);

            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            return elements[elements.Count - 1];
        }

        public bool IsEmpty() => elements.Count == 0;

        public bool IsFull() => elements.Count >= capacity;
    }
}