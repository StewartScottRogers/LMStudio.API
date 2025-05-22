Based on your detailed requirements, I will create a .NET 9.0 solution for a C# library implementing a stack data structure with push and pop operations, along with necessary supporting files and unit tests using the Microsoft Unit Test Framework.

Let's start by organizing our project structure:

### Solution Structure:
- MyStackSolution
  - MyStackProject
    - Interfaces
      - IMyStack.cs
    - Models
      - MyStack.cs
    - Properties
      - AssemblyInfo.cs
    - UnitTests
      - MyStackUnitTest.cs

First, let's create the necessary files and folders.

### Step 1: Create the Solution File (.sln)
Create a file named `MyStackSolution.sln` with the following content:
```plaintext
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 15
VisualStudioVersion = 15.0.26228.4
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "MyStackProject", "MyStackProject\MyStackProject.csproj", "{6A045A82-CE6D-4EBA-AEE7-F74D57DD4BB5}"
EndProject
Global
    GlobalSection(SolutionConfigurationPlatforms) = preSolution
        Debug|Any CPU = Debug|Any CPU
        Release|Any CPU = Release|Any CPU
    EndGlobalSection
    GlobalSection(ProjectConfigurationPlatforms) = postSolution
        {6A045A82-CE6D-4EBA-AEE7-F74D57DD4BB5}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
        {6A045A82-CE6D-4EBA-AEE7-F74D57DD4BB5}.Debug|Any CPU.Build.0 = Debug|Any CPU
        {6A045A82-CE6D-4EBA-AEE7-F74D57DD4BB5}.Release|Any CPU.ActiveCfg = Release|Any CPU
        {6A045A82-CE6D-4EBA-AEE7-F74D57DD4BB5}.Release|Any CPU.Build.0 = Release|Any CPU
    EndGlobalSection
    GlobalSection(SolutionProperties) = preSolution
        HideSolutionNode = FALSE
    EndGlobalSection
EndGlobal
```

### Step 2: Create the Project File (.csproj)
Create a file named `MyStackProject.csproj` with the following content:
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>disable</ImplicitUsings>
    <Nullable>disable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.0.0" />
    <PackageReference Include="MSTest.TestAdapter" Version="2.2.8" />
    <PackageReference Include="MSTest.TestFramework" Version="2.2.8" />
  </ItemGroup>

</Project>
```

### Step 3: Create the Interface File
Create a file named `IMyStack.cs` under `Interfaces` folder:
```csharp
using System;
using System.Collections.Generic;

namespace MyStackProject.Interfaces
{
    public interface IMyStack<T>
    {
        void Push(T item);
        T Pop();
        bool IsEmpty();
        bool IsFull(int maxSize);
        T Peek();
    }
}
```

### Step 4: Create the Model File
Create a file named `MyStack.cs` under `Models` folder:
```csharp
using System;
using MyStackProject.Interfaces;

namespace MyStackProject.Models
{
    public class MyStack<T> : IMyStack<T>
    {
        private readonly List<T> stack = new();
        private readonly int maxSize;

        public MyStack(int size)
        {
            maxSize = size;
        }

        public void Push(T item)
        {
            if (IsFull(maxSize))
            {
                throw new InvalidOperationException("The stack is full.");
            }
            stack.Add(item);
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The stack is empty.");
            }
            var item = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            return item;
        }

        public bool IsEmpty()
        {
            return stack.Count == 0;
        }

        public bool IsFull(int maxSize)
        {
            return stack.Count >= maxSize;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("The stack is empty.");
            }
            return stack[stack.Count - 1];
        }
    }
}
```

### Step 5: Create Unit Test File
Create a file named `MyStackUnitTest.cs` under `UnitTests` folder:
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyStackProject.Models;

namespace MyStackProject.UnitTests
{
    [TestClass]
    public class MyStackUnitTest
    {
        private readonly MyStack<int> stack = new(5);

        [TestMethod]
        public void Push_ShouldAddItemToStack()
        {
            stack.Push(1);
            Assert.AreEqual(1, stack.Peek());
        }

        [TestMethod]
        public void Pop_ShouldRemoveItemFromStack()
        {
            stack.Push(1);
            var item = stack.Pop();
            Assert.AreEqual(1, item);
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsEmpty_ShouldReturnTrueForNewStack()
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod]
        public void IsFull_ShouldReturnFalseWhenStackIsNotFull()
        {
            stack.Push(1);
            Assert.IsFalse(stack.IsFull(5));
        }

        [TestMethod]
        public void IsFull_ShouldReturnTrueWhenStackIsFull()
        {
            for (int i = 0; i < 5; i++)
            {
                stack.Push(i);
            }
            Assert.IsTrue(stack.IsFull(5));
        }

        [TestMethod]
        public void Peek_ShouldReturnTopItemWithoutRemovingIt()
        {
            stack.Push(1);
            var item = stack.Peek();
            Assert.AreEqual(1, item);
            Assert.AreEqual(1, stack.Peek());
        }
    }
}
```

### Step 6: Create AssemblyInfo.cs File
Create a file named `AssemblyInfo.cs` under the `Properties` folder:
```csharp
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MyStackProject.UnitTests")]
```

By following these steps, you have created a complete .NET 9.0 solution with a C# library implementing a stack data structure and associated unit tests. The solution adheres to the specified coding style guidelines and uses only Microsoft's basic component library.