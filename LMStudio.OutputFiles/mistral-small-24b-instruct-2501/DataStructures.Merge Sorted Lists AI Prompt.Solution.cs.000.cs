namespace MergeSortedListsLibrary.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for merging sorted lists.
    /// </summary>
    public interface IMergeSortedLists
    {
        /// <summary>
        /// Merges multiple sorted lists into a single sorted list without duplicates.
        /// </summary>
        /// <param name="lists">A collection of sorted integer lists.</param>
        /// <returns>A tuple containing the merged sorted list and the total number of elements merged.</returns>
        var MergeSortedListsTuple MergeSortedLists(IEnumerable<IEnumerable<int>> lists);
    }
}