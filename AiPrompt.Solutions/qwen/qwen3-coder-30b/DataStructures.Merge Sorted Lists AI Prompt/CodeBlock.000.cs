using System;
using System.Collections.Generic;

namespace MergeSortedLists
{
    /// <summary>
    /// Interface for merging sorted lists of integers
    /// </summary>
    public interface IMergeSortedLists
    {
        /// <summary>
        /// Merges multiple sorted integer lists into a single sorted list without duplicates
        /// </summary>
        /// <param name="sortedLists">Collection of sorted integer lists</param>
        /// <returns>A tuple containing the merged result and processing statistics</returns>
        (List<int> Result, MergeStatistics Statistics) MergeSortedListsTuple(IEnumerable<IEnumerable<int>> sortedLists);
    }
}