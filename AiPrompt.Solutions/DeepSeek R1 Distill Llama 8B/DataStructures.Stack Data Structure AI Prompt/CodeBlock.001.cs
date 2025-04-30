using System;
using System.Collections.Generic;

public class Stack<T> : IStack<T>
{
    private readonly int capacity;
    private readonly List<T> elements = new List<T>();

    public Stack(int initialCapacity)
    {
        this.capacity = initialCapacity;
    }

    public void Push(T value)
    {
        if (IsFull())
        {
            throw new InvalidOperationException("Stack is full");
        }
        elements.Add(value);
    }

    public T Pop()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }
        var lastIndex = elements.Count - 1;
        var value = elements[lastIndex];
        elements.RemoveAt(lastIndex);
        return value;
    }

    public bool IsEmpty() => elements.Count == 0;

    public bool IsFull() => elements.Count >= capacity;

    public T Peek()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Stack is empty");
        }
        return elements[elements.Count - 1];
    }
}