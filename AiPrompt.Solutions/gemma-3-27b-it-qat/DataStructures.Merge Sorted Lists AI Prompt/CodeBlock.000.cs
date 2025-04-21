// File: SortedListMerger.cs

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegerListMergeLibrary
{
    /// <summary>
    /// Provides a fluent interface for merging sorted lists of integers.
    /// </summary>
    public class SortedListMerger
    {
        private readonly List<List<int>> inputLists = new();

        /// <summary>
        /// Adds a sorted list to the merger.
        /// </summary>
        /// <param name="sortedList">The sorted list to add.</param>
        /// <returns>The SortedListMerger instance for chaining operations.</returns>
        public SortedListMerger AddSortedList(List<int> sortedList)
        {
            if (sortedList != null)
            {
                inputLists.Add(sortedList);
            }

            return this;
        }

        /// <summary>
        /// Merges the added sorted lists into a single sorted list without duplicates.
        /// </summary>
        /// <returns>A tuple containing the merged and sorted list, or an empty list if no input lists were provided.</returns>
        public (List<int> MergedListTuple) MergeLists()
        {
            if (inputLists.Count == 0)
            {
                return (new List<int>()); // Return an empty list if there are no input lists.
            }

            var mergedList = new List<int>();
            var sortedSet = new SortedSet<int>(); // Use a SortedSet to automatically handle sorting and duplicates.

            foreach (var list in inputLists)
            {
                if (list != null)
                {
                    foreach (var number in list)
                    {
                        sortedSet.Add(number);
                    }
                }
            }

            mergedList = sortedSet.ToList(); // Convert the SortedSet back to a List.

            return (MergedListTuple: mergedList);
        }
    }
}