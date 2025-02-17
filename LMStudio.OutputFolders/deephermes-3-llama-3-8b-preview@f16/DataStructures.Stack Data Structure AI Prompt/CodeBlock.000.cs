using System;
using System.Collections.Generic;

namespace StackImplementation
{
    // Interface for stack implementation
    public interface IStack<T>
    {
        void Push(T item);
        T Pop();
        bool IsEmpty { get; }
        bool IsFull { get; }
        T Peek();
    }

    // Custom exception class for stack overflow
    public class StackOverflowException : Exception
    {
        public StackOverflowException(string message) : base(message) { }
    }

    // Implementation of stack using List<T>
    public class StackList<T> : IStack<T>
    {
        private readonly List<T> _stack = new List<T>();

        // Push an element to the top of the stack
        public void Push(T item)
        {
            if (IsFull) throw new StackOverflowException("The stack is full.");

            _stack.Add(item);
        }

        // Remove and return the top element from the stack
        public T Pop()
        {
            if (IsEmpty) throw new InvalidOperationException("The stack is empty.");

            var result = Peek();
            _stack.RemoveAt(_stack.Count - 1);

            return result;
        }

        // Check if the stack is empty
        public bool IsEmpty => _stack.Count == 0;

        // Check if the stack is full
        public bool IsFull => _stack.Capacity == _stack.Count;

        // Get the value of the top element without removing it
        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("The stack is empty.");

            return _stack[_stack.Count - 1];
        }
    }

    // Test class for demonstration purposes
    public static class StackTest
    {
        // Example usage of the stack implementation
        public static void RunStackExample()
        {
            var stack = new StackList<int>();

            Console.WriteLine("Pushing elements onto the stack:");

            for (int i = 1; i <= 5; i++)
            {
                stack.Push(i);
                Console.WriteLine($"Pushed {i}");
            }

            // Peek at the top element
            var peekResult = stack.Peek();
            Console.WriteLine($"Peek: Top element is {peekResult}");

            // Pop elements from the stack
            for (int i = 1; i <= 5; i++)
            {
                var poppedValue = stack.Pop();
                Console.WriteLine($"Popped {poppedValue}");
            }

            // Check if the stack is empty after popping all elements
            Console.WriteLine($"Is stack empty? {stack.IsEmpty}");

            try
            {
                // Attempt to push an element on a full stack (throws StackOverflowException)
                stack.Push(6);
            }
            catch (StackOverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Check if the stack is full after pushing an element (should not be full due to exception)
            Console.WriteLine($"Is stack full? {stack.IsFull}");
        }
    }
}