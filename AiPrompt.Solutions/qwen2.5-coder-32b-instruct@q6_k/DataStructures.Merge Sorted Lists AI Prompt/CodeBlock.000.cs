// IMergeLists.cs
using System.Collections.Generic;

namespace SortedListsMerger
{
    public interface IMergeLists
    {
        List<int> Merge(List<List<int>> sortedLists);
    }
}