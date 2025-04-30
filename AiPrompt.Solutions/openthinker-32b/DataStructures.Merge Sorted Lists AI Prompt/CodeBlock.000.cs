using System.Collections.Generic;

namespace SortedListsMerger
{
    public interface IMergedListProcessor
    {
        List<int> MergeSortedLists(IEnumerable<IEnumerable<int>> sortedLists);
    }
}