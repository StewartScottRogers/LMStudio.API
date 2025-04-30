Creating a .NET 9.0 solution with a stack data structure can be an exciting task, but note that as of my last update in October 2023, there's no officially released version .NET 9.0. However, I'll create the solution based on your specifications using the latest available stable version, which is .NET 6 or .NET 7. You can easily migrate this to any future version like .NET 9.0.

Let’s begin by setting up a Visual Studio 2022 project for a C# library that implements a stack data structure with the specified operations and constraints.

### Step 1: Create Solution

1. Open **Visual Studio 2022**.
2. Click on `Create a new project`.
3. Choose `Class Library (.NET Standard)` as the template.
4. Set the name to `StackLibrary`.
5. Set the location and solution name to `StackSolution`.
6. Ensure that the Framework is set to `.NET 7`.

### Step 2: Create Stack Data Structure

Create a new file named `CustomStack.cs`:

```csharp
using System;
using System.Collections.Generic;

namespace StackLibrary
{
    public class CustomStack<T>
    {
        private readonly List<T> stackList = new();
        private readonly int capacity;

        public CustomStack(int capacity)
        {
            this.capacity = capacity;
        }

        public bool IsEmpty()
        {
            return stackList.Count == 0;
        }

        public bool IsFull()
        {
            return stackList.Count >= capacity;
        }

        public void Push(T item)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Stack is full.");
            }
            stackList.Add(item);
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            var topItem = stackList[stackList.Count - 1];
            stackList.RemoveAt(stackList.Count - 1);
            return topItem;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return stackList[stackList.Count - 1];
        }
    }
}
```

### Step 3: Unit Testing

Create a new project within the same solution named `StackLibrary.Tests`.

1. Click on `Add` -> `New Project`.
2. Choose `Unit Test Project (.NET Core)`.
3. Set the name to `StackLibrary.Tests`.
4. Ensure that the Framework is set to `.NET 7`.

Next, add a reference from `StackLibrary.Tests` to `StackLibrary`. Right-click on `Dependencies`, then `Add Reference`, and select `StackLibrary`.

Create a new test file named `CustomStackTests.cs`:

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackLibrary;

namespace StackLibrary.Tests
{
    [TestClass]
    public class CustomStackTests
    {
        private readonly CustomStack<int> stack;

        public CustomStackTests()
        {
            stack = new CustomStack<int>(5);
        }

        [TestMethod]
        public void IsEmpty_ReturnsTrue_WhenStackIsEmpty()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsFull_ReturnsFalse_WhenStackIsNotFull()
        {
            Assert.IsFalse(stack.IsFull());
        }

        [TestMethod]
        public void Push_AddsItemToStack()
        {
            stack.Push(1);
            Assert.AreEqual(1, stack.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_ThrowsException_WhenStackIsEmpty()
        {
            stack.Pop();
        }

        [TestMethod]
        public void Peek_ReturnsTopItemWithoutRemovingIt()
        {
            stack.Push(2);
            Assert.AreEqual(2, stack.Peek());
            Assert.AreEqual(1, stack.stackList.Count);
        }

        [TestMethod]
        public void IsFull_ReturnsTrue_WhenStackIsFull()
        {
            for (int i = 0; i < 5; i++)
            {
                stack.Push(i);
            }
            Assert.IsTrue(stack.IsFull());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Push_ThrowsException_WhenStackIsFull()
        {
            for (int i = 0; i <= 5; i++)
            {
                stack.Push(i);
            }
        }
    }
}
```

### Step 4: Compile and Run

1. Build the solution.
2. Right-click on `StackLibrary.Tests` in the Solution Explorer, then click on `Run Tests`.

This setup gives you a complete .NET library with a stack implementation, along with unit tests to verify its functionality. If you want to migrate this to .NET 9.0 in the future, simply update the framework version in your project files.