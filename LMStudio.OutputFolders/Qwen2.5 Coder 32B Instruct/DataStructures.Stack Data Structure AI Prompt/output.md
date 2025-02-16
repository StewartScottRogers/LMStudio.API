Creating a .NET 9.0 solution with the specified requirements involves several steps. However, since .NET 9.0 does not exist as of now (as of my last update in October 2023), I will assume you meant to use the latest stable version available at that time, which is likely .NET 6 or .NET 7, and ensure it's compatible with Visual Studio 2022.

Below is a step-by-step guide to creating a C# library implementing a stack data structure. This example uses .NET 6 for compatibility with Visual Studio 2022.

### Step 1: Create the Solution

Open Visual Studio 2022, create a new solution and name it `StackLibrarySolution`.

### Step 2: Create the Stack Library Project

In the solution, add a Class Library project named `StackLibrary`.

### Step 3: Implement the Stack Data Structure

Create separate files for each class, interface, and enumeration as per requirements.

#### IStack.cs
```csharp
public interface IStack<T>
{
    void Push(T value);
    T Pop();
    T Peek();
    bool IsEmpty();
    bool IsFull();
}
```

#### StackOverflowException.cs
```csharp
public class StackOverflowException : Exception
{
    public StackOverflowException(string message) : base(message)
    {
    }
}

public class StackUnderflowException : Exception
{
    public StackUnderflowException(string message) : base(message)
    {
    }
}
```

#### FixedSizeStack.cs
```csharp
using System;
using System.Collections.Generic;

public sealed class FixedSizeStack<T> : IStack<T>
{
    private readonly T[] elements;
    private int topIndex = -1;
    private readonly int capacity;

    public FixedSizeStack(int initialCapacity)
    {
        if (initialCapacity <= 0) throw new ArgumentException("Initial capacity must be greater than zero.");

        this.capacity = initialCapacity;
        this.elements = new T[capacity];
    }

    public void Push(T value)
    {
        if (IsFull())
            throw new StackOverflowException("Stack is full");

        elements[++topIndex] = value;
    }

    public T Pop()
    {
        if (IsEmpty())
            throw new StackUnderflowException("Stack is empty");

        var poppedValue = elements[topIndex];
        topIndex--;
        return poppedValue;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new StackUnderflowException("Stack is empty");

        return elements[topIndex];
    }

    public bool IsEmpty()
    {
        return topIndex == -1;
    }

    public bool IsFull()
    {
        return topIndex == capacity - 1;
    }
}
```

### Step 4: Create Unit Test Project

In the solution, add a new Unit Test project named `StackLibraryTests`.

#### StackLibraryTests.csproj
Ensure you are using the Microsoft Unit Testing Framework:
```xml
<ItemGroup>
    <PackageReference Include="MSTest.TestFramework" Version="2.2.8" />
    <PackageReference Include="MSTest.TestAdapter" Version="2.2.8" />
</ItemGroup>
```

#### FixedSizeStackTests.cs
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class FixedSizeStackTests
{
    [TestMethod]
    public void Push_ShouldAddElementToTop()
    {
        var stack = new FixedSizeStack<int>(3);
        stack.Push(1);
        Assert.AreEqual(1, stack.Peek());
    }

    [TestMethod]
    public void Pop_ShouldRemoveAndReturnTopElement()
    {
        var stack = new FixedSizeStack<int>(3);
        stack.Push(1);
        stack.Push(2);
        int poppedValue = stack.Pop();
        Assert.AreEqual(2, poppedValue);
        Assert.AreEqual(1, stack.Peek());
    }

    [TestMethod]
    public void Pop_ShouldThrowExceptionIfEmpty()
    {
        var stack = new FixedSizeStack<int>(3);
        Assert.ThrowsException<StackUnderflowException>(() => stack.Pop());
    }

    [TestMethod]
    public void Peek_ShouldReturnTopElementWithoutRemovingIt()
    {
        var stack = new FixedSizeStack<int>(3);
        stack.Push(1);
        int peekedValue = stack.Peek();
        Assert.AreEqual(1, peekedValue);
        Assert.AreEqual(1, stack.Pop());
    }

    [TestMethod]
    public void Peek_ShouldThrowExceptionIfEmpty()
    {
        var stack = new FixedSizeStack<int>(3);
        Assert.ThrowsException<StackUnderflowException>(() => stack.Peek());
    }

    [TestMethod]
    public void IsEmpty_ShouldReturnTrueWhenNoElementsArePresent()
    {
        var stack = new FixedSizeStack<int>(3);
        Assert.IsTrue(stack.IsEmpty());
    }

    [TestMethod]
    public void IsFull_ShouldReturnFalseWhenNotAllCapacityIsUsed()
    {
        var stack = new FixedSizeStack<int>(3);
        stack.Push(1);
        Assert.IsFalse(stack.IsFull());
    }

    [TestMethod]
    public void IsFull_ShouldReturnTrueWhenAllCapacityIsUsed()
    {
        var stack = new FixedSizeStack<int>(2);
        stack.Push(1);
        stack.Push(2);
        Assert.IsTrue(stack.IsFull());
    }

    [TestMethod]
    public void Push_ShouldThrowExceptionIfFull()
    {
        var stack = new FixedSizeStack<int>(3);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Assert.ThrowsException<StackOverflowException>(() => stack.Push(4));
    }
}
```

### Step 5: Run the Unit Tests

Build and run the tests in Visual Studio 2022 to ensure all tests pass.

This implementation adheres to the coding style, naming conventions, and requirements provided.