namespace MergeSortedListsLibrary.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using MergeSortedListsLibrary.Interfaces;
    using MergeSortedListsLibrary.Records;

    /// <summary>
    /// Service for merging sorted lists.
    /// </summary>
    public class MergeSortedListsService : IMergeSortedLists
    {
        /// <inheritdoc/>
        public var MergeSortedListsTuple MergeSortedLists(IEnumerable<IEnumerable<int>> lists)
        {
            if (lists == null) throw new ArgumentNullException(nameof(lists));

            // Use a HashSet to avoid duplicates and maintain order.
            var mergedList = new SortedSet<int>();

            foreach (var list in lists)
            {
                if (list != null)
                {
                    mergedList.UnionWith(list);
                }
            }

            return MergeResult(
                MergedList: mergedList,
                TotalElementsMerged: mergedList.Count
            );
        }
    }
}