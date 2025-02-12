using System.Collections.Generic;
using System.Linq;

namespace StackLibrary;

public record Stack<T> : IStack<T>
{
    private readonly List<T> items = new();

    public int Capacity { get; init; } = 10; // Default capacity

    public void Push(T item)
    {
        if (IsFull)
            throw new InvalidOperationException("The stack is full.");

        items.Add(item);
    }

    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("The stack is empty.");

        var item = items.Last();
        items.RemoveAt(items.Count - 1);

        return item;
    }

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("The stack is empty.");

        return items.Last();
    }

    public bool IsEmpty => !items.Any();

    public bool IsFull => items.Count == Capacity;
}