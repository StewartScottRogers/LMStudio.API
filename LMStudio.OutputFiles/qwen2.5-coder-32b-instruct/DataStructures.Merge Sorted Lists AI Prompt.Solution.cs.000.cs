using System;
using System.Collections.Generic;
using System.Linq;

public class SortedListMerger
{
    public static readonly SortedListMerger Instance = new SortedListMerger();
    
    private SortedListMerger() { }

    // Fluent interface method for merging sorted lists.
    public IEnumerable<int> MergeSortedLists(IEnumerable<IEnumerable<int>> listOfLists)
    {
        var mergedList = new List<int>();
        
        if (listOfLists == null) return mergedList;

        foreach (var list in listOfLists)
        {
            if (list != null && list.Any())
            {
                mergedList.AddRange(list);
            }
        }

        // Use LINQ to merge and remove duplicates.
        var result = mergedList.Distinct().OrderBy(x => x).ToList();

        return result;
    }
}