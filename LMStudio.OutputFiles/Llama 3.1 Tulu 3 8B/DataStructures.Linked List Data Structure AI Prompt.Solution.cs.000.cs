using System;

public readonly struct Node<T>
{
    public T Value { get; }
    public Node<T> Next { get; }

    public Node(T value, Node<T> next = default)
    {
        this.Value = value;
        this.Next = next;
    }
}