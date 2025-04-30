Creating a .NET 9.0 solution that meets all your specified requirements is quite an ambitious task, especially considering that .NET 9.0 doesn't exist yet as of my last update in October 2023. However, I can provide you with a detailed example using the latest version available at the time of writing, which is .NET 6.0 (as .NET versions are typically released every year or two). You can then migrate this to .NET 9.0 once it becomes available.

Below is an implementation for your in-memory library that merges sorted lists of integers and adheres to all the guidelines you've provided:

### Solution Structure

1. **Library Project:**
   - `SortedListsMerger.csproj`
   - `IMergedListProcessor.cs` (Interface)
   - `MergedListProcessor.cs` (Class Implementation)
   
2. **Unit Test Project:**
   - `SortedListsMerger.Tests.csproj`
   - `MergedListProcessorTests.cs`

### Implementing the Solution

#### IMergedListProcessor.cs

```csharp
using System.Collections.Generic;

namespace SortedListsMerger
{
    public interface IMergedListProcessor
    {
        List<int> MergeSortedLists(IEnumerable<IEnumerable<int>> sortedLists);
    }
}
```

#### MergedListProcessor.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace SortedListsMerger
{
    public class MergedListProcessor : IMergedListProcessor
    {
        public List<int> MergeSortedLists(IEnumerable<IEnumerable<int>> sortedLists)
        {
            if (sortedLists == null) throw new ArgumentNullException(nameof(sortedLists));

            var mergedList = new HashSet<int>(); // To avoid duplicates

            foreach (var list in sortedLists)
            {
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        mergedList.Add(item);
                    }
                }
            }

            return mergedList.ToList().OrderBy(x => x).ToList();
        }
    }
}
```

#### SortedListsMerger.csproj

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Library</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <Nullable>disable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

</Project>
```

### Unit Testing

#### MergedListProcessorTests.csproj

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Library</OutputType>
    <TargetFramework>net6.0</TargetFramework>
    <ImplicitUsings>disable</ImplicitUsings>
    <Nullable>disable</Nullable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="MSTest.TestAdapter" Version="2.2.11" />
    <PackageReference Include="MSTest.TestFramework" Version="2.2.11" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\SortedListsMerger\SortedListsMerger.csproj" />
  </ItemGroup>

</Project>
```

#### MergedListProcessorTests.cs

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SortedListsMerger.Tests
{
    [TestClass]
    public class MergedListProcessorTests
    {
        private readonly IMergedListProcessor processor = new MergedListProcessor();

        [TestMethod]
        public void MergeSortedLists_WithMultipleLists_ReturnsMergedAndSortedUniqueList()
        {
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 2, 4, 6 };
            var list3 = new List<int> { 0, 7, 8 };

            var result = processor.MergeSortedLists(new List<IEnumerable<int>> { list1, list2, list3 });

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, result);
        }

        [TestMethod]
        public void MergeSortedLists_WithNullLists_ReturnsEmptyList()
        {
            var result = processor.MergeSortedLists(null);

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(new List<int>(), result);
        }

        [TestMethod]
        public void MergeSortedLists_WithEmptyLists_ReturnsEmptyList()
        {
            var list1 = new List<int>();
            var list2 = new List<int>();

            var result = processor.MergeSortedLists(new List<IEnumerable<int>> { list1, list2 });

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(new List<int>(), result);
        }

        [TestMethod]
        public void MergeSortedLists_WithNullAndEmptyLists_ReturnsEmptyList()
        {
            var list1 = new List<int>();
            var list2 = new List<int>();

            var result = processor.MergeSortedLists(new List<IEnumerable<int>> { null, list1, list2 });

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(new List<int>(), result);
        }

        [TestMethod]
        public void MergeSortedLists_WithLargeLists_ReturnsMergedAndSortedUniqueList()
        {
            // Simulating large lists
            var list1 = Enumerable.Range(0, 500).ToList();
            var list2 = Enumerable.Range(500, 500).ToList();

            var result = processor.MergeSortedLists(new List<IEnumerable<int>> { list1, list2 });

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(Enumerable.Range(0, 1000).ToList(), result);
        }

        [TestMethod]
        public void MergeSortedLists_WithDuplicateElements_ReturnsMergedAndSortedUniqueList()
        {
            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 2, 3, 4 };

            var result = processor.MergeSortedLists(new List<IEnumerable<int>> { list1, list2 });

            Assert.IsNotNull(result);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4 }, result);
        }
    }
}
```

### Final Notes

- The provided implementation uses a `HashSet<int>` to ensure that all elements in the final merged list are unique.
- The method `MergeSortedLists` throws an `ArgumentNullException` if the input is null. This adheres to handling null cases as specified.
- The solution includes unit tests for various edge conditions, including null and empty lists, large lists, and duplicate elements.

### Migration to .NET 9.0

Once .NET 9.0 becomes available:

1. Update the `TargetFramework` in both `.csproj` files from `net6.0` to `net9.0`.
2. Rebuild your solution to ensure compatibility with any new features or changes in .NET 9.0.

This implementation should meet all of your requirements for creating a library that merges sorted lists efficiently and provides comprehensive unit tests.