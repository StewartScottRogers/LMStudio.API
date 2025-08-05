# Stack Implementation in C#

I'll create a complete .NET 9.0 solution for a stack data structure with all the required functionality and following your coding guidelines.

## Solution Structure

### 1. Project File (StackLibrary.csproj)
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>disable</ImplicitUsings>
    <Nullable>disable</Nullable>
  </PropertyGroup>

</Project>
```

### 2. Stack Interface (IStack.cs)
```csharp
namespace StackLibrary;

/// <summary>
/// Defines the contract for a stack data structure
/// </summary>
/// <typeparam name="T">The type of elements in this stack</typeparam>
public interface IStack<T>
{
    /// <summary>
    /// Adds an element to the top of the stack
    /// </summary>
    /// <param name="value">The element to add</param>
    void Push(T value);
    
    /// <summary>
    /// Removes and returns the element at the top of the stack
    /// </summary>
    /// <returns>The element that was removed from the top of the stack</returns>
    T Pop();
    
    /// <summary>
    /// Returns the element at the top of the stack without removing it
    /// </summary>
    /// <returns>The element at the top of the stack</returns>
    T Peek();
    
    /// <summary>
    /// Checks if the stack is empty
    /// </summary>
    /// <returns>True if the stack is empty, false otherwise</returns>
    bool IsEmpty();
    
    /// <summary>
    /// Checks if the stack is full
    /// </summary>
    /// <returns>True if the stack is full, false otherwise</returns>
    bool IsFull();
}
```

### 3. Stack Implementation (Stack.cs)
```csharp
using System;

namespace StackLibrary;

/// <summary>
/// A generic stack implementation using an array
/// </summary>
/// <typeparam name="T">The type of elements in this stack</typeparam>
public class Stack<T> : IStack<T>
{
    private readonly T[] _items;
    private int _topIndex;
    private readonly int _maxSize;

    /// <summary>
    /// Initializes a new instance of the Stack class with a specified maximum size
    /// </summary>
    /// <param name="maxSize">The maximum number of elements the stack can hold</param>
    public Stack(int maxSize)
    {
        _maxSize = maxSize;
        _items = new T[maxSize];
        _topIndex = -1;
    }

    /// <summary>
    /// Adds an element to the top of the stack
    /// </summary>
    /// <param name="value">The element to add</param>
    public void Push(T value)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("Stack is full");
        }
        
        _topIndex++;
        _items[_topIndex] = value;
    }

    /// <summary>
    /// Removes and returns the element at the top of the stack
    /// </summary>
    /// <returns>The element that was removed from the top of the stack</returns>
    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }
        
        var value = _items[_topIndex];
        _topIndex--;
        return value;
    }

    /// <summary>
    /// Returns the element at the top of the stack without removing it
    /// </summary>
    /// <returns>The element at the top of the stack</returns>
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }
        
        return _items[_topIndex];
    }

    /// <summary>
    /// Checks if the stack is empty
    /// </summary>
    /// <returns>True if the stack is empty, false otherwise</returns>
    public bool IsEmpty()
    {
        return _topIndex == -1;
    }

    /// <summary>
    /// Checks if the stack is full
    /// </summary>
    /// <returns>True if the stack is full, false otherwise</returns>
    public bool IsFull()
    {
        return _topIndex == _maxSize - 1;
    }
}
```

### 4. Unit Tests (StackTests.cs)
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackLibrary.Tests;

[TestClass]
public class StackTests
{
    /// <summary>
    /// Tests that a new stack is empty
    /// </summary>
    [TestMethod]
    public void Stack_IsEmpty_ReturnsTrue_ForNewStack()
    {
        // Arrange
        var stack = new Stack<int>(5);
        
        // Act
        var result = stack.IsEmpty();
        
        // Assert
        Assert.IsTrue(result);
    }

    /// <summary>
    /// Tests that a stack is not empty after pushing an element
    /// </summary>
    [TestMethod]
    public void Stack_IsEmpty_ReturnsFalse_AfterPush()
    {
        // Arrange
        var stack = new Stack<int>(5);
        stack.Push(1);
        
        // Act
        var result = stack.IsEmpty();
        
        // Assert
        Assert.IsFalse(result);
    }

    /// <summary>
    /// Tests that IsFull returns false for a new stack
    /// </summary>
    [TestMethod]
    public void Stack_IsFull_ReturnsFalse_ForNewStack()
    {
        // Arrange
        var stack = new Stack<int>(5);
        
        // Act
        var result = stack.IsFull();
        
        // Assert
        Assert.IsFalse(result);
    }

    /// <summary>
    /// Tests that IsFull returns true when stack is full
    /// </summary>
    [TestMethod]
    public void Stack_IsFull_ReturnsTrue_WhenStackIsFull()
    {
        // Arrange
        var stack = new Stack<int>(3);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        
        // Act
        var result = stack.IsFull();
        
        // Assert
        Assert.IsTrue(result);
    }

    /// <summary>
    /// Tests that Push adds an element to the top of the stack
    /// </summary>
    [TestMethod]
    public void Stack_Push_AddsElementToTop()
    {
        // Arrange
        var stack = new Stack<int>(5);
        stack.Push(1);
        
        // Act
        var result = stack.Peek();
        
        // Assert
        Assert.AreEqual(1, result);
    }

    /// <summary>
    /// Tests that Pop removes and returns the top element
    /// </summary>
    [TestMethod]
    public void Stack_Pop_RemovesAndReturnsTopElement()
    {
        // Arrange
        var stack = new Stack<int>(5);
        stack.Push(1);
        stack.Push(2);
        
        // Act
        var result = stack.Pop();
        
        // Assert
        Assert.AreEqual(2, result);
    }

    /// <summary>
    /// Tests that Peek returns the top element without removing it
    /// </summary>
    [TestMethod]
    public void Stack_Peek_ReturnsTopElementWithoutRemoving()
    {
        // Arrange
        var stack = new Stack<int>(5);
        stack.Push(1);
        stack.Push(2);
        
        // Act
        var firstPeekResult = stack.Peek();
        var secondPeekResult = stack.Peek();
        
        // Assert
        Assert.AreEqual(2, firstPeekResult);
        Assert.AreEqual(2, secondPeekResult);
    }

    /// <summary>
    /// Tests that Pop throws exception when stack is empty
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Stack_Pop_ThrowsException_WhenStackIsEmpty()
    {
        // Arrange
        var stack = new Stack<int>(5);
        
        // Act - This should throw an exception
        stack.Pop();
    }

    /// <summary>
    /// Tests that Peek throws exception when stack is empty
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Stack_Peek_ThrowsException_WhenStackIsEmpty()
    {
        // Arrange
        var stack = new Stack<int>(5);
        
        // Act - This should throw an exception
        stack.Peek();
    }

    /// <summary>
    /// Tests that Push throws exception when stack is full
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Stack_Push_ThrowsException_WhenStackIsFull()
    {
        // Arrange
        var stack = new Stack<int>(2);
        stack.Push(1);
        stack.Push(2);
        
        // Act - This should throw an exception
        stack.Push(3);
    }

    /// <summary>
    /// Tests that a stack works correctly with multiple operations
    /// </summary>
    [TestMethod]
    public void Stack_MultipleOperations_WorkCorrectly()
    {
        // Arrange
        var stack = new Stack<int>(5);
        
        // Act
        stack.Push(1);
        stack.Push(2);
        var peekResult = stack.Peek();
        var popResult = stack.Pop();
        var isEmptyResult = stack.IsEmpty();
        stack.Push(3);
        var finalPeek = stack.Peek();
        
        // Assert
        Assert.AreEqual(2, peekResult);
        Assert.AreEqual(2, popResult);
        Assert.IsFalse(isEmptyResult);
        Assert.AreEqual(3, finalPeek);
    }
}
```

### 5. Solution File (StackSolution.sln)
```xml
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 16
VisualStudioVersion = 17.0.31903.59
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "StackLibrary", "StackLibrary.csproj", "{8583A646-1011-478F-8423-545189181345}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "StackLibrary.Tests", "StackLibrary.Tests.csproj", "{20273735-8A76-4161-8907-8311E1457319}"
EndProject
Global
    GlobalSection(SolutionConfigurationPlatforms) = preSolution
        Debug|AnyCPU = Debug|AnyCPU
        Release|AnyCPU = Release|AnyCPU
    EndGlobalSection
    GlobalSection(ProjectConfigurationPlatforms) = postSolution
        {8583A646-1011-478F-8423-545189181345}.Debug|AnyCPU.ActiveCfg = Debug|AnyCPU
        {8583A646-1011-478F-8423-545189181345}.Debug|AnyCPU.Build.0 = Debug|AnyCPU
        {8583A646-1011-478F-8423-545189181345}.Release|AnyCPU.ActiveCfg = Release|AnyCPU
        {8583A646-1011-478F-8423-545189181345}.Release|AnyCPU.Build.0 = Release|AnyCPU
        {20273735-8A76-4161-8907-8311E1457319}.Debug|AnyCPU.ActiveCfg = Debug|AnyCPU
        {20273735-8A76-4161-8907-8311E1457319}.Debug|AnyCPU.Build.0 = Debug|AnyCPU
        {20273735-8A76-4161-8907-8311E1457319}.Release|AnyCPU.ActiveCfg = Release|AnyCPU
        {20273735-8A76-4161-8907-8311E1457319}.Release|AnyCPU.Build.0 = Release|AnyCPU
    EndGlobalSection
    GlobalSection(SolutionProperties) = preSolution
        HideSolutionNode = FALSE
    EndGlobalSection
EndGlobal
```

### 6. Test Project File (StackLibrary.Tests.csproj)
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>disable</ImplicitUsings>
    <Nullable>disable</Nullable>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.11.1" />
    <PackageReference Include="MSTest.TestAdapter" Version="3.6.0" />
    <PackageReference Include="MSTest.TestFramework" Version="3.6.0" />
    <PackageReference Include="coverlet.collector" Version="6.0.2" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\StackLibrary\StackLibrary.csproj" />
  </ItemGroup>

</Project>
```

This solution provides a complete implementation of a stack data structure with all required functionality:

1. **IStack<T> Interface**: Defines the contract for stack operations
2. **Stack<T> Class**: Implements the interface with proper error handling
3. **Comprehensive Unit Tests**: Test all boundary conditions and edge cases
4. **Full .NET 9.0 Compatibility**: Uses only Microsoft's basic component library
5. **Follows All Coding Guidelines**: Proper naming conventions, documentation, and code style

The implementation handles:
- Push operations to add elements to the top of the stack
- Pop operations to remove elements from the top
- Peek to examine the top element without removing it
- IsEmpty to check if the stack has no elements
- IsFull to check if the stack has reached capacity

All unit tests cover boundary conditions and ensure proper behavior under normal and error situations.