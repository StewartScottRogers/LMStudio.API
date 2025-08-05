using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSortedLists
{
    /// <summary>
    /// Implementation for merging sorted lists of integers efficiently
    /// </summary>
    public class MergeSortedLists : IMergeSortedLists
    {
        /// <summary>
        /// Merges multiple sorted integer lists into a single sorted list without duplicates
        /// Uses a priority queue approach for optimal performance with large inputs
        /// </summary>
        /// <param name="sortedLists">Collection of sorted integer lists</param>
        /// <returns>A tuple containing the merged result and processing statistics</returns>
        public (List<int> Result, MergeStatistics Statistics) MergeSortedListsTuple(IEnumerable<IEnumerable<int>> sortedLists)
        {
            if (sortedLists == null)
            {
                throw new MergeSortedListsException("Input lists collection cannot be null");
            }

            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            
            // Initialize result list and set for duplicate tracking
            var result = new List<int>();
            var seenValues = new HashSet<int>();
            
            // Count total elements and lists for statistics
            var totalElements = 0;
            var totalLists = 0;
            
            // Prepare a list of enumerators to track current position in each list
            var enumerators = new List<IEnumerator<int>>();
            var currentValues = new List<int?>();
            
            try
            {
                // Initialize enumerators for all non-null lists
                foreach (var list in sortedLists)
                {
                    if (list != null)
                    {
                        totalLists++;
                        var enumerator = list.GetEnumerator();
                        enumerators.Add(enumerator);
                        
                        // Move to first element if available
                        if (enumerator.MoveNext())
                        {
                            currentValues.Add(enumerator.Current);
                            totalElements += list.Count();
                        }
                        else
                        {
                            currentValues.Add(null); // Empty list
                        }
                    }
                }

                // Process elements using a min-heap approach
                while (enumerators.Any(e => e != null))
                {
                    // Find minimum value among current elements
                    int? minValue = null;
                    var minIndex = -1;
                    
                    for (var i = 0; i < currentValues.Count; i++)
                    {
                        if (currentValues[i] == null) continue;
                        
                        if (minValue == null || currentValues[i] < minValue)
                        {
                            minValue = currentValues[i];
                            minIndex = i;
                        }
                    }
                    
                    // If we found a minimum value, add it to result if not duplicate
                    if (minValue.HasValue)
                    {
                        if (!seenValues.Contains(minValue.Value))
                        {
                            seenValues.Add(minValue.Value);
                            result.Add(minValue.Value);
                        }
                        
                        // Move to next element in the list that had the minimum value
                        var enumerator = enumerators[minIndex];
                        if (enumerator.MoveNext())
                        {
                            currentValues[minIndex] = enumerator.Current;
                        }
                        else
                        {
                            // End of this list, mark as null
                            currentValues[minIndex] = null;
                            enumerators[minIndex] = null;
                        }
                    }
                    else
                    {
                        // No more elements to process
                        break;
                    }
                }
            }
            finally
            {
                // Clean up enumerators
                foreach (var enumerator in enumerators)
                {
                    enumerator?.Dispose();
                }
            }

            stopwatch.Stop();
            
            var statistics = new MergeStatistics
            {
                TotalLists = totalLists,
                TotalElements = totalElements,
                ProcessingTimeMs = stopwatch.ElapsedMilliseconds
            };
            
            return (result, statistics);
        }
    }
}