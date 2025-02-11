
Here is a basic implementation of the SortedListMerger class in C# that follows your guidelines. This class provides a fluent interface for merging sorted lists of integers, handling null or empty input lists efficiently, and removing duplicates from the output list.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

public class SortedListMerger
{
    private List<int> _mergedList = new();

    public SortedListMerger AddList(IEnumerable<int> list)
    {
        // Check for null or empty input list
        if (list == null || !list.Any()) return this;

        // Merge the lists and remove duplicates
        _mergedList = _mergedList
            .Concat(list)
            .Distinct()
            .OrderBy(x => x)
            .ToList();

        return this;
    }

    public List<int> GetMergedList()
    {
        return _mergedList;
    }
}
```

You can use the SortedListMerger class as follows:

```csharp
var list1 = new[] { 1, 2, 3 };
var list2 = new[] { 2, 4, 6 };
var list3 = new[] { 3, 5, 7 };

var mergedList = new SortedListMerger()
    .AddList(list1)
    .AddList(list2)
    .AddList(list3)
    .GetMergedList();
```

This will result in a sorted list containing the numbers 1 through 7 without any duplicates.

Remember to write unit tests for this class using Microsoft's Unit Test Framework to ensure it behaves as expected.