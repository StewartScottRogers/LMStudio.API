namespace LinkedList.Core.Interfaces;

/// <summary>
/// Defines the contract for a linked list data structure.
/// </summary>
public interface ILinkedList<T>
{
    /// <summary>
    /// Gets the number of elements in the linked list.
    /// </summary>
    int Count { get; }

    /// <summary>
    /// Inserts an element at the beginning of the linked list.
    /// </summary>
    /// <param name="value">The value to insert.</param>
    void InsertAtBeginning(T value);

    /// <summary>
    /// Searches for a specific element in the linked list.
    /// </summary>
    /// <param name="value">The value to search for.</param>
    /// <returns>A tuple indicating whether the element was found and its position.</returns>
    (bool Found, int Position) Search(T value);

    /// <summary>
    /// Deletes an element from the linked list.
    /// </summary>
    /// <param name="value">The value to delete.</param>
    /// <returns>A tuple indicating whether the element was deleted and its position.</returns>
    (bool Deleted, int Position) Delete(T value);

    /// <summary>
    /// Determines whether the linked list contains a specific value.
    /// </summary>
    /// <param name="value">The value to locate.</param>
    /// <returns>true if the element is found; otherwise, false.</returns>
    bool Contains(T value);

    /// <summary>
    /// Gets all elements in the linked list as an array.
    /// </summary>
    /// <returns>An array containing all elements of the linked list.</returns>
    T[] GetAllElements();
}