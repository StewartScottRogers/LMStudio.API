using System.Collections.Generic;

namespace SortedListMerger
{
    public record MergeResultTuple(List<int> MergedList, bool Success)
    {
        /// <summary>
        /// Constructor for the MergeResultTuple.
        /// </summary>
        /// <param name="mergedList">The merged list of integers.</param>
        /// <param name="success">A boolean indicating whether the merge was successful.</param>
        public MergeResultTuple(List<int> mergedList, bool success)
        {
            MergedList = mergedList;
            Success = success;
        }
    }
}