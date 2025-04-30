// MergedList.cs
using System;
using System.Collections.Generic;

namespace SortedListsMerger
{
    public class MergedList : IMergeLists
    {
        public List<int> Merge(List<List<int>> sortedLists)
        {
            if (sortedLists == null)
                throw new ArgumentNullException(nameof(sortedLists));

            var mergedList = new List<int>();
            var indices = new Dictionary<int, int>();

            // Initialize indices for each list
            foreach (var list in sortedLists)
            {
                indices.Add(sortedLists.IndexOf(list), 0);
            }

            while (true)
            {
                bool allExhausted = true;
                int? minValue = null;
                int minIndex = -1;

                foreach (var kvp in indices)
                {
                    var listIndex = kvp.Key;
                    var elementIndex = kvp.Value;

                    if (elementIndex < sortedLists[listIndex].Count)
                    {
                        allExhausted = false;
                        var currentValue = sortedLists[listIndex][elementIndex];

                        if (!minValue.HasValue || currentValue < minValue.Value)
                        {
                            minValue = currentValue;
                            minIndex = listIndex;
                        }
                    }
                }

                if (allExhausted)
                    break;

                // Avoid duplicates
                if (mergedList.Count == 0 || mergedList[mergedList.Count - 1] != minValue.Value)
                {
                    mergedList.Add(minValue.Value);
                }

                indices[minIndex]++;
            }

            return mergedList;
        }
    }
}