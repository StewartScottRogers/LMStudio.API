Creating a .NET 9.0 solution with the specified requirements involves several steps, including setting up the project structure, implementing the stack data structure, and writing unit tests. Given that .NET 9.0 is not yet released as of my knowledge cutoff in October 2023, I will create this example using .NET 6.0 which is a stable version compatible with Visual Studio 2022. You can later migrate it to .NET 9.0 when it becomes available.

Below are the steps and code snippets that follow your guidelines:

### Step 1: Create the Solution

Open Visual Studio 2022, and create a new solution:
- File > New > Project.
- Choose "Class Library (.NET)" under C# project types.
- Name the project `StackLibrary`.
- Ensure the target framework is .NET 6.0 (or whichever version you have installed).

### Step 2: Create Supporting Files

Create separate files for each class, interface, enumeration, record, and struct.

#### StackRecord.cs
```csharp
using System;

namespace StackLibrary.Models
{
    public record StackRecord<T>(T Value)
        where T : notnull;
}
```

#### IStackOperations.cs
```csharp
namespace StackLibrary.Operations
{
    public interface IStackOperations<T>
    {
        bool IsEmpty { get; }
        bool IsFull { get; }
        void Push(T item);
        var PopTuple();
        T Peek();
    }
}
```

#### StackImplementation.cs
```csharp
using System;
using System.Collections.Generic;

namespace StackLibrary.Implementations
{
    public class StackImplementation<T> : IStackOperations<T>
        where T : notnull
    {
        private readonly int capacity;
        private readonly List<StackRecord<T>> stackRecords;

        public bool IsEmpty => stackRecords.Count == 0;
        public bool IsFull => stackRecords.Count >= capacity;

        public StackImplementation(int initialCapacity)
        {
            if (initialCapacity < 1) throw new ArgumentException("Initial capacity must be greater than zero.");

            this.capacity = initialCapacity;
            this.stackRecords = new List<StackRecord<T>>(capacity);
        }

        public void Push(T item)
        {
            if (IsFull) throw new InvalidOperationException("The stack is full.");
            
            stackRecords.Add(new StackRecord<T>(item));
        }

        public var PopTuple()
        {
            if (IsEmpty) throw new InvalidOperationException("The stack is empty.");

            T topItem = Peek();
            stackRecords.RemoveAt(stackRecords.Count - 1);

            return new { Value = topItem };
        }

        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("The stack is empty.");

            var topRecord = stackRecords[stackRecords.Count - 1];
            return topRecord.Value;
        }
    }
}
```

#### StackLibrary.csproj
Ensure the project file references all necessary files:
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <ImplicitUsings>disable</ImplicitUsings>
    <Nullable>disable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <Compile Include="Models\StackRecord.cs" />
    <Compile Include="Operations\IStackOperations.cs" />
    <Compile Include="Implementations\StackImplementation.cs" />
  </ItemGroup>

</Project>
```

### Step 3: Create Unit Test Project

Add a new test project to the solution:
- Right-click on the Solution in Solution Explorer > Add > New Project.
- Choose "Unit Test Project (.NET)" under C# project types.
- Name the project `StackLibrary.Tests`.

#### StackImplementationTests.cs
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StackLibrary.Tests
{
    [TestClass]
    public class StackImplementationTests
    {
        private readonly IStackOperations<int> stack;

        public StackImplementationTests()
        {
            this.stack = new Implementations.StackImplementation<int>(3);
        }

        [TestMethod]
        public void IsEmpty_ShouldReturnTrue_WhenStackIsEmpty()
        {
            Assert.IsTrue(stack.IsEmpty, "The stack should be empty.");
        }

        [TestMethod]
        public void Push_ShouldAddItemToTopOfStack()
        {
            stack.Push(1);

            Assert.IsFalse(stack.IsEmpty, "The stack should not be empty after pushing an item.");
            Assert.AreEqual(1, stack.Peek(), "The top of the stack should be 1.");
        }

        [TestMethod]
        public void Pop_ShouldRemoveItemFromTopOfStack()
        {
            stack.Push(2);
            var resultTuple = stack.PopTuple();

            Assert.IsTrue(stack.IsEmpty, "The stack should be empty after popping the last item.");
            Assert.AreEqual(2, resultTuple.Value, "The popped value should be 2.");
        }

        [TestMethod]
        public void Peek_ShouldReturnTopItemWithoutRemoving()
        {
            stack.Push(3);

            var peekValue = stack.Peek();

            Assert.IsFalse(stack.IsEmpty, "The stack should not be empty after peaking an item.");
            Assert.AreEqual(3, peekValue, "The top of the stack should still be 3.");
        }

        [TestMethod]
        public void IsFull_ShouldReturnTrue_WhenStackIsFull()
        {
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);

            Assert.IsTrue(stack.IsFull, "The stack should be full.");
        }

        [TestMethod]
        public void Push_ShouldThrowException_WhenStackIsFull()
        {
            stack.Push(7);
            stack.Push(8);
            stack.Push(9);

            var exception = Assert.ThrowsException<InvalidOperationException>(() => stack.Push(10));

            Assert.AreEqual("The stack is full.", exception.Message, "Pushing to a full stack should throw InvalidOperationException.");
        }

        [TestMethod]
        public void Pop_ShouldThrowException_WhenStackIsEmpty()
        {
            var exception = Assert.ThrowsException<InvalidOperationException>(() => stack.PopTuple());

            Assert.AreEqual("The stack is empty.", exception.Message, "Popping from an empty stack should throw InvalidOperationException.");
        }
    }
}
```

#### StackLibrary.Tests.csproj
Ensure the project file references all necessary files and the `StackLibrary` project:
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <ImplicitUsings>disable</ImplicitUsings>
    <Nullable>disable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="MSTest.TestFramework" Version="2.2.8" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.2.0" />
    <PackageReference Include="MSTest.TestAdapter" Version="2.2.8" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\StackLibrary\StackLibrary.csproj" />
  </ItemGroup>

</Project>
```

### Step 4: Build and Test

1. Build the solution.
2. Run all tests in the test explorer to verify functionality.

This completes the implementation of a stack data structure with push, pop, isEmpty, isFull, and peek operations following the specified guidelines. The unit tests ensure that the bounding conditions are covered.