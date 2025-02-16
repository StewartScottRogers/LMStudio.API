using System;
using StackDataStructure.Interfaces;

namespace StackDataStructure
{
    /// <summary>
    /// Class that implements the stack data structure.
    /// </summary>
    public class StackClass<Type> : IStack<Type>
    {
        private const int MaxSize = 100; // Maximum size of the stack.
        private readonly Type[] elements;
        private int top;

        public StackClass()
        {
            this.elements = new Type[MaxSize];
            this.top = -1;
        }

        /// <summary>
        /// Adds an element to the top of the stack.
        /// </summary>
        /// <param name="element">The element to be added.</param>
        public void Push(Type element)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Stack is full.");
            }
            elements[++top] = element;
        }

        /// <summary>
        /// Removes and returns the top element of the stack.
        /// </summary>
        /// <returns>The top element of the stack.</returns>
        public Type Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return elements[top--];
        }

        /// <summary>
        /// Checks if the stack is empty.
        /// </summary>
        /// <returns>True if the stack is empty, otherwise false.</returns>
        public bool IsEmpty()
        {
            return top == -1;
        }

        /// <summary>
        /// Checks if the stack is full.
        /// </summary>
        /// <returns>True if the stack is full, otherwise false.</returns>
        public bool IsFull()
        {
            return top == MaxSize - 1;
        }

        /// <summary>
        /// Returns the value of the top element without removing it.
        /// </summary>
        /// <returns>The top element of the stack.</returns>
        public Type Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return elements[top];
        }
    }
}