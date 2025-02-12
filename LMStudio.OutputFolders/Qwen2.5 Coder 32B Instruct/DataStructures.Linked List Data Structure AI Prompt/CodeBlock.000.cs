namespace DataStructures;

public record Node<T>
{
    public readonly T Value;
    public readonly Node<T> Next;

    public Node(T value, Node<T> next = null)
    {
        Value = value;
        Next = next;
    }
}