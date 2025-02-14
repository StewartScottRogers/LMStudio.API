using System;
using System.Collections.Generic;

public class Stack<T> : IStack<T>
{
    private readonly T[] items;
    private int top = -1;
    private readonly int capacity;

    public Stack(int size)
    {
        if (size <= 0)
            throw new ArgumentException("Size must be greater than zero", nameof(size));

        capacity = size;
        items = new T[capacity];
    }

    public void Push(T item)
    {
        if (IsFull())
            throw new InvalidOperationException("Stack is full.");

        items[++top] = item;
    }

    public T Pop()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty.");

        return items[top--];
    }

    public bool IsEmpty() => top == -1;

    public bool IsFull() => top >= capacity - 1;

    public T Peek()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Stack is empty.");

        return items[top];
    }
}