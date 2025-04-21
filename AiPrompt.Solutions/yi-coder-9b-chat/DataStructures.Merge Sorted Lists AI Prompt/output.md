Here's an outline for a simple implementation in C#:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

namespace SortedListMerger
{
    public class ListMerger 
	{
        // Method to merge N sorted lists of integers without duplicates
        public static IEnumerable<int> MergeLists(params IEnumerable<int>[] lists) 
		{
            return lists.SelectMany(l => l) // Flatten the list of lists into a single list
                        .Distinct()  // Remove duplicates by converting to a set
                        .OrderBy(n => n); // Sort the list in ascending order
        }
    }

    public static class ExtensionMethods 
	{
        // Extension method for IEnumerable<int> to merge multiple sorted lists into a single fluent interface
        public static IEnumerable<int> MergeSortedLists(this IEnumerable<IEnumerable<int>> enumerable) 
		{
            return ListMerger.MergeLists(enumerable.ToArray()); // Use the static method to merge the sorted lists
        }
    }
}```