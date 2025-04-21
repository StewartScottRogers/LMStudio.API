// StackDataStructure.sln

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when type has no parameterless constructor.

using Microsoft.VisualStudio.TestTools.UnitTests;
using System;

namespace StackDataStructureLibrary
{
    // Define an enumeration for stack status.
    public enum StackStatus
    {
        Empty,
        Full
    }

    // Record to represent the result of a pop operation.
    public record PopResult(bool Success, object? Value);

    // Interface defining the stack operations.
    public interface IStack
    {
        void Push(object value);
        PopResult Pop();
        bool IsEmpty();
        bool IsFull();
        object? Peek();
    }

    // Class implementing the stack data structure using an array.
    public class Stack : IStack
    {
        private readonly object[] _stackArray; // Array to store stack elements.
        private int _topIndex = -1; // Index of the top element in the stack.
        private readonly int _capacity; // Maximum capacity of the stack.

        // Constructor to initialize the stack with a specified capacity.
        public Stack(int capacity)
        {
            _capacity = capacity;
            _stackArray = new object[capacity];
        }

        // Method to add an element to the top of the stack.
        public void Push(object value)
        {
            if (IsFull())
            {
                throw new StackOverflowException("Stack is full.");
            }

            _topIndex++;
            _stackArray[_topIndex] = value;
        }

        // Method to remove and return the element from the top of the stack.
        public PopResult Pop()
        {
            if (IsEmpty())
            {
                return new PopResult(false, null); // Return false if the stack is empty.
            }

            var value = _stackArray[_topIndex];
            _stackArray[_topIndex] = null; // Set the popped element to null.
            _topIndex--;
            return new PopResult(true, value); // Return true and the popped value if successful.
        }

        // Method to check if the stack is empty.
        public bool IsEmpty()
        {
            return _topIndex == -1;
        }

        // Method to check if the stack is full.
        public bool IsFull()
        {
            return _topIndex == _capacity - 1;
        }

        // Method to get the value of the top element without removing it.
        public object? Peek()
        {
            if (IsEmpty())
            {
                return null; // Return null if the stack is empty.
            }

            return _stackArray[_topIndex];
        }
    }
}