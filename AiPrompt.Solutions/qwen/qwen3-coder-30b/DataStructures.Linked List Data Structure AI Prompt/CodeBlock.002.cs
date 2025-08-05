using LinkedList.Core.Interfaces;
using LinkedList.Core.Models;

namespace LinkedList.Core;

/// <summary>
/// A linked list implementation that supports dynamic memory allocation.
/// </summary>
/// <typeparam name="T">The type of elements in this linked list.</typeparam>
public class LinkedList<T> : ILinkedList<T>
{
    /// <summary>
    /// The first node in the linked list, or null if the list is empty.
    /// </summary>
    private Node<T>? Head;

    /// <summary>
    /// Gets the number of elements in the linked list.
    /// </summary>
    public int Count { get; private set; }

    /// <summary>
    /// Initializes a new instance of the LinkedList class.
    /// </summary>
    public LinkedList()
    {
        Head = null;
        Count = 0;
    }

    /// <summary>
    /// Inserts an element at the beginning of the linked list.
    /// Time Complexity: O(1)
    /// </summary>
    /// <param name="value">The value to insert.</param>
    public void InsertAtBeginning(T value)
    {
        var newNode = new Node<T>(value);
        newNode.Next = Head;
        Head = newNode;
        Count++;
    }

    /// <summary>
    /// Searches for a specific element in the linked list.
    /// Time Complexity: O(n)
    /// </summary>
    /// <param name="value">The value to search for.</param>
    /// <returns>A tuple indicating whether the element was found and its position (0-indexed).</returns>
    public (bool Found, int Position) Search(T value)
    {
        var currentNode = Head;
        int position = 0;

        // Traverse the list until we find the value or reach the end
        while (currentNode != null)
        {
            if (Equals(currentNode.Value, value))
            {
                return (true, position);
            }
            
            currentNode = currentNode.Next;
            position++;
        }

        // Value not found
        return (false, -1);
    }

    /// <summary>
    /// Deletes an element from the linked list.
    /// Time Complexity: O(n)
    /// </summary>
    /// <param name="value">The value to delete.</param>
    /// <returns>A tuple indicating whether the element was deleted and its position (0-indexed).</returns>
    public (bool Deleted, int Position) Delete(T value)
    {
        // Handle case when list is empty
        if (Head == null)
        {
            return (false, -1);
        }

        // Handle case when deleting the first element
        if (Equals(Head.Value, value))
        {
            Head = Head.Next;
            Count--;
            return (true, 0);
        }

        var currentNode = Head;
        int position = 0;

        // Traverse the list to find the node before the one to delete
        while (currentNode.Next != null)
        {
            if (Equals(currentNode.Next.Value, value))
            {
                currentNode.Next = currentNode.Next.Next;
                Count--;
                return (true, position + 1);
            }
            
            currentNode = currentNode.Next;
            position++;
        }

        // Value not found
        return (false, -1);
    }

    /// <summary>
    /// Determines whether the linked list contains a specific value.
    /// Time Complexity: O(n)
    /// </summary>
    /// <param name="value">The value to locate.</param>
    /// <returns>true if the element is found; otherwise, false.</returns>
    public bool Contains(T value)
    {
        return Search(value).Found;
    }

    /// <summary>
    /// Gets all elements in the linked list as an array.
    /// Time Complexity: O(n)
    /// </summary>
    /// <returns>An array containing all elements of the linked list.</returns>
    public T[] GetAllElements()
    {
        var result = new T[Count];
        var currentNode = Head;
        int index = 0;

        while (currentNode != null)
        {
            result[index] = currentNode.Value;
            currentNode = currentNode.Next;
            index++;
        }

        return result;
    }
}