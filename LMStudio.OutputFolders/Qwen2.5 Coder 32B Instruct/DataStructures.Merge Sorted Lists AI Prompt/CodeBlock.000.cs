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