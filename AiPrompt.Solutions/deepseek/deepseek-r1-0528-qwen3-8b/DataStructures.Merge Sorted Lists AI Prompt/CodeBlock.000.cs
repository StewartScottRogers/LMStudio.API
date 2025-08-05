// HeapNode.cs
using System;
using System.Collections.Generic;

namespace MergeLibrary;

/// <summary>
/// Represents a node in the priority queue used during merge operations.
/// Contains an integer value, its source list, and the index within that list.
/// </summary>
public readonly record struct HeapNode(int Value, List<int> CurrentList, int IndexInCurrentList);

// In MergedSortedLists.csproj (library project)
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Library</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>false</ImplicitUsings>
    <Nullable>disable</Nullable>
  </PropertyGroup>
  <!-- Other project settings -->
</Project>

// In Tests/MergedSortedTests.csproj
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>false</ImplicitUsings>
    <Nullable>disable</Nullable>
    <!-- Include necessary packages for unit testing -->
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.3.1">
      <ExcludeAssets>BuildReady;Compile</ExcludeAssets>
    </PackageReference>
  </PropertyGroup>

// MergeTests.cs (unit tests)
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MergeLibrary.Tests
{
    [TestClass]
    public class MergeTests : TestClassBase // Assume TestClassBase is defined elsewhere for test setup if needed.
    {
        // ... unit tests here ...
    }
}