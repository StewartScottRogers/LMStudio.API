using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeLibrary;

/// <summary>
/// A utility class for merging multiple sorted lists of integers efficiently.
/// </summary>
public static class MergedSortedLists
{
    /// <summary>
    /// Merges N sorted lists into a single sorted list with no duplicates.
    /// </summary>
    public static List<int> Merge(params List<List<int>>[] input)
    {
        // Handle null or empty input directly in the method parameter checks.
        if (input == null) return new();

        var activeHeads = new List<HeapNode>();
        foreach (var list in input)
        {
            if (list != null && list.Count > 0)
                activeHeads.Add(new HeapNode(list[0], list, 0));
        }

        // Now implement the merge with careful handling of duplicates.
    }
}