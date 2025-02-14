using System;
using System.Collections.Generic;

public class SortedListsMergeService : ISortedListsMergeService
{
    public List<int> MergeSortedLists(params List<int>[] sortedLists)
    {
        if (sortedLists == null || sortedLists.Length == 0) return new List<int>();

        var mergedList = new HashSet<int>(); // Using HashSet to avoid duplicates
        foreach (var list in sortedLists)
        {
            if (list != null && list.Count > 0)
            {
                foreach (var number in list)
                {
                    mergedList.Add(number);
                }
            }
        }

        var resultList = new List<int>(mergedList);
        resultList.Sort();
        return resultList;
    }
}

public interface ISortedListsMergeService
{
    List<int> MergeSortedLists(params List<int>[] sortedLists);
}