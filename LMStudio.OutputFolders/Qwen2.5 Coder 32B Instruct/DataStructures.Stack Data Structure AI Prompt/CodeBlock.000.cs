using System;
using System.Collections.Generic;

namespace StackLibrary
{
    public class Stack<T>
    {
        private readonly List<T> elements;
        private readonly int capacity;

        public Stack(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be greater than zero.");

            this.capacity = capacity;
            elements = new List<T>();
        }

        /// <summary>
        /// Adds an element to the top of the stack.
        /// </summary>
        /// <param name="value">The value to add.</param>
        public void Push(T value)
        {
            if (IsFull())
                throw new InvalidOperationException("Stack is full.");

            elements.Add(value);
        }

        /// <summary>
        /// Removes and returns the top element of the stack.
        /// </summary>
        /// <returns>The top element of the stack.</returns>
        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            var topElement = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            return topElement;
        }

        /// <summary>
        /// Returns the top element of the stack without removing it.
        /// </summary>
        /// <returns>The top element of the stack.</returns>
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            return elements[elements.Count - 1];
        }

        /// <summary>
        /// Checks if the stack is empty.
        /// </summary>
        /// <returns>True if the stack is empty, otherwise false.</returns>
        public bool IsEmpty()
        {
            return elements.Count == 0;
        }

        /// <summary>
        /// Checks if the stack is full.
        /// </summary>
        /// <returns>True if the stack is full, otherwise false.</returns>
        public bool IsFull()
        {
            return elements.Count >= capacity;
        }
    }
}