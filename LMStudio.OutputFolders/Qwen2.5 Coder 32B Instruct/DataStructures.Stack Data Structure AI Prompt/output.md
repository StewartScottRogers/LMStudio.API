Sure, let's create a C# library that implements a stack data structure with the specified operations. We will also include unit tests for the library using the Microsoft Unit Test Framework.

First, let’s set up the solution and create the necessary projects:

1. Open Visual Studio 2022.
2. Create a new .NET Class Library (C#) project named `StackLibrary`.
3. Create a new Test Project (.NET Core) named `StackLibrary.Tests` targeting `.NET 6` or later since there is no .NET 9 at the time of writing.

Now, we'll add the stack implementation in the `StackLibrary` project and then write unit tests for it in the `StackLibrary.Tests` project. 

### StackLibrary Project

#### Stack.cs
Create a file named `Stack.cs`:

```csharp
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
```

### StackLibrary.Tests Project

#### StackTests.cs
Create a file named `StackTests.cs`:

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StackLibrary.Tests
{
    [TestClass]
    public class StackTests
    {
        private readonly int stackCapacity = 3;
        private Stack<int> stack;

        [TestInitialize]
        public void TestInitialize()
        {
            stack = new Stack<int>(stackCapacity);
        }

        [TestMethod]
        public void Push_AddsElementToStack()
        {
            var elementToAdd = 1;

            stack.Push(elementToAdd);

            Assert.AreEqual(1, stack.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_OnEmptyStack_ThrowsInvalidOperationException()
        {
            stack.Pop();
        }

        [TestMethod]
        public void Pop_RemovesTopElementFromStack()
        {
            stack.Push(1);
            stack.Push(2);

            var poppedElement = stack.Pop();

            Assert.AreEqual(2, poppedElement);
            Assert.AreEqual(1, stack.Peek());
        }

        [TestMethod]
        public void Peek_ReturnsTopElementWithoutRemovingIt()
        {
            stack.Push(1);
            stack.Push(2);

            var topElement = stack.Peek();

            Assert.AreEqual(2, topElement);
            Assert.AreEqual(2, stack.Peek());
        }

        [TestMethod]
        public void IsEmpty_ChecksIfStackIsEmpty()
        {
            Assert.IsTrue(stack.IsEmpty());

            stack.Push(1);

            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void IsFull_ChecksIfStackIsFull()
        {
            for (int i = 0; i < stackCapacity; i++)
                stack.Push(i);

            Assert.IsTrue(stack.IsFull());

            stack.Pop();

            Assert.IsFalse(stack.IsFull());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Push_OnFullStack_ThrowsInvalidOperationException()
        {
            for (int i = 0; i < stackCapacity + 1; i++)
                stack.Push(i);
        }
    }
}
```

### File System Structure

The final structure of the solution should be:

- **StackLibrary**
  - Stack.cs
- **StackLibrary.Tests**
  - StackTests.cs

You can now compile and run the tests to ensure everything works as expected. 

This setup ensures that we have a simple, well-documented stack implementation with comprehensive unit testing coverage.