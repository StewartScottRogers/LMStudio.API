using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSortedListsLib
{
    public static class MergeUtility
    {
        /// <summary>
        /// Merges multiple sorted lists into a single sorted list without duplicates.
        /// </summary>
        /// <param name="sortedLists">A collection of sorted lists to merge.</param>
        /// <returns>A merged, sorted list containing unique elements.</returns>
        public static List<int> MergeSortedLists(IEnumerable<IEnumerable<int>> sortedLists)
        {
            if (sortedLists == null) throw new ArgumentNullException(nameof(sortedLists));

            var enumeratorList = sortedLists.Select(list => list.GetEnumerator()).ToList();

            // Use a min-heap to efficiently get the smallest element among all lists
            var priorityQueue = new SortedSet<(int Value, int ListIndex)>(
                Comparer<(int Value, int ListIndex)>.Create((a, b) =>
                    a.Value == b.Value ? a.ListIndex.CompareTo(b.ListIndex) : a.Value.CompareTo(b.Value)
                )
            );

            // Initialize the heap with the first element of each list
            for (var i = 0; i < enumeratorList.Count; i++)
            {
                if (enumeratorList[i].MoveNext())
                {
                    priorityQueue.Add((enumeratorList[i].Current, i));
                }
            }

            var mergedList = new List<int>();
            int? lastAddedValue = null;

            // Extract the smallest element and add to the result list
            while (priorityQueue.Count > 0)
            {
                var currentTuple = priorityQueue.Min;
                priorityQueue.Remove(currentTuple);

                if (lastAddedValue != currentTuple.Value)
                {
                    mergedList.Add(currentTuple.Value);
                    lastAddedValue = currentTuple.Value;
                }

                // Move to the next element in the corresponding list
                if (enumeratorList[currentTuple.ListIndex].MoveNext())
                {
                    priorityQueue.Add((enumeratorList[currentTuple.ListIndex].Current, currentTuple.ListIndex));
                }
            }

            return mergedList;
        }

        /// <summary>
        /// Fluent interface method to merge multiple sorted lists.
        /// </summary>
        public static IEnumerable<int> Merge(this IEnumerable<IEnumerable<int>> sortedLists)
        {
            return MergeSortedLists(sortedLists);
        }
    }
}