using System.Collections.Generic;

namespace SortedListMerger
{
    public interface IMergeableList
    {
        /// <summary>
        /// Merges multiple sorted lists into a single sorted list without duplicates.
        /// </summary>
        /// <param name="lists">The sorted lists of integers to merge.</param>
        /// <returns>A tuple containing the merged and sorted list and a boolean indicating success.</returns>
        var MergeSortedListsTuple MergeSortedLists(IEnumerable<IEnumerable<int>> lists);
    }
}