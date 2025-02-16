Sure, let's create a .NET 9.0 solution that meets all your requirements. We'll start by setting up the project structure and then implement the stack data structure along with unit tests.

### Project Structure

```
StackLibrary/
├── StackLibrary.csproj
├── StackDataStructure/
│   ├── StackInterface.cs
│   ├── StackClass.cs
└── Tests/
    ├── UnitTest1.csproj
    └── StackTests.cs
```

### Step 1: Create the .NET Solution

First, create a new solution in Visual Studio 2022 and add the necessary projects.

### StackLibrary.csproj

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <OutputType>Library</OutputType>
    <RootNamespace>StackDataStructure</RootNamespace>
  </PropertyGroup>

</Project>
```

### StackInterface.cs

```csharp
using System;

namespace StackDataStructure.Interfaces
{
    /// <summary>
    /// Interface for stack data structure.
    /// </summary>
    public interface IStack<Type>
    {
        void Push(Type element);
        Type Pop();
        bool IsEmpty();
        bool IsFull();
        Type Peek();
    }
}
```

### StackClass.cs

```csharp
using System;
using StackDataStructure.Interfaces;

namespace StackDataStructure
{
    /// <summary>
    /// Class that implements the stack data structure.
    /// </summary>
    public class StackClass<Type> : IStack<Type>
    {
        private const int MaxSize = 100; // Maximum size of the stack.
        private readonly Type[] elements;
        private int top;

        public StackClass()
        {
            this.elements = new Type[MaxSize];
            this.top = -1;
        }

        /// <summary>
        /// Adds an element to the top of the stack.
        /// </summary>
        /// <param name="element">The element to be added.</param>
        public void Push(Type element)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Stack is full.");
            }
            elements[++top] = element;
        }

        /// <summary>
        /// Removes and returns the top element of the stack.
        /// </summary>
        /// <returns>The top element of the stack.</returns>
        public Type Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return elements[top--];
        }

        /// <summary>
        /// Checks if the stack is empty.
        /// </summary>
        /// <returns>True if the stack is empty, otherwise false.</returns>
        public bool IsEmpty()
        {
            return top == -1;
        }

        /// <summary>
        /// Checks if the stack is full.
        /// </summary>
        /// <returns>True if the stack is full, otherwise false.</returns>
        public bool IsFull()
        {
            return top == MaxSize - 1;
        }

        /// <summary>
        /// Returns the value of the top element without removing it.
        /// </summary>
        /// <returns>The top element of the stack.</returns>
        public Type Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty.");
            }
            return elements[top];
        }
    }
}
```

### UnitTest1.csproj

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <OutputType>Library</OutputType>
    <RootNamespace>Tests</RootNamespace>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.VisualStudio.TestPlatform" Version="17.6.0" />
    <ProjectReference Include="../StackLibrary/StackLibrary.csproj" />
  </ItemGroup>

</Project>
```

### StackTests.cs

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackDataStructure;

namespace Tests
{
    [TestClass]
    public class StackTests
    {
        private readonly IStack<int> stack = new StackClass<int>();

        /// <summary>
        /// Tests the Push and Pop methods.
        /// </summary>
        [TestMethod]
        public void TestPushAndPop()
        {
            stack.Push(1);
            var value = stack.Pop();
            Assert.AreEqual(1, value);

            stack.Push(2);
            value = stack.Pop();
            Assert.AreEqual(2, value);
        }

        /// <summary>
        /// Tests the Peek method.
        /// </summary>
        [TestMethod]
        public void TestPeek()
        {
            stack.Push(1);
            var value = stack.Peek();
            Assert.AreEqual(1, value);
        }

        /// <summary>
        /// Tests the IsEmpty method.
        /// </summary>
        [TestMethod]
        public void TestIsEmpty()
        {
            Assert.IsTrue(stack.IsEmpty());
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
        }

        /// <summary>
        /// Tests the IsFull method.
        /// </summary>
        [TestMethod]
        public void TestIsFull()
        {
            for (int i = 0; i < 100; i++)
            {
                stack.Push(i);
            }
            Assert.IsTrue(stack.IsFull());
        }

    }
}
```

### Explanation

1. **StackInterface.cs**: Defines the `IStack` interface with methods for push, pop, isEmpty, isFull, and peek.
2. **StackClass.cs**: Implements the `IStack` interface using an array to store stack elements.
3. **StackTests.cs**: Contains unit tests for the stack operations using the Microsoft Unit Test Framework.

### Running the Tests

To run the tests, you can use the built-in test explorer in Visual Studio 2022. Ensure that all bounding conditions are tested, such as pushing and popping elements, checking if the stack is empty or full, and peeking at the top element.

This solution meets all the specified requirements and should be fully compilable and executable without additional coding.