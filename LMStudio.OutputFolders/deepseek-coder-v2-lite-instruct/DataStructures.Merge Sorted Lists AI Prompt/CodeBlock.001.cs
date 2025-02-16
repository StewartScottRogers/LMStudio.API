// Merger.cs
using System;
using System.Collections.Generic;

namespace InMemoryLibrary
{
    public class Merger<T> : IMerger<T> where T : IComparable<T>
    {
        public List<T> MergeSortedLists(List<List<T>> lists)
        {
            var minHeap = new SortedSet<(T value, int listIndex, int elementIndex)>();
            var result = new List<T>();

            // Initialize the heap with the first element of each list
            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].Count > 0)
                {
                    minHeap.Add((lists[i][0], i, 0));
                }
            }

            while (minHeap.Count > 0)
            {
                var current = minHeap.Min;
                minHeap.Remove(current);
                result.Add(current.value);

                // If there is a next element in the same list, add it to the heap
                if (current.elementIndex + 1 < lists[current.listIndex].Count)
                {
                    var next = (lists[current.listIndex][current.elementIndex + 1], current.listIndex, current.elementIndex + 1);
                    minHeap.Add(next);
                }
            }

            return result;
        }
    }
}