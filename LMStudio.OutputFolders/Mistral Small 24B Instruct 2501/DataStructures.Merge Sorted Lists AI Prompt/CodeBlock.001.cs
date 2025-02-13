using System;
using System.Collections.Generic;
using System.Linq;

namespace SortedListMerger
{
    public class MergeService : IMergeService
    {
        /// <summary>
        /// Merges multiple sorted lists into a single sorted list without duplicates.
        /// </summary>
        /// <param name="sortedLists">An enumerable of sorted integer lists.</param>
        /// <returns>A tuple containing the merged sorted list and a boolean indicating success.</returns>
        public var MergeSortedListsTuple(IEnumerable<IEnumerable<int>> sortedLists)
        {
            // Flatten the input lists into one list
            var flattenedList = new List<int>();
            foreach (var list in sortedLists)
            {
                if(list != null && !list.Any())
                    continue;
                flattenedList.AddRange(list);
            }

            // Remove duplicates and sort the list
            var mergedList = flattenedList.Distinct().OrderBy(x => x).ToList();

            return new
            {
                MergedList = mergedList,
                Success = true
            };
        }
    }
}