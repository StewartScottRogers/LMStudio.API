Sure, let's create a .NET 9.0 solution that includes a C# library for a stack data structure with the specified requirements and constraints. Below are the steps and the corresponding code snippets.

### Solution Structure:
1. **Solution File**: `StackLibrary.sln`
2. **Class Library Project**: `StackLibrary.csproj`

### Class Library Files:
- `IStack.cs`: Interface for Stack operations.
- `StackDataStructure.cs`: Record to hold stack data.
- `StackImplementation.cs`: Implementation of the Stack.

### Unit Test Project:
1. **Unit Test File**: `StackTests.csproj`
2. **Test Files**:
   - `PushOperationTests.cs`: Tests for Push operation.
   - `PopOperationTests.cs`: Tests for Pop operation.
   - `IsEmptyOperationTests.cs`: Tests for IsEmpty operation.
   - `IsFullOperationTests.cs`: Tests for IsFull operation.
   - `PeekOperationTests.cs`: Tests for Peek operation.

### Implementation

#### 1. Solution File (`StackLibrary.sln`)
```plaintext
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.0.34928.59
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "StackLibrary", "StackLibrary\StackLibrary.csproj", "{C65B8E1A-CE73-4267-A733-F6581C5CAB03}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "StackTests", "StackTests\StackTests.csproj", "{0D3A2486-C868-4D83-A65E-E6DBA62D11C3}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{C65B8E1A-CE73-4267-A733-F6581C5CAB03}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{C65B8E1A-CE73-4267-A733-F6581C5CAB03}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{C65B8E1A-CE73-4267-A733-F6581C5CAB03}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{C65B8E1A-CE73-4267-A733-F6581C5CAB03}.Release|Any CPU.Build.0 = Release|Any CPU
		{0D3A2486-C868-4D83-A65E-E6DBA62D11C3}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{0D3A2486-C868-4D83-A65E-E6DBA62D11C3}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{0D3A2486-C868-4D83-A65E-E6DBA62D11C3}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{0D3A2486-C868-4D83-A65E-E6DBA62D11C3}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
EndGlobal
```

#### 2. Class Library Project (`StackLibrary.csproj`)
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <RootNamespace>StackLibrary</RootNamespace>
    <ImplicitUsings>disable</ImplicitUsings>
    <Nullable>disable</Nullable>
  </PropertyGroup>

</Project>
```

#### 3. Interface Definition (`IStack.cs`)
```csharp
namespace StackLibrary
{
    public interface IStack
    {
        void Push(int element);
        int Pop();
        bool IsEmpty();
        bool IsFull();
        int Peek();
    }
}
```

#### 4. Record Definition (`StackDataStructure.cs`)
```csharp
namespace StackLibrary
{
    public record StackDataStructure(int[] Elements, int Top);
}
```

#### 5. Implementation of the Stack (`StackImplementation.cs`)
```csharp
using System;

namespace StackLibrary
{
    public class StackImplementation : IStack
    {
        private readonly StackDataStructure stack;
        private readonly int maxSize;

        public StackImplementation(int size)
        {
            if (size <= 0) throw new ArgumentException("Size must be greater than zero", nameof(size));
            maxSize = size;
            var elements = new int[maxSize];
            stack = new StackDataStructure(elements, -1);
        }

        public void Push(int element)
        {
            if (IsFull())
                throw new InvalidOperationException("Stack is full");

            var topIndex = stack.Top + 1;
            var newArray = stack.Elements[..];
            newArray[topIndex] = element;

            stack = new StackDataStructure(newArray, topIndex);
        }

        public int Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");

            var topElement = Peek();
            var topIndex = stack.Top - 1;
            var newArray = stack.Elements[..];
            newArray[topIndex + 1] = default;

            stack = new StackDataStructure(newArray, topIndex);
            return topElement;
        }

        public bool IsEmpty()
        {
            return stack.Top == -1;
        }

        public bool IsFull()
        {
            return stack.Top >= maxSize - 1;
        }

        public int Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty");

            return stack.Elements[stack.Top];
        }
    }
}
```

#### 6. Unit Test Project (`StackTests.csproj`)
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <RootNamespace>StackTests</RootNamespace>
    <ImplicitUsings>disable</ImplicitUsings>
    <Nullable>disable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="MSTest.TestFramework" Version="2.2.8" />
    <PackageReference Include="MSTest.TestAdapter" Version="2.2.8" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\StackLibrary\StackLibrary.csproj" />
  </ItemGroup>

</Project>
```

#### 7. Unit Test Implementation (`PushOperationTests.cs`)
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackLibrary;

namespace StackTests
{
    [TestClass]
    public class PushOperationTests
    {
        private IStack stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new StackImplementation(3);
        }

        [TestMethod]
        public void Push_AddsElementToTop_WhenNotEmpty()
        {
            stack.Push(10);
            var resultTuple = (topValue: stack.Peek(), topIndex: stack.Top);

            Assert.AreEqual(10, resultTuple.topValue);
            Assert.AreEqual(0, resultTuple.topIndex);
        }

        [TestMethod]
        public void Push_AddsMultipleElementsToTop_WhenNotEmpty()
        {
            stack.Push(10);
            stack.Push(20);
            var resultTuple = (topValue: stack.Peek(), topIndex: stack.Top);

            Assert.AreEqual(20, resultTuple.topValue);
            Assert.AreEqual(1, resultTuple.topIndex);
        }

        [TestMethod]
        public void Push_ThrowsException_WhenFull()
        {
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            try
            {
                stack.Push(40);
                Assert.Fail("Expected InvalidOperationException to be thrown.");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Stack is full", ex.Message);
            }
        }
    }
}
```

#### 8. Unit Test Implementation (`PopOperationTests.cs`)
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackLibrary;

namespace StackTests
{
    [TestClass]
    public class PopOperationTests
    {
        private IStack stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new StackImplementation(3);
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
        }

        [TestMethod]
        public void Pop_RemovesElementFromTop_WhenNotEmpty()
        {
            var resultTuple = (topValue: stack.Pop(), topIndex: stack.Top);

            Assert.AreEqual(30, resultTuple.topValue);
            Assert.AreEqual(1, resultTuple.topIndex);
        }

        [TestMethod]
        public void Pop_RemovesMultipleElementsFromTop_WhenNotEmpty()
        {
            var firstPopResult = stack.Pop();
            var secondPopResult = stack.Pop();

            Assert.AreEqual(30, firstPopResult);
            Assert.AreEqual(20, secondPopResult);
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void Pop_ThrowsException_WhenEmpty()
        {
            stack.Pop();
            stack.Pop();
            stack.Pop();

            try
            {
                stack.Pop();
                Assert.Fail("Expected InvalidOperationException to be thrown.");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Stack is empty", ex.Message);
            }
        }
    }
}
```

#### 9. Unit Test Implementation (`IsEmptyOperationTests.cs`)
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackLibrary;

namespace StackTests
{
    [TestClass]
    public class IsEmptyOperationTests
    {
        private IStack stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new StackImplementation(3);
        }

        [TestMethod]
        public void IsEmpty_ReturnsTrue_WhenNewlyCreated()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_ReturnsFalse_AfterPushingElements()
        {
            stack.Push(10);

            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_ReturnsTrue_AfterPoppingAllElements()
        {
            stack.Push(10);
            stack.Pop();

            Assert.IsTrue(stack.IsEmpty());
        }
    }
}
```

#### 10. Unit Test Implementation (`IsFullOperationTests.cs`)
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackLibrary;

namespace StackTests
{
    [TestClass]
    public class IsFullOperationTests
    {
        private IStack stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new StackImplementation(2);
        }

        [TestMethod]
        public void IsFull_ReturnsFalse_WhenNewlyCreated()
        {
            Assert.IsFalse(stack.IsFull());
        }

        [TestMethod]
        public void IsFull_ReturnsFalse_AfterPushingOneElement()
        {
            stack.Push(10);

            Assert.IsFalse(stack.IsFull());
        }

        [TestMethod]
        public void IsFull_ReturnsTrue_AfterPushingAllElements()
        {
            stack.Push(10);
            stack.Push(20);

            Assert.IsTrue(stack.IsFull());
        }
    }
}
```

#### 11. Unit Test Implementation (`PeekOperationTests.cs`)
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackLibrary;

namespace StackTests
{
    [TestClass]
    public class PeekOperationTests
    {
        private IStack stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new StackImplementation(3);
        }

        [TestMethod]
        public void Peek_ReturnsTopElement_WhenNotEmpty()
        {
            stack.Push(10);

            var topValue = stack.Peek();

            Assert.AreEqual(10, topValue);
        }

        [TestMethod]
        public void Peek_DoesNotModifyStack_TopIndexRemainsSame()
        {
            stack.Push(10);
            var initialTopIndex = stack.Top;

            stack.Peek();
            var finalTopIndex = stack.Top;

            Assert.AreEqual(initialTopIndex, finalTopIndex);
        }

        [TestMethod]
        public void Peek_ThrowsException_WhenEmpty()
        {
            try
            {
                stack.Peek();
                Assert.Fail("Expected InvalidOperationException to be thrown.");
            }
            catch (InvalidOperationException ex)
            {
                Assert.AreEqual("Stack is empty", ex.Message);
            }
        }
    }
}
```

### Instructions:
1. **Create the Solution**:
   - Open Visual Studio 2022.
   - Create a new solution named `StackLibrary.sln`.

2. **Add Class Library Project**:
   - Right-click on the solution and add a new project > .NET Core > Class Library (.NET Core).
   - Name it `StackLibrary` and ensure it targets `.NET 9.0`.
   - Add files for interface, record, and implementation as per above code snippets.

3. **Add Unit Test Project**:
   - Right-click on the solution and add a new project > .NET Core > MSTest Test Project (.NET Core).
   - Name it `StackTests` and ensure it targets `.NET 9.0`.
   - Add references to `StackLibrary`.

4. **Copy Code Snippets**:
   - Copy each code snippet into respective files in the projects.

5. **Build and Run Tests**:
   - Build the solution.
   - Run all unit tests from Test Explorer to ensure everything is working as expected.

This setup should meet the requirements specified including the coding standards, file structure, and testing framework usage.