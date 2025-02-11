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