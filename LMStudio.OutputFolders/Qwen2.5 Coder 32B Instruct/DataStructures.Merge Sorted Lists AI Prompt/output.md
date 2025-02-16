Creating a .NET 9.0 solution that merges sorted lists of integers into a single sorted list without duplicates, while adhering to the specified guidelines, involves several steps. Below is the implementation of such a library in C#. However, it's important to note that as of now (2023), there is no official .NET 9.0 release. The instructions will follow .NET 6 or later conventions and should be compatible with Visual Studio 2022.

### Step-by-Step Implementation

1. **Setup the Solution:**
   - Open Visual Studio 2022.
   - Create a new .NET Class Library project named `MergeSortedListsLibrary`.
   - Add a new Unit Test Project named `MergeSortedListsTests` to the solution.

2. **Implement the Merging Logic:**

#### MergeSortedLists.cs
```csharp
using System;
using System.Collections.Generic;

public class MergeSortedLists
{
    private readonly List<List<int>> sortedLists;

    public MergeSortedLists()
    {
        this.sortedLists = new List<List<int>>();
    }

    public MergeSortedLists Add(List<int> list)
    {
        if (list != null)
        {
            this.sortedLists.Add(list);
        }
        return this;
    }

    public List<int> MergeAndRemoveDuplicates()
    {
        var mergedList = new SortedSet<int>();
        foreach (var list in sortedLists)
        {
            if (list == null) continue;

            foreach (var item in list)
            {
                mergedList.Add(item);
            }
        }
        return new List<int>(mergedList);
    }
}
```

3. **Create a Fluent Interface:**

Since the `MergeSortedLists` class already provides a fluent interface by returning `this` from the `Add` method, no further changes are needed.

4. **Unit Tests Implementation:**

#### MergeSortedListsTests.cs
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

[TestClass]
public class MergeSortedListsTests
{
    [TestMethod]
    public void TestMergeAndRemoveDuplicates()
    {
        var list1 = new List<int> { 1, 3, 5 };
        var list2 = new List<int> { 2, 4, 6 };
        var list3 = new List<int> { 3, 5, 7 };

        var result = new MergeSortedLists()
            .Add(list1)
            .Add(list2)
            .Add(list3)
            .MergeAndRemoveDuplicates();

        CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7 }, result);
    }

    [TestMethod]
    public void TestNullLists()
    {
        var list1 = new List<int> { 1, 3, 5 };
        var list2 = null as List<int>;
        var list3 = new List<int> { 2, 4, 6 };

        var result = new MergeSortedLists()
            .Add(list1)
            .Add(list2)
            .Add(list3)
            .MergeAndRemoveDuplicates();

        CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, result);
    }

    [TestMethod]
    public void TestEmptyLists()
    {
        var list1 = new List<int> { };
        var list2 = new List<int> { 2, 4, 6 };
        var list3 = new List<int> { };

        var result = new MergeSortedLists()
            .Add(list1)
            .Add(list2)
            .Add(list3)
            .MergeAndRemoveDuplicates();

        CollectionAssert.AreEqual(new List<int> { 2, 4, 6 }, result);
    }

    [TestMethod]
    public void TestAllEmptyLists()
    {
        var list1 = new List<int> { };
        var list2 = new List<int> { };
        var list3 = new List<int> { };

        var result = new MergeSortedLists()
            .Add(list1)
            .Add(list2)
            .Add(list3)
            .MergeAndRemoveDuplicates();

        CollectionAssert.AreEqual(new List<int>(), result);
    }
}
```

5. **Build and Test:**
   - Build the solution in Visual Studio 2022.
   - Run all unit tests to ensure that they pass.

### Explanation

- The `MergeSortedLists` class manages a list of lists (`sortedLists`) and provides methods to add lists and perform merging.
- The `Add` method allows for chaining operations, creating a fluent interface.
- The `MergeAndRemoveDuplicates` method uses a `SortedSet<int>` to efficiently merge lists and remove duplicates.
- Unit tests verify the correctness of the implementation under different scenarios.

This setup adheres to the coding standards provided and ensures that the library is robust and efficient.