// LinkedList.cs
using System;
using System.Collections.Generic;

public sealed class LinkedList
{
    public Node? Head { get; private set; }

    /// <summary>
    /// Inserts an element at the beginning of the linked list.
    /// </summary>
    /// <param name="value">The value to insert.</param>
    public void InsertAtBeginning(int value)
    {
        Head = new Node(value, Head);
    }

    /// <summary>
    /// Searches for a specific element in the linked list.
    /// </summary>
    /// <param name="value">The value to search for.</param>
    /// <returns>True if found, otherwise false.</returns>
    public bool Search(int value)
    {
        var currentNode = Head;
        while (currentNode is not null)
        {
            if (currentNode.Value == value)
            {
                return true;
            }
            currentNode = currentNode.Next;
        }
        return false;
    }

    /// <summary>
    /// Deletes an element from the linked list.
    /// </summary>
    /// <param name="value">The value to delete.</param>
    /// <returns>True if deleted, otherwise false.</returns>
    public bool Delete(int value)
    {
        if (Head is null) return false;

        // If head node itself holds the key to be deleted
        if (Head.Value == value)
        {
            Head = Head.Next;
            return true;
        }

        Node? previousNode = null;
        var currentNode = Head;

        // Search for the key to be deleted, keep track of the previous node
        while (currentNode is not null && currentNode.Value != value)
        {
            previousNode = currentNode;
            currentNode = currentNode.Next;
        }

        // If key was not present in linked list
        if (currentNode is null) return false;

        // Unlink the node from linked list
        previousNode!.Next = currentNode.Next;

        return true;
    }
}