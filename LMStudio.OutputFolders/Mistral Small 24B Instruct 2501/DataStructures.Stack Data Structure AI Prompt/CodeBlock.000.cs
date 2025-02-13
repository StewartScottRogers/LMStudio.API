using System;
using System.Collections.Generic;

namespace StackLibrary
{
    public class Stack<T>
    {
        private readonly List<T> stackList;
        private const int DefaultCapacity = 10;

        public Stack(int capacity = DefaultCapacity)
        {
            stackList = new List<T>(capacity);
        }

        /// <summary>
        /// Push an element onto the top of the stack.
        /// </summary>
        /// <param name="item">The item to push.</param>
        public void Push(T item)
        {
            if (IsFull())
                throw new InvalidOperationException("Stack is full.");
            stackList.Add(item);
        }

        /// <summary>
        /// Pop the top element from the stack.
        /// </summary>
        /// <returns>The popped item.</returns>
        public var PopElementTuple => GetTopElementTuple();

        private (bool Success, T Element) GetTopElementTuple()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");
            var topElement = stackList[^1];
            stackList.RemoveAt(stackList.Count - 1);
            return (true, topElement);
        }

        /// <summary>
        /// Check if the stack is empty.
        /// </summary>
        /// <returns>True if the stack is empty; otherwise, false.</returns>
        public bool IsEmpty()
        {
            return stackList.Count == 0;
        }

        /// <summary>
        /// Check if the stack is full.
        /// </summary>
        /// <returns>True if the stack is full; otherwise, false.</returns>
        public bool IsFull()
        {
            return stackList.Count >= DefaultCapacity;
        }

        /// <summary>
        /// Get the value of the top element without removing it.
        /// </summary>
        /// <returns>The top element.</returns>
        public var PeekElementTuple
        {
            get
            {
                if (IsEmpty())
                    throw new InvalidOperationException("Stack is empty.");
                return (true, stackList[^1]);
            }
        }
    }
}