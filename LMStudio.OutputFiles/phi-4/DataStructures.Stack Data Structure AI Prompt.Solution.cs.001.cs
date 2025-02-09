using System;
using System.Collections.Generic;

namespace StackLibrary
{
    /// <summary>
    /// A record representing a Stack data structure with basic operations.
    /// </summary>
    public record StackRecord<T>(readonly int capacity) : IStack<T>
    {
        private readonly List<T> _items = new();

        /// <summary>
        /// Checks if the stack is empty.
        /// </summary>
        public bool IsEmpty() => !_items.Any();

        /// <summary>
        /// Checks if the stack is full.
        /// </summary>
        public bool IsFull() => _items.Count == capacity;

        /// <summary>
        /// Adds an element to the top of the stack.
        /// </summary>
        public void Push(T item)
        {
            if (IsFull())
                throw new InvalidOperationException("Stack is full");
            _items.Add(item);
        }

        /// <summary>
        /// Removes and returns the element at the top of the stack.
        /// </summary>
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");

            var item = _items[^1];
            _items.RemoveAt(_items.Count - 1);
            return item;
        }

        /// <summary>
        /// Returns the element at the top of the stack without removing it.
        /// </summary>
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");

            return _items[^1];
        }
    }
}