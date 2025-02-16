using System;

namespace DataStructure
{
    /// <summary>
    /// Represents an element in a linked list.
    /// </summary>
    public class LinkedListElement<T>
    {
        /// <summary>
        /// The value of the element.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// The next element in the list.
        /// </summary>
        private readonly LinkedListElement<T> Next;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedListElement{T}"/> class.
        /// </summary>
        /// <param name="value">The value of the element.</param>
        public LinkedListElement(T value)
        {
            Value = value;
        }

        public void SetNext(LinkedListElement<T> next)
        {
            Next = next;
        }
    }
}