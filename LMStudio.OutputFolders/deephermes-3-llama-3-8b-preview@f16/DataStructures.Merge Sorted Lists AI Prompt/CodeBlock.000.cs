public interface IMergeableList<T> where T : IComparable<T>
{
    /// <summary>
    /// Merges the given list of lists into a single sorted list.
    /// </summary>
    /// <param name="lists">The lists to merge.</param>
    /// <returns>A merged and sorted list containing all elements from the input lists.</returns>
    IEnumerable<T> Merge(IEnumerable<IEnumerable<T>> lists);
}