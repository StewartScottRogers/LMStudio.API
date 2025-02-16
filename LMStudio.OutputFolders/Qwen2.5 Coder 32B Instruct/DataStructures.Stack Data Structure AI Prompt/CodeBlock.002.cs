using System;
using System.Collections.Generic;

public sealed class FixedSizeStack<T> : IStack<T>
{
    private readonly T[] elements;
    private int topIndex = -1;
    private readonly int capacity;

    public FixedSizeStack(int initialCapacity)
    {
        if (initialCapacity <= 0) throw new ArgumentException("Initial capacity must be greater than zero.");

        this.capacity = initialCapacity;
        this.elements = new T[capacity];
    }

    public void Push(T value)
    {
        if (IsFull())
            throw new StackOverflowException("Stack is full");

        elements[++topIndex] = value;
    }

    public T Pop()
    {
        if (IsEmpty())
            throw new StackUnderflowException("Stack is empty");

        var poppedValue = elements[topIndex];
        topIndex--;
        return poppedValue;
    }

    public T Peek()
    {
        if (IsEmpty())
            throw new StackUnderflowException("Stack is empty");

        return elements[topIndex];
    }

    public bool IsEmpty()
    {
        return topIndex == -1;
    }

    public bool IsFull()
    {
        return topIndex == capacity - 1;
    }
}