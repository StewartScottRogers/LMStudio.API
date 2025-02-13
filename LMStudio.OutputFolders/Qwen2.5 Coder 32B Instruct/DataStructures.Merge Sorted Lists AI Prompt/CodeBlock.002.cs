// Services/MergeService.cs
using System.Collections.Generic;
using MergedSortedLists.Interfaces;

namespace MergedSortedLists.Services
{
    public readonly struct MergeService : IMergeService
    {
        public List<int> Merge(List<List<int>> sortedLists)
        {
            if (sortedLists == null || sortedLists.Count == 0)
                return new List<int>();

            SortedSet<int> mergedSet = new SortedSet<int>(); // Ensures no duplicates and is always sorted

            foreach (var list in sortedLists)
            {
                if (list != null && list.Count > 0)
                    mergedSet.UnionWith(list);
            }

            var resultListTuple = new List<int>(mergedSet);

            return resultListTuple;
        }
    }
}