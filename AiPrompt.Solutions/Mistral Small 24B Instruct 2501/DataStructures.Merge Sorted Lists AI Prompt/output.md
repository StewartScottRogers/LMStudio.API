Creating an in-memory library that merges sorted lists of integers following the provided guidelines involves several steps. Below is a complete .NET 9.0 solution setup for this task.

### Solution Structure

The solution will consist of:
- **MergedLibrary**: A class library project containing the core logic.
- **MergedLibrary.Tests**: A unit test project to ensure functionality and performance.

### Project Files
We'll create separate files for each class, interface, etc., as required by the guidelines.

#### MergedLibrary

##### Program.cs
```csharp
using System;
using System.Collections.Generic;

namespace MergedLibrary
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 2, 4, 6 };
            var list3 = new List<int> { 0, 7, 8 };

            var result = new SortedListMerger<int>().Add(list1).Add(list2).Add(list3).Merge();

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
```

##### SortedListMerger.cs
```csharp
using System;
using System.Collections.Generic;

namespace MergedLibrary
{
    public class SortedListMerger<T> where T : IComparable<T>
    {
        private readonly List<List<T>> lists = new();

        public SortedListMerger<T> Add(List<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            lists.Add(list);
            return this;
        }

        public List<T> Merge()
        {
            var mergedList = new List<T>();
            foreach (var list in lists)
            {
                mergedList.AddRange(list);
            }

            mergedList.Sort();
            RemoveDuplicates(mergedList);

            return mergedList;
        }

        private void RemoveDuplicates(List<T> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].CompareTo(list[i - 1]) == 0)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
```

#### MergedLibrary.Tests

##### SortedListMergerTests.cs
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MergedLibrary.Tests
{
    [TestClass]
    public class SortedListMergerTests
    {
        private readonly SortedListMerger<int> merger = new();

        [TestMethod]
        public void Merge_TwoSortedLists_ReturnsMergedAndSorted()
        {
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 2, 4, 6 };

            var result = merger.Add(list1).Add(list2).Merge();

            Assert.AreEqual(6, result.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, result);
        }

        [TestMethod]
        public void Merge_WithNullList_ReturnsMergedAndSorted()
        {
            var list1 = new List<int> { 1, 3, 5 };
            merger.Add(list1).Add(null);

            var result = merger.Merge();

            Assert.AreEqual(3, result.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 3, 5 }, result);
        }

        [TestMethod]
        public void Merge_WithEmptyList_ReturnsMergedAndSorted()
        {
            var list1 = new List<int> { 1, 3, 5 };
            var emptyList = new List<int>();

            var result = merger.Add(list1).Add(emptyList).Merge();

            Assert.AreEqual(3, result.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 3, 5 }, result);
        }

        [TestMethod]
        public void Merge_WithDuplicateValues_ReturnsUnique()
        {
            var list1 = new List<int> { 1, 2, 3 };
            var list2 = new List<int> { 2, 4, 6 };

            var result = merger.Add(list1).Add(list2).Merge();

            Assert.AreEqual(5, result.Count);
            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 6 }, result);
        }

        [TestMethod]
        public void Merge_WithNegativeNumbers_ReturnsMergedAndSorted()
        {
            var list1 = new List<int> { -3, -1, 1 };
            var list2 = new List<int> { -2, 0, 2 };

            var result = merger.Add(list1).Add(list2).Merge();

            Assert.AreEqual(6, result.Count);
            CollectionAssert.AreEqual(new List<int> { -3, -2, -1, 0, 1, 2 }, result);
        }
    }
}
```

### Instructions to Set Up in Visual Studio 2022
1. Open Visual Studio 2022.
2. Create a new solution named `MergedLibrarySolution`.
3. Add a Class Library project named `MergedLibrary` and add the provided `.cs` files to it.
4. Add a Unit Test Project named `MergedLibrary.Tests` and reference the `MergedLibrary` project.
5. Add the provided test file to the `MergedLibrary.Tests` project.
6. Build and run the solution to ensure all components work correctly.

This setup follows all specified guidelines, ensuring proper naming conventions, code organization, and testing practices.