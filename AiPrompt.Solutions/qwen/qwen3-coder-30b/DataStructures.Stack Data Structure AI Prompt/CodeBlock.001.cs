using System;

namespace StackLibrary;

/// <summary>
/// A generic stack implementation using an array
/// </summary>
/// <typeparam name="T">The type of elements in this stack</typeparam>
public class Stack<T> : IStack<T>
{
    private readonly T[] _items;
    private int _topIndex;
    private readonly int _maxSize;

    /// <summary>
    /// Initializes a new instance of the Stack class with a specified maximum size
    /// </summary>
    /// <param name="maxSize">The maximum number of elements the stack can hold</param>
    public Stack(int maxSize)
    {
        _maxSize = maxSize;
        _items = new T[maxSize];
        _topIndex = -1;
    }

    /// <summary>
    /// Adds an element to the top of the stack
    /// </summary>
    /// <param name="value">The element to add</param>
    public void Push(T value)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("Stack is full");
        }
        
        _topIndex++;
        _items[_topIndex] = value;
    }

    /// <summary>
    /// Removes and returns the element at the top of the stack
    /// </summary>
    /// <returns>The element that was removed from the top of the stack</returns>
    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }
        
        var value = _items[_topIndex];
        _topIndex--;
        return value;
    }

    /// <summary>
    /// Returns the element at the top of the stack without removing it
    /// </summary>
    /// <returns>The element at the top of the stack</returns>
    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }
        
        return _items[_topIndex];
    }

    /// <summary>
    /// Checks if the stack is empty
    /// </summary>
    /// <returns>True if the stack is empty, false otherwise</returns>
    public bool IsEmpty()
    {
        return _topIndex == -1;
    }

    /// <summary>
    /// Checks if the stack is full
    /// </summary>
    /// <returns>True if the stack is full, false otherwise</returns>
    public bool IsFull()
    {
        return _topIndex == _maxSize - 1;
    }
}