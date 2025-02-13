using System;
using System.Collections.Generic;

/// <summary>
/// Represents a basic stack data structure with push, pop, peek, is empty, and is full operations.
/// </summary>
public class Stack<T>
{
    private List<T> _stack = new List<T>();
    public int MaxCapacity { get; set; } = int.MaxValue; // Default to unlimited capacity

    /// <summary>
    /// Initializes a new stack with the specified maximum capacity.
    /// If the capacity is not specified, it defaults to Int32.MaxValue.
    /// </summary>
    public Stack(int? maxCapacity)
    {
        _stack = new List<T>(maxCapacity ?? (int?)Int32.MaxValue);
    }

    /// <summary>
    /// Adds an item to the top of the stack.
    /// Throws an exception if the stack is full.
    /// </summary>
    public void AddItem(T item)
    {
        if (Count >= MaxCapacity)
            throw new InvalidOperationException("Stack is full. Cannot add more items.");

        _stack.Add(item);
    }

    /// <summary>
    /// Removes and returns the top item of the stack.
    /// Throws an exception if the stack is empty.
    /// </summary>
    public T RemoveItem()
    {
        if (Count == 0)
            throw new InvalidOperationException("Stack is empty. Cannot remove items.");

        return _stack.RemoveAt(Count - 1);
    }

    /// <summary>
    /// Peeks at the top item of the stack without removing it.
    /// Returns null if the stack is empty.
    /// </summary>
    public T? PeekItem()
    {
        return Count > 0 ? _stack[Count - 1] : null;
    }

    /// <summary>
    /// Checks if the stack is empty.
    /// Returns true if there are no items in the stack; otherwise, false.
    /// </summary>
    public bool IsEmpty => _stack.Count == 0;

    /// <summary>
    /// Checks if the stack is full.
    /// Returns true if the stack contains more items than its capacity; otherwise, false.
    /// </summary>
    public bool IsFull => Count >= MaxCapacity;

    /// <summary>
    /// Gets the total number of items in the stack.
    /// </summary>
    public int Count => _stack.Count;
}