Sure, let's create a .NET 9.0 solution with a C# library implementing a stack data structure as per your requirements. Since .NET 9.0 doesn't exist at the time of writing this, I'll create the project targeting .NET 6.0, which is the latest stable version. You can easily upgrade it to .NET 9.0 when that version becomes available.

Here's how we will structure the solution:

1. **StackLibrary**: A class library containing the stack implementation.
2. **StackLibrary.Tests**: A unit test project for testing the stack operations.

### Step-by-Step Implementation

#### 1. Create a .NET 6.0 Class Library Project
Name the project `StackLibrary`.

#### 2. Implement Stack Operations

**IStack.cs**
```csharp
public interface IStack<T>
{
    void Push(T item);
    T Pop();
    bool IsEmpty();
    bool IsFull();
    T Peek();
}
```

**Stack.cs**
```csharp
using System;
using System.Collections.Generic;

public class Stack<T> : IStack<T>
{
    private readonly T[] items;
    private int top = -1;
    private readonly int capacity;

    public Stack(int size)
    {
        if (size <= 0)
            throw new ArgumentException("Size must be greater than zero", nameof(size));

        capacity = size;
        items = new T[capacity];
    }

    public void Push(T item)
    {
        if (IsFull())
            throw new InvalidOperationException("Stack is full.");

        items[++top] = item;
    }

    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty.");

        return items[top--];
    }

    public bool IsEmpty() => top == -1;

    public bool IsFull() => top >= capacity - 1;

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty.");

        return items[top];
    }
}
```

#### 3. Create a .NET 6.0 Unit Test Project
Name the project `StackLibrary.Tests`.

Add a reference to `StackLibrary` in `StackLibrary.Tests`.

**StackTests.cs**
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class StackTests
{
    [TestMethod]
    public void Push_ShouldIncrementTop()
    {
        // Arrange
        var stack = new Stack<int>(5);
        
        // Act
        stack.Push(1);

        // Assert
        Assert.IsFalse(stack.IsEmpty());
    }

    [TestMethod]
    public void Pop_ShouldDecrementTopAndReturnLastPushedElement()
    {
        // Arrange
        var stack = new Stack<int>(5);
        stack.Push(1);

        // Act
        int result = stack.Pop();

        // Assert
        Assert.AreEqual(1, result);
        Assert.IsTrue(stack.IsEmpty());
    }

    [TestMethod]
    public void IsEmpty_ShouldReturnTrueForNewStack()
    {
        // Arrange
        var stack = new Stack<int>(5);

        // Act & Assert
        Assert.IsTrue(stack.IsEmpty());
    }

    [TestMethod]
    public void Peek_ShouldReturnTopElementWithoutRemovingIt()
    {
        // Arrange
        var stack = new Stack<int>(5);
        stack.Push(1);

        // Act
        int result = stack.Peek();

        // Assert
        Assert.AreEqual(1, result);
        Assert.IsFalse(stack.IsEmpty());
    }

    [TestMethod]
    public void IsFull_ShouldReturnTrueWhenStackIsFull()
    {
        // Arrange
        var stack = new Stack<int>(2);
        stack.Push(1);
        stack.Push(2);

        // Act & Assert
        Assert.IsTrue(stack.IsFull());
    }
}
```

### Step-by-Step Execution Instructions

1. Open Visual Studio 2022.
2. Create a new solution with the name `StackSolution`.
3. Add a new Class Library project named `StackLibrary` to the solution.
4. Add a new Unit Test Project named `StackLibrary.Tests` to the solution.
5. Implement the code as shown above in their respective files.
6. Ensure all namespaces and file references are correctly set up.
7. Build the solution to ensure there are no compilation errors.
8. Run the unit tests from the Test Explorer to verify that all test cases pass.

This setup will provide you with a complete, compilable, and executable C# library implementing a stack data structure along with its corresponding unit tests.