Creating a .NET 9.0 solution that meets all your requirements is quite an extensive task, but I'll provide you with the core components for this project to get you started. Note that as of now, .NET 9.0 does not exist, so we'll create the solution based on .NET 6.0 which is a current stable version and should be fully compatible with Visual Studio 2022.

### Step-by-Step Guide

1. **Create Solution and Projects**
   - Create a new Class Library Project named `InMemoryLibrary`.
   - Add a new Unit Test Project named `InMemoryLibrary.Tests`.

2. **Implement the Logic for Merging Sorted Lists**

Here is a simplified implementation of the required functionality:

#### InMemoryLibrary/IMergeService.cs
```csharp
namespace InMemoryLibrary
{
    public interface IMergeService
    {
        List<int> MergeSortedLists(params List<int>[] sortedLists);
    }
}
```

#### InMemoryLibrary/MergeService.cs
```csharp
using System;
using System.Collections.Generic;

namespace InMemoryLibrary
{
    public class MergeService : IMergeService
    {
        public List<int> MergeSortedLists(params List<int>[] sortedLists)
        {
            var mergedList = new List<int>();
            var iterators = new List<IEnumerator<int>>();
            
            foreach (var list in sortedLists)
            {
                if (list != null && list.Count > 0)
                {
                    iterators.Add(list.GetEnumerator());
                }
            }

            while (iterators.Count > 0)
            {
                int minValue = int.MaxValue;
                int indexToRemove = -1;
                
                for (int i = 0; i < iterators.Count; i++)
                {
                    if (!iterators[i].MoveNext())
                    {
                        iterators.RemoveAt(i);
                        i--;
                        continue;
                    }

                    if (iterators[i].Current < minValue)
                    {
                        minValue = iterators[i].Current;
                        indexToRemove = i;
                    }
                }

                // Avoid duplicates
                if (mergedList.Count == 0 || mergedList[mergedList.Count - 1] != minValue)
                {
                    mergedList.Add(minValue);
                }

                if (indexToRemove >= 0 && !iterators[indexToRemove].MoveNext())
                {
                    iterators.RemoveAt(indexToRemove);
                }
            }
            
            return mergedList;
        }
    }
}
```

#### InMemoryLibrary/Program.cs
```csharp
using System;
using System.Collections.Generic;

namespace InMemoryLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var mergeService = new MergeService();
            
            var list1 = new List<int> { 1, 3, 5, 7 };
            var list2 = new List<int> { 0, 2, 6, 8 };
            var list3 = new List<int> { 4, 9 };

            var result = mergeService.MergeSortedLists(list1, list2, list3);

            Console.WriteLine("Merged Sorted List:");
            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
        }
    }
}
```

### Unit Testing

#### InMemoryLibrary.Tests/MergeServiceTests.cs
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace InMemoryLibrary.Tests
{
    [TestClass]
    public class MergeServiceTests
    {
        private readonly IMergeService mergeService = new MergeService();

        [TestMethod]
        public void TestMergeSortedLists()
        {
            var list1 = new List<int> { 1, 3, 5 };
            var list2 = new List<int> { 2, 4, 6 };

            var result = mergeService.MergeSortedLists(list1, list2);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, result);
        }

        [TestMethod]
        public void TestMergeWithNullAndEmptyLists()
        {
            var list1 = new List<int>();
            var list2 = (List<int>)null;
            var list3 = new List<int> { 1, 2, 3 };

            var result = mergeService.MergeSortedLists(list1, list2, list3);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3 }, result);
        }

        [TestMethod]
        public void TestMergeWithDuplicates()
        {
            var list1 = new List<int> { 1, 2, 2 };
            var list2 = new List<int> { 2, 3, 4 };

            var result = mergeService.MergeSortedLists(list1, list2);

            CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4 }, result);
        }
    }
}
```

### Explanation

- **MergeService**: Implements the logic to merge multiple sorted lists into one sorted list without duplicates.
- **Unit Tests**: Verifies that the method works correctly under various conditions including handling null and empty lists and removing duplicates.

This code meets your specified guidelines for naming, coding style, and structure. You can further extend this solution based on additional requirements or optimizations needed.