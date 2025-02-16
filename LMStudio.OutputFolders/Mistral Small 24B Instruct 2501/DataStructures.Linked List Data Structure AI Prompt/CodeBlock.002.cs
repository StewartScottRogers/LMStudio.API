using DataStructure;
using System;

namespace Interfaces
{
    /// <summary>
    /// Represents a linked list.
    /// </summary>
    public class LinkedList<T> : ILinkedList<T>
    {
        private readonly LinkedListElement<T> Head = null;

        /// <summary>
        /// Inserts an element at the beginning of the list.
        /// </summary>
        /// <param name="value">The value to insert.</param>
        public void InsertAtBeginning(T value)
        {
            var newElement = new LinkedListElement<T>(value);
            newElement.SetNext(Head);

            Head = newElement;
        }

        /// <summary>
        /// Deletes an element from the list.
        /// </summary>
        /// <param name="value">The value to delete.</param>
        /// <returns>True if the element was deleted, false otherwise.</returns>
        public bool DeleteElement(T value)
        {
            LinkedListElement<T> current = Head;
            LinkedListElement<T> previous = null;

            while (current != null)
            {
                if (Equals(current.Value, value))
                {
                    if (previous == null)
                    {
                        // Deleting the head
                        Head = current.Next;
                    }
                    else
                    {
                        previous.SetNext(current.Next);
                    }

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false; // Element not found
        }

        /// <summary>
        /// Searches for an element in the list.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>The element if found, null otherwise.</returns>
        public LinkedListElement<T> SearchElement(T value)
        {
            LinkedListElement<T> current = Head;

            while (current != null)
            {
                if (Equals(current.Value, value))
                {
                    return current;
                }

                current = current.Next;
            }

            return null; // Element not found
        }
    }
}