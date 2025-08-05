namespace LinkedList.Core.Models;

/// <summary>
/// Represents a node in a linked list.
/// </summary>
/// <typeparam name="T">The type of data stored in the node.</typeparam>
public class Node<T>
{
    /// <summary>
    /// Gets or sets the value stored in this node.
    /// </summary>
    public T Value { get; set; }

    /// <summary>
    /// Gets or sets the next node in the linked list.
    /// </summary>
    public Node<T>? Next { get; set; }

    /// <summary>
    /// Initializes a new instance of the Node class with the specified value.
    /// </summary>
    /// <param name="value">The value to store in the node.</param>
    public Node(T value)
    {
        Value = value;
        Next = null;
    }
}