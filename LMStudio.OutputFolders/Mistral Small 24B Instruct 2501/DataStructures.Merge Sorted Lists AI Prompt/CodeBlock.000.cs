using System;
using System.Collections.Generic;
using System.Linq;

namespace SortedListMerger
{
    public class SortedListMerger : IMergeableList
    {
        private readonly List<int> mergedList = new();

        /// <summary>
        /// Merges multiple sorted lists into a single sorted list without duplicates.
        /// </summary>
        /// <param name="lists">The sorted lists of integers to merge.</param>
        /// <returns>A tuple containing the merged and sorted list and a boolean indicating success.</returns>
        public var MergeSortedListsTuple MergeSortedLists(IEnumerable<IEnumerable<int>> lists)
        {
            foreach (var list in lists)
            {
                if (list == null) continue;

                foreach (var item in list)
                {
                    if (!mergedList.Contains(item))
                    {
                        mergedList.Add(item);
                    }
                }

                // Sort the list after each merge to ensure it remains sorted
                mergedList.Sort();
            }

            var result = new MergeResultTuple(mergedList, true);
            return result;
        }

    }
}