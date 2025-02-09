Sure, let's create a C# library that implements a stack data structure following the provided guidelines. We'll use Visual Studio 2022 to set up this .NET 9.0 solution.

### Step-by-Step Solution

#### 1. Initialize a New Solution in Visual Studio:
   - Open Visual Studio 2022.
   - Create a new solution, select "Class Library (.NET Core)" or ".NET" based on the available options.
   - Name the project `StackDataStructure`.
   - Set the target framework to .NET 9.0.

#### 2. Define Interfaces:
   - We'll define an interface for our stack operations.
   
**IStack.cs**
```csharp
namespace StackDataStructure
{
    public interface IStack<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
        bool IsEmpty();
        bool IsFull();
    }
}
```

#### 3. Define the Stack Class:
   - Implement the stack operations in a class named `Stack`.
   
**Stack.cs**
```csharp
using System;
using System.Collections.Generic;

namespace StackDataStructure
{
    public class Stack<T> : IStack<T>
    {
        private readonly List<T> items;
        private readonly int capacity;

        public Stack(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Capacity must be greater than zero.");

            this.capacity = capacity;
            items = new List<T>(capacity);
        }

        public void Push(T item)
        {
            if (IsFull())
                throw new InvalidOperationException("Stack is full.");
            
            items.Add(item);
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            var topItem = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            return topItem;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");
            
            return items[items.Count - 1];
        }

        public bool IsEmpty() => items.Count == 0;

        public bool IsFull() => items.Count >= capacity;
    }
}
```

#### 4. Implement Unit Tests:
   - Create a unit test project and implement tests for our stack operations.
   
**StackDataStructure.Tests.csproj**
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>

    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="MSTest.TestFramework" Version="3.0.2" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.6.1" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\StackDataStructure\StackDataStructure.csproj" />
  </ItemGroup>

</Project>
```

**UnitTest1.cs**
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackDataStructure;

namespace StackDataStructure.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private const int StackCapacity = 5;
        private readonly IStack<int> stack;

        public UnitTest1()
        {
            stack = new Stack<int>(StackCapacity);
        }

        [TestMethod]
        public void IsEmpty_ReturnsTrue_WhenStackIsInitialized()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void Push_IncreasesCount()
        {
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
            stack.Push(2);
            Assert.AreEqual(2, ((Stack<int>)stack).Items.Count);
        }

        [TestMethod]
        public void Peek_ReturnsTopElement_WithoutRemovingIt()
        {
            stack.Push(5);
            var topItem = stack.Peek();
            Assert.AreEqual(5, topItem);
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_OnEmptyStackThrows()
        {
            stack.Pop();
        }

        [TestMethod]
        public void Pop_ReturnsTopElement()
        {
            stack.Push(3);
            var item = stack.Pop();
            Assert.AreEqual(3, item);
        }

        [TestMethod]
        public void IsFull_ReturnsTrue_WhenCapacityIsReached()
        {
            for (int i = 0; i < StackCapacity; i++)
                stack.Push(i);

            Assert.IsTrue(stack.IsFull());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Push_OnFullStackThrows()
        {
            for (int i = 0; i <= StackCapacity; i++)
                stack.Push(i);
        }
    }
}
```

#### 5. Documentation:
   - Add a `.README.md` to document the project.

**README.md**
```markdown
# Stack Data Structure Implementation in C#

This repository contains a simple implementation of a stack data structure using C#. The stack supports basic operations such as push, pop, peek, and checks for empty/full status.

## Features

- **Push**: Adds an element to the top of the stack.
- **Pop**: Removes and returns the top element from the stack. Throws an exception if the stack is empty.
- **Peek**: Returns the top element without removing it. Throws an exception if the stack is empty.
- **IsEmpty**: Checks if the stack is empty.
- **IsFull**: Checks if the stack has reached its capacity.

## Usage

To use this library, simply create a `Stack<T>` object with a specified capacity and call the appropriate methods to manipulate the stack.

### Example Code
```csharp
var stack = new Stack<int>(5);
stack.Push(10);
Console.WriteLine(stack.Peek()); // Outputs 10
stack.Pop();
Console.WriteLine(stack.IsEmpty()); // Outputs true
```

## Unit Tests

The project includes unit tests that verify the correctness of the stack operations. These tests cover boundary conditions and typical scenarios.

### Running Tests
To run the tests, open this solution in Visual Studio 2022 and execute the tests via the Test Explorer.
```

### Final Solution Structure:
- **StackDataStructure.sln**
  - **StackDataStructure.csproj** (Class Library)
    - **IStack.cs** (Interface definition)
    - **Stack.cs** (Implementation of stack operations)
  - **StackDataStructure.Tests.csproj** (Unit test project)
    - **UnitTest1.cs** (Unit tests for the stack implementation)
- **README.md**

This solution should be fully compilable and executable in Visual Studio 2022, adhering to all provided guidelines.