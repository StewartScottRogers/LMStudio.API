Below is a detailed implementation of a stack data structure in C# using .NET 9.0, adhering to your specifications. The solution includes separate files for classes, interfaces, and unit tests, with comprehensive comments and documentation.

### Solution Structure

1. **StackLibrary** (Class Library Project)
   - `IStack.cs`: Interface defining stack operations.
   - `StackRecord.cs`: Record implementing the stack data structure.
   - `Program.cs`: Entry point demonstrating usage of the stack.

2. **StackTests** (Unit Test Project)
   - `StackTests.cs`: Unit tests for the stack implementation.

### File: IStack.cs

```csharp
using System;
using System.Collections.Generic;

namespace StackLibrary
{
    /// <summary>
    /// Defines the operations available on a Stack data structure.
    /// </summary>
    public interface IStack<T>
    {
        bool IsEmpty();
        bool IsFull();
        void Push(T item);
        T Pop();
        T Peek();
    }
}
```

### File: StackRecord.cs

```csharp
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
```

### File: Program.cs

```csharp
using System;

namespace StackLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new StackRecord<int>(5);

            Console.WriteLine("Pushing elements onto the stack...");
            for (int i = 1; i <= 5; i++)
            {
                stack.Push(i);
                Console.WriteLine($"Pushed: {i}");
            }

            Console.WriteLine("\nPeeking top element:");
            Console.WriteLine($"Top Element: {stack.Peek()}");

            Console.WriteLine("\nPopping elements from the stack...");
            while (!stack.IsEmpty())
            {
                Console.WriteLine($"Popped: {stack.Pop()}");
            }
        }
    }
}
```

### File: StackTests.cs

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StackLibrary.Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void TestPushAndPeek()
        {
            var stack = new StackRecord<int>(3);
            Assert.IsTrue(stack.IsEmpty());

            stack.Push(1);
            Assert.AreEqual(1, stack.Peek());
            Assert.IsFalse(stack.IsFull());

            stack.Push(2);
            Assert.AreEqual(2, stack.Peek());
            Assert.IsFalse(stack.IsFull());

            stack.Push(3);
            Assert.IsTrue(stack.IsFull());
        }

        [TestMethod]
        public void TestPop()
        {
            var stack = new StackRecord<int>(3);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.AreEqual(3, stack.Pop());
            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());

            Assert.ThrowsException<InvalidOperationException>(() => stack.Pop());
        }

        [TestMethod]
        public void TestIsFull()
        {
            var stack = new StackRecord<int>(2);
            stack.Push(1);
            stack.Push(2);

            Assert.IsTrue(stack.IsFull());
            Assert.ThrowsException<InvalidOperationException>(() => stack.Push(3));
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            var stack = new StackRecord<int>(2);
            Assert.IsTrue(stack.IsEmpty());

            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());

            stack.Pop();
            Assert.IsTrue(stack.IsEmpty());
        }
    }
}
```

### README.md

```markdown
# Stack Library Documentation

## Overview

This library implements a basic stack data structure with operations for pushing, popping, peeking, and checking if the stack is empty or full.

## Features

- **Push**: Adds an element to the top of the stack.
- **Pop**: Removes and returns the top element from the stack.
- **Peek**: Returns the top element without removing it.
- **IsEmpty**: Checks if the stack is empty.
- **IsFull**: Checks if the stack is full.

## Usage

```csharp
var stack = new StackRecord<int>(5);
stack.Push(1);
int topElement = stack.Peek();
```

## Unit Tests

The solution includes comprehensive unit tests to ensure all functionalities are working as expected. Run these tests using the Microsoft Unit Test Framework.
```

This setup ensures a clean, well-documented, and fully testable implementation of a stack data structure in C#.