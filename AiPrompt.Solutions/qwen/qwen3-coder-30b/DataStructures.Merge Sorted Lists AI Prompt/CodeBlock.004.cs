using System;

namespace MergeSortedLists
{
    /// <summary>
    /// Statistics about the merge operation
    /// </summary>
    public class MergeStatistics
    {
        /// <summary>
        /// Gets or sets the total number of lists processed
        /// </summary>
        public int TotalLists { get; set; }
        
        /// <summary>
        /// Gets or sets the total number of elements processed
        /// </summary>
        public int TotalElements { get; set; }
        
        /// <summary>
        /// Gets or sets the processing time in milliseconds
        /// </summary>
        public long ProcessingTimeMs { get; set; }
    }
}