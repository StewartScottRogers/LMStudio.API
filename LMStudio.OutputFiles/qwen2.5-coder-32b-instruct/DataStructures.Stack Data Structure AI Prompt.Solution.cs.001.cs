using System;
using System.Collections.Generic;

namespace StackDataStructure
{
    public class Stack<T> : IStack<T>
    {
        private readonly List<T> items;
        private readonly int capacity;

        public Stack(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be greater than zero.");

            this.capacity = capacity;
            items = new List<T>(capacity);
        }

        public void Push(T item)
        {
            if (IsFull())
                throw new InvalidOperationException("Stack is full.");
            
            items.Add(item);
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            var topItem = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            return topItem;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");
            
            return items[items.Count - 1];
        }

        public bool IsEmpty() => items.Count == 0;

        public bool IsFull() => items.Count >= capacity;
    }
}