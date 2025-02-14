using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<int>(5);

            // Test push and pop methods
            for (var i = 0; i < 10; i++)
            {
                try
                {
                    stack.Push(i);
                    Console.WriteLine($"Pushed {i} to stack.");
                }
                catch (InvalidOperationException e) when (e.Message == "Cannot pop from an empty stack.")
                {
                    Console.WriteLine("Stack is already empty, cannot pop.");
                }
            }

            for (var i = 0; i < 5; i++)
            {
                try
                {
                    Console.WriteLine($"Popped {stack.Pop()} from stack.");
                }
                catch (InvalidOperationException e) when (e.Message == "Cannot pop from an empty stack.")
                {
                    Console.WriteLine("Stack is already empty, cannot pop.");
                }
            }
        }
    }
}