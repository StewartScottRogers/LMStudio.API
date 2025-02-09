using System;
using System.Collections.Generic;
using System.Linq;

// Fluent interface for merging sorted lists of integers
public static class ListMerger
{
    private static IOrderedEnumerable<int> MergeSortedLists(IEnumerable<IEnumerable<int>> lists)
    {
        // Ensure null or empty list handling and LINQ merge operation
        if (lists == null || !lists.Any())
            return Enumerable.Empty<int>().OrderBy(n => n);
        
        return lists.SelectMany(list => list).Distinct().OrderBy(n => n);
    }

    // Fluent method to start merging process
    public static IOrderedEnumerable<int> Merge(this IEnumerable<IEnumerable<int>> lists)
    {
        return MergeSortedLists(lists);
    }
}