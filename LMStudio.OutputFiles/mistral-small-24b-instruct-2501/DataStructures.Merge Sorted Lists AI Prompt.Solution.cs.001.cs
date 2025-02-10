namespace MergeSortedListsLibrary.Records
{
    using System.Collections.Generic;

    /// <summary>
    /// Record representing the result of merging sorted lists.
    /// </summary>
    public record MergeResult(
        IEnumerable<int> MergedList,
        int TotalElementsMerged);
}