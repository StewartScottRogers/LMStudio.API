```csharp
// Solution File (.sln) - StackSolution.sln

Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.8.34330.188
MinimumVisualStudioVersion = 10.0.40219.1
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "StackLibrary", "StackLibrary\StackLibrary.csproj", "{B3D1C62A-649A-497C-A06F-44145D18991A}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{B3D1C62A-649A-497C-A06F-44145D18991A}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{B3D1C62A-649A-497C-A06F-44145D18991A}.Debug|Any CPU.BuildCfg = Debug|Any CPU
		{B3D1C62A-649A-497C-A06F-44145D18991A}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{B3D1C62A-649A-497C-A06F-44145D18991A}.Release|Any CPU.BuildCfg = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideAndSeekPath = 
		Visibility = FullyQualifiedName
	EndGlobalSection
EndGlobal
```

```csharp
// Project File (.csproj) - StackLibrary\StackLibrary.csproj

<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>disable</ImplicitUsings>
    <Nullable>disable</Nullable>
    <OutputType>Library</OutputType>
    <RootNamespace>StackLibrary</RootNamespace>
  </PropertyGroup>

</Project>
```

```csharp
// Interface File - StackLibrary\IStack.cs

namespace StackLibrary;

public interface IStack
{
	bool IsEmpty();
	bool IsFull();
	void Push(int data);
	int Pop();
	int Peek();
}
```

```csharp
// Record File - StackLibrary\StackParametersRecord.cs

namespace StackLibrary;

public record StackParametersRecord(int Capacity, int TopIndex) ;
```

```csharp
// Class File - StackLibrary\Stack.cs

namespace StackLibrary;

public class Stack : IStack
{
	private readonly int[] stackArray;
	private StackParametersRecord stackParameters;

	public Stack(int capacity)
	{
		stackArray = new int[capacity];
		stackParameters = new StackParametersRecord(capacity, -1); // Initialize top to -1 for an empty stack.
	}

	public bool IsEmpty()
	{
		// Check if the stack is empty by verifying if the top index is -1.
		return stackParameters.TopIndex == -1;
	}

	public bool IsFull()
	{
		// Check if the stack is full by comparing the top index with the capacity minus 1.
		return stackParameters.TopIndex == stackParameters.Capacity - 1;
	}

	public void Push(int data)
	{
		// Check for stack overflow before pushing an element.
		if (IsFull())
		{
			throw new StackOverflowException("Stack is full.");
		}

		// Increment the top index and then add the data to the stack array at the new top index.
		stackParameters = new StackParametersRecord(stackParameters.Capacity, ++stackParameters.TopIndex);
		stackArray[stackParameters.TopIndex] = data;
	}

	public int Pop()
	{
		// Check for stack underflow before popping an element.
		if (IsEmpty())
		{
			throw new InvalidOperationException("Stack is empty.");
		}

		// Get the value at the top of the stack and then decrement the top index.
		int data = stackArray[stackParameters.TopIndex];
		stackParameters = new StackParametersRecord(stackParameters.Capacity, --stackParameters.TopIndex);
		return data;
	}

	public int Peek()
	{
		// Check if the stack is empty before peeking at the top element.
		if (IsEmpty())
		{
			throw new InvalidOperationException("Stack is empty.");
		}

		// Return the value at the top of the stack without removing it.
		return stackArray[stackParameters.TopIndex];
	}
}
```

```csharp
// Unit Test File - StackLibrary\UnitTest1.cs

using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackLibrary;

namespace StackLibraryTests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void IsEmpty_NewStack_ReturnsTrue()
        {
            // Arrange
            var stack = new Stack(5);

            // Act
            bool isEmpty = stack.IsEmpty();

            // Assert
            Assert.IsTrue(isEmpty);
        }

        [TestMethod]
        public void IsFull_NewStack_ReturnsFalse()
        {
            // Arrange
            var stack = new Stack(5);

            // Act
            bool isFull = stack.IsFull();

            // Assert
            Assert.IsFalse(isFull);
        }

        [TestMethod]
        public void Push_OneElement_IsEmptyReturnsFalse()
        {
            // Arrange
            var stack = new Stack(5);

            // Act
            stack.Push(10);

            // Assert
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void Push_FiveElements_IsFullReturnsTrue()
        {
            // Arrange
            var stack = new Stack(5);

            // Act
            for (int i = 0; i < 5; i++)
            {
                stack.Push(i);
            }

            // Assert
            Assert.IsTrue(stack.IsFull());
        }

        [TestMethod]
        public void Push_StackOverflow_ThrowsException()
        {
            // Arrange
            var stack = new Stack(2);

            // Act & Assert
            Assert.ThrowsException<StackOverflowException>(() =>
            {
                stack.Push(1);
                stack.Push(2);
                stack.Push(3); // Should throw an exception
            });
        }

        [TestMethod]
        public void Pop_OneElement_IsEmptyReturnsTrue()
        {
            // Arrange
            var stack = new Stack(5);
            stack.Push(10);

            // Act
            int poppedValue = stack.Pop();

            // Assert
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void Pop_StackUnderflow_ThrowsException()
        {
            // Arrange
            var stack = new Stack(5);

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                stack.Pop(); // Should throw an exception
            });
        }

        [TestMethod]
        public void Peek_OneElement_ReturnsValue()
        {
            // Arrange
            var stack = new Stack(5);
            stack.Push(10);

            // Act
            int peekedValue = stack.Peek();

            // Assert
            Assert.AreEqual(10, peekedValue);
        }

        [TestMethod]
        public void Peek_StackUnderflow_ThrowsException()
        {
            // Arrange
            var stack = new Stack(5);

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                stack.Peek(); // Should throw an exception
            });
        }
    }
}
```