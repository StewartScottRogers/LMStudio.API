using System;

namespace MergeSortedLists
{
    /// <summary>
    /// Exception thrown when an error occurs in the merge sorted lists functionality
    /// </summary>
    public class MergeSortedListsException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the MergeSortedListsException class with a specified error message
        /// </summary>
        /// <param name="message">The message that describes the error</param>
        public MergeSortedListsException(string message) : base(message)
        {
        }
    }
}