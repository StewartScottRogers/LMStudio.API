using System.Collections.Generic;

public class SortedListsMergeFluentInterface : ISortedListsMergeFluentInterface
{
    private readonly List<List<int>> listsToMerge = new();

    public ISortedListsMergeFluentInterface AddList(List<int> list)
    {
        if (list != null && list.Count > 0)
            listsToMerge.Add(list);
        return this;
    }

    public List<int> Merge()
    {
        var service = new SortedListsMergeService();
        return service.MergeSortedLists(listsToMerge.ToArray());
    }
}

public interface ISortedListsMergeFluentInterface
{
    ISortedListsMergeFluentInterface AddList(List<int> list);
    List<int> Merge();
}