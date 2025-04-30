public readonly struct Node
{
    public int Value { get; }
    public readonly Node? Next { get; }

    public Node(int value, Node? next = null)
    {
        Value = value;
        Next = next;
    }
}