 Below is a complete .NET 9.0 solution in C# that adheres to all the specified requirements, including file structure, coding style, and unit testing. This solution includes a stack data structure with push, pop, isEmpty, isFull, and peek operations. It uses only the Microsoft Basic Component Library for its implementation.

### Solution Structure
- **MyStack**: A class library containing all necessary components for the stack implementation.
  - **Stacks/Stack.cs**: Contains the `Stack` class with push, pop, isEmpty, isFull, and peek methods.
  - **Tests/StackTests.cs**: Unit tests for the `Stack` class using Microsoft's unit testing framework.

### Implementation

#### Stacks/Stack.cs
```csharp
using System;

namespace MyStack
{
    public class Stack
    {
        private readonly int[] items;
        private int top = -1;

        public Stack(int size)
        {
            items = new int[size];
        }

        public void Push(int item)
        {
            if (IsFull())
                throw new InvalidOperationException("Stack is full.");
            items[++top] = item;
        }

        public int Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");
            return items[top--];
        }

        public bool IsEmpty() => top == -1;

        public bool IsFull() => top == items.Length - 1;

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");
            return items[top];
        }
    }
}
```

#### Tests/StackTests.cs
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStack;
using System;

namespace StackTests
{
    [TestClass]
    public class UnitTest1
    {
        private Stack stack;

        [TestInitialize]
        public void Setup()
        {
            stack = new Stack(5);
        }

        [TestMethod]
        public void TestPushPop()
        {
            stack.Push(10);
            Assert.AreEqual(10, stack.Pop());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPopEmptyStack()
        {
            stack.Pop();
        }

        [TestMethod]
        public void TestIsEmpty()
        {
            Assert.IsTrue(stack.IsEmpty());
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void TestIsFull()
        {
            for (int i = 0; i < 5; i++)
                stack.Push(i);
            Assert.IsTrue(stack.IsFull());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestPushFullStack()
        {
            for (int i = 0; i < 5; i++)
                stack.Push(i);
            stack.Push(6);
        }

        [TestMethod]
        public void TestPeek()
        {
            stack.Push(22);
            Assert.AreEqual(22, stack.Peek());
            Assert.IsFalse(stack.IsEmpty()); // Ensure peek doesn't affect the stack being empty
        }
    }
}
```

### Directory Structure
- **MyStack/**
  - **Stacks/**
    - **Stack.cs**
  - **Tests/**
    - **UnitTests1.cs**

This structure ensures that each class, interface, or other construct is in its own file as per the requirements. The provided code includes comprehensive unit tests to ensure all functionalities are working correctly and robustly.