using System.Collections.Generic;

namespace SortedListMerger
{
    public interface IMergeService
    {
        var MergeSortedListsTuple(IEnumerable<IEnumerable<int>> sortedLists);
    }
}