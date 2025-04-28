// IntegerListMerger/IntegerListMerger.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegerListMerger
{
    /// <summary>
    /// Provides functionality to merge sorted lists of integers into a single sorted list without duplicates.
    /// </summary>
    public class IntegerListMergerClass
    {
        /// <summary>
        /// Merges multiple sorted lists of integers into a single sorted list, removing duplicates.
        /// </summary>
        /// <param name="sortedLists">A collection of sorted integer lists to merge.</param>
        /// <returns>A tuple containing the merged and sorted list of integers without duplicates.</returns>
        public (List<int> MergedListTuple) MergeSortedLists(IEnumerable<List<int>> sortedLists)
        {
            // Handle null or empty input.
            if (sortedLists == null || !sortedLists.Any())
            {
                return (new List<int>());
            }

            // Concatenate all lists into a single list.
            var concatenatedList = sortedLists.SelectMany(list => list).ToList();

            // Remove duplicates and sort the list.
            var distinctSortedList = concatenatedList.Distinct().OrderBy(x => x).ToList();

            return (distinctSortedList);
        }
    }
}