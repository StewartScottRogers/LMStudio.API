using System;
using System.Collections.Generic;

public class MergedListResult
{
    private readonly SortedSet<int> _uniqueElements;
    public int TotalElements { get; private set; }

    public MergedListResult()
    {
        _uniqueElements = new SortedSet<int>();
        TotalElements = 0;
    }

    public MergedListResult Merge(IEnumerable<int> list)
    {
        if (list == null) return this;

        foreach (int num in list)
        {
            if (_uniqueElements.Add(num))
                TotalElements++;
        }

        return this;
    }

    public List<int> ToSortedList()
    {
        return _uniqueElements.ToList();
    }
}