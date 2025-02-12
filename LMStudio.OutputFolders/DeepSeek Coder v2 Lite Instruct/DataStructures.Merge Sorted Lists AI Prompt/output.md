 To create an in-memory library that merges sorted lists of integers using .NET 9.0, Visual Studio 2022, and adhering to the specified coding standards and requirements, follow these steps:

### Step 1: Initialize a New Solution in Visual Studio
1. Open Visual Studio 2022.
2. Create a new solution by selecting `File > New > Project`.
3. Choose `.NET Core` as the framework and `.NET 9.0 (Long-term support)` for the project template.
4. Name your solution `MergeSortedListsLibrary` and click `Create`.

### Step 2: Define the Project Structure
1. Add a new class library project to the solution named `MergeSortedListsLib`.
2. Ensure each class, interface, enumeration, and record is in its own file as per the requirements.

### Step 3: Develop the Library Code
#### a. Define Interfaces and Records
Create an interface `IMergeableList<T>` that will be implemented by classes that can merge sorted lists. Also, define a record `MergeResult` to hold the result of the merge operation.

**IMergeableList.cs:**
```csharp
namespace MergeSortedListsLib
{
    public interface IMergeableList<T> where T : IComparable<T>
    {
        IEnumerable<T> Merge(IEnumerable<IEnumerable<T>> lists);
    }
}
```

**MergeResult.cs:**
```csharp
namespace MergeSortedListsLib
{
    public record MergeResult<T>(List<T> SortedList, HashSet<T> UniqueElements);
}
```

#### b. Implement the Merging Logic
Create a class `Merger` that implements `IMergeableList<int>` to handle the merging of sorted lists of integers.

**Merger.cs:**
```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSortedListsLib
{
    public class Merger : IMergeableList<int>
    {
        public IEnumerable<int> Merge(IEnumerable<IEnumerable<int>> lists)
        {
            var priorityQueue = new SortedSet<(int Value, int ListIndex)>();
            var resultList = new List<int>();
            var seen = new HashSet<int>();

            foreach (var list in lists)
            {
                if (list.Any())
                {
                    priorityQueue.Add((list.First(), lists.ToList().IndexOf(list)));
                }
            }

            while (priorityQueue.Count > 0)
            {
                var (value, listIndex) = priorityQueue.Min;
                priorityQueue.Remove(priorityQueue.Min);

                if (!seen.Contains(value))
                {
                    resultList.Add(value);
                    seen.Add(value);
                }

                var nextElement = lists.ElementAt(listIndex).SkipWhile(x => x == value).FirstOrDefault();
                if (nextElement != default)
                {
                    priorityQueue.Add((nextElement, listIndex));
                }
            }

            return resultList;
        }
    }
}
```

### Step 4: Develop Unit Tests
1. Add a new unit test project to the solution named `MergeSortedListsLibTests`.
2. Use the Microsoft Unit Test Framework to create tests for the merging logic.

**MergerTests.cs:**
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MergeSortedListsLib.Tests
{
    [TestClass]
    public class MergerTests
    {
        private Merger _merger = new Merger();

        [TestMethod]
        public void TestMergeTwoLists()
        {
            var lists = new List<IEnumerable<int>>
            {
                new List<int> { 1, 3, 5 },
                new List<int> { 2, 4, 6 }
            };

            var result = _merger.Merge(lists);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, result.ToList());
        }

        [TestMethod]
        public void TestMergeEmptyLists()
        {
            var lists = new List<IEnumerable<int>>
            {
                new List<int>(),
                new List<int>()
            };

            var result = _merger.Merge(lists);
            CollectionAssert.AreEqual(new List<int>(), result.ToList());
        }

        [TestMethod]
        public void TestMergeNullLists()
        {
            var lists = new List<IEnumerable<int>>
            {
                null,
                null
            };

            var result = _merger.Merge(lists);
            CollectionAssert.AreEqual(new List<int>(), result.ToList());
        }
    }
}
```

### Step 5: Document the Project
1. Create a `README` file in the root directory of the solution to document the project, including instructions on how to use the library and key points of logic.

### Step 6: Compile and Test the Solution
1. Build and run the solution to ensure all parts are working correctly.
2. Run unit tests to verify the functionality.

This setup ensures that your library adheres to the specified requirements, is well-documented, and includes comprehensive unit testing.