public static class MergingExtensions
{
    /// <summary>
    /// Merges a list of sorted lists into a single sorted list using a fluent interface.
    /// </summary>
    /// <param name="source">The first list to merge.</param>
    /// <param name="additionalLists">Additional lists to merge with the source.</param>
    /// <returns>A merged and sorted list containing all elements from the input lists.</returns>
    public static IEnumerable<T> MergeWith(this IMergeableList<T> source, params IEnumerable<T>[] additionalLists)
        => source.Merge(additionalLists.Select(list => list.AsEnumerable()));
}