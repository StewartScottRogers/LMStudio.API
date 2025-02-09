using System;
using System.Collections.Generic;
using System.Linq;

// Default implementation of the merging strategy
public class MergeStrategy<T> : IMergeStrategy<T>
{
    // Merges multiple sorted lists into a single sorted list without duplicates.
    public IEnumerable<T> MergeLists(IEnumerable<IEnumerable<T>> sortedLists)
    {
        if (sortedLists == null) throw new ArgumentNullException(nameof(sortedLists));
        
        var mergedSet = new SortedSet<T>();
        
        foreach (var sortedList in sortedLists.Where(list => list != null && list.Any()))
        {
            foreach (var item in sortedList)
            {
                mergedSet.Add(item);
            }
        }

        return mergedSet;
    }
}