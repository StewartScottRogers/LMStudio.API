using System;
using System.Collections.Generic;
using System.Linq;

namespace InMemoryLibrary
{
    public class MergeSortedLists
    {
        /// <summary>
        /// Merges multiple sorted lists into one sorted list without duplicates.
        /// </summary>
        /// <param name="sortedLists">The input sorted lists of integers.</param>
        /// <returns>A single sorted list containing all elements from the input lists, with no duplicates.</returns>
        public List<int> Merge(IEnumerable<IReadOnlyList<int>> sortedLists)
        {
            var mergedSet = new SortedSet<int>();
            foreach (var list in sortedLists)
            {
                if (list == null) continue;
                foreach (var item in list)
                {
                    mergedSet.Add(item);
                }
            }
            return new List<int>(mergedSet);
        }

        /// <summary>
        /// Overload to handle fluent chaining.
        /// </summary>
        public FluentMerge MergeFluent(IEnumerable<IReadOnlyList<int>> sortedLists) => new FluentMerge(this, sortedLists);

    }

    public class FluentMerge
    {
        private readonly MergeSortedLists _mergeSortedLists;
        private readonly List<List<int>> _sortedLists;

        internal FluentMerge(MergeSortedLists mergeSortedLists, IEnumerable<IReadOnlyList<int>> sortedLists)
        {
            _mergeSortedLists = mergeSortedLists ?? throw new ArgumentNullException(nameof(mergeSortedLists));
            _sortedLists = sortedLists?.Select(list => list.ToList()).ToList() ?? throw new ArgumentNullException(nameof(sortedLists));
        }

        /// <summary>
        /// Adds a new sorted list to the fluent interface for merging.
        /// </summary>
        /// <param name="newSortedList">The new sorted list of integers.</param>
        /// <returns>The current FluentMerge instance.</returns>
        public FluentMerge Add(IReadOnlyList<int> newSortedList)
        {
            _sortedLists.Add(newSortedList?.ToList() ?? throw new ArgumentNullException(nameof(newSortedList)));
            return this;
        }

        /// <summary>
        /// Executes the merge operation on all collected lists.
        /// </summary>
        /// <returns>A single sorted list containing all elements from the input lists, with no duplicates.</returns>
        public List<int> Execute()
        {
            return _mergeSortedLists.Merge(_sortedLists);
        }
    }
}